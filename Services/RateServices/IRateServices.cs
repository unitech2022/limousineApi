
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LimousineApi.Core;
using LimousineApi.Models;

namespace LimousineApi.Services.RateServices
{
    public interface IRateServices :BaseInterface
    {
        
        Task<dynamic> AddRate(Rate rate);

        Task<dynamic> GetRatesByUserId(int driverId);

         Task<dynamic> GetRatesByUTripId(int tripId);
    }
}