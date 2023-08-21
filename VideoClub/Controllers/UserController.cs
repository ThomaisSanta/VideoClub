using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoClub.Areas.Movies.Data;
using VideoClub.Common.Services;
using VideoClub.Core.Interfaces;
using PagedList;

namespace VideoClub.Controllers
{
    public class UserController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IPaginationService _paginationService;

        public UserController(IMovieService movieService,
            IPaginationService paginationService)
        {
            _movieService = movieService;
            _paginationService = paginationService;
        }

        // GET : Movie
        public ActionResult Index(PaginationDTO paginationDTO)
        {
            ViewBag.CurrentSort = paginationDTO.SortOrder;
            ViewBag.GenreSortParm = paginationDTO.SortOrder == "Genre" ? "genre_desc" : "Genre";
            ViewBag.CurrentFilter = paginationDTO.SearchString;
            var movies = _movieService.GetMovies();
            var paginationModel = _paginationService.GetMoviesPaginated(movies, paginationDTO);
            return View(paginationModel.Items.ToPagedList(paginationModel.PageNumber, paginationModel.PageSize));
        }
    }
}