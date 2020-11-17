using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointsAPI.Domain.Models
{
    public class Point
    {
        public int Id { get; set; }
        public string PayerName { get; set; }
        public int Amount { get; set; }
        public DateTime TransactionDate { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}