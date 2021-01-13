﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Entities.Concrete;

namespace ToDoList.WebUI
{
    public static class IdentityInitializer
    {
        public static async Task SeedData(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("Admin");
            if(adminRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Admin" });
            }
            var memberRole = await roleManager.FindByNameAsync("Member");
            if(memberRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Member" });
            }

            var adminUser = await userManager.FindByNameAsync("TheOryZ");
            if(adminUser == null)
            {
                AppUser user = new AppUser
                {
                    Name = "John",
                    Surname = "Doe",
                    UserName = "TheOryZ",
                    Email = "johnDoe@gmail.com"
                };
                await userManager.CreateAsync(user,"JDoe4815162342");
                await userManager.AddToRoleAsync(user,"Admin");
            }
        }
    }
}
