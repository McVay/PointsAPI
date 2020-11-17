using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointsAPI.Domain.Models
{
    public class UserBalanceResource
    {
        public string PayerName { get; set; }
        public int PointsBalance { get; set; }
    }
}