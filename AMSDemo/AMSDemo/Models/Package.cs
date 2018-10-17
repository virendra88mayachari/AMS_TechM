﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMSDemo.Models
{
    public class Package
    {
        public int PackageId { get; set; }
        public int OPLDId { get; set; }
        //public string PackageLength { get; set; }
        //public string PackageWidth { get; set; }
        //public string PackageHeight { get; set; }                      
        //public string PackageTrackingNumber { get; set; }
        //public string PackageDimensionalWeight { get; set; }
        //public string PackageActualWeight { get; set; }
        //public string PackageReferenceType1 { get; set; }
        //public string PackageReferenceNumber1 { get; set; }
        //public string PackageReferenceType2 { get; set; }
        //public string PackageReferenceNumber2 { get; set; }
        //public string PackageReferenceType3 { get; set; }
        //public string PackageReferenceNumber3 { get; set; }
        //public string PackageReferenceType4 { get; set; }
        //public string PackageReferenceNumber4 { get; set; }
        //public string PackageReferenceType5 { get; set; }
        //public string PackageReferenceNumber5 { get; set; }
        //public string PackageAccessorialType1 { get; set; }
        //public string PackageAccessorialValue1 { get; set; }
        //public string PackageAccessorialType2 { get; set; }
        //public string PackageAccessorialValue2 { get; set; }
        //public string PackageAccessorialType3 { get; set; }
        //public string PackageAccessorialValue3 { get; set; }
        //public string PackageAccessorialType4 { get; set; }
        //public string PackageAccessorialValue4 { get; set; }
        //public string PackageAccessorialType5 { get; set; }
        //public string PackageAccessorialValue5 { get; set; }
        //public string PackageAccessorialType6 { get; set; }
        //public string PackageAccessorialValue6 { get; set; }
        //public string PackageAccessorialType7{ get; set; }
        //public string PackageAccessorialValue7 { get; set; }
        //public string PackageAccessorialType8 { get; set; }
        //public string PackageAccessorialValue8 { get; set; }
        //public string PackageAccessorialType9 { get; set; }
        //public string PackageAccessorialValue9 { get; set; }
        //public string PackageAccessorialType10 { get; set; }
        //public string PackageAccessorialValue10 { get; set; }
        //public string PackageAccessorialType11 { get; set; }
        //public string PackageAccessorialValue11 { get; set; }
        //public string PackageAccessorialType12 { get; set; }
        //public string PackageAccessorialValue12 { get; set; }
        //public string PackageAccessorialType13 { get; set; }
        //public string PackageAccessorialValue13 { get; set; }
        //public string PackageAccessorialType14 { get; set; }
        //public string PackageAccessorialValue14 { get; set; }
        //public string PackageAccessorialType15 { get; set; }
        //public string PackageAccessorialValue15 { get; set; }
        //public string PackageBilledWeight { get; set; }
        //public string PackageMerchDesc { get; set; }
        //public string PackageCODCNTLNR { get; set; }
        //public string PackageCODCSHONLYIND { get; set; }
        //public string PackageCALLARSIND { get; set; }
        //public string PackageCALLARSSCHPKDT { get; set; }
        //public string PackageCSGNPHNNR { get; set; }
        //public string PackageSPCLINSTR { get; set; }
        //public string PackageEARLYDELTM { get; set; }
        //public string PackageALTREFTYPCD { get; set; }
        //public string PackageDLVTOATTNNAM { get; set; }
        //public string PackageSchDelievryDate { get; set; }
        //public string PackageSchDelievryTime { get; set; }
        //public string PackageTRANTKNO{ get; set; }
        //public string PackageGDWELIGIBILITY { get; set; }

        public string PKG_REC_FLAG { get; set; }
        public string PKG_SEQ_NR { get; set; }
        public string PKG_DTL_LENGTH_RED { get; set; }
        public string PKG_DTL_WIDTH_RED { get; set; }
        public string PKG_DTL_HEIGHT { get; set; }
        public string PKG_DTL_HEIGHT_RED { get; set; }
        public string PKG_TRACKING_NUM { get; set; }
        public string PKG_DIM_WEIGHT_NUM { get; set; }
        public string PKG_ACTUAL_WEIGHT { get; set; }
        public string PKG_ACTUAL_WEIGHT_NUM { get; set; }
        public string PKG_OVSZ_IND { get; set; }
        public string PKG_VOID_IND { get; set; }
        public string PKG_REF_TYP_CD_1 { get; set; }
        public string PKG_REF_NUMBER_1 { get; set; }
        public string PKG_REF_TYP_CD_2 { get; set; }
        public string PKG_REF_NUMBER_2 { get; set; }
        public string PKG_REF_TYP_CD_3 { get; set; }
        public string PKG_REF_NUMBER_3 { get; set; }
        public string PKG_REF_TYP_CD_4 { get; set; }
        public string PKG_REF_NUMBER_4 { get; set; }
        public string PKG_REF_TYP_CD_5 { get; set; }
        public string PKG_REF_NUMBER_5 { get; set; }
        public string PKG_ACC_TYPE_1 { get; set; }
        public string PKG_ACC_VALUE_1 { get; set; }
        public string PKG_ACC_VALUE_N_1 { get; set; }
        public string CRA_PKG_ACC_CCY_CD_1 { get; set; }
        public string PKG_ACC_TYPE_2 { get; set; }
        public string PKG_ACC_VALUE_2 { get; set; }
        public string PKG_ACC_VALUE_N_2 { get; set; }
        public string CRA_PKG_ACC_CCY_CD_2 { get; set; }
        public string PKG_ACC_TYPE_3 { get; set; }
        public string PKG_ACC_VALUE_3 { get; set; }
        public string PKG_ACC_VALUE_N_3 { get; set; }
        public string CRA_PKG_ACC_CCY_CD_3 { get; set; }
        public string PKG_ACC_TYPE_4 { get; set; }
        public string PKG_ACC_VALUE_4 { get; set; }
        public string PKG_ACC_VALUE_N_4 { get; set; }
        public string CRA_PKG_ACC_CCY_CD_4 { get; set; }
        public string PKG_ACC_TYPE_5 { get; set; }
        public string PKG_ACC_VALUE_5 { get; set; }
        public string PKG_ACC_VALUE_N_5 { get; set; }
        public string CRA_PKG_ACC_CCY_CD_5 { get; set; }
        public string PKG_ACC_TYPE_6 { get; set; }
        public string PKG_ACC_VALUE_6 { get; set; }
        public string PKG_ACC_VALUE_N_6 { get; set; }
        public string CRA_PKG_ACC_CCY_CD_6 { get; set; }
        public string PKG_ACC_TYPE_7 { get; set; }
        public string PKG_ACC_VALUE_7 { get; set; }
        public string PKG_ACC_VALUE_N_7 { get; set; }
        public string CRA_PKG_ACC_CCY_CD_7 { get; set; }
        public string PKG_ACC_TYPE_8 { get; set; }
        public string PKG_ACC_VALUE_8 { get; set; }
        public string PKG_ACC_VALUE_N_8 { get; set; }
        public string CRA_PKG_ACC_CCY_CD_8 { get; set; }
        public string PKG_ACC_TYPE_9 { get; set; }
        public string PKG_ACC_VALUE_9 { get; set; }
        public string PKG_ACC_VALUE_N_9 { get; set; }
        public string CRA_PKG_ACC_CCY_CD_9 { get; set; }
        public string PKG_ACC_TYPE_10 { get; set; }
        public string PKG_ACC_VALUE_10 { get; set; }
        public string PKG_ACC_VALUE_N_10 { get; set; }
        public string CRA_PKG_ACC_CCY_CD_10 { get; set; }
        public string PKG_ACC_TYPE_11 { get; set; }
        public string PKG_ACC_VALUE_11 { get; set; }
        public string PKG_ACC_VALUE_N_11 { get; set; }
        public string CRA_PKG_ACC_CCY_CD_11 { get; set; }
        public string PKG_ACC_TYPE_12 { get; set; }
        public string PKG_ACC_VALUE_12 { get; set; }
        public string PKG_ACC_VALUE_N_12 { get; set; }
        public string CRA_PKG_ACC_CCY_CD_12 { get; set; }
        public string PKG_ACC_TYPE_13 { get; set; }
        public string PKG_ACC_VALUE_13 { get; set; }
        public string PKG_ACC_VALUE_N_13 { get; set; }
        public string CRA_PKG_ACC_CCY_CD_13 { get; set; }
        public string PKG_ACC_TYPE_14 { get; set; }
        public string PKG_ACC_VALUE_14 { get; set; }
        public string PKG_ACC_VALUE_N_14 { get; set; }
        public string RA_PKG_ACC_CCY_CD_14 { get; set; }
        public string PKG_ACC_TYPE_15 { get; set; }
        public string PKG_ACC_VALUE_15 { get; set; }
        public string PKG_ACC_VALUE_N_15 { get; set; }
        public string CRA_PKG_ACC_CCY_CD_15 { get; set; }
        public string PKG_BILLED_WEIGHT { get; set; }
        public string PKG_BILLED_WEIGHT_NUM { get; set; }
        public string PKG_MERCH_DESC { get; set; }
        public string PKG_COD_CNTL_NR { get; set; }
        public string PKG_COD_CSH_ONLY_IND { get; set; }
        public string PKG_CALL_ARS_IND { get; set; }
        public string PKG_CALL_ARS_SCH_PKDT { get; set; }
        public string PKG_CSGN_PHN_NR { get; set; }
        public string PKG_SPCL_INSTR { get; set; }
        public string PKG_EARLY_DEL_TM { get; set; }
        public string PKG_PKG_ALT_REF_TYP_CD { get; set; }
        public string PKG_DLV_TO_ATTN_NAM { get; set; }
        public string PKG_SDD_CC { get; set; }
        public string PKG_SDD_YY { get; set; }
        public string PKG_SDD_MM { get; set; }
        public string PKG_SDD_DD { get; set; }
        public string PKG_SDD_HH { get; set; }
        public string PKG_SDD_MN { get; set; }
        public string PKG_TRAN_TK_NO { get; set; }
        public string PKG_GDW_ELIGIBILITY { get; set; }
        public string PKG_Flags { get; set; }
        public string PKG_CLINIC_TRIALS_FLAG { get; set; }
        public string PKG_CLINIC_TRIALS_ID { get; set; }
    }
}