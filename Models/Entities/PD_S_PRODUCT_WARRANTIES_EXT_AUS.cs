using System;
using System.Collections.Generic;

namespace Fox.Microservices.Products.Models.Entities
{
    public partial class PD_S_PRODUCT_WARRANTIES_EXT_AUS
    {
        public string COMPANY_CODE { get; set; }
        public string DIVISION_CODE { get; set; }
        public string PRODUCT_CODE { get; set; }
        public string WARRANTY_TYPE { get; set; }
        public DateTime DT_EFFECTIVE_FROM { get; set; }
        public short? RETURN_FOR_CREDIT { get; set; }
        public short? ON_DEFECT { get; set; }
        public short? SHELL_MAKE { get; set; }
        public short? LOSS_AND_DAMAGE { get; set; }
        public DateTime? DT_INSERT { get; set; }
        public string USERINSERT { get; set; }
        public DateTime? DT_UPDATE { get; set; }
        public string USERUPDATE { get; set; }
        public Guid ROWGUID { get; set; }
        public string NOTE { get; set; }
    }
}
