using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingAPI.Application.Features.Commands.AppUser.RefreshTokenLogin
{
    public class RefreshTokenLoginCommandRequest:IRequest<RefreshTokenLoginCommandRespons>
    {
        public string RefreshToken { get; set; }
    }
}
