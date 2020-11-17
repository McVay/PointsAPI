using Microsoft.EntityFrameworkCore;
using PointsAPI.Domain.Models;
using PointsAPI.Domain.Repositories;
using PointsAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointsAPI.Persistence.Repositories
{
    public class PointRepository : BaseRepository, IPointRepository
    {
        public PointRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddPointsToUser(int userId, Point point)
        {
            var user = await _context.User.FindAsync(userId);
            if (user.Points == null)
                user.Points = new List<Point>();
            user.Points.Add(point);
        }

        public async Task<IEnumerable<Point>> DeductPointsFromUser(int userId, int amount)
        {
            var user = await _context.User.FindAsync(userId);

            var deductedPoints = new Dictionary<string, int>();
            var availablePoints = user.Points.Where(w => w.Amount != 0).OrderBy(o => o.TransactionDate);
            var remainingAmount = amount;

            foreach (var point in availablePoints)
            {
                // If the payer is not in the dictionary yet, initialize it to 0.
                if (!deductedPoints.ContainsKey(point.PayerName))
                {
                    deductedPoints[point.PayerName] = 0;
                }

                // If the point amount is negative, we need to take away any points we've already deducted and put it back in the remaining amount
                if (point.Amount < 0 && deductedPoints[point.PayerName] > 0)
                {
                    var currentDeduction = deductedPoints[point.PayerName];
                    var pointsToAddBack = currentDeduction + point.Amount > 0 ? Math.Abs(point.Amount) : currentDeduction;
                    deductedPoints[point.PayerName] -= pointsToAddBack;

                    point.Amount += pointsToAddBack;
                    remainingAmount += pointsToAddBack;
                }
                else
                {
                    // If there's enough points to cover the remaining amount, deduct whatever is needed and exit the loop
                    if (point.Amount >= remainingAmount)
                    {
                        deductedPoints[point.PayerName] += remainingAmount;
                        point.Amount -= remainingAmount;
                        break;
                    }
                    // Otherwise we need to take all the points we can and lower the amount left to deduct
                    else
                    {
                        deductedPoints[point.PayerName] += point.Amount;
                        remainingAmount -= point.Amount;
                        point.Amount = 0;
                    }
                }
            }

            var newPoints = deductedPoints.Select(d => new Point { PayerName = d.Key, Amount = -1 * d.Value, TransactionDate = DateTime.Now }).ToList();

            return newPoints;
        }

        public async Task<IEnumerable<Point>> GetPoints(int userId)
        {
            var user = await _context.User.FindAsync(userId);
            return user.Points.GroupBy(g => g.PayerName)
                                .Where(w => w.Sum(s => s.Amount) >= 0)
                                .Select(s => new Point
                                {
                                    PayerName = s.Key,
                                    Amount = s.Sum(t => t.Amount),
                                    TransactionDate = DateTime.Now
                                }).ToList();
        }
    }
}