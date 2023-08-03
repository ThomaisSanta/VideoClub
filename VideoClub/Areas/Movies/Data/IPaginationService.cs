using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoClub.Areas.Movies.Data;
using VideoClub.Core.Entities;

namespace VideoClub.Core.Interfaces
{
    public interface IPaginationService
    {
        PaginationModel<Movie> GetMoviesPaginated(IEnumerable<Movie> movies, PaginationDTO paginationDTO);
    }
}
