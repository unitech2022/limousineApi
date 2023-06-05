using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LimousineApi.Models;

using LimousineApi.Services.BookingServices;

namespace LimousineApi.Controllers
{
    [Route("Bookings")]
    public class BookingsController : Controller
    {

        private readonly IBookingServices _repository;
        private IMapper _mapper;

        public BookingsController(IBookingServices repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("add-booking")]
        public async Task<ActionResult> AddBooking([FromForm] Booking booking)
        {

            return Ok(await _repository.AddBooking(booking));

        }


        [HttpGet]
        [Route("get-Bookings-by-userId")]
        public async Task<ActionResult> GetBookingsTrip([FromForm] string userId)
        {

            return Ok(await _repository.GetBookingsByUserId(userId));
        }


        [HttpPost]
        [Route("change-status-booking")]
        public async Task<ActionResult> ChangeStatusBooking([FromForm] int bookingId,[FromForm] int status,[FromForm] int type)
        {

            return Ok(await _repository.AcceptBooking(bookingId,status,type));
        }

    }
}