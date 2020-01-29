using Fox.Microservices.Products.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPITools.Models;

namespace Fox.Microservices.Products.Models
{
    public class PriceListInfo: ModelBase
    {
        public string PriceListCode { get; set; }
        public double? UnitNetPrice { get; set; }
        public string CurrencyCode { get; set; }

        public PriceListInfo()
        {

        }

        public PriceListInfo(PD_S_PRODUCT_PRICELIST Entity) : base(Entity.ROWGUID)
        {
            UnitNetPrice = Entity.UNIT_NET_PRICE;
            PriceListCode = Entity.PRICELIST_CODE;
            CurrencyCode = Entity.CURRENCY_CODE ?? "AUD";
        }
    }
}
