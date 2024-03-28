using Infrastructure.Helpers;
using Application.Services.AuthSercvices;
using Application.Services.AuthSercvices.Models;
 using Domain.Consts;
using Infrastructure.ApplicationUserAggregate;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
 
namespace Infrastructure.Services.AuthSercvices
{
    public class AuthService :IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JWT _jwt;

        public AuthService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<JWT> jwt)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwt = jwt.Value;
        }
        public async Task<RegisterResponseModel> RegisterAsync(RegisterModel model)
        {
            bool isEmailExist = await _userManager.FindByEmailAsync(model.Email) is not null;
            if (isEmailExist)
                return new RegisterResponseModel { Message = "Something went wrong with email!" };
            
            bool isUsernameExist = await _userManager.FindByEmailAsync(model.Email) is not null; 
            if (isUsernameExist)
                return new RegisterResponseModel { Message = "Something went wrong with username!" };

            var user = new ApplicationUser
            {
                UserName = model.Username,
                Email = model.Email,
            
            }; 
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                var errors = string.Empty;

                foreach (var error in result.Errors)
                    errors += $"{error.Description},";

                return new RegisterResponseModel { Message = errors };
            }
            //ToDo:: Modify to set user Role based on the RegisterAsync calling (From App / Dashboard) 
            await _userManager.AddToRoleAsync(user, AppRoles.Customer); 
            return new RegisterResponseModel
            {
                  IsRegister= true,
                  Message= "Register successfully" ,
             };
        }


        public async Task<AuthModel> AuthAsync(TokenRequestModel model)
        {
            var authModel = new AuthModel();

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                authModel.Message = "Email or Password is incorrect!";
                return authModel;
            }

            var jwtSecurityToken = await CreateJwtToken(user); 
            authModel.IsAuthenticated = true;
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            
            return authModel;
        }
        private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim("roles", role));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(_jwt.DurationInDays),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }

    }

}
 