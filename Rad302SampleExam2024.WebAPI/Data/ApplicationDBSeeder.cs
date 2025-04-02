using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Rad302SampleExam2024.WebAPI.Models;

namespace RAD302FinalExam20222023.Data
{
  public class ApplicationDbSeeder
  {
    private readonly ApplicationDbContext _ctx;

        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public ApplicationDbSeeder(ApplicationDbContext ctx, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _ctx = ctx;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task Seed()
        {
          _ctx.Database.EnsureCreated();
            // Seed the Main User
            await _roleManager.CreateAsync(new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Admin" });
            ApplicationUser user = await _userManager.FindByEmailAsync("paul@itsligo.ie");
                if (user == null)
                {
                user = new ApplicationUser()
                {
                        Id = Guid.NewGuid().ToString(),
                        Lastname = "Powell",
                        Firstname = "Paul",
                        Email = "paul@itsligo.ie",
                        UserName = "paul@itsligo.ie",
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString(),
                    };

                    var result = await _userManager.CreateAsync(user, "P@ssw0rd!");
                    if (result != IdentityResult.Success)
                    {
                        throw new InvalidOperationException("Could not create user in Seeding");
                    }
                else if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Admin");
                }
                _ctx.SaveChanges();
                }
        }
    }
}

