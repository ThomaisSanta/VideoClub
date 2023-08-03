using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using VideoClub.App_Start;
using VideoClub.Core.Entities;
using VideoClub.Infrastructure.Data;

namespace VideoClub
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //Call registerDependencies to use autofac (for dependency injection)
            DependencyConfig.RegisterDependencies();
            var context = new VideoClubContext();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var adminInitializer = new AdminInitializer(userManager, roleManager);
            adminInitializer.AdminUser();
            //var adminInit = new AdminInitController(userManager, roleManager);
            //adminInit.AdminUser();
            var roleManagerUser = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new VideoClubContext()));

            // Create the "User" role if it doesn't exist
            if (!roleManagerUser.RoleExists("User"))
            {
                var role = new IdentityRole("User");
                roleManagerUser.Create(role);
            }
        }
    }
}
