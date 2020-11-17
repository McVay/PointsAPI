using PointsAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointsAPI.Domain.Repositories
{
    public interface IPointRepository
    {
        Task AddPointsToUser(int userId, Point point);

        Task<IEnumerable<UserBalanceResource>> GetPoints(int userId);

        Task<IEnumerable<Point>> DeductPointsFromUser(int userId, int amount);
    }
}