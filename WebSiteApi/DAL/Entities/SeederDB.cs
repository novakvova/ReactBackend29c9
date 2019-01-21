using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSiteApi.DAL.Entities
{
    public class SeederDB
    {
        public static void SeedData(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            var email = "admin@gmail.com";
            var password = "Qwerty1-";
            var roleName = "Admin";
            var countUsers = userManager.Users.Count();
            if(countUsers==0)
            {
                var user = new IdentityUser
                {
                    Email = email,
                    UserName = email
                };
                var result = userManager.CreateAsync(user, password).Result;
                var roleResult = roleManager.CreateAsync(new IdentityRole
                {
                    Name=roleName
                }).Result;

                result = userManager.AddToRoleAsync(user, roleName).Result;
            }
        }

        public static void SeedDataByAsService(IServiceProvider services)
        {
            using (var scope = services
                .GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var userManager = scope.ServiceProvider
                    .GetRequiredService<UserManager<IdentityUser>>();
                var roleManager = scope.ServiceProvider
                    .GetRequiredService<RoleManager<IdentityRole>>();
                SeederDB.SeedData(userManager, roleManager);
            }
        }
    }
}
