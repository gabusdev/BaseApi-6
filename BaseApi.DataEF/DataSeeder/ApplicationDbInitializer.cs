using BaseApi.Core.Entities;
using BaseApi.Core.Entities.Enums;
using BaseApi.DataEF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BaseApi.Api.AppServices.DataSeed
{
    public static class ApplicationDbInitializer
    {
        public static void SeedAplicationData(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<CoreDbContext>()!;
                context.Database.EnsureCreated();

                var userManager =
                         serviceScope.ServiceProvider.GetService<UserManager<User>>()!;
                
                if (userManager.FindByEmailAsync("admin@mail.com").Result == null)
                {
                    var user = new User
                    {
                        FirstName = "Admin",
                        LastName = "Admin",
                        UserName = "Administrator",
                        Email = "admin@mail.com"
                    };

                    IdentityResult result = userManager.CreateAsync(user, "Temp_123").Result;

                    if (result.Succeeded)
                    {
                        userManager.AddToRoleAsync(user, Enum.GetName(RoleEnum.Administrator)).Wait();
                    }
                }

                if (userManager.FindByEmailAsync("guest@mail.com").Result == null)
                {
                    var user = new User
                    {
                        FirstName = "Guest",
                        LastName = "Guest",
                        UserName = "Guest",
                        Email = "guest@mail.com"
                    };

                    IdentityResult result = userManager.CreateAsync(user, "Temp_123").Result;

                    if (result.Succeeded)
                    {
                        userManager.AddToRoleAsync(user, Enum.GetName(RoleEnum.User)).Wait();
                    }
                }
            }
        }
    }
}
