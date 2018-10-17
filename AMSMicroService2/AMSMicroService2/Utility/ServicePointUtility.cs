using AMSMicroService2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMSMicroService2.Utility
{
    public class ServicePointUtility
    {
        public static ServicePoint CreateServicePoint(OPLD opldDetails,string consigneeName, string clarifiedSignature, bool isMatch)
        {
            //Create Service point
            ServicePoint servicePoint = new ServicePoint();
            servicePoint.AddressLine1 = opldDetails.SHIP_ADDR_LINE_1_1;
            servicePoint.AddressLine2 = opldDetails.SHIP_ADDR_LINE_1_2;
            servicePoint.AddressLine3 = opldDetails.SHIP_ADDR_LINE_1_3;
            servicePoint.AddressType = opldDetails.SHIP_ADDR_TYPE_1;
            servicePoint.AttentionName = opldDetails.SHIP_ATTENTION_NAME_1;
            servicePoint.CityName = opldDetails.SHIP_CITY_NAME_1;
            servicePoint.CountryCode = opldDetails.SHIP_COUNTRY_CODE_1;
            servicePoint.CreatedDate = System.DateTime.Now.ToString();
            servicePoint.PhoneNumber = opldDetails.SHIP_PH_NR_1;
            servicePoint.ShiperNumber = opldDetails.PAGE_SHIPPER_NUMBER;
            servicePoint.StateCode = opldDetails.SHIP_STATE_CODE_1;
            servicePoint.ZipCode = opldDetails.SHIP_ZIP_CODE_1;

            servicePoint.ConsigneeName = string.IsNullOrEmpty(consigneeName) ? opldDetails.SHIP_ATTENTION_NAME_1 : consigneeName;
            servicePoint.SignatureClarify = clarifiedSignature;

            servicePoint.ServicePointStatus = (isMatch ? "Match found between OPld and DIALS" : "No Match found between OPld and DIALS");

            return servicePoint;
        }
    }
}
