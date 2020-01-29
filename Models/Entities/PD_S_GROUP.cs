using System;
using System.Collections.Generic;

namespace Fox.Microservices.Products.Models.Entities
{
    public partial class PD_S_GROUP
    {
        public PD_S_GROUP()
        {
            PD_S_PRODUCT = new HashSet<PD_S_PRODUCT>();
        }

        public string COMPANY_CODE { get; set; }
        public string DIVISION_CODE { get; set; }
        public string GROUP_CODE { get; set; }
        public string GROUP_DESCR { get; set; }
        public DateTime? DT_START { get; set; }
        public DateTime? DT_END { get; set; }
        public DateTime? DT_INSERT { get; set; }
        public string USERINSERT { get; set; }
        public DateTime? DT_UPDATE { get; set; }
        public string USERUPDATE { get; set; }
        public Guid ROWGUID { get; set; }

        public virtual ICollection<PD_S_PRODUCT> PD_S_PRODUCT { get; set; }
    }
}
