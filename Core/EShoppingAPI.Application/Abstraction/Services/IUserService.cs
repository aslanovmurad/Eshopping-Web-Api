using EShoppingAPI.Application.DTOs.User;
using EShoppingAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingAPI.Application.Abstraction.Services
{
    public interface IUserService
    {
        Task<CreateUserRespons> CreateAsync(CreateUser user);
        Task UpdateRefreshTokenAsync(string refrefshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate);
        Task UpdatePasswordAsync(string userId, string resetToken, string newPassword);
    }
}
