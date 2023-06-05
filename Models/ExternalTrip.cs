using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimousineApi.Models
{
    public class ExternalTrip
    {
           public int id { get; set; }
        public int driverId { get; set; }

        public string? name { get; set; }
        public double price { get; set; }
        public string? userId { get; set; }

         public string? startCity { get; set; }
        public string? endCity { get; set; }

        public double startPointLat { get; set; }
        public double startPointLng { get; set; }

        public double endPointLat { get; set; }
        public double endPointLng { get; set; }

        public int? Sets { get; set; }

        public int status { get; set; }
         public int bookings { get; set; }
        public DateTime StartingAt { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime CreatedAt { get; set; }

        public ExternalTrip()
        {

            CreatedAt = DateTime.UtcNow.AddHours(3);
        }
    }
}