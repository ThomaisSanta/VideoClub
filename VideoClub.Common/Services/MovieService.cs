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
    public class MovieService : IMovieService
    {
        private readonly VideoClubContext _context;

        public MovieService(VideoClubContext context)
        {
            _context = context;
        }
        public IEnumerable<Movie> GetMovies()
        {
            return _context.Movies.ToList();
        }
        public Movie GetMovieById(int? id)
        {
            return _context.Movies.Find(id);
        }
        public IEnumerable<Movie> GetAvailableMovies()
        {
            return _context.Movies.Where(m => m.CopiesAvailable > 0).ToList();
        }
    }
}
