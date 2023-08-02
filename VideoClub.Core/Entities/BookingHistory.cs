using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoClub.Core.Entities
{
    public class BookingHistory
    {
        public int BookingHistoryID { get; set; }
        public string CustomerID { get; set; }
        public int CopyID { get; set; }
        //public int MovieID { get; set; }
        public DateTime DateMovieGotReturned { get; set; }
        //public virtual Movie Movie { get; set; }
        public virtual Copy Copy { get; set; }
    }
}
