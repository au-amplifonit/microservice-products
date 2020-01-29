using System;
using System.Collections.Generic;

namespace Fox.Microservices.Products.Models.Entities
{
    public partial class PD_S_PRODUCT_EXT_AUS
    {
        public string COMPANY_CODE { get; set; }
        public string DIVISION_CODE { get; set; }
        public string PRODUCT_CODE { get; set; }
        public DateTime? DT_INSERT { get; set; }
        public string USERINSERT { get; set; }
        public DateTime? DT_UPDATE { get; set; }
        public string USERUPDATE { get; set; }
        public Guid ROWGUID { get; set; }
        public string SALE_TYPE { get; set; }
        public string ZERO_TOPUP { get; set; }
        public string WC_ALLSTATE { get; set; }
        public string WC_VIC { get; set; }
        public string WC_NSW { get; set; }
        public string WC_QLD { get; set; }
        public string WC_SA { get; set; }
        public string WC_WA { get; set; }
        public string WC_ACT { get; set; }
        public string WC_TAS { get; set; }
        public string WC_NT { get; set; }
        public string WC_ALLOWED_FOR_NSW_POST_MAY { get; set; }
        public string WC_ALLOWED_FOR_VIC_WORKSAFE { get; set; }
        public string WC_VIC_WS_CODE { get; set; }
        public string WC_INCLUDED_NSW_WC_LIST { get; set; }
        public string WC_INCLUDED_VIC_WC_LIST { get; set; }
        public DateTime? DT_OHS_APPROVED_FROM { get; set; }
        public DateTime? DT_OHS_APPROVED_TO { get; set; }
        public DateTime? DT_NHC_APPROVED_FROM { get; set; }
        public DateTime? DT_NHC_APPROVED_TO { get; set; }
        public string TECHNOLOGY { get; set; }
        public string WC_NSW_WS_CODE { get; set; }
        public string DVA { get; set; }
        public string DVA_CODE { get; set; }
        public string RAP_CODE { get; set; }
        public string DVA_PRE_W_APPROVAL { get; set; }
        public string DVA_PRE_G_APPROVAL { get; set; }
        public string NDIS_SUPPORT_NO { get; set; }
        public string PRODUCT_COMMER { get; set; }
        public string FLG_CUSTOM_DEVICE { get; set; }
    }
}
