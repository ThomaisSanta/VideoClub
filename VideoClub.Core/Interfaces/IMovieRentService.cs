using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Core.Entities;

namespace VideoClub.Core.Interfaces
{
    public interface IMovieRentService
    {
        MovieRent AddMovieRent(int movieID, string userID, string comment);
        MovieRent GetActiveBooking(MovieRent movieRentItem);
        void DeleteActiveMovieRent(int? copyID);
        IEnumerable<MovieRent> GetMovieRents();
        string GetCommentWithCopieID(int? copyID);
        //MovieRent GetBookingFormInUsers(string userName);
        ////MovieRentInUsersViewModel GetBookingFormInUsers(string userName);
        //MovieRent GetBookingFormInMovies(string movieTitle);
        ////MovieRentInMoviesViewModel GetBookingFormInMovies(string movieTitle);
    }
}
