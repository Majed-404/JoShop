using Domain.Consts;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Seeds
{
    public static partial class DefaultUsers
    {
        public static class DefaultRoles
        {
            public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
            {
                if (!roleManager.Roles.Any())
                {
                    try
                    {
                        await roleManager.CreateAsync(new IdentityRole(AppRoles.Admin));
                        await roleManager.CreateAsync(new IdentityRole(AppRoles.Customer));
                    }
                    catch (Exception ex)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.WriteLine(ex.Message);
                         
                    }
                }
            }
        }
    }
}
