using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoClub.Core.Entities;
using VideoClub.Core.Interfaces;
using VideoClub.Infrastructure.Data;
using VideoClub.Areas.MovieRents.Data;
using AutoMapper;

namespace VideoClub.Areas.MovieRents.Controllers
{
    public class MovieRentsController : Controller
    {
        private readonly IMovieRentService _movieRentService;
        private readonly IMovieService _movieService;
        private readonly ICopyService _copyService;
        private readonly IMapper _mapper;
        private readonly UserStore<ApplicationUser> _userStore;
        private UserManager<ApplicationUser> _userManager;

        public MovieRentsController(IMovieRentService movieRentService, ICopyService copyService, IMovieService movieService,IMapper mapper)
        {
            _movieRentService = movieRentService;
            _copyService = copyService;
            _movieService = movieService;
            _mapper = mapper;
        }

        public MovieRentsController(IMovieRentService movieRentService,
            IMovieService movieService,
            ApplicationUserManager userManager,
            ApplicationRoleManager roleManager,
            IMapper mapper)
        {
            _userStore = new UserStore<ApplicationUser>(new VideoClubContext());
            _userManager = new UserManager<ApplicationUser>(_userStore);
            UserManager = userManager;
            _movieRentService = movieRentService;
            _movieService = movieService;
            _mapper = mapper;
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

        public ActionResult Index()
        {
            var activeBookingList = new List<MovieRentViewModel>();
            var movieRent = _movieRentService.GetMovieRents();
            foreach (var movieRentItem in movieRent)
            {
                var username = UserManager.FindById(movieRentItem.CustomerID).UserName;
                var activeBookingItem = _movieRentService.GetActiveBooking(movieRentItem);
                var activeBookingViewModel = _mapper.Map<MovieRentViewModel>(activeBookingItem);
                activeBookingViewModel.UserName = username;
                activeBookingViewModel.Title = _copyService.GetTitleFromCopyID(activeBookingItem.CopyID);
                //var activeBookingItem = _movieRentService.GetActiveBooking(movieRentItem, username);
                activeBookingList.Add(activeBookingViewModel);
            }
            return View(activeBookingList);
        }

        //GET 
        [HttpGet]
        public ActionResult NewBookingFormMovie(string movieTitle)
        {
            var booking = new MovieRentInMoviesViewModel
            {
                TitleForm = movieTitle,
            };
            return View(booking);
        }

        //Post
        [HttpPost]
        public ActionResult NewBookingFormMovie(MovieRentInMoviesViewModel model)
        {
            var user = UserManager.FindByName(model.UserNameForm);
            var newBooking = _movieRentService.AddMovieRent(model.MovieFormID,
                user.Id,
                model.CommentForm);
            return RedirectToAction("MoviesInAdmin", "Movie");
        }

        //Get
        [HttpGet]
        public ActionResult NewBookingForm(string userName)
        {
            var booking = new MovieRentInUsersViewModel
            {
                UserNameForm = userName,
                Booking = _movieService.GetAvailableMovies().Select(m => new SelectListItem
                {
                    Value = m.MovieID.ToString(),
                    Text = m.Title
                }).ToList()
            };
            return View(booking);
        }

        //Post
        [HttpPost]
        public ActionResult NewBookingForm(MovieRentInUsersViewModel model)
        {
            var user = UserManager.FindByName(model.UserNameForm);
            var newBooking = _movieRentService.AddMovieRent(model.MovieIDForm,
                user.Id,
                model.CommentForm);
            return RedirectToAction("Customers", "Admin");
        }

        // GET: Movie/Delete/5
        public ActionResult Delete()
        {
            return View();
        }

        // POST: Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? copyID)
        {
            _movieRentService.DeleteActiveMovieRent(copyID);
            return RedirectToAction("Index");
        }
    }
}