using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoClub.Core.Entities;
using VideoClub.Infrastructure.Data;

namespace VideoClub.App_Start
{
    public class AdminInitializer
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly UserStore<ApplicationUser> _userStore;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminInitializer(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void AdminUser()
        {
            // create admin user and assign them to the admin role
            using (var context = new VideoClubContext())
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                //Create an admin role if it doesn't exist
                if (!roleManager.RoleExists("Admin"))
                {
                    var adminRole = new IdentityRole("Admin");
                    roleManager.Create(adminRole);
                }

                // Create an admin user if it doesn't exist
                var adminUser = userManager.FindByName("admin");
                if (adminUser == null)
                {
                    adminUser = new ApplicationUser { UserName = "admin", Email = "admin@admin.com" };
                    var result = userManager.Create(adminUser, "Admin@123");

                    if (result.Succeeded)
                    {
                        // Assign the admin user to the admin role
                        userManager.AddToRoleAsync(adminUser.Id, "Admin").Wait();
                    }

                }
            }
        }
    }
}