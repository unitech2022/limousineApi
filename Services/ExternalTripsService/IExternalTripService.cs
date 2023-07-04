using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LimousineApi.Core;
using LimousineApi.Dtos;
using LimousineApi.Models;
using LimousineApi.ViewModels;

namespace LimousineApi.Services.ExternalTripsService
{
    public interface IExternalTripService : BaseInterface
    {

        Task<dynamic> GitDriverTrip(int driverId);


             Task<dynamic> GetExternalTrips(int driverId);
        Task<dynamic> AddTrip(ExternalTrip trip);

          Task<ExternalTripDetailsResponse> ExternalTripDetails(int tripId);

           Task<ExternalTripDetailsUser> ExternalTripDetailsUser(int tripId,string userId);


         Task<dynamic> SearchToExternalTrip(string startCity,string endCity,DateTime start);

          Task<dynamic> UpdateExternalTrip(UpdateExternalTripDto updateExternalTripDto,int id);
        Task<dynamic> ChangeStatusTrip(int TripId, int Status,string UserId);


        Task<dynamic> PaymentExternalTrip(int tripId,int payment,string userId);

    }
}