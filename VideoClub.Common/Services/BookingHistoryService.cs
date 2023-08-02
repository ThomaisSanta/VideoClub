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
        //private readonly VideoClubContext _context;
        //private readonly IMovieService _movieService;
        //public BookingHistoryService(VideoClubContext context,
        //    IMovieService movieService)
        //{
        //    _context = context;
        //    _movieService = movieService;
        //}

        //public void AddInBookingHistory(int copyID, string userID, DateTime returnDate)
        //{
        //    var newInBookingHistory = new BookingHistory
        //    {
        //        CustomerID = userID,
        //        CopyID = copyID,
        //        DateMovieGotReturned = returnDate
        //    };
        //    _context.BookingsHistory.Add(newInBookingHistory);
        //    _context.SaveChanges();
        //}

        //public IEnumerable<BookingHistoryViewModel> GetBookingHistoryForUser(string userID)
        //{
        //    var userHistoryList = _context.BookingsHistory
        //        .Where(h => h.CustomerID == userID)
        //        .ToList();
        //    var bookingHistoryList = new List<BookingHistoryViewModel>();
        //    foreach (var userHistoryItem in userHistoryList)
        //    {
        //        var movieID = _context.Copy
        //            .Where(c => c.CopyID == userHistoryItem.CopyID)
        //            .Select(c => c.MovieID)
        //            .FirstOrDefault();

        //        var bookingHistoryItem = new BookingHistory
        //        {
        //            CopyID = userHistoryItem.CopyID,
        //            DateMovieGotReturned = userHistoryItem.DateMovieGotReturned
        //        };

        //        var bookingHistoryViewModelItem = new BookingHistoryViewModel
        //        {
        //            Title = _movieService.GetMovieById(movieID).Title,
        //            BookingHistory = bookingHistoryItem,
        //            Comment = _context.MovieRent
        //                .Where(m => m.CopyID == bookingHistoryItem.CopyID)
        //                .Select(m => m.Comment)
        //                .FirstOrDefault()
        //        };
        //        bookingHistoryList.Add(bookingHistoryViewModelItem);

        //    }
        //    return bookingHistoryList;
        //}
    }
}
