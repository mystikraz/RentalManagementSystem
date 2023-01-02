using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Room : BaseEntity
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
        public long FlatId { get; set; }
        public long SubMeterId { get; set; }
        public virtual Flat? Flat { get; set; }
        public virtual Tenant? Tenant { get; set; }
        public virtual SubMeter? SubMeter { get; set; }
    }
}
