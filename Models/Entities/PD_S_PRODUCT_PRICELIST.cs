using System;
using System.Collections.Generic;

namespace Fox.Microservices.Products.Models.Entities
{
    public partial class PD_S_PRODUCT_PRICELIST
    {
        public string COMPANY_CODE { get; set; }
        public string DIVISION_CODE { get; set; }
        public string PRODUCT_CODE { get; set; }
        public string PRICELIST_CODE { get; set; }
        public DateTime DT_VALID { get; set; }
        public double? UNIT_NET_PRICE { get; set; }
        public string CURRENCY_CODE { get; set; }
        public double? CURRENCY_RATE { get; set; }
        public DateTime? DT_INSERT { get; set; }
        public string USERINSERT { get; set; }
        public DateTime? DT_UPDATE { get; set; }
        public string USERUPDATE { get; set; }
        public Guid ROWGUID { get; set; }

        public virtual PD_S_PRODUCT PD_S_PRODUCT { get; set; }
    }
}
