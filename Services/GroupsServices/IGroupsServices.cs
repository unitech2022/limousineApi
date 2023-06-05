using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LimousineApi.Core;

namespace LimousineApi.Services.GroupsServices
{
    public interface IGroupsServices :BaseInterface
    {
        Task<dynamic> AcceptGroup(int driverId,int status,int groupId);

         Task<dynamic> GetGroupDetails(int groupId);

         Task<dynamic> GetGroupByDriverId(int driverId);
      
        
    }
}