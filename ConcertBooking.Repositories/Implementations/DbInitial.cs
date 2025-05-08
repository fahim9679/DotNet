using ConcertBooking.Entities;
using ConcertBooking.Infrastructure;
using ConcertBooking.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertBooking.Repositories.Implementations
{
    public class DbInitial : IDbInitial
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitial(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public Task Seed()
        {
            if(!_roleManager.RoleExistsAsync(GlobalConfiguration.Admin_Role).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(GlobalConfiguration.Admin_Role)).GetAwaiter().GetResult();
                var user = new ApplicationUser
                {
                    Email = "fahim9679@gmail.com",
                    UserName = "fahim9679@gmail.com",
                    EmailConfirmed = true,
                    Address = "",
                    Pincode = "",
                    PhoneNumber="",
                    FirstName="Admin"
                };
                _userManager.CreateAsync(user,"Aa@123456").GetAwaiter().GetResult();
                _userManager.AddToRoleAsync(user,GlobalConfiguration.Admin_Role).GetAwaiter().GetResult();
            }
           return Task.CompletedTask;
        }
    }
}
