using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LimousineApi.Models;
using LimousineApi.Services.DriverService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LimousineApi.Controllers
{
    [Route("driver")]
    public class DriversController : ControllerBase
    {


        private readonly IDriverService _repository;
        private IMapper _mapper;
        public DriversController(IDriverService repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }



        [HttpPost]
        [Route("add-driver")]
        public async Task<ActionResult> AddDriver([FromForm] Driver driver)
        {
            if (driver == null)
            {
                return NotFound();
            }

            await _repository.AddAsync(driver);

            return Ok(driver);
        }



        [HttpPost]
        [Route("update-driver")]
        public async Task<ActionResult> UpdateDriverLocation([FromForm] AddressModel address, [FromForm] int driverId)
        {
            return Ok(await _repository.UpdateDriverLocation(address, driverId));
        }


        [HttpGet]
        [Route("get-drivers")]
        public async Task<ActionResult> GetDrivers([FromQuery] string UserId)
        {

            return Ok(await _repository.GetItems(UserId));
        }


        [HttpGet]
        [Route("get-driver-home")]
        public async Task<ActionResult> GetDriverHome([FromQuery] string UserId, [FromQuery] AddressModel addressModel)
        {

            return Ok(await _repository.HomeDriver(UserId, addressModel));
        }


    }
}