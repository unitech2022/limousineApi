using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimousineApi.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string? UserId { get; set; }

        public bool Default { get; set; }


         public double Lat { get; set; }
         public double Lang { get; set; }
          public string? Label { get; set; }

           public DateTime CreatedAt { get; set; }

            public Address()
        {

            CreatedAt = DateTime.UtcNow.AddHours(3);
            Default=false;
            
        }
    }
}