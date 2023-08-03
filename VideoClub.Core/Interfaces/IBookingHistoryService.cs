using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Core.Entities;

namespace VideoClub.Core.Interfaces
{
    public interface IBookingHistoryService
    {
        void AddInBookingHistory(int copyID, string userID, DateTime returnDate);
        IEnumerable<BookingHistory> GetBookingHistoryForUser(string userID);
        //IEnumerable<BookingHistoryViewModel> GetBookingHistoryForUser(string userID);
    }
}
