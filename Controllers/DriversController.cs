using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LimousineApi.Data;
using LimousineApi.Models;
using LimousineApi.Services.DriverService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LimousineApi.Controllers
{
    [Route("driver")]
    public class DriversController : ControllerBase
    {


        private readonly IDriverService _repository;
        private IMapper _mapper;
        private readonly AppDBcontext _context;
        public DriversController(IDriverService repository, IMapper mapper, AppDBcontext context)
        {
            _repository = repository;
            _mapper = mapper;
            _context = context;
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
        [Route("update-driver-location")]
        public async Task<ActionResult> UpdateDriverLocation([FromForm] AddressModel address, [FromForm] int driverId)
        {
            return Ok(await _repository.UpdateDriverLocation(address, driverId));
        }



        [HttpPost]
        [Route("update-driver")]
        public async Task<ActionResult> UpdateDriver([FromForm] Driver update)
        {
            return Ok(await _repository.UpdateDriver(update));
        }

        [HttpPost]
        [Route("update-status-driver")]
        public async Task<ActionResult> UpdateStatusDriver([FromForm] int status, [FromForm] int driverId)
        {
            return Ok(await _repository.ChangeDriverStatus(driverId, status));
        }

        [HttpGet]
        [Route("get-drivers")]
        public async Task<ActionResult> GetDrivers([FromQuery] string UserId)
        {

            return Ok(await _repository.GetItems(UserId));
        }


        [HttpGet]
        [Route("get-driver-by-id")]
        public async Task<ActionResult> GetDriverById([FromQuery] int driverId)
        {

            return Ok(await _repository.GetDriverById(driverId));
        }

        [HttpGet]
        [Route("get-driver-home")]
        public async Task<ActionResult> GetDriverHome([FromQuery] string UserId, [FromQuery] AddressModel addressModel)
        {
            Driver? driver = await _context.Drivers!.FirstOrDefaultAsync(t => t.UserId == UserId);
            if (driver == null)
            {
                return NotFound();
            }


            return Ok(await _repository.HomeDriver(UserId, addressModel));
        }


    }
}