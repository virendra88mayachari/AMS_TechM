﻿using MySql.Data.MySqlClient;
using System;
using AMSMicroService2.Models;

namespace AMSMicroService2.DatabaseOps
{
    public class SakilaContext
    {
        public string ConnectionString { get; set; }

        public SakilaContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public int GetLastOPLDID()
        {
            int lastOPLDID = 0;

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT max(OPLDID) AS OPLDID FROM oplddetails", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.IsDBNull(0))
                        {
                            lastOPLDID = 0;
                        }
                        else
                            lastOPLDID = Convert.ToInt32(reader["OPLDID"]); 
                    }
                }
            }

            return lastOPLDID;
        }

        public int GetLastDIALSID()
        {
            int lastDIALSID = 0;

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT max(DialsID) AS DialsID FROM DialsData", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.IsDBNull(0))
                        {
                            lastDIALSID = 0;
                        }
                        else
                            lastDIALSID = Convert.ToInt32(reader["DialsID"]); // reader.GetInt32("OPLDID");
                    }
                }
            }

            return lastDIALSID;
        }

        public int GetLastSPID()
        {
            int lastSPID = 0;

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT max(ServicePointID) AS ServicePointID FROM servicepoint", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.IsDBNull(0))
                        {
                            lastSPID = 0;
                        }
                        else
                            lastSPID = Convert.ToInt32(reader["ServicePointID"]);
                    }
                }
            }

            return lastSPID;
        }

       

        public bool AddNewDIALS(DIALS newDIALSdata)
        {
            int rowsAffected = 0;

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO DialsData VALUES('" + (GetLastDIALSID() + 1) + "','" + newDIALSdata.TrackingNumber + "','" + newDIALSdata.ShiperNumber + "','" + newDIALSdata.ClarifiedSignature +
                    "','" + newDIALSdata.ConsigneeName + "','" + newDIALSdata.Region + "','" + newDIALSdata.District + "','" + newDIALSdata.SLIC + "','" + newDIALSdata.Country +
                    "','" + newDIALSdata.DeliverySLICState + "','" + newDIALSdata.City + "','" + newDIALSdata.StreetNumber + "','" + newDIALSdata.StreetName + "','" + newDIALSdata.StreetType +
                    "','" + newDIALSdata.BuildingFloorNumber + "','" + newDIALSdata.RoomSuiteNumber + "','" + newDIALSdata.PostalCode + "','" + DateTime.Now.ToString() + "')", conn);

                rowsAffected = cmd.ExecuteNonQuery();
            }

            return rowsAffected > 0 ? true : false;
        }

        public bool AddNewServicePoint(ServicePoint newServicePoint)
        {
            int rowsAffected = 0;

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO servicepoint VALUES('" + (GetLastSPID() + 1) + "','" + newServicePoint.ShiperNumber + "','" + newServicePoint.ConsigneeName +
                    "','" + newServicePoint.AttentionName + "','" + newServicePoint.AddressType + "','" + newServicePoint.AddressLine1 + "','" + newServicePoint.AddressLine2 + "','" + newServicePoint.AddressLine3 + "','" + newServicePoint.CityName +
                    "','" + newServicePoint.StateCode + "','" + newServicePoint.ZipCode + "','" + newServicePoint.CountryCode + "','" + newServicePoint.PhoneNumber + "','" + newServicePoint.SignatureClarify +
                     "','" + DateTime.Now.ToString() + "','" + 1 + "')", conn);

                rowsAffected = cmd.ExecuteNonQuery();
            }

            return rowsAffected > 0 ? true : false;
        }

        public bool UpdateOPLDProcessingStatus(string trackingNumber)
        {
            int rowsAffected = 0;

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("Update oplddetails set ProcessingStatus='Processed' WHERE TrackingNumber='" + trackingNumber + "'", conn);

                rowsAffected = cmd.ExecuteNonQuery();
            }

            return rowsAffected > 0 ? true : false;
        }

        public DIALS GetMatchingDialsID(string trackingNumber)
        {
            DIALS dialsObject = new DIALS();

            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM DialsData WHERE TrackingNumber='" + trackingNumber + "'", conn);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.IsDBNull(0))
                            {
                                return null;
                            }
                            else
                            {
                                dialsObject.TrackingNumber = reader.GetString("TrackingNumber");
                                dialsObject.DialsID = reader.GetInt32("DialsID");
                                dialsObject.ConsigneeName = reader.GetString("ConsigneeName");
                                dialsObject.ClarifiedSignature = reader.GetString("ClarifiedSignature");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return dialsObject;
        }


        public ServicePoint CompareOPLDAdd1WithSPAddr1(string addressLine1)
        {
            ServicePoint servicePoint = new ServicePoint();

            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM servicepoint WHERE AddressLine1='" + addressLine1 + "'", conn);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.IsDBNull(0))
                            {
                                return null;
                            }
                            else
                            {
                                servicePoint.ServicePointID = reader.GetInt32("ServicePointID");
                                servicePoint.AddressLine1 = reader.GetString("AddressLine1");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return servicePoint;
        }

        public int GetStopIDCount(int servicepointID)
        {
            int stopID = 0;

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT StopID FROM servicepoint where ServicePointID='"+ servicepointID + "'", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.IsDBNull(0))
                        {
                            stopID = 0;
                        }
                        else
                            stopID = Convert.ToInt32(reader["StopID"]);
                    }
                }
            }

            return stopID;
        }

        public bool UpdateServicePoint(int servicePointId)
        {
            int rowsAffected = 0;

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("Update servicepoint set TimeStamp ='"+ System.DateTime.Now.ToString() + "',StopID ='" + (GetStopIDCount(servicePointId) + 1) + "' WHERE ServicePointID='" + servicePointId + "'", conn);

                rowsAffected = cmd.ExecuteNonQuery();
            }

            return rowsAffected > 0 ? true : false;
        }
    }
}