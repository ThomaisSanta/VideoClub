﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Core.Entities;
using VideoClub.Core.Interfaces;
using VideoClub.Infrastructure.Data;

namespace VideoClub.Common.Services
{
    public class MovieRentService : IMovieRentService
    {
        private readonly VideoClubContext _context;
        private readonly ICopyService _copyService;
        private readonly IBookingHistoryService _bookHistoryService;

        public MovieRentService(VideoClubContext context,
            ICopyService copyService,
            IBookingHistoryService bookHistoryService)
        {
            _copyService = copyService;
            _context = context;
            _bookHistoryService = bookHistoryService;
        }
        public MovieRent AddMovieRent(int movieID, string userID, string comment)
        {
            var copyID = _copyService.GetFirstAvailableCopyIDFromMovieID(movieID);
            var newBooking = new MovieRent
            {
                CopyID = copyID,
                CustomerID = userID,
                Comment = comment,
                BookingDate = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(7)

            };
            _context.MovieRent.Add(newBooking);
            _context.SaveChanges();
            //Add the rent of the movie also in Booking History table
            _bookHistoryService.AddInBookingHistory(copyID, userID, DateTime.Now.AddDays(7));
            return newBooking;
        }

        public MovieRent GetActiveBooking(MovieRent movieRentItem)
        {
            var movieID = _context.Copy
                    .Where(c => c.CopyID == movieRentItem.CopyID)
                    .Select(c => c.MovieID)
                    .FirstOrDefault();
            var activeBookingItem = new MovieRent
            {
                CopyID = movieRentItem.CopyID,
                ReturnDate = movieRentItem.ReturnDate,
                Comment = movieRentItem.Comment,
            };
            return activeBookingItem;
        }

        public string GetCommentWithCopieID(int? copyID)
        {
            return _context.MovieRent
                        .Where(m => m.CopyID == copyID)
                        .Select(m => m.Comment)
                        .FirstOrDefault();
                        
        }
        public void DeleteActiveMovieRent(int? copyID)
        {
            var movieRentToDelete = _context.MovieRent
                .Where(r => r.CopyID == copyID)
                .FirstOrDefault();
            if (movieRentToDelete != null)
            {
                var movieID = movieRentToDelete.Copy.MovieID; // Retrieve MovieID from Copy navigation property
                var copy = movieRentToDelete.Copy;
                copy.CopyIsBooked = false;
                var movie = _context.Movies
                    .FirstOrDefault(m => m.MovieID == movieID);
                if (movie != null)
                {
                    movie.CopiesAvailable += 1;
                }
                _context.MovieRent.Remove(movieRentToDelete);
                _context.SaveChanges();
            }
        }

        public IEnumerable<MovieRent> GetMovieRents()
        {
            return _context.MovieRent.ToList();
        }
    }
}
