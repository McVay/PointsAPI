using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointsAPI.Domain.Models
{
    public class PointResource
    {
        public string PayerName { get; set; }
        public int Amount { get; set; }

        public DateTime TransactionDate { get; set; }
    }
}