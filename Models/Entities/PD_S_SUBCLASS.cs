using System;
using System.Collections.Generic;

namespace Fox.Microservices.Products.Models.Entities
{
    public partial class PD_S_SUBCLASS
    {
        public PD_S_SUBCLASS()
        {
            PD_S_PRODUCT = new HashSet<PD_S_PRODUCT>();
        }

        public string COMPANY_CODE { get; set; }
        public string DIVISION_CODE { get; set; }
        public string CLASS_CODE { get; set; }
        public string SUBCLASS_CODE { get; set; }
        public string SUBCLASS_DESCR { get; set; }
        public string SUBCLASSGROUP_CODE { get; set; }
        public short? PRIORITY_ABSOLUTE { get; set; }
        public short? PRIORITY_SUBCLASS { get; set; }
        public DateTime? DT_START { get; set; }
        public DateTime? DT_END { get; set; }
        public DateTime? DT_INSERT { get; set; }
        public string USERINSERT { get; set; }
        public DateTime? DT_UPDATE { get; set; }
        public string USERUPDATE { get; set; }
        public Guid ROWGUID { get; set; }

        public virtual PD_S_CLASS PD_S_CLASS { get; set; }
        public virtual ICollection<PD_S_PRODUCT> PD_S_PRODUCT { get; set; }
    }
}
