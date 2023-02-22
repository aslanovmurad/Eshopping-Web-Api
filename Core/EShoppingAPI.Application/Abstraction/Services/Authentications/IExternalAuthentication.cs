using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingAPI.Application.Abstraction.Services.Authentications
{
    public interface IExternalAuthentication
    {
        Task<DTOs.Token> FacebookLoginAsync(string AuthToken,int accessTokenLifeTime);
        Task<DTOs.Token> GoogleLoginAsync(string IdToken, int accessTokenLifeTime);
    }
}
