using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimousineApi.Dtos
{
    public class UpdateExternalTripDto
    {
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
        public string? StartingAt { get; set; }
        public string? EndTime { get; set; }
    }
}