using PointsAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointsAPI.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ListAsync();

        Task AddAsync(User user);

        Task<User> FindByIdAsync(int id);

        Task<bool> ExistsAsync(int id);
    }
}