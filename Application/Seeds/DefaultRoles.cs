﻿using Domain.Consts;
using Microsoft.AspNetCore.Identity;

namespace Application.Seeds
{
    public static partial class DefaultUsers
    {
        public static class DefaultRoles
        {
            public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
            {
                if (!roleManager.Roles.Any())
                {
                    await roleManager.CreateAsync(new IdentityRole(AppRoles.Admin));
                    await roleManager.CreateAsync(new IdentityRole(AppRoles.Customer));
                }
            }
        }
    }
}