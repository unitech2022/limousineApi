using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LimousineApi.Models;
using LimousineApi.Services.CarTypesService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LimousineApi.Controllers
{
    [Route("carTypes")]
    public class CarTypesController : Controller
    {
         private readonly ICarTypesService _repository;
        private IMapper _mapper;
        public CarTypesController(ICarTypesService repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

    [HttpPost]
        [Route("add-carType")]
        public async Task<ActionResult> AddDriver([FromForm] CarType carType)
        {
            if (carType == null)
            {
                return NotFound();
            }

            await _repository.AddAsync(carType);

            return Ok(carType);
        }


        [HttpGet]
        [Route("get_car_types")]
        public async Task<ActionResult> GetDrivers([FromQuery] string UserId)
        {

            return Ok(await _repository.GetCarTypes());
        }

       
    }
}