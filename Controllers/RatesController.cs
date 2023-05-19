using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LimousineApi.Models;
using LimousineApi.Services.RateServices;

namespace LimousineApi.Controllers
{
    [Route("rates")]
    public class RatesController : Controller
    {

        private readonly IRateServices _repository;
        private IMapper _mapper;

        public RatesController(IRateServices repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("add-rate")]
        public async Task<ActionResult> AddRateMarket([FromForm] Rate rate)
        {

            return Ok(await _repository.AddRate(rate));

        }


        [HttpGet]
        [Route("get-rates-trip")]
        public async Task<ActionResult> GetRatesTrip([FromForm] int tripId)
        {

            return Ok(await _repository.GetRatesByUTripId(tripId));
        }


        [HttpGet]
        [Route("get-rates-driver")]
        public async Task<ActionResult> GetRatesDriver([FromForm] int driverId)
        {

            return Ok(await _repository.GetRatesByUserId(driverId));
        }

    }
}