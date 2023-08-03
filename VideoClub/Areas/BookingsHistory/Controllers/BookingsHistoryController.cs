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
using AutoMapper;
using VideoClub.Areas.BookingsHistory.Data;
using VideoClub.Common.Services;
using VideoClub.Areas.MovieRents.Data;

namespace VideoClub.Areas.BookingsHistory.Controllers
{
    public class BookingsHistoryController : Controller
    {
        private readonly IBookingHistoryService _bookingHistoryService;
        private readonly ICopyService _copyService;
        private readonly IMovieRentService _movieRentService;
        private readonly IMapper _mapper;
        private readonly UserStore<ApplicationUser> _userStore;
        private UserManager<ApplicationUser> _userManager;

        public BookingsHistoryController(IBookingHistoryService bookingHistoryService,
            ICopyService copyService,
            IMovieRentService movieRentService,
            IMapper mapper)
        {
            _bookingHistoryService = bookingHistoryService;
            _mapper = mapper;
            _copyService = copyService;
            _movieRentService = movieRentService;
        }

        public BookingsHistoryController(IBookingHistoryService bookingHistoryService,
            ApplicationUserManager userManager,
            IMapper mapper)
        {
            _userStore = new UserStore<ApplicationUser>(new VideoClubContext());
            _userManager = new UserManager<ApplicationUser>(_userStore);
            UserManager = userManager;
            _bookingHistoryService = bookingHistoryService;
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

        //GET : Booking History of each user
        //public ActionResult BookingHistory(string userName)
        public ActionResult Index(string userName)
        {
            var userID = UserManager.FindByName(userName).Id;
            IEnumerable<BookingHistory> bookingHistoryList = _bookingHistoryService.GetBookingHistoryForUser(userID);
            var bookingHistoryViewModelList = new List<BookingsHistoryViewModel>();
            foreach (var bookingHistoryitem in bookingHistoryList)
            {
                var bookingHistoryViewModelItem = _mapper.Map<BookingsHistoryViewModel>(bookingHistoryitem);
                bookingHistoryViewModelItem.Title = _copyService.GetTitleFromCopyID(bookingHistoryitem.CopyID);
                bookingHistoryViewModelItem.Comment = _movieRentService.GetCommentWithCopieID(bookingHistoryitem.CopyID);
                bookingHistoryViewModelList.Add(bookingHistoryViewModelItem);
            }
            return View(bookingHistoryViewModelList);
            //return View(_bookingHistoryService.GetBookingHistoryForUser(userID));
        }
    }
}