﻿
using lab5.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace lab5.Data
{
    //Инициализация базы данных первой учетной записью и двумя ролями admin и user
    public static class DbUserInitializer
    { 
    public static async Task Initialize(IServiceProvider serviceProvider)
    {
        UserManager<ApplicationUser> userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        string adminEmail = "admin@gmail.com";
        string adminName = "admin@gmail.com";

        string password = "_Aa123456";
        if (await roleManager.FindByNameAsync("admin") == null)
        {
            await roleManager.CreateAsync(new IdentityRole("admin"));
        }
        if (await roleManager.FindByNameAsync("user") == null)
        {
            await roleManager.CreateAsync(new IdentityRole("user"));
        }
        if (await userManager.FindByNameAsync(adminEmail) == null)
        {
                ApplicationUser admin = new ApplicationUser
            {
                Email = adminEmail,
                UserName = adminName
            };
            IdentityResult result = await userManager.CreateAsync(admin, password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(admin, "admin");
            }
        }
    }
    }
}



