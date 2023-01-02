using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Building : BaseEntity
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
        public long AddressId { get; set; }
        public long MeterId { get; set; }
        public virtual Address? Address { get; set; }
        public virtual ICollection<Flat>? Flats { get; set; }
        public virtual Tenant? Tenant { get; set; }
        public virtual Meter? Meter { get; set; }
    }
}
