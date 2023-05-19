using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LimousineApi.Models;
using LimousineApi.Services.TripsService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LimousineApi.Controllers
{
    [Route("trips")]
    public class TripsController : Controller
    {
        private readonly ITripService _repository;
        private IMapper _mapper;
        public TripsController(ITripService repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpPost]
        [Route("add-trip")]
        public async Task<ActionResult> AddTrip([FromForm] Trip trip,[FromForm] int type)
        {
            if (trip == null)
            {
                return NotFound();
            }

            await _repository.AddTrip(trip,type);

            return Ok(trip);
        }


        [HttpPost]
        [Route("change_status_trip")]
        public async Task<ActionResult> ChangeStatusTrip([FromForm] int tripId,[FromForm] int status,[FromForm] string userId)
        {

            return Ok(await _repository.ChangeStatusTrip(tripId,status,userId));
        }


        [HttpGet]
        [Route("home_user")]
        public async Task<ActionResult> HomeUser([FromForm] string UserId)
        {
            
            return Ok(await _repository.GetHomeUser(UserId));
        }
  [HttpGet]
        [Route("histories-user")]
        public async Task<ActionResult> HistoriesUser([FromForm] string UserId)
        {
            
            return Ok(await _repository.GetHistoryTripsUser(UserId));
        }

          [HttpGet]
        [Route("histories-driver")]
        public async Task<ActionResult> HistoriesDriver([FromForm] int driverId)
        {
            
            return Ok(await _repository.GetHistoryTripsDriver(driverId));
        }
    }
}