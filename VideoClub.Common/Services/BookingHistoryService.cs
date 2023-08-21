using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Core.Entities;
using VideoClub.Core.Interfaces;
using VideoClub.Infrastructure.Data;

namespace VideoClub.Common.Services
{
    public class BookingHistoryService : IBookingHistoryService
    {
        private readonly VideoClubContext _context;
        public BookingHistoryService(VideoClubContext context)
        {
            _context = context;
        }

        public void AddInBookingHistory(int copyID, string userID, DateTime returnDate)
        {
            var newInBookingHistory = new BookingHistory
            {
                CustomerID = userID,
                CopyID = copyID,
                DateMovieGotReturned = returnDate
            };
            _context.BookingsHistory.Add(newInBookingHistory);
            _context.SaveChanges();
        }

        public IEnumerable<BookingHistory> GetBookingHistoryForUser(string userID)
        {
            var userHistoryList = _context.BookingsHistory
                .Where(h => h.CustomerID == userID)
                .ToList();
            var bookingHistoryList = new List<BookingHistory>();
            foreach (var userHistoryItem in userHistoryList)
            {
                var movieID = _context.Copy
                    .Where(c => c.CopyID == userHistoryItem.CopyID)
                    .Select(c => c.MovieID)
                    .FirstOrDefault();

                var bookingHistoryItem = new BookingHistory
                {
                    CopyID = userHistoryItem.CopyID,
                    DateMovieGotReturned = userHistoryItem.DateMovieGotReturned
                };
                bookingHistoryList.Add(bookingHistoryItem);
            }
            return bookingHistoryList;
        }
    }
}
