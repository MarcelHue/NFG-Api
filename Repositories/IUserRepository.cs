using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NetFlixGo.DTOs;
using NetFlixGo.Entities;

namespace NetFlixGo.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserAsync(Guid userId);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(Guid userId);

        Task<User> AuthUserAsync(toAuthUserDto user);
    }
}