using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LimousineApi.Core;
using LimousineApi.Models;

namespace LimousineApi.Services.GroupLocationsServices
{
    public interface IGroupsLocationServices :BaseInterface
    {
          Task<dynamic> AddGroupLocation(GroupLocation groupLocation );
         Task<dynamic> GetGroupLocationsByDriverId(int driverId );
            Task<dynamic> GetGroupLocationsByUserId(string userId );
        
    }
}