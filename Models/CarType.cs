using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimousineApi.Models
{
    public class CarType
    {
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? Image { get; set; }
        public double? Price { get; set; }
        public int Sets { get; set; }
        public DateTime CreatedAt { get; set; }

        public CarType()
        {

            CreatedAt = DateTime.UtcNow.AddHours(3);
        }
    }
}