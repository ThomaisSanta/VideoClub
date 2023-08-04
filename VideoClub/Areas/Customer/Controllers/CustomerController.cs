using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VideoClub.Controllers
{
    public class CustomerController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
    }
}