using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoClub.Areas.MovieRents.Data
{
    public class MovieRentViewModel
    {
        public string Title { get; set; }
        public int CopyID { get; set; }
        public string UserName { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Comment { get; set; }
    }
}