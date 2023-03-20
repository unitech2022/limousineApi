using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LimousineApi.Models;

namespace LimousineApi.ViewModels
{
    public class ResponseHomeDriver
    {
        public Driver? driver { get; set; }

        public UserDetailResponse? user { get; set; }
         public UserDetailResponse? driverUser { get; set; }

        public Trip? trip { get; set; }


    }
}