using Application.Services.AuthSercvices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AuthSercvices
{
    public interface IAuthService
    {
        Task<AuthModel> RegisterAsync(RegisterModel model);
         Task<AuthModel> GetTokenAsync(TokenRequestModel model);
         
    }
}
