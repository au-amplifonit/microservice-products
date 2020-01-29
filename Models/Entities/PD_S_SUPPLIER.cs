using System;
using System.Collections.Generic;

namespace Fox.Microservices.Products.Models.Entities
{
    public partial class PD_S_SUPPLIER
    {
        public PD_S_SUPPLIER()
        {
            PD_S_PRODUCTPD_S_SUPPLIER = new HashSet<PD_S_PRODUCT>();
            PD_S_PRODUCTPD_S_SUPPLIERNavigation = new HashSet<PD_S_PRODUCT>();
        }

        public string COMPANY_CODE { get; set; }
        public string DIVISION_CODE { get; set; }
        public string SUPPLIER_CODE { get; set; }
        public string SUPPLIER_DESCR { get; set; }
        public string SUPPLIER_TYPE_CODE { get; set; }
        public string FLG_SERIAL21 { get; set; }
        public short? LEAD_TIME { get; set; }
        public DateTime? DT_START { get; set; }
        public DateTime? DT_END { get; set; }
        public DateTime? DT_INSERT { get; set; }
        public string USERINSERT { get; set; }
        public DateTime? DT_UPDATE { get; set; }
        public string USERUPDATE { get; set; }
        public Guid ROWGUID { get; set; }

        public virtual ICollection<PD_S_PRODUCT> PD_S_PRODUCTPD_S_SUPPLIER { get; set; }
        public virtual ICollection<PD_S_PRODUCT> PD_S_PRODUCTPD_S_SUPPLIERNavigation { get; set; }
    }
}
