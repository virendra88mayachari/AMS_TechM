using Microsoft.AspNetCore.Mvc;
using System.IO;
using AMSDemo.Models;
using AMSDemo.Utility;
using AMSDemo.DatabaseOps;
using System.Threading;
using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace AMSDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProcessOPLDController : ControllerBase
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void OPLDFileWatcher()
        {
            try
            {
                var opldFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "OPLDFiles");

                var files = Directory.GetFiles(opldFolderPath);

                if (files.Length > 0)
                {
                    foreach (string fileName in files)
                    {
                        log.Info(DateTime.Now.ToString() + " AMS-POC-MicroServiceProcessOPLDNDIALSFiles: OPLD file Read in Progress.");

                        string opldString = System.IO.File.ReadAllText(Path.Combine(opldFolderPath, fileName));

                        //opldString = opldString.Replace("'", "\'");

                        //Process OPLD data
                        List<OPLD> opldObjectList = new List<OPLD>();
                        OPLDUtility.ProcessOPLDMessage(opldString, ref opldObjectList);

                        log.Info(DateTime.Now.ToString() + " AMS-POC-MicroServiceProcessOPLDNDIALSFiles: OPLD file Processed.");

                        //Push OPLD to Queue
                        MicroServiceProcessOPLDFile(opldObjectList);

                        log.Info(DateTime.Now.ToString() + " AMS-POC-MicroServiceProcessOPLDNDIALSFiles: OPLD Message Pushed to MQ.");

                        //Move File to archive folder
                        var archiveFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Archive");
                        DirectoryInfo directoryInfo = Directory.CreateDirectory(archiveFolderPath);

                        var destFile = Path.Combine(archiveFolderPath, fileName.Substring(fileName.LastIndexOf("/")));
                        var destAPath = fileName.Substring(0, fileName.LastIndexOf("/"));
                        var destFinalPath = destAPath.Substring(0, destAPath.LastIndexOf("/")) + "/Archive/" + destFile;

                        if (!System.IO.File.Exists(destFinalPath))
                        {
                            System.IO.File.Move(fileName, destFinalPath);
                            log.Info(DateTime.Now.ToString() + " Source OPLD File delted from opldFiles");
                        }
                        else
                        {
                            System.IO.File.Delete(fileName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(DateTime.Now.ToString() + " AMS-MicroServiceProcessOPLDNDIALSFiles: " + Convert.ToString(ex.Message));
            }
        }

        public void DIALSFileWatcher()
        {
            try
            {
                var dialsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "DIALSFiles");

                var files = Directory.GetFiles(dialsFolderPath);

                if (files.Length > 0)
                {
                    foreach (string fileName in files)
                    {
                        log.Info(DateTime.Now.ToString() + " AMS-POC-MicroServiceProcessOPLDNDIALSFiles: DIALS file Read in Progress.");
                        FileStream fileStream = new FileStream(Path.Combine(dialsFolderPath, fileName), FileMode.Open);
                        using (BufferedStream bufferedStream = new BufferedStream(fileStream))
                        {
                            using (StreamReader streamReader = new StreamReader(bufferedStream))
                            {
                                while (!streamReader.EndOfStream)
                                {
                                    string dialsString = streamReader.ReadLine();

                                    if (!string.IsNullOrEmpty(dialsString.Trim()) && dialsString != "\u001a")
                                    {
                                        //Process DIALS data
                                        var dialsObject = DIALSUtility.ProcessDIALSData(dialsString);

                                        SakilaContext context = new SakilaContext("server=127.0.01;port=3306;database=ams;user=root;password=techM@Ups1");
                                        // SakilaContext context = new SakilaContext("server=techm.cooavdyjxzoz.us-east-1.rds.amazonaws.com;port=3306;database=ams;user=root;password=Password123");
                                        DIALS dials = context.GetMatchingDialsID(dialsObject.TrackingNumber);

                                        //Store in to DB
                                        if (!string.IsNullOrEmpty(dialsObject.TrackingNumber) && (dialsObject.TrackingNumber != dials.TrackingNumber))
                                        {
                                            MicroServiceProcessDIALSFile(dialsObject);
                                        }
                                        else
                                        {
                                            log.Warn(DateTime.Now.ToString() + " AMS-MicroServiceProcessOPLDNDIALSFiles: Tracking number already exists.");
                                            continue;
                                        }
                                    }
                                }
                            }
                        }

                        fileStream.Close();

                        //Move file to archive folder
                        var archiveFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Archive");

                        DirectoryInfo directoryInfo = Directory.CreateDirectory(archiveFolderPath);

                        var destFile = Path.Combine(archiveFolderPath, fileName.Substring(fileName.LastIndexOf("/")));
                        var destAPath = fileName.Substring(0, fileName.LastIndexOf("/"));
                        var destFinalPath = destAPath.Substring(0, destAPath.LastIndexOf("/")) + "/Archive/" + destFile;

                        if (!System.IO.File.Exists(destFinalPath))
                        {
                            System.IO.File.Move(fileName, destFinalPath);
                        }
                        else
                        {
                            System.IO.File.Delete(fileName);
                        }

                    }
                }

                log.Info(DateTime.Now.ToString() + " AMS-POC-MicroServiceProcessOPLDNDIALSFiles: DIALS file processed and data inserted into DB.");
            }
            catch (Exception ex)
            {
                log.Error(DateTime.Now.ToString() + " AMS-MicroServiceProcessOPLDNDIALSFiles: " + Convert.ToString(ex.Message));
            }

        }

        //MicroService 2
        [HttpPost]
        public IActionResult MicroServiceProcessOPLDFile(List<OPLD> opldObjectList)
        {
            try
            {
                //Push OPLD in DB
                SakilaContext context = new SakilaContext("server=127.0.01;port=3306;database=ams;user=root;password=techM@Ups1");
                //SakilaContext context = new SakilaContext("server=techm.cooavdyjxzoz.us-east-1.rds.amazonaws.com;port=3306;database=ams;user=root;password=Password123");

                foreach (var opldObject in opldObjectList)
                {
                    var addOPLDResult = context.AddNewOPLD(opldObject);
                    if (addOPLDResult.Item1)
                    {
                        opldObject.Packages.ForEach(m => m.OPLDId = addOPLDResult.Item2);

                        context.AddNewOPLDPackages(opldObject.Packages);
                    }
                }

                log.Info(DateTime.Now.ToString() + " AMS-POC-MicroServiceProcessOPLDNDIALSFiles: OPLD Data inserted in DB.");

                //Push OPLD in to Active MQ2
                CommonUtility<OPLD>.PushToActiveMQ(opldObjectList, 1);
                log.Info(DateTime.Now.ToString() + " AMS-MicroServiceProcessOPLDNDIALSFiles: OPLD message pushed to MQ.");

            }
            catch (Exception ex)
            {
                log.Error(DateTime.Now.ToString() + " AMS-MicroServiceProcessOPLDNDIALSFiles: " + Convert.ToString(ex.Message));
                return new JsonResult(new { Result = System.Net.HttpStatusCode.InternalServerError });
            }

            return Ok(new { Result = "Success" });
        }

        [HttpPost]
        public IActionResult MicroServiceProcessDIALSFile(DIALS dialsObject)
        {
            try
            {
                SakilaContext context = new SakilaContext("server=127.0.01;port=3306;database=ams;user=root;password=techM@Ups1");
                //SakilaContext context = new SakilaContext("server=techm.cooavdyjxzoz.us-east-1.rds.amazonaws.com;port=3306;database=ams;user=root;password=Password123");
                context.AddNewDIALS(dialsObject);
            }
            catch (Exception ex)
            {
                log.Error(DateTime.Now.ToString() + " AMS-MicroServiceProcessOPLDNDIALSFiles: " + Convert.ToString(ex.Message));
                return new JsonResult(new { Result = System.Net.HttpStatusCode.InternalServerError });
            }

            return Ok(new { Result = "Success" });
        }
    }
}