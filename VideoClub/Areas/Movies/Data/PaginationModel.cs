using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace VideoClub.Areas.Movies.Data
{
    public class PaginationModel<T>
    {
        public List<T> Items { get; set; } 
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public PaginationModel()
        {
            Items = new List<T>();
        }

        public PaginationModel(List<T> items)
        {
            Items = items;
        }

        public PaginationModel(List<T> items, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            Items = items;
        }
    }
}