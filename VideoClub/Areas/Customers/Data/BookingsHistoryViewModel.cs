using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoClub.Core.Entities;

namespace VideoClub.Areas.Customers.Data
{
    public class BookingsHistoryViewModel
    {
        //public BookingHistory BookingHistory { get; set; }
        public int CopyID { get; set; }
        //public int MovieID { get; set; }
        public DateTime ReturnedDate { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
    }
}