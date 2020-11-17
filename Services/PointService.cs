using PointsAPI.Domain.Models;
using PointsAPI.Domain.Repositories;
using PointsAPI.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointsAPI.Services
{
    public class PointService : IPointsService
    {
        private readonly IPointRepository _pointRepository;
        private readonly IUnitOfWork _unitOfwork;

        public PointService(IPointRepository pointRepository, IUnitOfWork unitOfWork)
        {
            _pointRepository = pointRepository;
            _unitOfwork = unitOfWork;
        }

        public async Task<IEnumerable<Point>> GetPoints(int userId)
        {
            return await _pointRepository.GetPoints(userId);
        }

        public async Task AddPointsToUser(int userId, Point point)
        {
            await _pointRepository.AddPointsToUser(userId, point);
            await _unitOfwork.CompleteAsync();
        }

        public async Task<IEnumerable<Point>> DeductPointsFromUser(int userId, int amount)
        {
            var newPoints = await _pointRepository.DeductPointsFromUser(userId, amount);
            await _unitOfwork.CompleteAsync();

            return newPoints;
        }
    }
}