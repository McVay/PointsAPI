using PointsAPI.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PointsAPI.Domain.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> ListAsync();

        Task<User> GetAsync(int id);

        Task CreateUser(User user);

        Task<bool> UserExists(int id);
    }
}