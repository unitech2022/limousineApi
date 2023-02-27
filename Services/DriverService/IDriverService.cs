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

        Task<dynamic> HomeDriver(string userId,AddressModel location);
        
    }
}