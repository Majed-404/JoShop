
using Infrastructure.ApplicationUserAggregate;
using Infrastructure.Seeds;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static Infrastructure.Seeds.DefaultUsers;

namespace Infrastructure.Data;
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    //public UserManager<ApplicationUser> _userManager { get; }
    //public RoleManager<IdentityRole> _roleManager { get; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options
                                    //,UserManager<ApplicationUser> userManager,
                                    //RoleManager<IdentityRole> roleManager

        ) : base(options)
    {
        //_userManager= userManager ;
        //_roleManager = roleManager  ;
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
 
        //SeedDefaultUsersAndRoles().ConfigureAwait(false);
    }

    //private async Task SeedDefaultUsersAndRoles()
    //{
    //    #region Seeds Default users and roles

    //    await DefaultRoles.SeedRolesAsync(_roleManager);
    //    await  DefaultUsers.SeedAdminUserAsync(_userManager) ;
    //    #endregion
    //}
}
