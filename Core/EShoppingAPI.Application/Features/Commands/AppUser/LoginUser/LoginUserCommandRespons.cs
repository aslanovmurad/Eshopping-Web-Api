using EShoppingAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingAPI.Application.Features.Commants.AppUser.LoginUser
{
    public class LoginUserCommandRespons
    {
        public Token Token { get; set; }
        public string Message { get; set; }
    }
}
