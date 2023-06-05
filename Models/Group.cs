using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimousineApi.Models
{
    public class Group
    {
        public int id { get; set; }

        public double price { get; set; }

       public int driverId { get; set; }
        public string? startCity { get; set; }

        public string? endCity { get; set; }
         public int peoples { get; set; }
        public int status { get; set; }
        public DateTime CreatedAt { get; set; }

        public Group()
        {
            status = 0;
            driverId=0;
            CreatedAt = DateTime.UtcNow.AddHours(3);
        }
    }
}