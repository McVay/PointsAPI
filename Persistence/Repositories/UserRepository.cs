using Microsoft.EntityFrameworkCore;
using PointsAPI.Domain.Models;
using PointsAPI.Domain.Repositories;
using PointsAPI.Persistence.Contexts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PointsAPI.Persistence.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(User user)
        {
            await _context.User.AddAsync(user);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.User.AnyAsync(u => u.Id == id);
        }

        public async Task<User> FindByIdAsync(int id)
        {
            return await _context.User.FindAsync(id);
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _context.User.AsNoTracking().ToListAsync();
        }
    }
}