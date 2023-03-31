using Azure.Core;
using EShoppingAPI.Application.Abstraction.Services;
using EShoppingAPI.Application.DTOs.User;
using EShoppingAPI.Application.Exceptions;
using EShoppingAPI.Application.Features.Commants.AppUser.CreateUser;
using EShoppingAPI.Application.Helpers;
using EShoppingAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
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
        public async Task UpdateRefreshTokenAsync(string refrefshToken, AppUser user, DateTime accessTokenDate,int addOnAccessTokenDate)
        {
            if (user != null)
            {
                user.RefreshToken = refrefshToken;
                user.RefreshTokenEndDate = accessTokenDate.AddSeconds(addOnAccessTokenDate);
                await _userManager.UpdateAsync(user);
            }
            else
                throw new NoteFoundUserException();
        }

        public async Task UpdatePasswordAsync(string userId, string resetToken, string newPassword)
        {
            AppUser user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                resetToken = resetToken.UrlDecode();
                IdentityResult result = await _userManager.ResetPasswordAsync(user, resetToken, newPassword);
                if (result.Succeeded)
                    await _userManager.UpdateSecurityStampAsync(user);
                else
                    throw new PasswordChangeFailedException();
            }
        }
    }
}
