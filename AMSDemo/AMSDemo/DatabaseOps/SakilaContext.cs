using MySql.Data.MySqlClient;
using System;
using AMSDemo.Models;
using System.Collections.Generic;

namespace AMSDemo.DatabaseOps
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

        public int GetLastOPLDPackageID(int opldId)
        {
            int lastOPLDID = 0;

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT max(PackageId) AS PackageId FROM opldpackages", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.IsDBNull(0))
                        {
                            lastOPLDID = 0;
                        }
                        else
                            lastOPLDID = Convert.ToInt32(reader["PackageId"]);
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
                MySqlCommand cmd = new MySqlCommand("SELECT max(ServicePointID) AS OPLDID FROM servicepoint", conn);
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

        public Tuple<bool, int> AddNewOPLD(OPLD newOPLD)
        {
            int rowsAffected = 0;
            int lastOPLD = (GetLastOPLDID() + 1);

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO oplddetails VALUES('" + lastOPLD + "','" + newOPLD.PAGE_SMT_REC_FLAG + "','" + newOPLD.VERSION_NUMBER + "','" + newOPLD.PAGE_INF_SRC_TYP_CD +
                    "','" + newOPLD.PAGE_SMT_REC_FLAG + "','" + newOPLD.VERSION_NUMBER + "','" + newOPLD.PAGE_INF_SRC_TYP_CD + "','" + newOPLD.PAGE_MAILBOX + "','" + newOPLD.PAGE_PICKUP_DT
                    + "','" + newOPLD.PAGE_PICKUP_CC_DT + "','" + newOPLD.PAGE_PICKUP_YY_DT + "','" + newOPLD.PAGE_PICKUP_MM_DT + "','" + newOPLD.PAGE_PICKUP_DD_DT + "','" + newOPLD.PAGE_SEQ_NUM
                    + "','" + newOPLD.PAGE_SHIPPER_NUMBER + "','" + newOPLD.PAGE_SHIPPER_COUNTRY + "','" + newOPLD.PAGE_PICKUP_BOOK + "','" + newOPLD.PAGE_PICKUP_PAGE + "','" + newOPLD.PAGE_PICKUP_BOOK_TYPE
                    + "','" + newOPLD.PAGE_VOID_IND + "','" + newOPLD.PAGE_VSN_NR + "','" + newOPLD.SMT_SEQ_NR + "','" + newOPLD.SHIP_PKGING_TYP + "','" + newOPLD.SHIP_DOC_IND + "','" + newOPLD.SHIP_CONTAINER_TYPE
                    + "','" + newOPLD.SHIP_BILL_TERMS + "','" + newOPLD.SHIP_PAY_MEDIA_TYPE + "','" + newOPLD.SHIP_SHR_3PB_FLG + "','" + newOPLD.SHIP_CSGN_3PB_FLG + "','" + newOPLD.SHIP_REF_TYP_CD_1
                    + "','" + newOPLD.SHIP_REF_NR_1 + "','" + newOPLD.SHIP_REF_TYP_CD_2 + "','" + newOPLD.SHIP_REF_NR_2 + "','" + newOPLD.SHIP_CWT_IND + "','" + newOPLD.SHIP_ADDR_TYPE_1
                    + "','" + newOPLD.SHIP_AC_NR_1 + "','" + newOPLD.SHIP_COMP_NA_1 + "','" + newOPLD.SHIP_ATTENTION_NAME_1 + "','" + newOPLD.SHIP_ADDR_LINE_1_1 + "','" + newOPLD.SHIP_ADDR_LINE_2_1
                    + "','" + newOPLD.SHIP_ADDR_LINE_3_1 + "','" + newOPLD.SHIP_CITY_NAME_1 + "','" + newOPLD.SHIP_STATE_CODE_1 + "','" + newOPLD.SHIP_ZIP_CODE_1 + "','" + newOPLD.SHIP_COUNTRY_CODE_1
                    + "','" + newOPLD.SHIP_PH_NR_1 + "','" + newOPLD.SHIP_ADDR_TYPE_2 + "','" + newOPLD.SHIP_AC_NR_2 + "','" + newOPLD.SHIP_COMP_NA_2 + "','" + newOPLD.SHIP_ATTENTION_NAME_2
                    + "','" + newOPLD.SHIP_ADDR_LINE_1_2 + "','" + newOPLD.SHIP_ADDR_LINE_2_2 + "','" + newOPLD.SHIP_ADDR_LINE_3_2 + "','" + newOPLD.SHIP_CITY_NAME_2 + "','" + newOPLD.SHIP_STATE_CODE_2
                    + "','" + newOPLD.SHIP_ZIP_CODE_2 + "','" + newOPLD.SHIP_COUNTRY_CODE_2 + "','" + newOPLD.SHIP_PH_NR_2 + "','" + newOPLD.SHIP_ADDR_TYPE_3 + "','" + newOPLD.SHIP_AC_NR_3
                    + "','" + newOPLD.SHIP_COMP_NA_3 + "','" + newOPLD.SHIP_ATTENTION_NAME_3 + "','" + newOPLD.SHIP_ADDR_LINE_1_3 + "','" + newOPLD.SHIP_ADDR_LINE_2_3 + "','" + newOPLD.SHIP_ADDR_LINE_3_3
                    + "','" + newOPLD.SHIP_CITY_NAME_3 + "','" + newOPLD.SHIP_STATE_CODE_3 + "','" + newOPLD.SHIP_ZIP_CODE_3 + "','" + newOPLD.SHIP_COUNTRY_CODE_3 + "','" + newOPLD.SHIP_PH_NR_3
                    + "','" + newOPLD.SHIP_ADDR_TYPE_4 + "','" + newOPLD.SHIP_AC_NR_4 + "','" + newOPLD.SHIP_COMP_NA_4 + "','" + newOPLD.SHIP_ATTENTION_NAME_4 + "','" + newOPLD.SHIP_ADDR_LINE_1_4
                    + "','" + newOPLD.SHIP_ADDR_LINE_2_4 + "','" + newOPLD.SHIP_ADDR_LINE_3_4 + "','" + newOPLD.SHIP_CITY_NAME_4 + "','" + newOPLD.SHIP_STATE_CODE_4 + "','" + newOPLD.SHIP_ZIP_CODE_4
                    + "','" + newOPLD.SHIP_COUNTRY_CODE_4 + "','" + newOPLD.SHIP_PH_NR_4 + "','" + newOPLD.SHIP_ADDR_TYPE_5 + "','" + newOPLD.SHIP_AC_NR_5 + "','" + newOPLD.SHIP_COMP_NA_5
                    + "','" + newOPLD.SHIP_ATTENTION_NAME_5 + "','" + newOPLD.SHIP_ADDR_LINE_1_5 + "','" + newOPLD.SHIP_ADDR_LINE_2_5 + "','" + newOPLD.SHIP_ADDR_LINE_3_5 + "','" + newOPLD.SHIP_CITY_NAME_5
                    + "','" + newOPLD.SHIP_STATE_CODE_5 + "','" + newOPLD.SHIP_ZIP_CODE_5 + "','" + newOPLD.SHIP_COUNTRY_CODE_5 + "','" + newOPLD.SHIP_PH_NR_5 + "','" + newOPLD.SHIP_ADDR_TYPE_6
                    + "','" + newOPLD.SHIP_AC_NR_6 + "','" + newOPLD.SHIP_COMP_NA_6 + "','" + newOPLD.SHIP_ATTENTION_NAME_6 + "','" + newOPLD.SHIP_ADDR_LINE_1_6 + "','" + newOPLD.SHIP_ADDR_LINE_2_6
                    + "','" + newOPLD.SHIP_ADDR_LINE_3_6 + "','" + newOPLD.SHIP_CITY_NAME_6 + "','" + newOPLD.SHIP_STATE_CODE_6 + "','" + newOPLD.SHIP_ZIP_CODE_6 + "','" + newOPLD.SHIP_COUNTRY_CODE_6
                    + "','" + newOPLD.SHIP_PH_NR_6 + "','" + newOPLD.SHIP_ADDR_TYPE_7 + "','" + newOPLD.SHIP_AC_NR_7 + "','" + newOPLD.SHIP_COMP_NA_7 + "','" + newOPLD.SHIP_ATTENTION_NAME_7
                    + "','" + newOPLD.SHIP_ADDR_LINE_1_7 + "','" + newOPLD.SHIP_ADDR_LINE_2_7 + "','" + newOPLD.SHIP_ADDR_LINE_3_7 + "','" + newOPLD.SHIP_CITY_NAME_7 + "','" + newOPLD.SHIP_STATE_CODE_7
                    + "','" + newOPLD.SHIP_ZIP_CODE_7 + "','" + newOPLD.SHIP_COUNTRY_CODE_7 + "','" + newOPLD.SHIP_PH_NR_7 + "','" + newOPLD.SHIP_ADDR_TYPE_8 + "','" + newOPLD.SHIP_AC_NR_8
                    + "','" + newOPLD.SHIP_COMP_NA_8 + "','" + newOPLD.SHIP_ATTENTION_NAME_8 + "','" + newOPLD.SHIP_ADDR_LINE_1_8 + "','" + newOPLD.SHIP_ADDR_LINE_2_8 + "','" + newOPLD.SHIP_ADDR_LINE_3_8
                    + "','" + newOPLD.SHIP_CITY_NAME_8 + "','" + newOPLD.SHIP_STATE_CODE_8 + "','" + newOPLD.SHIP_ZIP_CODE_8 + "','" + newOPLD.SHIP_COUNTRY_CODE_8 + "','" + newOPLD.SHIP_PH_NR_8
                    + "','" + newOPLD.SHIP_PKG_QTY + "','" + newOPLD.SHIP_OCA_IND + "','" + newOPLD.SHIP_COMM_RES_IND + "','" + newOPLD.SHIP_SVC_LVL + "','" + newOPLD.SHIP_SVC_LVL_IND + "','" + newOPLD.SHIP_WAYBILL_BRK_NR
                    + "','" + newOPLD.SHIP_WAYBILL_PRINT_IND + "','" + newOPLD.SHIP_ACC_TYPE_1 + "','" + newOPLD.SHIP_ACC_VALUE_1 + "','" + newOPLD.SHIP_ACC_VALUE_N_1 + "','" + newOPLD.SHIP_ACC_CCY_CD_1 + "','" + newOPLD.RA_SHIP_COD_CSH_ONLY_IND_1
                    + "','" + newOPLD.SHIP_ACC_TYPE_2 + "','" + newOPLD.SHIP_ACC_VALUE_2 + "','" + newOPLD.SHIP_ACC_VALUE_N_2 + "','" + newOPLD.SHIP_ACC_CCY_CD_2 + "','" + newOPLD.RA_SHIP_COD_CSH_ONLY_IND_2
                    + "','" + newOPLD.SHIP_ACC_TYPE_3 + "','" + newOPLD.SHIP_ACC_VALUE_3 + "','" + newOPLD.SHIP_ACC_VALUE_N_3 + "','" + newOPLD.SHIP_ACC_CCY_CD_3 + "','" + newOPLD.RA_SHIP_COD_CSH_ONLY_IND_3
                    + "','" + newOPLD.SHIP_ACC_TYPE_4 + "','" + newOPLD.SHIP_ACC_VALUE_4 + "','" + newOPLD.SHIP_ACC_VALUE_N_4 + "','" + newOPLD.SHIP_ACC_CCY_CD_4 + "','" + newOPLD.RA_SHIP_COD_CSH_ONLY_IND_4
                    + "','" + newOPLD.SHIP_ACC_TYPE_5 + "','" + newOPLD.SHIP_ACC_VALUE_5 + "','" + newOPLD.SHIP_ACC_VALUE_N_5 + "','" + newOPLD.SHIP_ACC_CCY_CD_5 + "','" + newOPLD.RA_SHIP_COD_CSH_ONLY_IND_5
                    + "','" + newOPLD.SHIP_ACC_TYPE_6 + "','" + newOPLD.SHIP_ACC_VALUE_6 + "','" + newOPLD.SHIP_ACC_VALUE_N_6 + "','" + newOPLD.SHIP_ACC_CCY_CD_6 + "','" + newOPLD.RA_SHIP_COD_CSH_ONLY_IND_6
                    + "','" + newOPLD.SHIP_ACC_TYPE_7 + "','" + newOPLD.SHIP_ACC_VALUE_7 + "','" + newOPLD.SHIP_ACC_VALUE_N_7 + "','" + newOPLD.SHIP_ACC_CCY_CD_7 + "','" + newOPLD.RA_SHIP_COD_CSH_ONLY_IND_7 + "','" + newOPLD.SHIP_ACC_TYPE_8
                    + "','" + newOPLD.SHIP_ACC_VALUE_8 + "','" + newOPLD.SHIP_ACC_VALUE_N_8 + "','" + newOPLD.SHIP_ACC_CCY_CD_8 + "','" + newOPLD.RA_SHIP_COD_CSH_ONLY_IND_8 + "','" + newOPLD.SHIP_ACC_TYPE_9
                    + "','" + newOPLD.SHIP_ACC_VALUE_9 + "','" + newOPLD.SHIP_ACC_VALUE_N_9 + "','" + newOPLD.SHIP_ACC_CCY_CD_9 + "','" + newOPLD.RA_SHIP_COD_CSH_ONLY_IND_9 + "','" + newOPLD.SHIP_ACC_TYPE_10
                    + "','" + newOPLD.SHIP_ACC_VALUE_10 + "','" + newOPLD.SHIP_ACC_VALUE_N_10 + "','" + newOPLD.SHIP_ACC_CCY_CD_10 + "','" + newOPLD.RA_SHIP_COD_CSH_ONLY_IND_10 + "','" + newOPLD.SHIP_ACC_TYPE_11
                    + "','" + newOPLD.SHIP_ACC_VALUE_11 + "','" + newOPLD.SHIP_ACC_VALUE_N_11 + "','" + newOPLD.SHIP_ACC_CCY_CD_11 + "','" + newOPLD.RA_SHIP_COD_CSH_ONLY_IND_11 + "','" + newOPLD.SHIP_ACC_TYPE_12
                    + "','" + newOPLD.SHIP_ACC_VALUE_12 + "','" + newOPLD.SHIP_ACC_VALUE_N_12 + "','" + newOPLD.SHIP_ACC_CCY_CD_12 + "','" + newOPLD.RA_SHIP_COD_CSH_ONLY_IND_12 + "','" + newOPLD.SHIP_ACC_TYPE_13
                    + "','" + newOPLD.SHIP_ACC_VALUE_13 + "','" + newOPLD.SHIP_ACC_VALUE_N_13 + "','" + newOPLD.SHIP_ACC_CCY_CD_13 + "','" + newOPLD.RA_SHIP_COD_CSH_ONLY_IND_13 + "','" + newOPLD.SHIP_ACC_TYPE_14 + "','" + newOPLD.SHIP_ACC_VALUE_14
                    + "','" + newOPLD.SHIP_ACC_VALUE_N_14 + "','" + newOPLD.SHIP_ACC_CCY_CD_14 + "','" + newOPLD.RA_SHIP_COD_CSH_ONLY_IND_14 + "','" + newOPLD.SHIP_ACC_TYPE_15 + "','" + newOPLD.SHIP_ACC_VALUE_15
                    + "','" + newOPLD.SHIP_ACC_VALUE_N_15 + "','" + newOPLD.SHIP_ACC_CCY_CD_15 + "','" + newOPLD.RA_SHIP_COD_CSH_ONLY_IND_15 + "','" + newOPLD.SHIP_ACC_TYPE_16 + "','" + newOPLD.SHIP_ACC_VALUE_16
                    + "','" + newOPLD.SHIP_ACC_VALUE_N_16 + "','" + newOPLD.SHIP_ACC_CCY_CD_16 + "','" + newOPLD.RA_SHIP_COD_CSH_ONLY_IND_16 + "','" + newOPLD.SHIP_ACC_TYPE_17 + "','" + newOPLD.SHIP_ACC_VALUE_17
                    + "','" + newOPLD.SHIP_ACC_VALUE_N_17 + "','" + newOPLD.SHIP_ACC_CCY_CD_17 + "','" + newOPLD.RA_SHIP_COD_CSH_ONLY_IND_17 + "','" + newOPLD.SHIP_ACC_TYPE_18 + "','" + newOPLD.SHIP_ACC_VALUE_18
                    + "','" + newOPLD.SHIP_ACC_VALUE_N_18 + "','" + newOPLD.SHIP_ACC_CCY_CD_18 + "','" + newOPLD.RA_SHIP_COD_CSH_ONLY_IND_18 + "','" + newOPLD.SHIP_ACC_TYPE_19 + "','" + newOPLD.SHIP_ACC_VALUE_19 + "','" + newOPLD.SHIP_ACC_VALUE_N_19
                    + "','" + newOPLD.SHIP_ACC_CCY_CD_19 + "','" + newOPLD.RA_SHIP_COD_CSH_ONLY_IND_19 + "','" + newOPLD.SHIP_ACC_TYPE_20 + "','" + newOPLD.SHIP_ACC_VALUE_20 + "','" + newOPLD.SHIP_ACC_VALUE_N_20 + "','" + newOPLD.SHIP_ACC_CCY_CD_20
                    + "','" + newOPLD.RA_SHIP_COD_CSH_ONLY_IND_20 + "','" + newOPLD.SHIP_ACC_TYPE_21 + "','" + newOPLD.SHIP_ACC_VALUE_21 + "','" + newOPLD.SHIP_ACC_VALUE_N_21 + "','" + newOPLD.SHIP_ACC_CCY_CD_21
                    + "','" + newOPLD.RA_SHIP_COD_CSH_ONLY_IND_21 + "','" + newOPLD.SHIP_ACC_TYPE_22 + "','" + newOPLD.SHIP_ACC_VALUE_22 + "','" + newOPLD.SHIP_ACC_VALUE_N_22 + "','" + newOPLD.SHIP_ACC_CCY_CD_22
                    + "','" + newOPLD.RA_SHIP_COD_CSH_ONLY_IND_22 + "','" + newOPLD.SHIP_ACC_TYPE_23 + "','" + newOPLD.SHIP_ACC_VALUE_23 + "','" + newOPLD.SHIP_ACC_VALUE_N_23 + "','" + newOPLD.SHIP_ACC_CCY_CD_23
                    + "','" + newOPLD.RA_SHIP_COD_CSH_ONLY_IND_23 + "','" + newOPLD.SHIP_ACC_TYPE_24 + "','" + newOPLD.SHIP_ACC_VALUE_24 + "','" + newOPLD.SHIP_ACC_VALUE_N_24 + "','" + newOPLD.SHIP_ACC_CCY_CD_24
                    + "','" + newOPLD.RA_SHIP_COD_CSH_ONLY_IND_24 + "','" + newOPLD.SHIP_ACC_TYPE_25 + "','" + newOPLD.SHIP_ACC_VALUE_25 + "','" + newOPLD.SHIP_ACC_VALUE_N_25 + "','" + newOPLD.SHIP_ACC_CCY_CD_25
                    + "','" + newOPLD.RA_SHIP_COD_CSH_ONLY_IND_25 + "','" + newOPLD.SHIP_ACC_TYPE_26 + "','" + newOPLD.SHIP_ACC_VALUE_26 + "','" + newOPLD.SHIP_ACC_VALUE_N_26 + "','" + newOPLD.SHIP_ACC_CCY_CD_26
                    + "','" + newOPLD.RA_SHIP_COD_CSH_ONLY_IND_26 + "','" + newOPLD.SHIP_ACC_TYPE_27 + "','" + newOPLD.SHIP_ACC_VALUE_27 + "','" + newOPLD.SHIP_ACC_VALUE_N_27 + "','" + newOPLD.SHIP_ACC_CCY_CD_27 + "','" + newOPLD.RA_SHIP_COD_CSH_ONLY_IND_27
                    + "','" + newOPLD.SHIP_ACC_TYPE_28 + "','" + newOPLD.SHIP_ACC_VALUE_28 + "','" + newOPLD.SHIP_ACC_VALUE_N_28 + "','" + newOPLD.SHIP_ACC_CCY_CD_28 + "','" + newOPLD.RA_SHIP_COD_CSH_ONLY_IND_28
                    + "','" + newOPLD.SHIP_ACC_TYPE_29 + "','" + newOPLD.SHIP_ACC_VALUE_29 + "','" + newOPLD.SHIP_ACC_VALUE_N_29 + "','" + newOPLD.SHIP_ACC_CCY_CD_29 + "','" + newOPLD.RA_SHIP_COD_CSH_ONLY_IND_29
                    + "','" + newOPLD.SHIP_ACC_TYPE_30 + "','" + newOPLD.SHIP_ACC_VALUE_30 + "','" + newOPLD.SHIP_ACC_VALUE_N_30 + "','" + newOPLD.SHIP_ACC_CCY_CD_30 + "','" + newOPLD.RA_SHIP_COD_CSH_ONLY_IND_30
                    + "','" + newOPLD.SHIP_ACC_TYPE_31 + "','" + newOPLD.SHIP_ACC_VALUE_31 + "','" + newOPLD.SHIP_ACC_VALUE_N_31 + "','" + newOPLD.SHIP_ACC_CCY_CD_31 + "','" + newOPLD.RA_SHIP_COD_CSH_ONLY_IND_31
                    + "','" + newOPLD.SHIP_ACC_TYPE_32 + "','" + newOPLD.SHIP_ACC_VALUE_32 + "','" + newOPLD.SHIP_ACC_VALUE_N_32 + "','" + newOPLD.SHIP_ACC_CCY_CD_32 + "','" + newOPLD.RA_SHIP_COD_CSH_ONLY_IND_32
                    + "','" + newOPLD.SHIP_ACC_TYPE_33 + "','" + newOPLD.SHIP_ACC_VALUE_33 + "','" + newOPLD.SHIP_ACC_VALUE_N_33 + "','" + newOPLD.SHIP_ACC_CCY_CD_33 + "','" + newOPLD.RA_SHIP_COD_CSH_ONLY_IND_33
                    + "','" + newOPLD.SHIP_ACC_TYPE_34 + "','" + newOPLD.SHIP_ACC_VALUE_34 + "','" + newOPLD.SHIP_ACC_VALUE_N_34 + "','" + newOPLD.SHIP_ACC_CCY_CD_34 + "','" + newOPLD.RA_SHIP_COD_CSH_ONLY_IND_34 + "','" + newOPLD.SHIP_ACC_TYPE_35
                    + "','" + newOPLD.SHIP_ACC_VALUE_35 + "','" + newOPLD.SHIP_ACC_VALUE_N_35 + "','" + newOPLD.SHIP_ACC_CCY_CD_35 + "','" + newOPLD.RA_SHIP_COD_CSH_ONLY_IND_35 + "','" + newOPLD.SHIP_UOM_WGT
                    + "','" + newOPLD.SHIP_DIM_WEIGHT + "','" + newOPLD.SHIP_DIM_WEIGHT_NUM + "','" + newOPLD.SHIP_ACTUAL_WEIGHT + "','" + newOPLD.SHIP_ACTUAL_WEIGHT_NUM + "','" + newOPLD.SHIP_BILLED_WEIGHT
                    + "','" + newOPLD.SHIP_BILLED_WEIGHT_NUM + "','" + newOPLD.SHIP_SENDER_NAME + "','" + newOPLD.SHIP_CRED_CARD_NR + "','" + newOPLD.SHIP_CRED_CARD_EXP_DT + "','" + newOPLD.SHIP_INTERNET_USER_ID
                    + "','" + newOPLD.SHIP_CRED_CARD_AUTH_NR + "','" + newOPLD.SHIP_SHIPPER + "','" + newOPLD.SHIP_CONSIGNEE + "','" + newOPLD.SHIP_CNSG_SHIP_NR + "','" + newOPLD.SHIP_3PB
                    + "','" + newOPLD.SHIP_3PB_SHIP_NR + "','" + newOPLD.SHIP_FREIGHT + "','" + newOPLD.SHIP_FREIGHT_SHIP_NR + "','" + newOPLD.SHIP_RLA_NR + "','" + newOPLD.SHIP_RLA_SHIP_NR
                    + "','" + newOPLD.SHIP_OVS_NR + "','" + newOPLD.SHIP_IVS_NR + "','" + newOPLD.SHIP_IVS_SHIP_NR + "','" + newOPLD.SHIP_HARM_CDE + "','" + newOPLD.SHIP_MANF_CTRY_ORIG_CD + "','" + newOPLD.SHIP_CUSTM_VAL_S
                    + "','" + newOPLD.SHIP_CUSTM_VAL_N + "','" + newOPLD.SHIP_GCCN_IND + "','" + newOPLD.SHIP_INV_TOTAL_AMT_N + "','" + newOPLD.SHIP_EXP_AC_NR + "','" + newOPLD.SHIP_EXP_COMP_NA + "','" + newOPLD.SHIP_EXP_ATTN_NAME
                    + "','" + newOPLD.SHIP_EXP_ADDR_LINE_1 + "','" + newOPLD.SHIP_EXP_ADDR_LINE_2 + "','" + newOPLD.SHIP_EXP_ADDR_LINE_3 + "','" + newOPLD.SHIP_EXP_CITY + "','" + newOPLD.SHIP_EXP_STATE_CD
                    + "','" + newOPLD.SHIP_EXP_POSTAL_CD + "','" + newOPLD.SHIP_EXP_CNTRY_CD + "','" + newOPLD.SHIP_IMP_CITY + "','" + newOPLD.SHIP_IMP_STATE_CD + "','" + newOPLD.SHIP_IMP_POSTAL_CD + "','" + newOPLD.SHIP_IMP_CNTRY_CD
                    + "','" + newOPLD.SHIP_CLRNCE_PORT + "','" + newOPLD.SHIP_SP_NR + "','" + newOPLD.SHIP_NR_PKG + "','" + newOPLD.SHIP_SVC_TYP_CD + "','" + newOPLD.SHIP_CSGN_ADDR_VAL_RES + "','" + newOPLD.SHIP_CRNCY_CDE
                    + "','" + newOPLD.SHIP_CSGN_VCE_PHN_NRS + "','" + newOPLD.SHIP_CSGN_FAX_PHN_NRS + "','" + newOPLD.SHIP_DOMEST_INTL_FLAG + "','" + newOPLD.SHIP_SOURCE_FLAG + "','" + newOPLD.SHIP_IMP_ACC_NR
                    + "','" + newOPLD.SHIP_IMP_FLG + "','" + newOPLD.SHIP_INV_CURR_CDE + "','" + newOPLD.SHIP_ACY_INS_CC + "','" + newOPLD.SHIP_ACY_INS_YY + "','" + newOPLD.SHIP_ACY_INS_MM
                    + "','" + newOPLD.SHIP_ACY_INS_DD + "','" + newOPLD.SHIP_ACY_INS_HH + "','" + newOPLD.SHIP_ACY_INS_MIN + "','" + newOPLD.SHIP_QVIO_DATA_AREA + "','" + newOPLD.SHIP_SHR_OPT_IND
                    + "','" + newOPLD.SHIP_USI + "','" + newOPLD.SHIP_TDPROD_TYP_CDE + "','" + newOPLD.AMS_TOKEN + "','" + newOPLD.FILLER + "','" + newOPLD.SHIP_REQ_ADDR_CLASS + "','" + newOPLD.SHIP_REQ_ADDR_ID
                    + "','" + newOPLD.SHIP_IA_GCCNNumber + "','" + newOPLD.SHIP_CA01_PKUP_PHN_NR + "','" + newOPLD.CRA_PDP_Delivery_Token + "','" + newOPLD.CRA_PDP_Delivery_NGDW_Start + "','" + newOPLD.CRA_PDP_Delivery_NGDW_End
                    + "','" + newOPLD.CRA_PDP_Delivery_NGDW_Confidence + "','" + newOPLD.CRA_PDP_Delivery_Date_Required + "','" + newOPLD.CRA_PDP_PickUp_Token + "','" + newOPLD.CRA_PDP_PickUp_NGDW_Start
                    + "','" + newOPLD.CRA_PDP_PickUp_NGDW_End + "','" + newOPLD.CRA_PDP_PickUp_NGDW_Confidence + "','" + newOPLD.CRA_PDP_PickUp_Date_Required + "','" + newOPLD.PDP_Replay + "','" + newOPLD.PDP_Flags
                    + "','" + newOPLD.SHIP_PSI_NR_PCS + "','" + newOPLD.SHIP_DSPLY_NAME + "','" + DateTime.Now.ToString() + "','" + newOPLD.ProcessingStatus + "')", conn);

                rowsAffected = cmd.ExecuteNonQuery();
            }

            return rowsAffected > 0 ? Tuple.Create<bool, int>(true, lastOPLD) : Tuple.Create<bool, int>(false, (GetLastOPLDID() + 1));
        }

        public bool AddNewOPLDPackages(List<Package> packageList)
        {
            int rowsAffected = 0;
            try
            {
                foreach (var package in packageList)
                {
                    using (MySqlConnection conn = GetConnection())
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand("INSERT INTO opldpackages VALUES('" + (GetLastOPLDPackageID(package.OPLDId) + 1) + "','" + package.OPLDId
                        + "','" + package.PKG_REC_FLAG + "','" + package.PKG_SEQ_NR + "','" + package.PKG_DTL_LENGTH_RED + "','" + package.PKG_DTL_WIDTH_RED + "','" + package.PKG_DTL_HEIGHT
                        + "','" + package.PKG_DTL_HEIGHT_RED + "','" + package.PKG_TRACKING_NUM + "','" + package.PKG_DIM_WEIGHT_NUM + "','" + package.PKG_ACTUAL_WEIGHT + "','" + package.PKG_ACTUAL_WEIGHT_NUM
                        + "','" + package.PKG_OVSZ_IND + "','" + package.PKG_VOID_IND + "','" + package.PKG_REF_TYP_CD_1 + "','" + package.PKG_REF_NUMBER_1 + "','" + package.PKG_REF_TYP_CD_2 + "','" + package.PKG_REF_NUMBER_2
                        + "','" + package.PKG_REF_TYP_CD_3 + "','" + package.PKG_REF_NUMBER_3 + "','" + package.PKG_REF_TYP_CD_4 + "','" + package.PKG_REF_NUMBER_4 + "','" + package.PKG_REF_TYP_CD_5
                        + "','" + package.PKG_REF_NUMBER_5 + "','" + package.PKG_ACC_TYPE_1 + "','" + package.PKG_ACC_VALUE_1 + "','" + package.PKG_ACC_VALUE_N_1 + "','" + package.CRA_PKG_ACC_CCY_CD_1
                        + "','" + package.PKG_ACC_TYPE_2 + "','" + package.PKG_ACC_VALUE_2 + "','" + package.PKG_ACC_VALUE_N_2 + "','" + package.CRA_PKG_ACC_CCY_CD_2 + "','" + package.PKG_ACC_TYPE_3
                        + "','" + package.PKG_ACC_VALUE_3 + "','" + package.PKG_ACC_VALUE_N_3 + "','" + package.CRA_PKG_ACC_CCY_CD_3 + "','" + package.PKG_ACC_TYPE_4 + "','" + package.PKG_ACC_VALUE_4
                        + "','" + package.PKG_ACC_VALUE_N_4 + "','" + package.CRA_PKG_ACC_CCY_CD_4 + "','" + package.PKG_ACC_TYPE_5 + "','" + package.PKG_ACC_VALUE_5 + "','" + package.PKG_ACC_VALUE_N_5
                        + "','" + package.CRA_PKG_ACC_CCY_CD_5 + "','" + package.PKG_ACC_TYPE_6 + "','" + package.PKG_ACC_VALUE_6 + "','" + package.PKG_ACC_VALUE_N_6 + "','" + package.CRA_PKG_ACC_CCY_CD_6
                        + "','" + package.PKG_ACC_TYPE_7 + "','" + package.PKG_ACC_VALUE_7 + "','" + package.PKG_ACC_VALUE_N_7 + "','" + package.CRA_PKG_ACC_CCY_CD_7 + "','" + package.PKG_ACC_TYPE_8
                        + "','" + package.PKG_ACC_VALUE_8 + "','" + package.PKG_ACC_VALUE_N_8 + "','" + package.CRA_PKG_ACC_CCY_CD_8 + "','" + package.PKG_ACC_TYPE_9 + "','" + package.PKG_ACC_VALUE_9
                        + "','" + package.PKG_ACC_VALUE_N_9 + "','" + package.CRA_PKG_ACC_CCY_CD_9 + "','" + package.PKG_ACC_TYPE_10 + "','" + package.PKG_ACC_VALUE_10 + "','" + package.PKG_ACC_VALUE_N_10
                        + "','" + package.CRA_PKG_ACC_CCY_CD_10 + "','" + package.PKG_ACC_TYPE_11 + "','" + package.PKG_ACC_VALUE_11 + "','" + package.PKG_ACC_VALUE_N_11 + "','" + package.CRA_PKG_ACC_CCY_CD_11
                        + "','" + package.PKG_ACC_TYPE_12 + "','" + package.PKG_ACC_VALUE_12 + "','" + package.PKG_ACC_VALUE_N_12 + "','" + package.CRA_PKG_ACC_CCY_CD_12 + "','" + package.PKG_ACC_TYPE_13
                        + "','" + package.PKG_ACC_VALUE_13 + "','" + package.PKG_ACC_VALUE_N_13 + "','" + package.CRA_PKG_ACC_CCY_CD_13 + "','" + package.PKG_ACC_TYPE_14 + "','" + package.PKG_ACC_VALUE_14
                        + "','" + package.PKG_ACC_VALUE_N_14 + "','" + package.RA_PKG_ACC_CCY_CD_14 + "','" + package.PKG_ACC_TYPE_15 + "','" + package.PKG_ACC_VALUE_15 + "','" + package.PKG_ACC_VALUE_N_15
                        + "','" + package.CRA_PKG_ACC_CCY_CD_15 + "','" + package.PKG_BILLED_WEIGHT + "','" + package.PKG_BILLED_WEIGHT_NUM + "','" + package.PKG_MERCH_DESC + "','" + package.PKG_COD_CNTL_NR
                        + "','" + package.PKG_COD_CSH_ONLY_IND + "','" + package.PKG_CALL_ARS_IND + "','" + package.PKG_CALL_ARS_SCH_PKDT + "','" + package.PKG_CSGN_PHN_NR + "','" + package.PKG_SPCL_INSTR
                        + "','" + package.PKG_EARLY_DEL_TM + "','" + package.PKG_PKG_ALT_REF_TYP_CD + "','" + package.PKG_DLV_TO_ATTN_NAM + "','" + package.PKG_SDD_CC + "','" + package.PKG_SDD_YY
                        + "','" + package.PKG_SDD_MM + "','" + package.PKG_SDD_DD + "','" + package.PKG_SDD_HH + "','" + package.PKG_SDD_MN + "','" + package.PKG_TRAN_TK_NO + "','" + package.PKG_GDW_ELIGIBILITY
                        + "','" + package.PKG_Flags + "','" + package.PKG_CLINIC_TRIALS_FLAG + "','" + package.PKG_CLINIC_TRIALS_ID + "','" + DateTime.Now.ToString() + "')", conn);

                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return rowsAffected > 0 ? true : false;
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

        public bool CheckIsTrackingNumberAlreadyExists(string trackingNumber)
        {
            bool result = false;
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM oplddetails WHERE TrackingNumber='" + trackingNumber + "'", conn);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.IsDBNull(0))
                            {
                                return false;
                            }
                            else
                            {
                                string trackNumber = reader.GetString("TrackingNumber");
                                result = string.IsNullOrEmpty(trackNumber) ? false : true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return result;
        }
    }
}