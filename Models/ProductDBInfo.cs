using Fox.Microservices.Products.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fox.Microservices.Products.Models
{
    internal class ProductDBInfo
    {
        public PD_S_PRODUCT Product { get; set; }
        public PD_S_PRODUCT_EXT_AUS ProductExt { get; set; }
        public PD_S_PRODUCT_WARRANTIES_EXT_AUS ProductWarranty { get; set; }
        public PD_S_CLASS ProductClass { get; set; }
        public PD_S_SUBCLASS ProductSubClass { get; set; }
        public PD_S_GROUP ProductGroup { get; set; }
        public PD_S_BAND ProductBand { get; set; }
        public PD_S_SUPPLIER ProductSupplier { get; set; }
        public IEnumerable<PD_S_PRODUCT_PRICELIST> ProductPriceList { get; set; }
    }

}
