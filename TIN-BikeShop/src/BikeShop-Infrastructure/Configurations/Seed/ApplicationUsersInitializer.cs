using BikeShop_Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeShop_Infrastructure.Configurations.Seed
{
    public static class ApplicationUsersInitializer
    {
        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByEmailAsync("test@wp.pl").Result == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = "test@wp.pl",
                    Email = "test@wp.pl"
                };

                var result = userManager.CreateAsync(user, "1qaz@WSX").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "User").Wait();
                }
            }

            if (userManager.FindByEmailAsync("testadmin@wp.pl").Result == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = "testadmin@wp.pl",
                    Email = "testadmin@wp.pl"
                };

                var result = userManager.CreateAsync(user, "1qaz@WSX").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }

            if (userManager.FindByEmailAsync("testmoderator@wp.pl").Result == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = "testmoderator@wp.pl",
                    Email = "testmoderator@wp.pl"
                };

                var result = userManager.CreateAsync(user, "1qaz@WSX").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Moderator").Wait();
                }
            }
        }
    }
}
