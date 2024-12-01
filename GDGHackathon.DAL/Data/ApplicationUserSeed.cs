using GDGHackathon.DAL.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDGHackathon.DAL.Data
{
    public static class ApplicationUserSeed
    {
        public async static Task SeedApplicationUserAsync(UserManager<ApplicationUser> _userManager)
        {
            if (_userManager.Users.Count() == 0)
            {
                var user = new ApplicationUser()
                {
                    Email = "Admin@gmail.com",
                    UserName = "Admin",
                    PhoneNumber = "010000000000",
                    Location = "Mansoura",
                    Role="Farmer"

                };
                _userManager.CreateAsync(user, "Admin@123");
            }
        }
    }
}
