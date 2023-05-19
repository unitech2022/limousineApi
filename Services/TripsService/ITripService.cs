using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LimousineApi.Core;
using LimousineApi.Models;
using LimousineApi.ViewModels;

namespace LimousineApi.Services.TripsService
{
    public interface ITripService : BaseInterface
    {

        Task<dynamic> GitDriverTrip(int driverId);

          Task<ResponseHomeUser> GetHomeUser(string UserId);


           Task<dynamic> GetHistoryTripsUser(string UserId);
             Task<dynamic> GetHistoryTripsDriver(int driverId);
        Task<dynamic> AddTrip(Trip trip,int type);

        Task<dynamic> AcceptTrip(int tripId,int driverId);
        Task<dynamic> ChangeStatusTrip(int TripId, int Status,string UserId);

    }
}