using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using LimousineApi.Data;
using LimousineApi.Models;
using LimousineApi.Models.BaseEntity;
using X.PagedList;
using LimousineApi.ViewModels;
using WajedApi.Helpers;

namespace LimousineApi.Services.BookingServices
{
    public class BookingServices : IBookingServices
    {
        private readonly IMapper _mapper;


        private readonly AppDBcontext _context;

        public BookingServices(IMapper mapper, AppDBcontext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public Task<dynamic> AddAsync(dynamic type)
        {
            throw new NotImplementedException();
        }

        public async Task<dynamic> AddBooking(Booking booking)
        {

            ExternalTrip? externalTrip = await _context.ExternalTrips!.FirstOrDefaultAsync(t => t.id == booking.externalTripId);
            await _context.Bookings!.AddAsync(booking);
            externalTrip!.bookings = externalTrip.bookings + 1;
            _context.SaveChanges();
            Driver? driver = await _context.Drivers!.FirstOrDefaultAsync(t => t.Id == externalTrip.driverId);
            await Functions.SendNotificationAsync(_context, driver!.UserId!, "تم اضافة حجز جديد", externalTrip.name!, "");
            return booking;
        }

        public async Task<dynamic> DeleteAsync(int typeId)
        {
            Booking? booking = await _context.Bookings!.FirstOrDefaultAsync(x => x.id == typeId);

            if (booking != null)
            {
                _context.Bookings!.Remove(booking);

                await _context.SaveChangesAsync();
            }

            return booking!;
        }

        public Task<dynamic> GetItems(string UserId)
        {
            throw new NotImplementedException();
        }

        public Task<dynamic> GetItemsPage(string UserId, int page)
        {
            throw new NotImplementedException();
        }

        public async Task<List<BonkingResponseUser>> GetBookingsByUserId(string userId)
        {
            List<BonkingResponseUser> bookings = new List<BonkingResponseUser> { };
            List<Booking> allBooking = await _context.Bookings!.Where(t => t.userId == userId).ToListAsync();
            foreach (var item in allBooking)
            {
                ExternalTrip? externalTrip = await _context.ExternalTrips!.FirstOrDefaultAsync(t => t.id == item.externalTripId);

                bookings.Add(new BonkingResponseUser
                {
                    trip = externalTrip,
                    booking = item
                });
            }
            return bookings;
        }

        public async Task<dynamic> GetRatesByUTripId(int tripId)
        {
            var data = await _context.Rates!.Where(t => t.TripId == tripId).ToListAsync();

            return data;
        }

        public Task<dynamic> GitById(int typeId)
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

        public async Task<dynamic> AcceptBooking(int bookingId, int status, int type)
        {
            var booking = await _context.Bookings!.FirstOrDefaultAsync(t => t.id == bookingId);
            if (booking != null)
            {
                booking.status = status;
                _context.SaveChanges();
                ExternalTrip? externalTrip = await _context.ExternalTrips!.FirstOrDefaultAsync(t => t.id == booking.externalTripId);
                User? user = await _context.Users.FirstOrDefaultAsync(t => t.Id == booking.userId);
                Driver? driver = await _context.Drivers!.FirstOrDefaultAsync(t => t.Id == booking!.driverId);
                if (status == 1)
                {

                    externalTrip!.bookings = externalTrip.bookings + 1;

                    _context.SaveChanges();

                    await Functions.SendNotificationAsync(_context, user!.Id, "تم تأكيد الحجز", externalTrip!.name!, "");

                }

                if (status == 2)
                {

                    externalTrip!.bookings = externalTrip.bookings - 1;

                    _context.SaveChanges();
                    double tax = externalTrip!.price * 10 / 100;
                    if (externalTrip.Payment == 0)
                    {
                        driver!.Wallet += tax;

                    }
                    else
                    {
                        double points = externalTrip!.price - tax;
                        driver!.Wallet -= points;
                    }
                    //  
                    if (type == 0)
                    {
                        await Functions.SendNotificationAsync(_context, driver!.UserId!, "تم الغاء الحجز", externalTrip!.name!, "");
                    }
                    else
                    {


                        await Functions.SendNotificationAsync(_context, user!.Id, "تم الغاء الحجز", externalTrip!.name!, "");

                    }

                }




            }
            return booking!;
        }
    }
}