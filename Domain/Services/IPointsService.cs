using PointsAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointsAPI.Domain.Services
{
    public interface IPointsService
    {
        public Task AddPointsToUser(int userId, Point point);

        public Task<IEnumerable<Point>> GetPoints(int userId);

        public Task<IEnumerable<Point>> DeductPointsFromUser(int userId, int amount);
    }
}