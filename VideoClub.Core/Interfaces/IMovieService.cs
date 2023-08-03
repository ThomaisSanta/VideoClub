using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Core.Entities;

namespace VideoClub.Core.Interfaces
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetMovies();
        Movie GetMovieById(int? id);
        IEnumerable<Movie> GetAvailableMovies();
        //MovieRent GetBookingFormInUsers(string userName);
        ////MovieRentInUsersViewModel GetBookingFormInUsers(string userName);
        //MovieRent GetBookingFormInMovies(string movieTitle);
        ////MovieRentInMoviesViewModel GetBookingFormInMovies(string movieTitle);
    }
}
