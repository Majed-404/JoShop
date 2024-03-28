using Application.Services.AuthSercvices.Models;
 

namespace Application.Services.AuthSercvices
{
    public interface IAuthService
    {
        Task<RegisterResponseModel> RegisterAsync(RegisterModel model);
         Task<AuthModel> AuthAsync(TokenRequestModel model);
 

    }
}
