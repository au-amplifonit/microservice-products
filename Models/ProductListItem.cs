using Fox.Microservices.Products.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fox.Microservices.Products.Models
{
    public class ProductListItem: ProductBase
    {
        public string BandDescription { get; set; }
        public string ClassDescription { get; set; }
        public string SubClassDescription { get; set; }
        public string GroupDescription { get; set; }
        public string WarrantyType { get; set; }
        public string CommercialDescription { get; set; }
        public string SupplierDescription { get; set; }

        public PriceListInfo[] PriceListInfos { get; set; }

        public ProductListItem(PD_S_PRODUCT Entity): base(Entity)
        {
            //Not working
            //GroupDescription = Entity.PD_S_GROUP?.GROUP_DESCR;

        }

        internal ProductListItem(ProductDBInfo productDBInfo):this(productDBInfo.Product)
        {
            BandDescription = productDBInfo.ProductBand?.BAND_DESCR;
            ClassDescription = productDBInfo.ProductClass?.CLASS_DESCR;
            SubClassDescription = productDBInfo.ProductSubClass?.SUBCLASS_DESCR;
            WarrantyType = productDBInfo.ProductWarranty?.WARRANTY_TYPE;
            GroupDescription = productDBInfo.ProductGroup?.GROUP_DESCR;
            CommercialDescription = productDBInfo.ProductExt?.PRODUCT_COMMER;
            SupplierDescription = productDBInfo.ProductSupplier?.SUPPLIER_DESCR;
            PriceListInfos = CreatePriceListInfoList(productDBInfo.ProductPriceList);
        }

        PriceListInfo[] CreatePriceListInfoList(IEnumerable<PD_S_PRODUCT_PRICELIST> PriceLists)
        {
            Dictionary<string, PriceListInfo> Result = new Dictionary<string, PriceListInfo>();
            foreach (PD_S_PRODUCT_PRICELIST priceList in PriceLists.OrderByDescending(E => E.DT_VALID))
                if (!Result.ContainsKey(priceList.PRICELIST_CODE))
                    Result.Add(priceList.PRICELIST_CODE, new PriceListInfo(priceList));
            return Result.Values.ToArray();
        }

        public void LoadExtData(ProductsContext AContext, PD_S_PRODUCT Entity)
        {
            BandDescription = Entity.PD_S_BAND?.BAND_DESCR;
            SubClassDescription = Entity.PD_S_SUBCLASS?.SUBCLASS_DESCR;
            SupplierDescription = Entity.PD_S_SUPPLIER?.SUPPLIER_DESCR;

            ClassDescription = AContext.PD_S_CLASS.FirstOrDefault(E => E.CLASS_CODE == Entity.CLASS_CODE)?.CLASS_DESCR;
            GroupDescription = AContext.PD_S_GROUP.FirstOrDefault(E => E.GROUP_CODE == Entity.GROUP_CODE)?.GROUP_DESCR;
            WarrantyType = AContext.PD_S_PRODUCT_WARRANTIES_EXT_AUS.FirstOrDefault(E => E.PRODUCT_CODE == Entity.PRODUCT_CODE)?.WARRANTY_TYPE;
            CommercialDescription = AContext.PD_S_PRODUCT_EXT_AUS.FirstOrDefault(E => E.PRODUCT_CODE == Entity.PRODUCT_CODE)?.PRODUCT_COMMER;

            PriceListInfos = CreatePriceListInfoList(Entity.PD_S_PRODUCT_PRICELIST.Where(E => E.DT_VALID <= DateTime.Today));
        }
    }
}
