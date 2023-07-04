using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LimousineApi.Data;
using LimousineApi.Models;
using LimousineApi.Services.WalletsServices;
using LimousineApi.ViewModels;
using Microsoft.EntityFrameworkCore;
using WajedApi.Helpers;

namespace LimousineApi.Services.TripsService
{



    public class TripService : ITripService
    {
        string[] statuesTrip = { "رحلة جديدة",
                        "تم القبول من السائق",
                         "تم الدفع",
                        "السائق وصل  ",
                        "تم الركوب" ,
                        "تم الوصول للوجهة ",
                         "تم التأكيد من السائق",
                        "تم التأكيد من العميل",
                         "تم الغاء الرحلة" };
        private readonly IMapper _mapper;
        private readonly AppDBcontext _context;

        private readonly IWalletsServices _walletRepo;

        public TripService(IMapper mapper, AppDBcontext context, IWalletsServices walletRepo)
        {
            _mapper = mapper;

            _context = context;
            _walletRepo = walletRepo;
        }

        public Task<dynamic> AcceptTrip(int tripId, int driverId)
        {
            throw new NotImplementedException();
        }

        // not available
        public async Task<dynamic> AddAsync(dynamic type)
        {



            await _context.Trips!.AddAsync(type);

            await _context.SaveChangesAsync();

            return type;
        }

        public async Task<dynamic> AddTrip(Trip trip, int type)
        {

            List<Driver> drivers = await _context.Drivers!.Where(t => t.Status == 1).ToListAsync();
            trip.driverId = 0;
            if (drivers.Count > 0)
            {
                foreach (var item in drivers)
                {
                    double distance = Functions.GetDistance(item!.Lat ?? 0.0, item.Lng ?? 0.0, trip!.startPointLat, trip!.startPointLng);
                    Console.WriteLine("distance" + distance);
                    if (type == 0)
                    {
                        if (distance < 60)
                        {
                            trip.driverId = item.Id;


                        }
                    }
                    else
                    {
                        if (distance < 1000)
                        {
                            trip.driverId = item.Id;


                        }
                    }

                }
            }
            Driver? driver = await _context.Drivers!.FirstOrDefaultAsync(t => t.Id == trip.driverId);
            if (driver != null)
            {
                driver!.Status = 0;
                _context.SaveChanges();
                await Functions.SendNotificationAsync(_context, driver!.UserId!, "رحلة جديدة", "رحلة جديدة", "");
            }



            await _context.Trips!.AddAsync(trip);
            await _context.SaveChangesAsync();

            return trip;

        }

        public async Task<dynamic> ChangeStatusTrip(int TripId, int Status, string UserId)
        {
            Trip? trip = await _context.Trips!.FirstOrDefaultAsync(t => t.id == TripId);
            Driver? driver = await _context.Drivers!.FirstOrDefaultAsync(t => t.Id == trip!.driverId);

            if (driver != null)
            {
                if (Status == 7 || Status == 6)
                {
                    driver.Status = 1;
                    _context.SaveChanges();
                }
                else if (Status == 1)
                {
                    driver.Status = 0;
                    _context.SaveChanges();
                }
            }


            if (trip != null)
            {
                trip.status = Status;
            }
            _context.SaveChanges();
            User? user = await _context.Users.FirstOrDefaultAsync(t => t.Id == UserId);
            if (Status !=8 && user != null && driver != null)
            {
                await Functions.SendNotificationAsync(_context, user!.Id, "تم تغيير حالة الرحلة ", statuesTrip![Status], "");
            }

            return trip!;

        }

        public Task<dynamic> DeleteAsync(int typeId)
        {
            throw new NotImplementedException();
        }


        public async Task<ResponseHomeUser> GetHomeUser(string UserId)
        {
            List<Address>? addresses = await _context.Addresses!.Where(t => t.UserId == UserId).ToListAsync();
            Trip? trip = await _context.Trips!.FirstOrDefaultAsync(t => t.userId == UserId && t.status < 7);
            Driver? driver = null;
            UserDetailResponse? driverDetail = null;
            User? user1 = await _context.Users.FirstOrDefaultAsync(t => t.Id == UserId);
            UserDetailResponse? userDetail = _mapper.Map<UserDetailResponse>(user1);
            bool activeTrip = false;
            if (trip != null)
            {
                activeTrip = true;
                driver = await _context.Drivers!.FirstOrDefaultAsync(t => t.Id == trip.driverId);
                if (driver != null)
                {
                    User? user = await _context.Users.FirstOrDefaultAsync(t => t.Id == driver!.UserId);
                    driverDetail = _mapper.Map<UserDetailResponse>(user);
                }

            }

            ResponseHomeUser responseHomeUser = new ResponseHomeUser
            {
                Addresses = addresses,
                trip = trip,
                tripActive = activeTrip,
                driver = driver,
                userDetail = userDetail,
                DriverDetails = driverDetail
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

        public async Task<dynamic> GetHistoryTripsUser(string UserId)
        {
            List<HistoryResponse> histories = new List<HistoryResponse>();

            List<Trip> canceledTrips = await _context.Trips!.Where(t => t.userId == UserId).ToListAsync();
            foreach (var item in canceledTrips)
            {
                UserDetailResponse? userDetailResponse = null;
                CarType? carType = null;
                Driver? driver = await _context.Drivers!.FirstOrDefaultAsync(t => t.Id == item.driverId);
                if (driver != null)
                {
                    User? user = await _context.Users.FirstOrDefaultAsync(t => t.Id == driver.UserId);

                    userDetailResponse = _mapper.Map<UserDetailResponse>(user);
                    carType = await _context.CarTypes!.FirstOrDefaultAsync(t => t.Id == driver.CarModelId);
                }

                HistoryResponse historyResponse = new HistoryResponse
                {
                    driver = driver,
                    userDetailDiver = userDetailResponse,
                    trip = item,
                    carType = carType
                };
                histories.Add(historyResponse);

            }

            return new
            {
                canceledTrips = histories.Where(t => t.trip!.status == 7),
                doneTrips = histories.Where(t => t.trip!.status == 6)
            };
        }


        public async Task<dynamic> GetHistoryTripsDriver(int driverId)
        {
            List<HistoryResponse> histories = new List<HistoryResponse>();

            List<Trip> canceledTrips = await _context.Trips!.Where(t => t.driverId == driverId).ToListAsync();
            foreach (var item in canceledTrips)
            {
                UserDetailResponse? userDetailResponse = null;
                CarType? carType = null;
                Driver? driver = await _context.Drivers!.FirstOrDefaultAsync(t => t.Id == item.driverId);
                if (driver != null)
                {
                    User? user = await _context.Users.FirstOrDefaultAsync(t => t.Id == driver.UserId);

                    userDetailResponse = _mapper.Map<UserDetailResponse>(user);
                    carType = await _context.CarTypes!.FirstOrDefaultAsync(t => t.Id == driver.CarModelId);
                }

                HistoryResponse historyResponse = new HistoryResponse
                {
                    driver = driver,
                    userDetailDiver = userDetailResponse,
                    trip = item,
                    carType = carType
                };
                histories.Add(historyResponse);

            }

            return new
            {
                canceledTrips = histories.Where(t => t.trip!.status == 7),
                doneTrips = histories.Where(t => t.trip!.status == 6)
            };
        }

        public async Task<dynamic> PaymentTrip(int tripId, int payment,string userId)
        {
            

            Trip? trip = await _context.Trips!.FirstOrDefaultAsync(t => t.id == tripId);
            Driver? driver = await _context.Drivers!.FirstOrDefaultAsync(t => t.Id == trip!.driverId);
            User? user = await _context.Users!.FirstOrDefaultAsync(t => t.Id == userId);

            double amount = 0.0;
            double tax = trip!.price * 10 / 100;
            if (payment == 0)
            {
                driver!.Wallet -= tax;

                amount = tax;
            }
            else
            {
                double points = trip!.price - tax;
                driver!.Wallet += points;
                amount = points;
            }

            trip!.payment = payment;

            Wallet wallet = new Wallet
            {
                UserIdFrom = userId,
                UserName = user!.FullName,
                UserIdTo = driver.UserId,
                Desc = "payment Trip",
                Amount = amount

            };
            await _walletRepo.AddWallet(wallet);
            _context.SaveChanges();
            return trip;
        }
    }
}