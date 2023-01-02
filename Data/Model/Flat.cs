using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Flat : BaseEntity
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
        public long BuildingId { get; set; }
        public long SubMeterId { get; set; }
        public virtual Building? Building { get; set; }
        public virtual ICollection<Room>? Rooms { get; set; }
        public virtual Tenant? Tenant { get; set; }
        public virtual SubMeter? SubMeter { get; set; }
    }
}
