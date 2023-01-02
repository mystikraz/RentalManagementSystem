using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Rent : BaseEntity
    {
        public long TenantId { get; set; }
        public decimal Price { get; set; }
        public DateTime Month { get; set; }
        public virtual Tenant? Tenant { get; set; }
    }
}
