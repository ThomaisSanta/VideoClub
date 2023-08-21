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
using VideoClub.Common.Services;
//using VideoClub.Areas.BookingsHistory.Data;
using VideoClub.Areas.Customers.Data;
using AutoMapper;

namespace VideoClub.Areas.Customers.Controllers
{
    public class CustomersController : Controller
    {
        //// GET: Customers/Customers
        //public ActionResult Index()
        //{
        //    return View();
        //}


        private readonly IBookingHistoryService _bookingHistoryService;
        private readonly ICopyService _copyService;
        private readonly IMovieRentService _movieRentService;
        //private readonly IMapper _mapper;
        private readonly IMovieService _movieService;
        private readonly UserStore<ApplicationUser> _userStore;
        private UserManager<ApplicationUser> _userManager;
        private ApplicationRoleManager _roleManager;

        public CustomersController()
        {
        }

        public CustomersController(IMovieService movieService,
            IBookingHistoryService bookingHistoryService,
            ICopyService copyService,
            IMovieRentService movieRentService)
            //IMapper mapper)
        {
            _bookingHistoryService = bookingHistoryService;
            //_mapper = mapper;
            _copyService = copyService;
            _movieService = movieService;
            _movieRentService = movieRentService;
        }

        public CustomersController(IMovieService movieService,
            IBookingHistoryService bookingHistoryService,
            IMovieRentService movieRentService,
            ICopyService copyService,
            //IMapper mapper,
            ApplicationUserManager userManager,
            ApplicationRoleManager roleManager)
        {
            _userStore = new UserStore<ApplicationUser>(new VideoClubContext());
            _userManager = new UserManager<ApplicationUser>(_userStore);
            UserManager = userManager;
            _movieService = movieService;
            _bookingHistoryService = bookingHistoryService;
            _movieRentService = movieRentService;
            _copyService = copyService;
            //_mapper = mapper;
            _roleManager = roleManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return (ApplicationUserManager)(_userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>());
            }
            private set
            {
                _userManager = value;
            }
        }

        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext
                    .GetOwinContext()
                    .Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }

        // GET: User
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Index()
        {
            var role = "User";
            var userRole = RoleManager.FindByName(role);
            if (userRole != null)
            {
                var showUser = UserManager
                    .Users
                    .Where(u => u.Roles
                    .Any(r => r.RoleId == userRole.Id))
                    .ToList();
                return View(showUser);
            }
            else
            {
                return View(new List<ApplicationUser>());
            }
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
            return RedirectToAction("Index", "Customers");
        }

        //GET : Booking History of each user
        public ActionResult BookingHistory(string userName)
        {
            var userID = UserManager.FindByName(userName).Id;
            IEnumerable<BookingHistory> bookingHistoryList = _bookingHistoryService.GetBookingHistoryForUser(userID);
            var bookingHistoryViewModelList = new List<BookingsHistoryViewModel>();
            foreach (var bookingHistoryitem in bookingHistoryList)
            {
                var bookingHistoryViewModelItem = new BookingsHistoryViewModel
                {
                    Title = _copyService.GetTitleFromCopyID(bookingHistoryitem.CopyID),
                    CopyID = bookingHistoryitem.CopyID,
                    ReturnedDate = bookingHistoryitem.DateMovieGotReturned,
                    Comment = _movieRentService.GetCommentWithCopieID(bookingHistoryitem.CopyID)
                };
                bookingHistoryViewModelList.Add(bookingHistoryViewModelItem);
            }
            return View(bookingHistoryViewModelList);
        }


    }




}