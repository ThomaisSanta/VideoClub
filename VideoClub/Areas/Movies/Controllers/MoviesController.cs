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
using VideoClub.Areas.MovieRents.Data;
using VideoClub.Common.Services;

namespace VideoClub.Areas.Movies.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieRentService _movieRentService;
        private readonly IMovieService _movieService;
        private readonly ICopyService _copyService;
        private readonly IPaginationService _paginationService;
        private readonly UserStore<ApplicationUser> _userStore;
        private UserManager<ApplicationUser> _userManager;

        public MoviesController(IMovieService movieService,
            IMovieRentService movieRentService,
            IPaginationService paginationService)
        {
            _movieService = movieService;
            _movieRentService = movieRentService;
            _paginationService = paginationService;
        }

        public MoviesController(IMovieService movieService,
            IMovieRentService movieRentService,
            ApplicationUserManager userManager)
        {
            _userStore = new UserStore<ApplicationUser>(new VideoClubContext());
            _userManager = new UserManager<ApplicationUser>(_userStore);
            UserManager = userManager;
            _movieService = movieService;
            _movieRentService = movieRentService;
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
        public ActionResult Index(PaginationDTO paginationDTO)
        {
            ViewBag.CurrentSort = paginationDTO.SortOrder;
            ViewBag.GenreSortParm = paginationDTO.SortOrder == "Genre" ? "genre_desc" : "Genre";
            ViewBag.CurrentFilter = paginationDTO.SearchString;
            var movies = _movieService.GetAvailableMovies();
            var paginationModel = _paginationService.GetMoviesPaginated(movies, paginationDTO);
            return View(paginationModel.Items.ToPagedList(paginationModel.PageNumber, paginationModel.PageSize));
        }

        //GET 
        [HttpGet]
        public ActionResult MoviesFormView(string movieTitle)
        {
            var booking = new MovieRentInMoviesBindingModel
            {
                TitleForm = movieTitle,
            };
            return View(booking);
        }

        //Post
        [HttpPost]
        public ActionResult MoviesFormView(MovieRentInMoviesBindingModel model)
        {
            var user = UserManager.FindByName(model.UserNameForm);
            var newBooking = _movieRentService.AddMovieRent(model.MovieFormID,
                user.Id,
                model.CommentForm);
            return RedirectToAction("Index", "Movies");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}