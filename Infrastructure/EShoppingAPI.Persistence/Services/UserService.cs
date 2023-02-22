using Azure.Core;
using EShoppingAPI.Application.Abstraction.Services;
using EShoppingAPI.Application.DTOs.User;
using EShoppingAPI.Application.Features.Commants.AppUser.CreateUser;
using EShoppingAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingAPI.Persistence.Services
{
    public class UserService : IUserService
    {
        readonly UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserRespons> CreateAsync(CreateUser model)
        {
            
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = model.UserName,
                Email = model.Email,
                NameSurName = model.NameSurname
            }, model.Password);

            CreateUserRespons respons = new() { Succeeded = result.Succeeded };

            if (result.Succeeded)
                respons.Message = "Users Created Succeessfully";
            else
                foreach (var error in result.Errors)
                {
                    respons.Message += $"{error.Code}-{error.Description}\n";
                }
            return respons;
        }
    }
}
