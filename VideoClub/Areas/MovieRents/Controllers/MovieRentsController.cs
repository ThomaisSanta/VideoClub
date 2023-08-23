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
using System.Diagnostics;

namespace VideoClub.Areas.MovieRents.Controllers
{
    public class MovieRentsController : Controller
    {
        private readonly IMovieRentService _movieRentService;
        private readonly ICopyService _copyService;
        private readonly UserStore<ApplicationUser> _userStore;
        private UserManager<ApplicationUser> _userManager;

        public MovieRentsController(IMovieRentService movieRentService, ICopyService copyService)
        {
            _movieRentService = movieRentService;
            _copyService = copyService;
        }

        public MovieRentsController(IMovieRentService movieRentService,
            ApplicationUserManager userManager)
        {
            _userStore = new UserStore<ApplicationUser>(new VideoClubContext());
            _userManager = new UserManager<ApplicationUser>(_userStore);
            UserManager = userManager;
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

        public ActionResult Index()
        {
            var activeBookingList = new List<MovieRentViewModel>();
            var movieRent = _movieRentService.GetMovieRents();
            foreach (var movieRentItem in movieRent)
            {
                var username = UserManager.FindById(movieRentItem.CustomerID).UserName;
                var activeBookingItem = _movieRentService.GetActiveBooking(movieRentItem);
                var activeBookingViewModel = new MovieRentViewModel
                {  
                    Title = _copyService.GetTitleFromCopyID(activeBookingItem.CopyID),
                    CopyID = activeBookingItem.CopyID,
                    UserName = username,
                    ReturnDate = activeBookingItem.ReturnDate,
                    Comment = activeBookingItem.Comment,
                }; 
                activeBookingList.Add(activeBookingViewModel);
            }
            return View(activeBookingList);
        }

        [HttpPost]
        public ActionResult DeleteMovieRent(MovieRentDTO movieRentDTO)
        {
            try
            {
                _movieRentService.DeleteActiveMovieRent(movieRentDTO.CopyID);
                return Json(movieRentDTO.CopyID);
            }
            catch (Exception ex)
            {
                Trace.TraceError("An error occurred while deleting movie rent: {0}", ex.Message);
                return Json(new { success = false });
            }
        }
    }
}