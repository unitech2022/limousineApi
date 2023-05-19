using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimousineApi.Models
{
    public class GroupLocation
    {
        public int id { get; set; }
        public int groupId { get; set; }
        public int driverId { get; set; }
        public string? userId { get; set; }
        public string? startLocation { get; set; }


        public string? endLocation { get; set; }


        public int status { get; set; }
        public DateTime CreatedAt { get; set; }

        public GroupLocation()
        {
            status = 0;
            CreatedAt = DateTime.UtcNow.AddHours(3);
        }
    }
}