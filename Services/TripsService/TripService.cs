using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LimousineApi.Data;
using LimousineApi.Models;
using LimousineApi.ViewModels;
using Microsoft.EntityFrameworkCore;
using WajedApi.Helpers;

namespace LimousineApi.Services.TripsService
{
    public class TripService : ITripService
    {

        private readonly IMapper _mapper;
        private readonly AppDBcontext _context;

        public TripService(IMapper mapper, AppDBcontext context)
        {
            _mapper = mapper;

            _context = context;
        }

        public Task<dynamic> AcceptTrip(int tripId, int driverId)
        {
            throw new NotImplementedException();
        }

        public async Task<dynamic> AddAsync(dynamic type)
        {



            await _context.Trips!.AddAsync(type);

            await _context.SaveChangesAsync();

            return type;
        }

        public async Task<dynamic> AddTrip(Trip trip)
        {

            List<Driver> drivers = await _context.Drivers!.Where(t => t.Status == 1).ToListAsync();
            trip.driverId = 0;
             if(drivers.Count >0){
               foreach (var item in drivers)
            {
                double distance = Functions.GetDistance(item!.Lat??0.0,item.Lng ?? 0.0, trip!.startPointLat, trip!.startPointLng);
                Console.WriteLine("distance" + distance);
                if (distance < 30)
                {
                    trip.driverId = item.Id;


                }

            }
         }
            Driver? driver = await _context.Drivers!.FirstOrDefaultAsync(t => t.Id == trip.driverId);
            if (driver != null)
            {
                driver!.Status = 0;
                _context.SaveChanges();
            }

            await _context.Trips!.AddAsync(trip);
            await _context.SaveChangesAsync();

            return trip;

        }

        public Task<dynamic> ChangeStatusTrip(int TripId, int Status)
        {
            throw new NotImplementedException();
        }

        public Task<dynamic> DeleteAsync(int typeId)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseHomeUser> GetHomeUser(string UserId)
        {
            Trip? trip = await _context.Trips!.FirstOrDefaultAsync(t => t.userId == UserId && t.status != 8);
            Driver? driver = null;
            UserDetailResponse? userDetail = null;
            bool activeTrip = false;
            if (trip != null)
            {
                activeTrip = true;
                driver = await _context.Drivers!.FirstOrDefaultAsync(t => t.Id == trip.driverId);
                if(driver!=null){
               User? user = await _context.Users.FirstOrDefaultAsync(t => t.Id == driver!.UserId);
                userDetail = _mapper.Map<UserDetailResponse>(user);
                }
               
            }

            ResponseHomeUser responseHomeUser = new ResponseHomeUser
            {
                trip = trip,
                tripActive = activeTrip,
                driver = driver,
                userDetail = userDetail
            };
            return responseHomeUser;
        }

        public Task<dynamic> GetItems(string UserId)
        {
            throw new NotImplementedException();
        }

        public Task<dynamic> GetItemsPage(string UserId, int page)
        {
            throw new NotImplementedException();
        }

        public Task<dynamic> GitById(int typeId)
        {
            throw new NotImplementedException();
        }

        public Task<dynamic> GitDriverTrip(int driverId)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateObject(dynamic category)
        {
            throw new NotImplementedException();
        }
    }
}