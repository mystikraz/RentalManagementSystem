using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Meter : BaseEntity
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        public string Reading { get; set; }
        public decimal Rate { get; set; }
        public virtual ICollection<Building>? Buildings { get; set; }

    }
}
