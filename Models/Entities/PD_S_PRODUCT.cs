using System;
using System.Collections.Generic;

namespace Fox.Microservices.Products.Models.Entities
{
    public partial class PD_S_PRODUCT
    {
        public PD_S_PRODUCT()
        {
            PD_S_PRODUCT_PRICELIST = new HashSet<PD_S_PRODUCT_PRICELIST>();
        }

        public string COMPANY_CODE { get; set; }
        public string DIVISION_CODE { get; set; }
        public string PRODUCT_CODE { get; set; }
        public string PRODUCT_STATUS { get; set; }
        public string PRODUCT_DESCR { get; set; }
        public string FLG_ACTIVE { get; set; }
        public string FLG_ORDERABLE { get; set; }
        public string FLG_CUSTOM { get; set; }
        public string FLG_SERIAL { get; set; }
        public string FLG_FRANCHISEE { get; set; }
        public string FLG_DUMMY { get; set; }
        public string FLG_QUICKSALE { get; set; }
        public string FLG_STOCKTAKE { get; set; }
        public string BRAND_CODE { get; set; }
        public int? MIN_QUANTITY { get; set; }
        public int? REORDER_MIN_QUANTITY { get; set; }
        public int? REORDER_MAX_QUANTITY { get; set; }
        public short? REORDER_MULTIPLE { get; set; }
        public string CLASS_CODE { get; set; }
        public string SUBCLASS_CODE { get; set; }
        public string BAND_CODE { get; set; }
        public string FAMILY_CODE { get; set; }
        public string GROUP_CODE { get; set; }
        public string TARIFF_POSITION_CODE { get; set; }
        public string FLG_QUALITYCHECK { get; set; }
        public string FLG_TRIAL { get; set; }
        public string FLG_SIDE { get; set; }
        public string BATTERY_SIZE_CODE { get; set; }
        public string REPLENISHMENT_TYPE_CODE { get; set; }
        public string VAT_CODE { get; set; }
        public DateTime? DT_INSERT { get; set; }
        public string USERINSERT { get; set; }
        public DateTime? DT_UPDATE { get; set; }
        public string USERUPDATE { get; set; }
        public Guid ROWGUID { get; set; }
        public string SUPPLIER_CODE { get; set; }

        public virtual PD_S_BAND PD_S_BAND { get; set; }
        public virtual PD_S_GROUP PD_S_GROUP { get; set; }
        public virtual PD_S_SUBCLASS PD_S_SUBCLASS { get; set; }
        public virtual PD_S_SUPPLIER PD_S_SUPPLIER { get; set; }
        public virtual PD_S_SUPPLIER PD_S_SUPPLIERNavigation { get; set; }
        public virtual ICollection<PD_S_PRODUCT_PRICELIST> PD_S_PRODUCT_PRICELIST { get; set; }
    }
}
