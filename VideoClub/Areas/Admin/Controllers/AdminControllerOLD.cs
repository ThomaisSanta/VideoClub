//using Microsoft.AspNet.Identity.EntityFramework;
//using Microsoft.AspNet.Identity;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using Microsoft.AspNet.Identity.Owin;
//using System.Net;
//using VideoClub.Core.Entities;
//using VideoClub.Core.Interfaces;
//using VideoClub.Infrastructure.Data;

//namespace VideoClub.Areas.Admin.Controllers
//{
//    public class AdminController : Controller
//    {
//        private readonly IMovieService _movieService;
//        private readonly UserStore<ApplicationUser> _userStore;
//        private UserManager<ApplicationUser> _userManager;
//        private ApplicationRoleManager _roleManager;

//        public AdminController()
//        {
//        }

//        public AdminController(IMovieService movieService)
//        {
//            _movieService = movieService;
//        }

//        public AdminController(IMovieService movieService,
//            ICopyService copyService,
//            ApplicationUserManager userManager,
//            ApplicationRoleManager roleManager)
//        {
//            _userStore = new UserStore<ApplicationUser>(new VideoClubContext());
//            _userManager = new UserManager<ApplicationUser>(_userStore);
//            UserManager = userManager;
//            _movieService = movieService;
//            _roleManager = roleManager;
//        }

//        public ApplicationUserManager UserManager
//        {
//            get
//            {
//                return (ApplicationUserManager)(_userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>());
//            }
//            private set
//            {
//                _userManager = value;
//            }
//        }

//        public ApplicationRoleManager RoleManager
//        {
//            get
//            {
//                return _roleManager ?? HttpContext
//                    .GetOwinContext()
//                    .Get<ApplicationRoleManager>();
//            }
//            private set
//            {
//                _roleManager = value;
//            }
//        }

//        // GET: Admin
//        public ActionResult Index()
//        {
//            return View();
//        }

//        public ActionResult Customers()
//        {
//            var role = "User";
//            var userRole = RoleManager.FindByName(role);
//            if (userRole != null)
//            {
//                var showUser = UserManager
//                    .Users
//                    .Where(u => u.Roles
//                    .Any(r => r.RoleId == userRole.Id))
//                    .ToList();
//                return View(showUser);
//            }
//            else
//            {
//                return View(new List<ApplicationUser>());
//            }
//        }
//    }
//}