using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoClub.Core.Entities
{
    public class MovieRent
    {
        public int MovieRentID { get; set; }
        public string CustomerID { get; set; }
        public int CopyID { get; set; }
        public string Comment { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime BookingDate { get; set; }
        public virtual Copy Copy { get; set; }
    }
}
