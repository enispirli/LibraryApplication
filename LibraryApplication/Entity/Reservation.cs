using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Reservation
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public DateTime TakenDate { get; set; }
        public DateTime DeliveryDate { get; set; }

        public virtual Book GetResBook { get; set; }
        public virtual User GetResUser { get; set; }
    }
}
