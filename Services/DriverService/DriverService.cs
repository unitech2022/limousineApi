using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LimousineApi.Data;
using LimousineApi.Models;
using LimousineApi.ViewModels;
using Microsoft.EntityFrameworkCore;
using WajedApi.Helpers;

namespace LimousineApi.Services.DriverService
{
    public class DriverService : IDriverService
    {

        private readonly IMapper _mapper;
        private readonly AppDBcontext _context;

        public DriverService(IMapper mapper, AppDBcontext context)
        {
            _mapper = mapper;

            _context = context;
        }

        public async Task<dynamic> AddAsync(dynamic type)
        {
            await _context.Drivers!.AddAsync(type);

            await _context.SaveChangesAsync();

            return type;
        }

        public Task<dynamic> DeleteAsync(int typeId)
        {
            throw new NotImplementedException();
        }



        public async Task<dynamic> GetItems(string userId)
        {
            List<Driver> drivers = await _context.Drivers!.ToListAsync();

            return drivers;
        }

        public Task<dynamic> GetItemsPage(string UserId, int page)
        {
            throw new NotImplementedException();
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


        public async Task<dynamic> UpdateDriverLocation(AddressModel type, int driverId)
        {
            Driver? driver = await _context.Drivers!.FirstOrDefaultAsync(t => t.Id == driverId);
            if (driver != null)
            {
                driver.Lat = type.Lat;
                driver.Lng = type.Lang;
                await _context.SaveChangesAsync();
            }


            return driver!;
        }

        public async Task<dynamic> HomeDriver(string userId, AddressModel addressModel)
        {
            Driver? driver = await _context.Drivers!.FirstOrDefaultAsync(t => t.UserId == userId);
            User? user = await _context.Users!.FirstOrDefaultAsync(t => t.Id == userId);
            //  update lat lng    
            if (driver != null)
            {
                driver.Lat = addressModel.Lat;
                driver.Lng = addressModel.Lang;

                await _context.SaveChangesAsync();
            }

         

            Trip? trip = await _context.Trips!.FirstOrDefaultAsync(t => t.status == 0 && t.driverId == driver!.Id);

            ResponseHomeDriver homeDriver = new ResponseHomeDriver
            {
                driver = driver,
                user = user,
                trip = trip
            };


            return homeDriver;
        }
    }
}