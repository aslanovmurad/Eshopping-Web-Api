using EShoppingAPI.Application.DTOs.User;
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
    }
}
