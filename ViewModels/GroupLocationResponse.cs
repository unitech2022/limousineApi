using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LimousineApi.Models;

namespace LimousineApi.ViewModels
{
    public class GroupLocationResponse
    {
        public GroupLocation? groupLocation { get; set; }
        public UserDetailResponse? userDetail { get; set; }
    }

      public class ExternalTripDetails
    {
        public ExternalTrip? trip { get; set; }
        public UserDetailResponse? userDetail { get; set; }
    }
}