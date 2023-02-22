using EShoppingAPI.Application.Abstraction.Services;
using EShoppingAPI.Application.DTOs.User;
using EShoppingAPI.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingAPI.Application.Features.Commants.AppUser.CreateUser
{
    public class CreateUsersCommentHandler : IRequestHandler<CreateUsersCommentRequest, CreateUsersCommentRespons>
    {
        readonly IUserService _userService;

        public CreateUsersCommentHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<CreateUsersCommentRespons> Handle(CreateUsersCommentRequest request, CancellationToken cancellationToken)
        {
          CreateUserRespons respons = await  _userService.CreateAsync(new()
            {
                Email = request.Email,
                NameSurname = request.NameSurname,
                Password = request.Password,
                PasswordConfirm = request.PasswordConfirm,
                UserName = request.UserName
            });
            return new()
            {
                Message = respons.Message,
                Succeeded = respons.Succeeded
            };
        }
    }
}
