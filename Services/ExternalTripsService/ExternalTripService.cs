
using AutoMapper;
using LimousineApi.Data;
using LimousineApi.Dtos;
using LimousineApi.Models;
using LimousineApi.Services.WalletsServices;
using LimousineApi.ViewModels;
using Microsoft.EntityFrameworkCore;


namespace LimousineApi.Services.ExternalTripsService
{



    public class ExternalTripService : IExternalTripService
    {

        private readonly IMapper _mapper;
        private readonly AppDBcontext _context;
private readonly IWalletsServices _walletRepo;
        public ExternalTripService(IMapper mapper, AppDBcontext context, IWalletsServices walletRepo)
        {
            _mapper = mapper;

            _context = context;
            _walletRepo = walletRepo;
        }


        // not available
        public async Task<dynamic> AddAsync(dynamic type)
        {



            await _context.ExternalTrips!.AddAsync(type);

            await _context.SaveChangesAsync();

            return type;
        }

        public async Task<dynamic> AddTrip(ExternalTrip trip)
        {
            // List<Driver> drivers = await _context.Drivers!.Where(t => t.Status == 1).ToListAsync();
            await _context.ExternalTrips!.AddAsync(trip);
            await _context.SaveChangesAsync();

            return trip;

        }

        public async Task<dynamic> ChangeStatusTrip(int TripId, int Status, string UserId)
        {
            ExternalTrip? trip = await _context.ExternalTrips!.FirstOrDefaultAsync(t => t.id == TripId);
            Driver? driver = await _context.Drivers!.FirstOrDefaultAsync(t => t.Id == trip!.driverId);




            // if (trip != null)
            // {
            //     trip.status = Status;
            // }
            // _context.SaveChanges();
            // User? user = await _context.Users.FirstOrDefaultAsync(t => t.Id == UserId);
            // if (user != null)
            // {
            //     await Functions.SendNotificationAsync(_context, user!.Id, "تم تغيير حالة الرحلة ", statuesTrip![Status], "");
            // }

            return trip!;

        }

        public async Task<dynamic> DeleteAsync(int typeId)
        {
            ExternalTrip? externalTrip = await _context.ExternalTrips!.FirstOrDefaultAsync(t => t.id == typeId);
            if (externalTrip != null)
            {
                List<Booking> bookings = await _context.Bookings!.Where(t => t.externalTripId == externalTrip.id).ToListAsync();
                _context.Bookings!.RemoveRange(bookings);
                _context.ExternalTrips!.Remove(externalTrip);
                await _context.SaveChangesAsync();
            }

            return externalTrip!;
        }



        public async Task<dynamic> GetItems(string UserId)
        {
            throw new NotImplementedException();
        }

        public Task<dynamic> GetItemsPage(string UserId, int page)
        {
            throw new NotImplementedException();
        }

        public async Task<dynamic> GitById(int typeId)
        {
            ExternalTrip? externalTrip = await _context.ExternalTrips!.FirstOrDefaultAsync(t => t.id == typeId);
            Driver? driver = await _context.Drivers!.FirstOrDefaultAsync(t => t.Id == externalTrip!.driverId);
            return new
            {
                externalTrip = externalTrip!,
                driver = driver
            };
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

        }

        public async Task<dynamic> GetExternalTrips(int driverId)
        {
            var trips = await _context.ExternalTrips!.OrderByDescending(t => t.CreatedAt).Where(t => t.driverId == driverId).ToListAsync();
            return trips;
        }






        public async Task<ExternalTripDetailsResponse> ExternalTripDetails(int tripId)
        {
            List<BookingResponse> bookingsResponse = new List<BookingResponse>();
            ExternalTrip? externalTrip = await _context.ExternalTrips!.FirstOrDefaultAsync(t => t.id == tripId);
            List<Booking> allBookings = await _context.Bookings!.Where(t => t.externalTripId == tripId).ToListAsync();

            foreach (var item in allBookings)
            {

                User? user = await _context.Users.FirstOrDefaultAsync(t => t.Id == item.userId);
                UserDetailResponse userDetailResponse = _mapper.Map<UserDetailResponse>(user);
                bookingsResponse.Add(new BookingResponse
                {
                    booking = item,
                    userDetail = userDetailResponse
                });


            }

            return new ExternalTripDetailsResponse
            {
                trip = externalTrip,
                bookingsResponse = bookingsResponse
            };

        }

        public async Task<dynamic> SearchToExternalTrip(string startCity, string endCity, DateTime start)
        {



            List<ExternalTrip> trips = new List<ExternalTrip> { };
            List<ExternalTrip> allTrips = await _context.ExternalTrips!.OrderByDescending(t => t.CreatedAt).Where(t => t.startCity == startCity && t.endCity == endCity).ToListAsync();
            foreach (var item in allTrips)
            {
                // int result = DateTime.Compare(start.Date, item.StartingAt.d);
                if (item.bookings < item.Sets && start.Date <= item.StartingAt.Date)
                {

                    trips.Add(item);
                }
            }

            return trips;
        }

        public async Task<dynamic> UpdateExternalTrip(UpdateExternalTripDto updateExternalTripDto, int id)
        {
            ExternalTrip? externalTrip = await _context.ExternalTrips!.FirstOrDefaultAsync(t => t.id == id);

            var externalTripUpdated = _mapper.Map(updateExternalTripDto, externalTrip);

            _context.SaveChanges();
            return externalTripUpdated!;

        }

        public async Task<ExternalTripDetailsUser> ExternalTripDetailsUser(int tripId, string userId)
        {
            bool isBooking = false;
            ExternalTrip? externalTrip = await _context.ExternalTrips!.FirstOrDefaultAsync(t => t.id == tripId);
            Booking? booking = await _context.Bookings!.FirstOrDefaultAsync(t => t.userId == userId && t.externalTripId == externalTrip!.id && t.status != 2);
            if (booking == null)
            {
                isBooking = false;

            }
            else
            {
                isBooking = true;
            }
            Driver? driver = await _context.Drivers!.FirstOrDefaultAsync(t => t.Id == externalTrip!.driverId);
            User? user = await _context.Users.FirstOrDefaultAsync(t => t.Id == driver!.UserId);

            UserDetailResponse driverProfile = _mapper.Map<UserDetailResponse>(user);

            return new ExternalTripDetailsUser
            {
                trip = externalTrip,
                driver = driver,
                profileDriver = driverProfile,
                isBooking = isBooking

            };



        }


        public async Task<dynamic> PaymentExternalTrip(int tripId, int payment,string userId)
        {

            ExternalTrip? trip = await _context.ExternalTrips!.FirstOrDefaultAsync(t => t.id == tripId);
            Driver? driver = await _context.Drivers!.FirstOrDefaultAsync(t => t.Id == trip!.driverId);
            User? user = await _context.Users!.FirstOrDefaultAsync(t => t.Id == userId);
            double tax = trip!.price * 10 / 100;
            double amount = 0.0;
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

            trip!.Payment = payment;

            Wallet wallet = new Wallet
            {
                UserIdFrom = user!.Id,
                UserName = user.FullName,
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