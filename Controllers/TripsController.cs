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
        public async Task<ActionResult> AddTrip([FromForm] Trip trip)
        {
            if (trip == null)
            {
                return NotFound();
            }

            await _repository.AddTrip(trip);

            return Ok(trip);
        }


        [HttpGet]
        [Route("home_user")]
        public async Task<ActionResult> HomeUser([FromForm] string UserId)
        {
            
            return Ok(await _repository.GetHomeUser(UserId));
        }

    }
}