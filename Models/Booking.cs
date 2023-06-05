using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimousineApi.Models
{
    public class Booking
    {
        public int id { get; set; }
        public string? userId { get; set; }
        public int driverId { get; set; }
        public int externalTripId { get; set; }
        public int status { get; set; }

          public DateTime CreatedAt { get; set; }

        public Booking()
        {

            CreatedAt = DateTime.UtcNow.AddHours(3);
        }
    }
}