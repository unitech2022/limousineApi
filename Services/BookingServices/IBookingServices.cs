
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LimousineApi.Core;
using LimousineApi.Models;
using LimousineApi.ViewModels;

namespace LimousineApi.Services.BookingServices
{
    public interface IBookingServices :BaseInterface
    {
        
        Task<dynamic> AddBooking(Booking rate);
Task<dynamic> AcceptBooking(int bookingId,int status,int type);
        Task<List<BonkingResponseUser>> GetBookingsByUserId(string driverId);

       
    }
}