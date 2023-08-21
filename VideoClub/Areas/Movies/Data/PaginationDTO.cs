using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoClub.Areas.Movies.Data
{
    public class PaginationDTO
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int TotalItems { get; set; }
        public string SortOrder { get; set; }
        public string CurrentFilter { get; set; }
        public string SearchString { get; set; }
        public int? Page { get; set; }
        public string Role { get; set; }

        public PaginationDTO(int? current, int? size)
        {
            if (current == null)
                current = 1;
            if (current < 1)
                current = 1;
            CurrentPage = (int)current;

            if (size == null)
                size = 3;
            if (size < 1)
                size = 3;
            PageSize = (int)size;
        }

        public PaginationDTO() { }

        public int SkipTo()
        {
            return (CurrentPage - 1) * PageSize;
        }
    }
}