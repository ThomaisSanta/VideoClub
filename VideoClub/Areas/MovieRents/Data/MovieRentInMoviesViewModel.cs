using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoClub.Areas.MovieRents.Data
{
    public class MovieRentInMoviesViewModel
    {
        public string UserNameForm { get; set; }
        public int MovieFormID { get; set; }
        public string TitleForm { get; set; }
        public string CommentForm { get; set; }
    }
}