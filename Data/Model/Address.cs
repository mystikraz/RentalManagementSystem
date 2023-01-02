using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Address: BaseEntity
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public virtual ICollection<Building>? Buildings { get; set; }
    }
}
