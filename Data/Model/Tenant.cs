using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Tenant : BaseEntity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public long? BuildingId { get; set; }
        public long? FlatId { get; set; }
        public long? RoomId { get; set; }
        public virtual Building? Building { get; set; }
        public virtual Flat? Flat { get; set; }
        public virtual Room? Room { get; set; }
        public virtual ICollection<Rent>? Rents { get; set; }
    }
}
