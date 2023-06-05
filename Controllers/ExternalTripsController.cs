using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LimousineApi.Dtos;
using LimousineApi.Models;
using LimousineApi.Services.ExternalTripsService;
using LimousineApi.Services.TripsService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LimousineApi.Controllers
{
    [Route("extrips")]
    public class ExternalTripsController : Controller
    {
        private readonly IExternalTripService _repository;
        private IMapper _mapper;
        public ExternalTripsController(IExternalTripService repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpPost]
        [Route("add-trip")]
        public async Task<ActionResult> AddTrip([FromForm] ExternalTrip trip)
        {
            if (trip == null)
            {
                return NotFound();
            }

            await _repository.AddTrip(trip);

            return Ok(trip);
        }


        [HttpPost]
        [Route("change_status_trip")]
        public async Task<ActionResult> ChangeStatusTrip([FromForm] int tripId, [FromForm] int status, [FromForm] string userId)
        {

            return Ok(await _repository.ChangeStatusTrip(tripId, status, userId));
        }





        [HttpGet]
        [Route("get-external-trips")]
        public async Task<ActionResult> HistoriesDriver([FromForm] int driverId)
        {

            return Ok(await _repository.GetExternalTrips(driverId));
        }


        [HttpGet]
        [Route("get-external-trip-byId")]
        public async Task<ActionResult> GetExternalTripId([FromForm] int tripId)
        {

            return Ok(await _repository.GitById(tripId));
        }



        [HttpGet]
        [Route("get-external-trip-Details")]
        public async Task<ActionResult> GetExternalTripDetails([FromForm] int tripId)
        {

            return Ok(await _repository.ExternalTripDetails(tripId));
        }


         [HttpGet]
        [Route("get-external-trip-Details-user")]
        public async Task<ActionResult> GetExternalTripDetailsUser([FromForm] int tripId,[FromForm] string userId)
        {

            return Ok(await _repository.ExternalTripDetailsUser(tripId,userId));
        }

        [HttpDelete]
        [Route("delete-external-trip")]
        public async Task<ActionResult> DeleteExternalTrip([FromForm] int tripId)
        {

            return Ok(await _repository.DeleteAsync(tripId));
        }


        [HttpPost]
        [Route("update-external-trip")]
        public async Task<ActionResult> UpdateExternalTrip([FromForm] UpdateExternalTripDto updateExternalTripDto, [FromForm] int tripId)
        {

            return Ok(await _repository.UpdateExternalTrip(updateExternalTripDto, tripId));
        }

        [HttpGet]
        [Route("search-external-trip")]
        public async Task<ActionResult> SearchExternalTrip([FromForm] string startCity, [FromForm] string endCity, [FromForm] DateTime date)
        {

            return Ok(await _repository.SearchToExternalTrip(startCity, endCity, date));
        }
    }
}