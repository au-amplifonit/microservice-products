using Fox.Microservices.Products.Models.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPITools.Models;

namespace Fox.Microservices.Products.Models
{
    public class ProductBase: ModelBase
    {
        [JsonProperty(Order = -10)]
        public string Code { get; set; }
        [JsonProperty(Order = -10)]
        string Description { get; set; }
        [JsonProperty(Order = -10)]
        bool IsActive { get; set; }
        [JsonProperty(Order = -10)]
        string BandCode { get; set; }
        [JsonProperty(Order = -10)]
        string ClassCode { get; set; }
        [JsonProperty(Order = -10)]
        string SubClassCode { get; set; }
        [JsonProperty(Order = -10)]
        string GroupCode { get; set; }
        [JsonProperty(Order = -10)]
        bool IsCustomHA { get; set; }
        [JsonProperty(Order = -10)]
        string SupplierCode { get; set; }

        public ProductBase()
        {

        }


        public ProductBase(PD_S_PRODUCT Entity): base(Entity.ROWGUID)
        {
            Code = Entity.PRODUCT_CODE;
            Description = Entity.PRODUCT_DESCR;
            IsActive = Entity.FLG_ACTIVE == "Y";
            BandCode = Entity.BAND_CODE;
            ClassCode = Entity.CLASS_CODE;
            SubClassCode = Entity.SUBCLASS_CODE;
            GroupCode = Entity.GROUP_CODE;
            IsCustomHA = Entity.FLG_CUSTOM == "Y";
            SupplierCode = Entity.SUPPLIER_CODE;
        }
    }
}
