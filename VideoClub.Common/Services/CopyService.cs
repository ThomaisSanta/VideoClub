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
    public class CopyService : ICopyService
    {
        //private readonly VideoClubContext _context;

        //public CopyService(VideoClubContext context)
        //{
        //    _context = context;
        //}
        //public IEnumerable<Copy> GetAvailableCopies()
        //{
        //    return _context.Copy.Where(c => c.CopyIsBooked == false).ToList();
        //}

        //public int GetFirstAvailableCopyIDFromMovieID(int movieID)
        //{
        //    var copy = _context.Copy
        //        .Where(c => c.MovieID == movieID && c.CopyIsBooked == false)
        //        .FirstOrDefault();
        //    copy.CopyIsBooked = true;

        //    var movie = _context.Movies.FirstOrDefault(m => m.MovieID == movieID);
        //    movie.CopiesAvailable -= 1;
        //    _context.SaveChanges();
        //    return copy.CopyID;
        //}
    }
}
