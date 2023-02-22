using EShoppingAPI.Application.Abstraction.Services;
using EShoppingAPI.Application.Abstraction.Token;
using EShoppingAPI.Application.DTOs;
using EShoppingAPI.Application.DTOs.Facebook;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EShoppingAPI.Application.Features.Commands.AppUser.FacebookLogin
{
    public class FacebookLoginCommandHandler : IRequestHandler<FacebookLoginCommandRequest, FacebookLoginCommandRespons>
    {
        readonly IAuthService _authService;

        public FacebookLoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<FacebookLoginCommandRespons> Handle(FacebookLoginCommandRequest request, CancellationToken cancellationToken)
        {

           var token = await _authService.FacebookLoginAsync(request.AuthToken,15);

            return new() { Token = token };
        }
    }
}
