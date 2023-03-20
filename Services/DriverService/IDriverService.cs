using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LimousineApi.Core;
using LimousineApi.Models;

namespace LimousineApi.Services.DriverService
{
    public interface IDriverService :BaseInterface
    {
        Task<dynamic> UpdateDriverLocation(AddressModel type,int driverId);
         Task<dynamic> ChangeDriverStatus(int driverId,int status);

        Task<dynamic> HomeDriver(string userId,AddressModel location);

         Task<dynamic> UpdateDriver(Driver driver);
          Task<dynamic> GetDriverById(int driverId);
        
    }
}