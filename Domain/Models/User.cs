using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointsAPI.Domain.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public IList<Point> Points { get; set; } = new List<Point>();
    }
}