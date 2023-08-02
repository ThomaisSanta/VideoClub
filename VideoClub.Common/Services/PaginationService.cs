using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Core.Entities;

namespace VideoClub.Common.Services
{
    public class PaginationService
    {
        //public PaginationModel<Movie> GetMoviesPaginated(IEnumerable<Movie> movies, PaginationDTO paginationDTO)
        //{
        //    if (paginationDTO.SearchString != null)
        //    {
        //        paginationDTO.Page = 1;
        //    }
        //    else
        //    {
        //        paginationDTO.SearchString = paginationDTO.CurrentFilter;
        //    }
        //    //search by title
        //    if (!String.IsNullOrEmpty(paginationDTO.SearchString))
        //    {
        //        movies = movies.Where(m => m.Title.Contains(paginationDTO.SearchString));
        //    }
        //    //filter movies by Genre if user chooses to
        //    switch (paginationDTO.SortOrder)
        //    {
        //        case "genre_desc":
        //            movies = movies.OrderByDescending(m => m.Genre);
        //            break;
        //        case "Genre":
        //            movies = movies.OrderBy(m => m.Genre);
        //            break;
        //        default:
        //            movies = movies.OrderBy(t => t.Title);
        //            break;
        //    }
        //    paginationDTO.PageSize = 3;
        //    paginationDTO.PageNumber = (paginationDTO.Page ?? 1);
        //    var items = movies.ToList();
        //    return new PaginationModel<Movie> { PageNumber = paginationDTO.PageNumber, PageSize = paginationDTO.PageSize, Items = items };
        //}
    }
}
