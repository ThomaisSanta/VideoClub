using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VideoClub.Areas.MovieRents.Data
{
    public class MovieRentInUsersViewModel
    {
        public string UserNameForm { get; set; }
        public int MovieIDForm { get; set; }
        public string TitleForm { get; set; }
        public string CommentForm { get; set; }
        public IEnumerable<SelectListItem> Booking { get; set; }
    }
}