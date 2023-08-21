using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoClub.Core.Entities;

namespace VideoClub.Areas.BookingsHistory.Data
{
    public class BookingsHistoryViewModelOLD
    {
        public BookingHistory BookingHistory { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
    }
}