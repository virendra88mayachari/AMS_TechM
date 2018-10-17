using AMSDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMSDemo.Utility
{
    public class OPLDUtility
    {
        private static List<OPLD> ProcessOPLD(string opldString, List<OPLD> oplds)
        {
            if (!string.IsNullOrEmpty(opldString) && opldString.StartsWith("01"))
            {
                OPLD opldData = new OPLD
                {
                    //opldData.TrackingNumber = opldString.Length > 3533 ? opldString.Substring(3533, 35).Trim() : "";
                    //opldData.VERSION_NUMBER = opldString.Length > 2 ? opldString.Substring(2, 4).Trim() : "";
                    //opldData.ShiperNumber = opldString.Length > 55 ? opldString.Substring(55, 10).Trim() : "";
                    //opldData.ShiperCountry = opldString.Length > 65 ? opldString.Substring(65, 2).Trim() : "";
                    //opldData.AttentionName = opldString.Length > 229 ? opldString.Substring(229, 35).Trim() : "";
                    //opldData.AddressType = opldString.Length > 182 ? opldString.Substring(182, 2).Trim() : "";
                    //opldData.AddressLine1 = opldString.Length > 264 ? opldString.Substring(264, 35).Trim() : "";
                    //opldData.AddressLine2 = opldString.Length > 299 ? opldString.Substring(299, 35).Trim() : "";
                    //opldData.AddressLine3 = opldString.Length > 334 ? opldString.Substring(334, 35).Trim() : "";
                    //opldData.CityName = opldString.Length > 369 ? opldString.Substring(369, 30).Trim() : "";
                    //opldData.StateCode = opldString.Length > 399 ? opldString.Substring(399, 5).Trim() : "";
                    //opldData.ZipCode = opldString.Length > 404 ? opldString.Substring(404, 9).Trim() : "";
                    //opldData.CountryCode = opldString.Length > 413 ? opldString.Substring(413, 2).Trim() : "";
                    //opldData.PhoneNumber = opldString.Length > 415 ? opldString.Substring(415, 15).Trim() : "";
                    //opldData.ProcessingStatus = "Pending";
                    //opldData.packages = new List<Package>();
                    //oplds.Add(opldData);

                    PAGE_SMT_REC_FLAG = opldString.Substring(0, 2).Trim(),
                    VERSION_NUMBER = opldString.Substring(2, 4).Trim(),
                    PAGE_INF_SRC_TYP_CD = opldString.Substring(6, 2).Trim(),
                    PAGE_MAILBOX = opldString.Substring(8, 24).Trim(),
                    PAGE_PICKUP_DT = opldString.Substring(32, 8).Trim(),
                    PAGE_PICKUP_CC_DT = opldString.Substring(32, 2).Trim(),
                    PAGE_PICKUP_YY_DT = opldString.Substring(34, 2).Trim(),
                    PAGE_PICKUP_MM_DT = opldString.Substring(36, 2).Trim(),
                    PAGE_PICKUP_DD_DT = opldString.Substring(38, 2).Trim(),
                    PAGE_SEQ_NUM = opldString.Substring(40, 15).Trim(),
                    PAGE_SHIPPER_NUMBER = opldString.Substring(55, 10).Trim(),
                    PAGE_SHIPPER_COUNTRY = opldString.Substring(65, 2).Trim(),
                    PAGE_PICKUP_BOOK = opldString.Substring(67, 7).Trim(),
                    PAGE_PICKUP_PAGE = opldString.Substring(74, 3).Trim(),
                    PAGE_PICKUP_BOOK_TYPE = opldString.Substring(77, 2).Trim(),
                    PAGE_VOID_IND = opldString.Substring(79, 1).Trim(),
                    PAGE_VSN_NR = opldString.Substring(80, 4).Trim(),
                    SMT_SEQ_NR = opldString.Substring(84, 9).Trim(),
                    SHIP_PKGING_TYP = opldString.Substring(93, 3).Trim(),
                    SHIP_DOC_IND = opldString.Substring(96, 1).Trim(),
                    SHIP_CONTAINER_TYPE = opldString.Substring(97, 3).Trim(),
                    SHIP_BILL_TERMS = opldString.Substring(100, 3).Trim(),
                    SHIP_PAY_MEDIA_TYPE = opldString.Substring(103, 2).Trim(),
                    SHIP_SHR_3PB_FLG = opldString.Substring(105, 1).Trim(),
                    SHIP_CSGN_3PB_FLG = opldString.Substring(106, 1).Trim(),
                    SHIP_REF_TYP_CD_1 = opldString.Substring(107, 2).Trim(),
                    SHIP_REF_NR_1 = opldString.Substring(109, 35).Trim(),
                    SHIP_REF_TYP_CD_2 = opldString.Substring(144, 2).Trim(),
                    SHIP_REF_NR_2 = opldString.Substring(146, 35).Trim(),
                    SHIP_CWT_IND = opldString.Substring(181, 1).Trim(),
                    SHIP_ADDR_TYPE_1 = opldString.Substring(182, 2).Trim(),
                    SHIP_AC_NR_1 = opldString.Substring(184, 10).Trim(),
                    SHIP_COMP_NA_1 = opldString.Substring(194, 35).Trim(),
                    SHIP_ATTENTION_NAME_1 = opldString.Substring(229, 35).Trim(),
                    SHIP_ADDR_LINE_1_1 = opldString.Substring(264, 35).Trim(),
                    SHIP_ADDR_LINE_2_1 = opldString.Substring(299, 35).Trim(),
                    SHIP_ADDR_LINE_3_1 = opldString.Substring(334, 35).Trim(),
                    SHIP_CITY_NAME_1 = opldString.Substring(369, 30).Trim(),
                    SHIP_STATE_CODE_1 = opldString.Substring(399, 5).Trim(),
                    SHIP_ZIP_CODE_1 = opldString.Substring(404, 9).Trim(),
                    SHIP_COUNTRY_CODE_1 = opldString.Substring(413, 2).Trim(),
                    SHIP_PH_NR_1 = opldString.Substring(415, 15).Trim(),
                    SHIP_ADDR_TYPE_2 = opldString.Substring(430, 2).Trim(),
                    SHIP_AC_NR_2 = opldString.Substring(432, 10).Trim(),
                    SHIP_COMP_NA_2 = opldString.Substring(442, 35).Trim(),
                    SHIP_ATTENTION_NAME_2 = opldString.Substring(477, 35).Trim(),
                    SHIP_ADDR_LINE_1_2 = opldString.Substring(512, 35).Trim(),
                    SHIP_ADDR_LINE_2_2 = opldString.Substring(547, 35).Trim(),
                    SHIP_ADDR_LINE_3_2 = opldString.Substring(582, 35).Trim(),
                    SHIP_CITY_NAME_2 = opldString.Substring(617, 30).Trim(),
                    SHIP_STATE_CODE_2 = opldString.Substring(647, 5).Trim(),
                    SHIP_ZIP_CODE_2 = opldString.Substring(652, 9).Trim(),
                    SHIP_COUNTRY_CODE_2 = opldString.Substring(661, 2).Trim(),
                    SHIP_PH_NR_2 = opldString.Substring(663, 15).Trim(),
                    SHIP_ADDR_TYPE_3 = opldString.Substring(678, 2).Trim(),
                    SHIP_AC_NR_3 = opldString.Substring(680, 10).Trim(),
                    SHIP_COMP_NA_3 = opldString.Substring(690, 35).Trim(),
                    SHIP_ATTENTION_NAME_3 = opldString.Substring(725, 35).Trim(),
                    SHIP_ADDR_LINE_1_3 = opldString.Substring(760, 35).Trim(),
                    SHIP_ADDR_LINE_2_3 = opldString.Substring(795, 35).Trim(),
                    SHIP_ADDR_LINE_3_3 = opldString.Substring(830, 35).Trim(),
                    SHIP_CITY_NAME_3 = opldString.Substring(865, 30).Trim(),
                    SHIP_STATE_CODE_3 = opldString.Substring(895, 5).Trim(),
                    SHIP_ZIP_CODE_3 = opldString.Substring(900, 9).Trim(),
                    SHIP_COUNTRY_CODE_3 = opldString.Substring(909, 2).Trim(),
                    SHIP_PH_NR_3 = opldString.Substring(911, 15).Trim(),
                    SHIP_ADDR_TYPE_4 = opldString.Substring(926, 2).Trim(),
                    SHIP_AC_NR_4 = opldString.Substring(928, 10).Trim(),
                    SHIP_COMP_NA_4 = opldString.Substring(938, 35).Trim(),
                    SHIP_ATTENTION_NAME_4 = opldString.Substring(973, 35).Trim(),
                    SHIP_ADDR_LINE_1_4 = opldString.Substring(1008, 35).Trim(),
                    SHIP_ADDR_LINE_2_4 = opldString.Substring(1043, 35).Trim(),
                    SHIP_ADDR_LINE_3_4 = opldString.Substring(1078, 35).Trim(),
                    SHIP_CITY_NAME_4 = opldString.Substring(1113, 30).Trim(),
                    SHIP_STATE_CODE_4 = opldString.Substring(1143, 5).Trim(),
                    SHIP_ZIP_CODE_4 = opldString.Substring(1148, 9).Trim(),
                    SHIP_COUNTRY_CODE_4 = opldString.Substring(1157, 2).Trim(),
                    SHIP_PH_NR_4 = opldString.Substring(1159, 15).Trim(),
                    SHIP_ADDR_TYPE_5 = opldString.Substring(1174, 2).Trim(),
                    SHIP_AC_NR_5 = opldString.Substring(1176, 10).Trim(),
                    SHIP_COMP_NA_5 = opldString.Substring(1186, 35).Trim(),
                    SHIP_ATTENTION_NAME_5 = opldString.Substring(1221, 35).Trim(),
                    SHIP_ADDR_LINE_1_5 = opldString.Substring(1256, 35).Trim(),
                    SHIP_ADDR_LINE_2_5 = opldString.Substring(1291, 35).Trim(),
                    SHIP_ADDR_LINE_3_5 = opldString.Substring(1326, 35).Trim(),
                    SHIP_CITY_NAME_5 = opldString.Substring(1361, 30).Trim(),
                    SHIP_STATE_CODE_5 = opldString.Substring(1391, 5).Trim(),
                    SHIP_ZIP_CODE_5 = opldString.Substring(1396, 9).Trim(),
                    SHIP_COUNTRY_CODE_5 = opldString.Substring(1405, 2).Trim(),
                    SHIP_PH_NR_5 = opldString.Substring(1407, 15).Trim(),
                    SHIP_ADDR_TYPE_6 = opldString.Substring(1422, 2).Trim(),
                    SHIP_AC_NR_6 = opldString.Substring(1424, 10).Trim(),
                    SHIP_COMP_NA_6 = opldString.Substring(1434, 35).Trim(),
                    SHIP_ATTENTION_NAME_6 = opldString.Substring(1469, 35).Trim(),
                    SHIP_ADDR_LINE_1_6 = opldString.Substring(1504, 35).Trim(),
                    SHIP_ADDR_LINE_2_6 = opldString.Substring(1539, 35).Trim(),
                    SHIP_ADDR_LINE_3_6 = opldString.Substring(1574, 35).Trim(),
                    SHIP_CITY_NAME_6 = opldString.Substring(1609, 30).Trim(),
                    SHIP_STATE_CODE_6 = opldString.Substring(1639, 5).Trim(),
                    SHIP_ZIP_CODE_6 = opldString.Substring(1644, 9).Trim(),
                    SHIP_COUNTRY_CODE_6 = opldString.Substring(1653, 2).Trim(),
                    SHIP_PH_NR_6 = opldString.Substring(1655, 15).Trim(),
                    SHIP_ADDR_TYPE_7 = opldString.Substring(1670, 2).Trim(),
                    SHIP_AC_NR_7 = opldString.Substring(1672, 10).Trim(),
                    SHIP_COMP_NA_7 = opldString.Substring(1682, 35).Trim(),
                    SHIP_ATTENTION_NAME_7 = opldString.Substring(1717, 35).Trim(),
                    SHIP_ADDR_LINE_1_7 = opldString.Substring(1752, 35).Trim(),
                    SHIP_ADDR_LINE_2_7 = opldString.Substring(1787, 35).Trim(),
                    SHIP_ADDR_LINE_3_7 = opldString.Substring(1822, 35).Trim(),
                    SHIP_CITY_NAME_7 = opldString.Substring(1857, 30).Trim(),
                    SHIP_STATE_CODE_7 = opldString.Substring(1887, 5).Trim(),
                    SHIP_ZIP_CODE_7 = opldString.Substring(1892, 9).Trim(),
                    SHIP_COUNTRY_CODE_7 = opldString.Substring(1901, 2).Trim(),
                    SHIP_PH_NR_7 = opldString.Substring(1903, 15).Trim(),
                    SHIP_ADDR_TYPE_8 = opldString.Substring(1918, 2).Trim(),
                    SHIP_AC_NR_8 = opldString.Substring(1920, 10).Trim(),
                    SHIP_COMP_NA_8 = opldString.Substring(1930, 35).Trim(),
                    SHIP_ATTENTION_NAME_8 = opldString.Substring(1965, 35).Trim(),
                    SHIP_ADDR_LINE_1_8 = opldString.Substring(2000, 35).Trim(),
                    SHIP_ADDR_LINE_2_8 = opldString.Substring(2035, 35).Trim(),
                    SHIP_ADDR_LINE_3_8 = opldString.Substring(2070, 35).Trim(),
                    SHIP_CITY_NAME_8 = opldString.Substring(2105, 30).Trim(),
                    SHIP_STATE_CODE_8 = opldString.Substring(2135, 5).Trim(),
                    SHIP_ZIP_CODE_8 = opldString.Substring(2140, 9).Trim(),
                    SHIP_COUNTRY_CODE_8 = opldString.Substring(2149, 2).Trim(),
                    SHIP_PH_NR_8 = opldString.Substring(2151, 15).Trim(),
                    SHIP_PKG_QTY = opldString.Substring(2166, 9).Trim(),
                    SHIP_OCA_IND = opldString.Substring(2175, 1).Trim(),
                    SHIP_COMM_RES_IND = opldString.Substring(2176, 1).Trim(),
                    SHIP_SVC_LVL = opldString.Substring(2177, 3).Trim(),
                    SHIP_SVC_LVL_IND = opldString.Substring(2180, 1).Trim(),
                    SHIP_WAYBILL_BRK_NR = opldString.Substring(2181, 11).Trim(),
                    SHIP_WAYBILL_PRINT_IND = opldString.Substring(2192, 1).Trim(),
                    SHIP_ACC_TYPE_1 = opldString.Substring(2193, 3).Trim(),
                    SHIP_ACC_VALUE_1 = opldString.Substring(2196, 15).Trim(),
                    SHIP_ACC_VALUE_N_1 = opldString.Substring(2196, 15).Trim(),
                    SHIP_ACC_CCY_CD_1 = opldString.Substring(2211, 3).Trim(),
                    RA_SHIP_COD_CSH_ONLY_IND_1 = opldString.Substring(2214, 2).Trim(),
                    SHIP_ACC_TYPE_2 = opldString.Substring(2216, 3).Trim(),
                    SHIP_ACC_VALUE_2 = opldString.Substring(2219, 15).Trim(),
                    SHIP_ACC_VALUE_N_2 = opldString.Substring(2219, 15).Trim(),
                    SHIP_ACC_CCY_CD_2 = opldString.Substring(2234, 3).Trim(),
                    RA_SHIP_COD_CSH_ONLY_IND_2 = opldString.Substring(2237, 2).Trim(),
                    SHIP_ACC_TYPE_3 = opldString.Substring(2239, 3).Trim(),
                    SHIP_ACC_VALUE_3 = opldString.Substring(2242, 15).Trim(),
                    SHIP_ACC_VALUE_N_3 = opldString.Substring(2242, 15).Trim(),
                    SHIP_ACC_CCY_CD_3 = opldString.Substring(2257, 3).Trim(),
                    RA_SHIP_COD_CSH_ONLY_IND_3 = opldString.Substring(2260, 2).Trim(),
                    SHIP_ACC_TYPE_4 = opldString.Substring(2262, 3).Trim(),
                    SHIP_ACC_VALUE_4 = opldString.Substring(2265, 15).Trim(),
                    SHIP_ACC_VALUE_N_4 = opldString.Substring(2265, 15).Trim(),
                    SHIP_ACC_CCY_CD_4 = opldString.Substring(2280, 3).Trim(),
                    RA_SHIP_COD_CSH_ONLY_IND_4 = opldString.Substring(2283, 2).Trim(),
                    SHIP_ACC_TYPE_5 = opldString.Substring(2285, 3).Trim(),
                    SHIP_ACC_VALUE_5 = opldString.Substring(2288, 15).Trim(),
                    SHIP_ACC_VALUE_N_5 = opldString.Substring(2288, 15).Trim(),
                    SHIP_ACC_CCY_CD_5 = opldString.Substring(2303, 3).Trim(),
                    RA_SHIP_COD_CSH_ONLY_IND_5 = opldString.Substring(2306, 2).Trim(),
                    SHIP_ACC_TYPE_6 = opldString.Substring(2308, 3).Trim(),
                    SHIP_ACC_VALUE_6 = opldString.Substring(2311, 15).Trim(),
                    SHIP_ACC_VALUE_N_6 = opldString.Substring(2311, 15).Trim(),
                    SHIP_ACC_CCY_CD_6 = opldString.Substring(2326, 3).Trim(),
                    RA_SHIP_COD_CSH_ONLY_IND_6 = opldString.Substring(2329, 2).Trim(),
                    SHIP_ACC_TYPE_7 = opldString.Substring(2331, 3).Trim(),
                    SHIP_ACC_VALUE_7 = opldString.Substring(2334, 15).Trim(),
                    SHIP_ACC_VALUE_N_7 = opldString.Substring(2334, 15).Trim(),
                    SHIP_ACC_CCY_CD_7 = opldString.Substring(2349, 3).Trim(),
                    RA_SHIP_COD_CSH_ONLY_IND_7 = opldString.Substring(2352, 2).Trim(),
                    SHIP_ACC_TYPE_8 = opldString.Substring(2354, 3).Trim(),
                    SHIP_ACC_VALUE_8 = opldString.Substring(2357, 15).Trim(),
                    SHIP_ACC_VALUE_N_8 = opldString.Substring(2357, 15).Trim(),
                    SHIP_ACC_CCY_CD_8 = opldString.Substring(2372, 3).Trim(),
                    RA_SHIP_COD_CSH_ONLY_IND_8 = opldString.Substring(2375, 2).Trim(),
                    SHIP_ACC_TYPE_9 = opldString.Substring(2377, 3).Trim(),
                    SHIP_ACC_VALUE_9 = opldString.Substring(2380, 15).Trim(),
                    SHIP_ACC_VALUE_N_9 = opldString.Substring(2380, 15).Trim(),
                    SHIP_ACC_CCY_CD_9 = opldString.Substring(2395, 3).Trim(),
                    RA_SHIP_COD_CSH_ONLY_IND_9 = opldString.Substring(2398, 2).Trim(),
                    SHIP_ACC_TYPE_10 = opldString.Substring(2400, 3).Trim(),
                    SHIP_ACC_VALUE_10 = opldString.Substring(2403, 15).Trim(),
                    SHIP_ACC_VALUE_N_10 = opldString.Substring(2403, 15).Trim(),
                    SHIP_ACC_CCY_CD_10 = opldString.Substring(2418, 3).Trim(),
                    RA_SHIP_COD_CSH_ONLY_IND_10 = opldString.Substring(2421, 2).Trim(),
                    SHIP_ACC_TYPE_11 = opldString.Substring(2423, 3).Trim(),
                    SHIP_ACC_VALUE_11 = opldString.Substring(2426, 15).Trim(),
                    SHIP_ACC_VALUE_N_11 = opldString.Substring(2426, 15).Trim(),
                    SHIP_ACC_CCY_CD_11 = opldString.Substring(2441, 3).Trim(),
                    RA_SHIP_COD_CSH_ONLY_IND_11 = opldString.Substring(2444, 2).Trim(),
                    SHIP_ACC_TYPE_12 = opldString.Substring(2446, 3).Trim(),
                    SHIP_ACC_VALUE_12 = opldString.Substring(2449, 15).Trim(),
                    SHIP_ACC_VALUE_N_12 = opldString.Substring(2449, 15).Trim(),
                    SHIP_ACC_CCY_CD_12 = opldString.Substring(2464, 3).Trim(),
                    RA_SHIP_COD_CSH_ONLY_IND_12 = opldString.Substring(2467, 2).Trim(),
                    SHIP_ACC_TYPE_13 = opldString.Substring(2469, 3).Trim(),
                    SHIP_ACC_VALUE_13 = opldString.Substring(2472, 15).Trim(),
                    SHIP_ACC_VALUE_N_13 = opldString.Substring(2472, 15).Trim(),
                    SHIP_ACC_CCY_CD_13 = opldString.Substring(2487, 3).Trim(),
                    RA_SHIP_COD_CSH_ONLY_IND_13 = opldString.Substring(2490, 2).Trim(),
                    SHIP_ACC_TYPE_14 = opldString.Substring(2492, 3).Trim(),
                    SHIP_ACC_VALUE_14 = opldString.Substring(2495, 15).Trim(),
                    SHIP_ACC_VALUE_N_14 = opldString.Substring(2495, 15).Trim(),
                    SHIP_ACC_CCY_CD_14 = opldString.Substring(2510, 3).Trim(),
                    RA_SHIP_COD_CSH_ONLY_IND_14 = opldString.Substring(2513, 2).Trim(),
                    SHIP_ACC_TYPE_15 = opldString.Substring(2515, 3).Trim(),
                    SHIP_ACC_VALUE_15 = opldString.Substring(2518, 15).Trim(),
                    SHIP_ACC_VALUE_N_15 = opldString.Substring(2518, 15).Trim(),
                    SHIP_ACC_CCY_CD_15 = opldString.Substring(2533, 3).Trim(),
                    RA_SHIP_COD_CSH_ONLY_IND_15 = opldString.Substring(2536, 2).Trim(),
                    SHIP_ACC_TYPE_16 = opldString.Substring(2538, 3).Trim(),
                    SHIP_ACC_VALUE_16 = opldString.Substring(2541, 15).Trim(),
                    SHIP_ACC_VALUE_N_16 = opldString.Substring(2541, 15).Trim(),
                    SHIP_ACC_CCY_CD_16 = opldString.Substring(2556, 3).Trim(),
                    RA_SHIP_COD_CSH_ONLY_IND_16 = opldString.Substring(2559, 2).Trim(),
                    SHIP_ACC_TYPE_17 = opldString.Substring(2561, 3).Trim(),
                    SHIP_ACC_VALUE_17 = opldString.Substring(2564, 15).Trim(),
                    SHIP_ACC_VALUE_N_17 = opldString.Substring(2564, 15).Trim(),
                    SHIP_ACC_CCY_CD_17 = opldString.Substring(2579, 3).Trim(),
                    RA_SHIP_COD_CSH_ONLY_IND_17 = opldString.Substring(2582, 2).Trim(),
                    SHIP_ACC_TYPE_18 = opldString.Substring(2584, 3).Trim(),
                    SHIP_ACC_VALUE_18 = opldString.Substring(2587, 15).Trim(),
                    SHIP_ACC_VALUE_N_18 = opldString.Substring(2587, 15).Trim(),
                    SHIP_ACC_CCY_CD_18 = opldString.Substring(2602, 3).Trim(),
                    RA_SHIP_COD_CSH_ONLY_IND_18 = opldString.Substring(2605, 2).Trim(),
                    SHIP_ACC_TYPE_19 = opldString.Substring(2607, 3).Trim(),
                    SHIP_ACC_VALUE_19 = opldString.Substring(2610, 15).Trim(),
                    SHIP_ACC_VALUE_N_19 = opldString.Substring(2610, 15).Trim(),
                    SHIP_ACC_CCY_CD_19 = opldString.Substring(2625, 3).Trim(),
                    RA_SHIP_COD_CSH_ONLY_IND_19 = opldString.Substring(2628, 2).Trim(),
                    SHIP_ACC_TYPE_20 = opldString.Substring(2630, 3).Trim(),
                    SHIP_ACC_VALUE_20 = opldString.Substring(2633, 15).Trim(),
                    SHIP_ACC_VALUE_N_20 = opldString.Substring(2633, 15).Trim(),
                    SHIP_ACC_CCY_CD_20 = opldString.Substring(2648, 3).Trim(),
                    RA_SHIP_COD_CSH_ONLY_IND_20 = opldString.Substring(2651, 2).Trim(),
                    SHIP_ACC_TYPE_21 = opldString.Substring(2653, 3).Trim(),
                    SHIP_ACC_VALUE_21 = opldString.Substring(2656, 15).Trim(),
                    SHIP_ACC_VALUE_N_21 = opldString.Substring(2656, 15).Trim(),
                    SHIP_ACC_CCY_CD_21 = opldString.Substring(2671, 3).Trim(),
                    RA_SHIP_COD_CSH_ONLY_IND_21 = opldString.Substring(2674, 2).Trim(),
                    SHIP_ACC_TYPE_22 = opldString.Substring(2676, 3).Trim(),
                    SHIP_ACC_VALUE_22 = opldString.Substring(2679, 15).Trim(),
                    SHIP_ACC_VALUE_N_22 = opldString.Substring(2679, 15).Trim(),
                    SHIP_ACC_CCY_CD_22 = opldString.Substring(2694, 3).Trim(),
                    RA_SHIP_COD_CSH_ONLY_IND_22 = opldString.Substring(2697, 2).Trim(),
                    SHIP_ACC_TYPE_23 = opldString.Substring(2699, 3).Trim(),
                    SHIP_ACC_VALUE_23 = opldString.Substring(2702, 15).Trim(),
                    SHIP_ACC_VALUE_N_23 = opldString.Substring(2702, 15).Trim(),
                    SHIP_ACC_CCY_CD_23 = opldString.Substring(2717, 3).Trim(),
                    RA_SHIP_COD_CSH_ONLY_IND_23 = opldString.Substring(2720, 2).Trim(),
                    SHIP_ACC_TYPE_24 = opldString.Substring(2722, 3).Trim(),
                    SHIP_ACC_VALUE_24 = opldString.Substring(2725, 15).Trim(),
                    SHIP_ACC_VALUE_N_24 = opldString.Substring(2725, 15).Trim(),
                    SHIP_ACC_CCY_CD_24 = opldString.Substring(2740, 3).Trim(),
                    RA_SHIP_COD_CSH_ONLY_IND_24 = opldString.Substring(2743, 2).Trim(),
                    SHIP_ACC_TYPE_25 = opldString.Substring(2745, 3).Trim(),
                    SHIP_ACC_VALUE_25 = opldString.Substring(2748, 15).Trim(),
                    SHIP_ACC_VALUE_N_25 = opldString.Substring(2748, 15).Trim(),
                    SHIP_ACC_CCY_CD_25 = opldString.Substring(2763, 3).Trim(),
                    RA_SHIP_COD_CSH_ONLY_IND_25 = opldString.Substring(2766, 2).Trim(),
                    SHIP_ACC_TYPE_26 = opldString.Substring(2768, 3).Trim(),
                    SHIP_ACC_VALUE_26 = opldString.Substring(2771, 15).Trim(),
                    SHIP_ACC_VALUE_N_26 = opldString.Substring(2771, 15).Trim(),
                    SHIP_ACC_CCY_CD_26 = opldString.Substring(2786, 3).Trim(),
                    RA_SHIP_COD_CSH_ONLY_IND_26 = opldString.Substring(2789, 2).Trim(),
                    SHIP_ACC_TYPE_27 = opldString.Substring(2791, 3).Trim(),
                    SHIP_ACC_VALUE_27 = opldString.Substring(2794, 15).Trim(),
                    SHIP_ACC_VALUE_N_27 = opldString.Substring(2794, 15).Trim(),
                    SHIP_ACC_CCY_CD_27 = opldString.Substring(2809, 3).Trim(),
                    RA_SHIP_COD_CSH_ONLY_IND_27 = opldString.Substring(2812, 2).Trim(),
                    SHIP_ACC_TYPE_28 = opldString.Substring(2814, 3).Trim(),
                    SHIP_ACC_VALUE_28 = opldString.Substring(2817, 15).Trim(),
                    SHIP_ACC_VALUE_N_28 = opldString.Substring(2817, 15).Trim(),
                    SHIP_ACC_CCY_CD_28 = opldString.Substring(2832, 3).Trim(),
                    RA_SHIP_COD_CSH_ONLY_IND_28 = opldString.Substring(2835, 2).Trim(),
                    SHIP_ACC_TYPE_29 = opldString.Substring(2837, 3).Trim(),
                    SHIP_ACC_VALUE_29 = opldString.Substring(2840, 15).Trim(),
                    SHIP_ACC_VALUE_N_29 = opldString.Substring(2840, 15).Trim(),
                    SHIP_ACC_CCY_CD_29 = opldString.Substring(2855, 3).Trim(),
                    RA_SHIP_COD_CSH_ONLY_IND_29 = opldString.Substring(2858, 2).Trim(),
                    SHIP_ACC_TYPE_30 = opldString.Substring(2860, 3).Trim(),
                    SHIP_ACC_VALUE_30 = opldString.Substring(2863, 15).Trim(),
                    SHIP_ACC_VALUE_N_30 = opldString.Substring(2863, 15).Trim(),
                    SHIP_ACC_CCY_CD_30 = opldString.Substring(2878, 3).Trim(),
                    RA_SHIP_COD_CSH_ONLY_IND_30 = opldString.Substring(2881, 2).Trim(),
                    SHIP_ACC_TYPE_31 = opldString.Substring(2883, 3).Trim(),
                    SHIP_ACC_VALUE_31 = opldString.Substring(2886, 15).Trim(),
                    SHIP_ACC_VALUE_N_31 = opldString.Substring(2886, 15).Trim(),
                    SHIP_ACC_CCY_CD_31 = opldString.Substring(2901, 3).Trim(),
                    RA_SHIP_COD_CSH_ONLY_IND_31 = opldString.Substring(2904, 2).Trim(),
                    SHIP_ACC_TYPE_32 = opldString.Substring(2906, 3).Trim(),
                    SHIP_ACC_VALUE_32 = opldString.Substring(2909, 15).Trim(),
                    SHIP_ACC_VALUE_N_32 = opldString.Substring(2909, 15).Trim(),
                    SHIP_ACC_CCY_CD_32 = opldString.Substring(2924, 3).Trim(),
                    RA_SHIP_COD_CSH_ONLY_IND_32 = opldString.Substring(2927, 2).Trim(),
                    SHIP_ACC_TYPE_33 = opldString.Substring(2929, 3).Trim(),
                    SHIP_ACC_VALUE_33 = opldString.Substring(2932, 15).Trim(),
                    SHIP_ACC_VALUE_N_33 = opldString.Substring(2932, 15).Trim(),
                    SHIP_ACC_CCY_CD_33 = opldString.Substring(2947, 3).Trim(),
                    RA_SHIP_COD_CSH_ONLY_IND_33 = opldString.Substring(2950, 2).Trim(),
                    SHIP_ACC_TYPE_34 = opldString.Substring(2952, 3).Trim(),
                    SHIP_ACC_VALUE_34 = opldString.Substring(2955, 15).Trim(),
                    SHIP_ACC_VALUE_N_34 = opldString.Substring(2955, 15).Trim(),
                    SHIP_ACC_CCY_CD_34 = opldString.Substring(2970, 3).Trim(),
                    RA_SHIP_COD_CSH_ONLY_IND_34 = opldString.Substring(2973, 2).Trim(),
                    SHIP_ACC_TYPE_35 = opldString.Substring(2975, 3).Trim(),
                    SHIP_ACC_VALUE_35 = opldString.Substring(2978, 15).Trim(),
                    SHIP_ACC_VALUE_N_35 = opldString.Substring(2978, 15).Trim(),
                    SHIP_ACC_CCY_CD_35 = opldString.Substring(2993, 3).Trim(),
                    RA_SHIP_COD_CSH_ONLY_IND_35 = opldString.Substring(2996, 2).Trim(),
                    SHIP_UOM_WGT = opldString.Substring(2998, 3).Trim(),
                    SHIP_DIM_WEIGHT = opldString.Substring(3001, 7).Trim(),
                    SHIP_DIM_WEIGHT_NUM = opldString.Substring(3001, 7).Trim(),
                    SHIP_ACTUAL_WEIGHT = opldString.Substring(3008, 7).Trim(),
                    SHIP_ACTUAL_WEIGHT_NUM = opldString.Substring(3008, 7).Trim(),
                    SHIP_BILLED_WEIGHT = opldString.Substring(3015, 7).Trim(),
                    SHIP_BILLED_WEIGHT_NUM = opldString.Substring(3015, 7).Trim(),
                    SHIP_SENDER_NAME = opldString.Substring(3022, 35).Trim(),
                    SHIP_CRED_CARD_NR = opldString.Substring(3057, 16).Trim(),
                    SHIP_CRED_CARD_EXP_DT = opldString.Substring(3073, 6).Trim(),
                    SHIP_INTERNET_USER_ID = opldString.Substring(3079, 16).Trim(),
                    SHIP_CRED_CARD_AUTH_NR = opldString.Substring(3095, 24).Trim(),
                    SHIP_SHIPPER = opldString.Substring(3119, 1).Trim(),
                    SHIP_CONSIGNEE = opldString.Substring(3120, 1).Trim(),
                    SHIP_CNSG_SHIP_NR = opldString.Substring(3121, 10).Trim(),
                    SHIP_3PB = opldString.Substring(3131, 1).Trim(),
                    SHIP_3PB_SHIP_NR = opldString.Substring(3132, 10).Trim(),
                    SHIP_FREIGHT = opldString.Substring(3142, 1).Trim(),
                    SHIP_FREIGHT_SHIP_NR = opldString.Substring(3143, 10).Trim(),
                    SHIP_RLA_NR = opldString.Substring(3153, 1).Trim(),
                    SHIP_RLA_SHIP_NR = opldString.Substring(3154, 10).Trim(),
                    SHIP_OVS_NR = opldString.Substring(3164, 1).Trim(),
                    SHIP_IVS_NR = opldString.Substring(3165, 1).Trim(),
                    SHIP_IVS_SHIP_NR = opldString.Substring(3166, 10).Trim(),
                    SHIP_HARM_CDE = opldString.Substring(3176, 35).Trim(),
                    SHIP_MANF_CTRY_ORIG_CD = opldString.Substring(3211, 2).Trim(),
                    SHIP_CUSTM_VAL_S = opldString.Substring(3213, 1).Trim(),
                    SHIP_CUSTM_VAL_N = opldString.Substring(3214, 18).Trim(),
                    SHIP_GCCN_IND = opldString.Substring(3232, 1).Trim(),
                    SHIP_INV_TOTAL_AMT_N = opldString.Substring(3233, 18).Trim(),
                    SHIP_EXP_AC_NR = opldString.Substring(3251, 10).Trim(),
                    SHIP_EXP_COMP_NA = opldString.Substring(3261, 35).Trim(),
                    SHIP_EXP_ATTN_NAME = opldString.Substring(3296, 35).Trim(),
                    SHIP_EXP_ADDR_LINE_1 = opldString.Substring(3331, 35).Trim(),
                    SHIP_EXP_ADDR_LINE_2 = opldString.Substring(3366, 35).Trim(),
                    SHIP_EXP_ADDR_LINE_3 = opldString.Substring(3401, 35).Trim(),
                    SHIP_EXP_CITY = opldString.Substring(3436, 30).Trim(),
                    SHIP_EXP_STATE_CD = opldString.Substring(3466, 5).Trim(),
                    SHIP_EXP_POSTAL_CD = opldString.Substring(3471, 9).Trim(),
                    SHIP_EXP_CNTRY_CD = opldString.Substring(3480, 2).Trim(),
                    SHIP_IMP_CITY = opldString.Substring(3482, 30).Trim(),
                    SHIP_IMP_STATE_CD = opldString.Substring(3512, 5).Trim(),
                    SHIP_IMP_POSTAL_CD = opldString.Substring(3517, 9).Trim(),
                    SHIP_IMP_CNTRY_CD = opldString.Substring(3526, 2).Trim(),
                    SHIP_CLRNCE_PORT = opldString.Substring(3528, 5).Trim(),
                    SHIP_SP_NR = opldString.Substring(3533, 35).Trim(),
                    SHIP_NR_PKG = opldString.Substring(3568, 6).Trim(),
                    SHIP_SVC_TYP_CD = opldString.Substring(3574, 3).Trim(),
                    SHIP_CSGN_ADDR_VAL_RES = opldString.Substring(3577, 2).Trim(),
                    SHIP_CRNCY_CDE = opldString.Substring(3579, 3).Trim(),
                    SHIP_CSGN_VCE_PHN_NRS = opldString.Substring(3582, 15).Trim(),
                    SHIP_CSGN_FAX_PHN_NRS = opldString.Substring(3597, 15).Trim(),
                    SHIP_DOMEST_INTL_FLAG = opldString.Substring(3612, 2).Trim(),
                    SHIP_SOURCE_FLAG = opldString.Substring(3614, 2).Trim(),
                    SHIP_IMP_ACC_NR = opldString.Substring(3616, 10).Trim(),
                    SHIP_IMP_FLG = opldString.Substring(3626, 1).Trim(),
                    SHIP_INV_CURR_CDE = opldString.Substring(3627, 3).Trim(),
                    SHIP_ACY_INS_CC = opldString.Substring(3630, 2).Trim(),
                    SHIP_ACY_INS_YY = opldString.Substring(3632, 2).Trim(),
                    SHIP_ACY_INS_MM = opldString.Substring(3634, 2).Trim(),
                    SHIP_ACY_INS_DD = opldString.Substring(3636, 2).Trim(),
                    SHIP_ACY_INS_HH = opldString.Substring(3638, 2).Trim(),
                    SHIP_ACY_INS_MIN = opldString.Substring(3640, 2).Trim(),
                    SHIP_QVIO_DATA_AREA = opldString.Substring(3642, 30).Trim(),
                    SHIP_SHR_OPT_IND = opldString.Substring(3672, 1).Trim(),
                    SHIP_USI = opldString.Substring(3673, 20).Trim(),
                    SHIP_TDPROD_TYP_CDE = opldString.Substring(3693, 4).Trim(),
                    AMS_TOKEN = opldString.Substring(3697, 32).Trim(),
                    FILLER = opldString.Substring(3729, 8).Trim(),
                    SHIP_REQ_ADDR_CLASS = opldString.Substring(3737, 2).Trim(),
                    SHIP_REQ_ADDR_ID = opldString.Substring(3739, 32).Trim(),
                    SHIP_IA_GCCNNumber = opldString.Substring(3771, 11).Trim(),
                    SHIP_CA01_PKUP_PHN_NR = opldString.Substring(3782, 15).Trim(),
                    CRA_PDP_Delivery_Token = opldString.Substring(3797, 32).Trim(),
                    CRA_PDP_Delivery_NGDW_Start = opldString.Substring(3829, 4).Trim(),
                    CRA_PDP_Delivery_NGDW_End = opldString.Substring(3833, 4).Trim(),
                    CRA_PDP_Delivery_NGDW_Confidence = opldString.Substring(3837, 2).Trim(),
                    CRA_PDP_Delivery_Date_Required = opldString.Substring(3839, 1).Trim(),
                    CRA_PDP_PickUp_Token = opldString.Substring(3840, 32).Trim(),
                    CRA_PDP_PickUp_NGDW_Start = opldString.Substring(3872, 4).Trim(),
                    CRA_PDP_PickUp_NGDW_End = opldString.Substring(3876, 4).Trim(),
                    CRA_PDP_PickUp_NGDW_Confidence = opldString.Substring(3880, 2).Trim(),
                    CRA_PDP_PickUp_Date_Required = opldString.Substring(3882, 1).Trim(),
                    PDP_Replay = opldString.Substring(3883, 1).Trim(),
                    PDP_Flags = opldString.Substring(3884, 4).Trim(),
                    SHIP_PSI_NR_PCS = opldString.Substring(3888, 5).Trim(),
                    SHIP_DSPLY_NAME = opldString.Substring(3893, 35).Trim(),
                    ProcessingStatus = "Pending",
                    Packages = new List<Package>()
                };
                oplds.Add(opldData);
            }

            return oplds;
        }

        private static List<Package> ProcessOPLDPackages(string packageString, List<Package> packages)
        {
            if (!string.IsNullOrEmpty(packageString) && packageString.StartsWith("02"))
            {
                Package packageData = new Package
                {
                    //PackageLength = packageString.Length > 19 ? packageString.Substring(11, 8).Trim() : "",
                    //PackageWidth = packageString.Length > 27 ? packageString.Substring(19, 8).Trim() : "",
                    //PackageHeight = packageString.Length > 35 ? packageString.Substring(27, 8).Trim() : "",
                    //PackageTrackingNumber = packageString.Length > 70 ? packageString.Substring(35, 35).Trim() : "",
                    //PackageDimensionalWeight = packageString.Length > 77 ? packageString.Substring(70, 7).Trim() : "",
                    //PackageActualWeight = packageString.Length > 84 ? packageString.Substring(77, 7).Trim() : "",
                    //PackageReferenceType1 = packageString.Length > 88 ? packageString.Substring(86, 2).Trim() : "",
                    //PackageReferenceNumber1 = packageString.Length > 123 ? packageString.Substring(88, 35).Trim() : "",

                    //PackageReferenceType2 = packageString.Length > 125 ? packageString.Substring(123, 2).Trim() : "",
                    //PackageReferenceNumber2 = packageString.Length > 160 ? packageString.Substring(125, 35).Trim() : "",

                    //PackageReferenceType3 = packageString.Length > 162 ? packageString.Substring(160, 2).Trim() : "",
                    //PackageReferenceNumber3 = packageString.Length > 197 ? packageString.Substring(162, 35).Trim() : "",

                    //PackageReferenceType4 = packageString.Length > 199 ? packageString.Substring(197, 2).Trim() : "",
                    //PackageReferenceNumber4 = packageString.Length > 234 ? packageString.Substring(199, 35).Trim() : "",

                    //PackageReferenceType5 = packageString.Length > 236 ? packageString.Substring(234, 2).Trim() : "",
                    //PackageReferenceNumber5 = packageString.Length > 271 ? packageString.Substring(236, 35).Trim() : "",

                    //PackageAccessorialType1 = packageString.Length > 274 ? packageString.Substring(271, 3).Trim() : "",
                    //PackageAccessorialValue1 = packageString.Length > 289 ? packageString.Substring(274, 15).Trim() : "",

                    //PackageAccessorialType2 = packageString.Length > 295 ? packageString.Substring(292, 3).Trim() : "",
                    //PackageAccessorialValue2 = packageString.Length > 310 ? packageString.Substring(295, 15).Trim() : "",

                    //PackageAccessorialType3 = packageString.Length > 316 ? packageString.Substring(313, 3).Trim() : "",
                    //PackageAccessorialValue3 = packageString.Length > 331 ? packageString.Substring(316, 15).Trim() : "",

                    //PackageAccessorialType4 = packageString.Length > 337 ? packageString.Substring(334, 3).Trim() : "",
                    //PackageAccessorialValue4 = packageString.Length > 352 ? packageString.Substring(337, 15).Trim() : "",

                    //PackageAccessorialType5 = packageString.Length > 358 ? packageString.Substring(355, 3).Trim() : "",
                    //PackageAccessorialValue5 = packageString.Length > 373 ? packageString.Substring(358, 15).Trim() : "",

                    //PackageAccessorialType6 = packageString.Length > 379 ? packageString.Substring(376, 3).Trim() : "",
                    //PackageAccessorialValue6 = packageString.Length > 394 ? packageString.Substring(379, 15).Trim() : "",

                    //PackageAccessorialType7 = packageString.Length > 400 ? packageString.Substring(397, 3).Trim() : "",
                    //PackageAccessorialValue7 = packageString.Length > 415 ? packageString.Substring(400, 15).Trim() : "",

                    //PackageAccessorialType8 = packageString.Length > 421 ? packageString.Substring(418, 3).Trim() : "",
                    //PackageAccessorialValue8 = packageString.Length > 436 ? packageString.Substring(421, 15).Trim() : "",

                    //PackageAccessorialType9 = packageString.Length > 442 ? packageString.Substring(439, 3).Trim() : "",
                    //PackageAccessorialValue9 = packageString.Length > 457 ? packageString.Substring(442, 15).Trim() : "",

                    //PackageAccessorialType10 = packageString.Length > 463 ? packageString.Substring(460, 3).Trim() : "",
                    //PackageAccessorialValue10 = packageString.Length > 478 ? packageString.Substring(463, 15).Trim() : "",

                    //PackageAccessorialType11 = packageString.Length > 484 ? packageString.Substring(481, 3).Trim() : "",
                    //PackageAccessorialValue11 = packageString.Length > 499 ? packageString.Substring(484, 15).Trim() : "",

                    //PackageAccessorialType12 = packageString.Length > 505 ? packageString.Substring(502, 3).Trim() : "",
                    //PackageAccessorialValue12 = packageString.Length > 520 ? packageString.Substring(505, 15).Trim() : "",

                    //PackageAccessorialType13 = packageString.Length > 526 ? packageString.Substring(523, 3).Trim() : "",
                    //PackageAccessorialValue13 = packageString.Length > 541 ? packageString.Substring(526, 15).Trim() : "",

                    //PackageAccessorialType14 = packageString.Length > 547 ? packageString.Substring(544, 3).Trim() : "",
                    //PackageAccessorialValue14 = packageString.Length > 562 ? packageString.Substring(547, 15).Trim() : "",

                    //PackageAccessorialType15 = packageString.Length > 568 ? packageString.Substring(565, 3).Trim() : "",
                    //PackageAccessorialValue15 = packageString.Length > 583 ? packageString.Substring(568, 15).Trim() : "",

                    //PackageBilledWeight = packageString.Length > 593 ? packageString.Substring(586, 7).Trim() : "",
                    //PackageMerchDesc = packageString.Length > 628 ? packageString.Substring(593, 35).Trim() : "",
                    //PackageCODCNTLNR = packageString.Length > 639 ? packageString.Substring(628, 11).Trim() : "",
                    //PackageCODCSHONLYIND = packageString.Length > 641 ? packageString.Substring(639, 2).Trim() : "",
                    //PackageCALLARSIND = packageString.Length > 642 ? packageString.Substring(641, 1).Trim() : "",
                    //PackageCALLARSSCHPKDT = packageString.Length > 652 ? packageString.Substring(642, 10).Trim() : "",
                    //PackageCSGNPHNNR = packageString.Length > 667 ? packageString.Substring(652, 15).Trim() : "",
                    //PackageSPCLINSTR = packageString.Length > 736 ? packageString.Substring(667, 69).Trim() : "",
                    //PackageEARLYDELTM = packageString.Length > 740 ? packageString.Substring(736, 4).Trim() : "",
                    //PackageALTREFTYPCD = packageString.Length > 742 ? packageString.Substring(740, 2).Trim() : "",
                    //PackageDLVTOATTNNAM = packageString.Length > 777 ? packageString.Substring(742, 35).Trim() : "",
                    //PackageSchDelievryDate = packageString.Length > 785 ? packageString.Substring(777, 8).Trim() : "",
                    //PackageSchDelievryTime = packageString.Length > 789 ? packageString.Substring(785, 4).Trim() : "",
                    //PackageTRANTKNO = packageString.Length > 824 ? packageString.Substring(789, 35).Trim() : "",
                    //PackageGDWELIGIBILITY = packageString.Length > 825 ? packageString.Substring(824, 1).Trim() : ""
                    PKG_REC_FLAG = packageString.Substring(0, 2),
                    PKG_SEQ_NR = packageString.Substring(2, 9),
                    PKG_DTL_LENGTH_RED = packageString.Substring(11, 8),
                    PKG_DTL_WIDTH_RED = packageString.Substring(19, 8),
                    PKG_DTL_HEIGHT = packageString.Substring(27, 8),
                    PKG_DTL_HEIGHT_RED = packageString.Substring(27, 8),
                    PKG_TRACKING_NUM = packageString.Substring(35, 35),
                    PKG_DIM_WEIGHT_NUM = packageString.Substring(70, 7),
                    PKG_ACTUAL_WEIGHT = packageString.Substring(77, 7),
                    PKG_ACTUAL_WEIGHT_NUM = packageString.Substring(77, 7),
                    PKG_OVSZ_IND = packageString.Substring(84, 1),
                    PKG_VOID_IND = packageString.Substring(85, 1),
                    PKG_REF_TYP_CD_1 = packageString.Substring(86, 2),
                    PKG_REF_NUMBER_1 = packageString.Substring(88, 35),
                    PKG_REF_TYP_CD_2 = packageString.Substring(123, 2),
                    PKG_REF_NUMBER_2 = packageString.Substring(125, 35),
                    PKG_REF_TYP_CD_3 = packageString.Substring(160, 2),
                    PKG_REF_NUMBER_3 = packageString.Substring(162, 35),
                    PKG_REF_TYP_CD_4 = packageString.Substring(197, 2),
                    PKG_REF_NUMBER_4 = packageString.Substring(199, 35),
                    PKG_REF_TYP_CD_5 = packageString.Substring(234, 2),
                    PKG_REF_NUMBER_5 = packageString.Substring(236, 35),
                    PKG_ACC_TYPE_1 = packageString.Substring(271, 3),
                    PKG_ACC_VALUE_1 = packageString.Substring(274, 15),
                    PKG_ACC_VALUE_N_1 = packageString.Substring(274, 15),
                    CRA_PKG_ACC_CCY_CD_1 = packageString.Substring(289, 3),
                    PKG_ACC_TYPE_2 = packageString.Substring(292, 3),
                    PKG_ACC_VALUE_2 = packageString.Substring(295, 15),
                    PKG_ACC_VALUE_N_2 = packageString.Substring(295, 15),
                    CRA_PKG_ACC_CCY_CD_2 = packageString.Substring(310, 3),
                    PKG_ACC_TYPE_3 = packageString.Substring(313, 3),
                    PKG_ACC_VALUE_3 = packageString.Substring(316, 15),
                    PKG_ACC_VALUE_N_3 = packageString.Substring(316, 15),
                    CRA_PKG_ACC_CCY_CD_3 = packageString.Substring(331, 3),
                    PKG_ACC_TYPE_4 = packageString.Substring(334, 3),
                    PKG_ACC_VALUE_4 = packageString.Substring(337, 15),
                    PKG_ACC_VALUE_N_4 = packageString.Substring(337, 15),
                    CRA_PKG_ACC_CCY_CD_4 = packageString.Substring(352, 3),
                    PKG_ACC_TYPE_5 = packageString.Substring(355, 3),
                    PKG_ACC_VALUE_5 = packageString.Substring(358, 15),
                    PKG_ACC_VALUE_N_5 = packageString.Substring(358, 15),
                    CRA_PKG_ACC_CCY_CD_5 = packageString.Substring(373, 3),
                    PKG_ACC_TYPE_6 = packageString.Substring(376, 3),
                    PKG_ACC_VALUE_6 = packageString.Substring(379, 15),
                    PKG_ACC_VALUE_N_6 = packageString.Substring(379, 15),
                    CRA_PKG_ACC_CCY_CD_6 = packageString.Substring(394, 3),
                    PKG_ACC_TYPE_7 = packageString.Substring(397, 3),
                    PKG_ACC_VALUE_7 = packageString.Substring(400, 15),
                    PKG_ACC_VALUE_N_7 = packageString.Substring(400, 15),
                    CRA_PKG_ACC_CCY_CD_7 = packageString.Substring(415, 3),
                    PKG_ACC_TYPE_8 = packageString.Substring(418, 3),
                    PKG_ACC_VALUE_8 = packageString.Substring(421, 15),
                    PKG_ACC_VALUE_N_8 = packageString.Substring(421, 15),
                    CRA_PKG_ACC_CCY_CD_8 = packageString.Substring(436, 3),
                    PKG_ACC_TYPE_9 = packageString.Substring(439, 3),
                    PKG_ACC_VALUE_9 = packageString.Substring(442, 15),
                    PKG_ACC_VALUE_N_9 = packageString.Substring(442, 15),
                    CRA_PKG_ACC_CCY_CD_9 = packageString.Substring(457, 3),
                    PKG_ACC_TYPE_10 = packageString.Substring(460, 3),
                    PKG_ACC_VALUE_10 = packageString.Substring(463, 15),
                    PKG_ACC_VALUE_N_10 = packageString.Substring(463, 15),
                    CRA_PKG_ACC_CCY_CD_10 = packageString.Substring(478, 3),
                    PKG_ACC_TYPE_11 = packageString.Substring(481, 3),
                    PKG_ACC_VALUE_11 = packageString.Substring(484, 15),
                    PKG_ACC_VALUE_N_11 = packageString.Substring(484, 15),
                    CRA_PKG_ACC_CCY_CD_11 = packageString.Substring(499, 3),
                    PKG_ACC_TYPE_12 = packageString.Substring(502, 3),
                    PKG_ACC_VALUE_12 = packageString.Substring(505, 15),
                    PKG_ACC_VALUE_N_12 = packageString.Substring(505, 15),
                    CRA_PKG_ACC_CCY_CD_12 = packageString.Substring(520, 3),
                    PKG_ACC_TYPE_13 = packageString.Substring(523, 3),
                    PKG_ACC_VALUE_13 = packageString.Substring(526, 15),
                    PKG_ACC_VALUE_N_13 = packageString.Substring(526, 15),
                    CRA_PKG_ACC_CCY_CD_13 = packageString.Substring(541, 3),
                    PKG_ACC_TYPE_14 = packageString.Substring(544, 3),
                    PKG_ACC_VALUE_14 = packageString.Substring(547, 15),
                    PKG_ACC_VALUE_N_14 = packageString.Substring(547, 15),
                    RA_PKG_ACC_CCY_CD_14 = packageString.Substring(562, 3),
                    PKG_ACC_TYPE_15 = packageString.Substring(565, 3),
                    PKG_ACC_VALUE_15 = packageString.Substring(568, 15),
                    PKG_ACC_VALUE_N_15 = packageString.Substring(568, 15),
                    CRA_PKG_ACC_CCY_CD_15 = packageString.Substring(583, 3),
                    PKG_BILLED_WEIGHT = packageString.Substring(586, 7),
                    PKG_BILLED_WEIGHT_NUM = packageString.Substring(586, 7),
                    PKG_MERCH_DESC = packageString.Substring(593, 35),
                    PKG_COD_CNTL_NR = packageString.Substring(628, 11),
                    PKG_COD_CSH_ONLY_IND = packageString.Substring(639, 2),
                    PKG_CALL_ARS_IND = packageString.Substring(641, 1),
                    PKG_CALL_ARS_SCH_PKDT = packageString.Substring(642, 10),
                    PKG_CSGN_PHN_NR = packageString.Substring(652, 15),
                    PKG_SPCL_INSTR = packageString.Substring(667, 69),
                    PKG_EARLY_DEL_TM = packageString.Substring(736, 4),
                    PKG_PKG_ALT_REF_TYP_CD = packageString.Substring(740, 2),
                    PKG_DLV_TO_ATTN_NAM = packageString.Substring(742, 35),
                    PKG_SDD_CC = packageString.Substring(777, 2),
                    PKG_SDD_YY = packageString.Substring(779, 2),
                    PKG_SDD_MM = packageString.Substring(781, 2),
                    PKG_SDD_DD = packageString.Substring(783, 2),
                    PKG_SDD_HH = packageString.Substring(785, 2),
                    PKG_SDD_MN = packageString.Substring(787, 2),
                    PKG_TRAN_TK_NO = packageString.Substring(789, 35),
                    PKG_GDW_ELIGIBILITY = packageString.Substring(824, 1),
                    PKG_Flags = packageString.Substring(825, 4),
                    PKG_CLINIC_TRIALS_FLAG = packageString.Substring(829, 1),
                    PKG_CLINIC_TRIALS_ID = packageString.Substring(830, 20)
                };

                packages.Add(packageData);

                return packages;
            }
            else
            {
                return packages;
            }
        }

        //public static void ProcessOPLDMessage(string opldString, ref List<OPLD> opldList)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(opldString))
        //        {
        //            opldString = null;
        //            return;
        //        }

        //        while (!string.IsNullOrEmpty(opldString))
        //        {
        //            if (string.IsNullOrEmpty(opldString))
        //            {
        //                break;
        //            }

        //            if (opldString.Trim().StartsWith("01"))
        //            {
        //                var opldObject = ProcessOPLD(opldString,opldList);
        //                //opldList.Add(opldObject);

        //                opldString = opldString.Substring(4030).Trim();

        //                ProcessOPLDMessage(opldString.Trim(), ref opldList);
        //            }
        //            else if (opldString.Trim().StartsWith("02"))
        //            {
        //                var opldObject = opldList.Last();
        //                ProcessOPLDPackages(opldString.Trim(), opldObject.packages);

        //                int subStringStart = opldString.Length > 849 ? 849 : opldString.Length;
        //                opldString = opldString.Substring(subStringStart).Trim();

        //                ProcessOPLDMessage(opldString, ref opldList);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public static void ProcessOPLDMessage(string opldString, ref List<OPLD> opldList)
        {
            try
            {
                while (!string.IsNullOrEmpty(opldString) && opldString.Length > 0)
                {
                    if (opldString.Trim().StartsWith("01"))
                    {
                        ProcessOPLD(opldString, opldList);

                        int subStringStart = opldString.Length > 4030 ? 4030 : opldString.Length;
                        opldString = opldString.Substring(subStringStart).Trim();
                    }
                    else if (opldString.Trim().StartsWith("02"))
                    {
                        var opldObject = opldList.Last();
                        ProcessOPLDPackages(opldString.Trim(), opldObject.Packages);

                        int subStringStart = opldString.Length > 849 ? 849 : opldString.Length;
                        opldString = opldString.Substring(subStringStart).Trim();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

