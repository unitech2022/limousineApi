using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimousineApi.Models
{
    public class AddressModel
    {
        public double Lat { get; set; }
         public double Lang { get; set; }
          public string? Address { get; set; }
    }
}