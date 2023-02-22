using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingAPI.Application.Features.Commants.AppUser.LoginUser
{
    public class LoginUserCommandRequest:IRequest<LoginUserCommandRespons>
    {
        public string UserNameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
