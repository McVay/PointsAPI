using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PointsAPI.Domain.Models;
using PointsAPI.Domain.Repositories;
using PointsAPI.Domain.Services;

namespace PointsAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfwork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfwork = unitOfWork;
        }

        public async Task CreateUser(User user)
        {
            await _userRepository.AddAsync(user);
            await _unitOfwork.CompleteAsync();
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _userRepository.ListAsync();
        }

        public async Task<User> GetAsync(int id)
        {
            return await _userRepository.FindByIdAsync(id);
        }

        public async Task<bool> UserExists(int id)
        {
            return await _userRepository.ExistsAsync(id);
        }
    }
}