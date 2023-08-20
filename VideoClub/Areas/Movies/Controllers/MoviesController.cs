using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoClub.Areas.Movies.Data;
using VideoClub.Core.Entities;
using VideoClub.Core.Interfaces;
using VideoClub.Infrastructure.Data;
using PagedList;

namespace VideoClub.Areas.Movies.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly ICopyService _copyService;
        private readonly IPaginationService _paginationService;
        private readonly UserStore<ApplicationUser> _userStore;
        private UserManager<ApplicationUser> _userManager;

        public MoviesController(IMovieService movieService,
            IPaginationService paginationService)
        {
            _movieService = movieService;
            _paginationService = paginationService;
        }

        public MoviesController(IMovieService movieService,
            ApplicationUserManager userManager)
        {
            _userStore = new UserStore<ApplicationUser>(new VideoClubContext());
            _userManager = new UserManager<ApplicationUser>(_userStore);
            UserManager = userManager;
            _movieService = movieService;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return (ApplicationUserManager)(_userManager ?? HttpContext
                    .GetOwinContext()
                    .GetUserManager<ApplicationUserManager>());
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET : Movie
        public ActionResult MoviesInUser(PaginationDTO paginationDTO)
        {
            ViewBag.CurrentSort = paginationDTO.SortOrder;
            ViewBag.GenreSortParm = paginationDTO.SortOrder == "Genre" ? "genre_desc" : "Genre";
            ViewBag.CurrentFilter = paginationDTO.SearchString;
            var movies = _movieService.GetMovies();
            var paginationModel = _paginationService.GetMoviesPaginated(movies, paginationDTO);
            return View(paginationModel.Items.ToPagedList(paginationModel.PageNumber, paginationModel.PageSize));
        }

        // GET : Movie
        //public ActionResult MoviesInAdmin(PaginationDTO paginationDTO)
        public ActionResult Index(PaginationDTO paginationDTO)
        {
            ViewBag.CurrentSort = paginationDTO.SortOrder;
            ViewBag.GenreSortParm = paginationDTO.SortOrder == "Genre" ? "genre_desc" : "Genre";
            ViewBag.CurrentFilter = paginationDTO.SearchString;
            var movies = _movieService.GetAvailableMovies();
            var paginationModel = _paginationService.GetMoviesPaginated(movies, paginationDTO);
            return View(paginationModel.Items.ToPagedList(paginationModel.PageNumber, paginationModel.PageSize));
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}