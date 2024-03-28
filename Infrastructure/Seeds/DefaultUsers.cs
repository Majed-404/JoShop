 using Domain.Consts;
using Infrastructure.ApplicationUserAggregate;
using Microsoft.AspNetCore.Identity;
 
namespace Infrastructure.Seeds
{
    public static partial class DefaultUsers
    {
        public static async Task SeedAdminUserAsync(UserManager<ApplicationUser> userManager)
        {
            var admin = new ApplicationUser
            {
                UserName = "joe",
                Email = "joe@joeshop.com",
                EmailConfirmed = true

            };
            var user = await userManager.FindByEmailAsync(admin.Email);
            if (user is null)
            {
                await userManager.CreateAsync(admin, "P@ssword123");
                await userManager.AddToRoleAsync(admin, AppRoles.Admin);
            };

        }
    }
}
