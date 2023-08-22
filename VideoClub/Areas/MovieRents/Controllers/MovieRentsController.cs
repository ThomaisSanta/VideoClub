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
        private readonly ICopyService _copyService;
        //private readonly IMapper _mapper;
        private readonly UserStore<ApplicationUser> _userStore;
        private UserManager<ApplicationUser> _userManager;

        public MovieRentsController(IMovieRentService movieRentService, ICopyService copyService)
            //IMapper mapper)
        {
            _movieRentService = movieRentService;
            _copyService = copyService;
            //_mapper = mapper;
        }

        public MovieRentsController(IMovieRentService movieRentService,
            ApplicationUserManager userManager)
            //IMapper mapper)
        {
            _userStore = new UserStore<ApplicationUser>(new VideoClubContext());
            _userManager = new UserManager<ApplicationUser>(_userStore);
            UserManager = userManager;
            _movieRentService = movieRentService;
            //_mapper = mapper;
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

        //// GET: Movie/Delete/5
        //public ActionResult Delete()
        //{
        //    return View();
        //}

        //// POST: Movie/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int? copyID)
        //{
        //    _movieRentService.DeleteActiveMovieRent(copyID);
        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public ActionResult DeleteMovieRent(int? copyID)
        {
            _movieRentService.DeleteActiveMovieRent(copyID);
            return Json(copyID);
        }
    }
}