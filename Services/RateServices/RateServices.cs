using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using LimousineApi.Data;
using LimousineApi.Models;
using LimousineApi.Models.BaseEntity;
using X.PagedList;

namespace LimousineApi.Services.RateServices
{
    public class RateServices : IRateServices
    {
        private readonly IMapper _mapper;


        private readonly AppDBcontext _context;

        public RateServices(IMapper mapper, AppDBcontext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public Task<dynamic> AddAsync(dynamic type)
        {
            throw new NotImplementedException();
        }

        public async Task<dynamic> AddRate(Rate rate)
        {
            await _context.Rates!.AddAsync(rate);
            Driver? driver = await _context.Drivers!.FirstOrDefaultAsync(t => t.Id == rate.DriverId);
              _context.SaveChanges();
            if (driver != null)
            {
                List<Rate> rates = await _context.Rates!.Where(t => t.DriverId == rate.DriverId).ToListAsync();
                //culact rate WorkShop
                int rateConte = rates.Count();
                 Console.WriteLine("rateConte"+rateConte);
                int stars = rates.Sum(t => t.Stare);
                Console.WriteLine("stars"+stars);
                double totalRate = stars / rateConte;
                Console.WriteLine("rate"+totalRate);
                driver!.Rate = totalRate;

            }

            _context.SaveChanges();

            return new
            {
                message = "تم التقييم بنجاح ",
                rate = rate
            };
        }

        public async Task<dynamic> DeleteAsync(int typeId)
        {
            Rate? rate = await _context.Rates!.FirstOrDefaultAsync(x => x.Id == typeId);

            if (rate != null)
            {
                _context.Rates!.Remove(rate);

                await _context.SaveChangesAsync();
            }

            return rate!;
        }

        public Task<dynamic> GetItems(string UserId)
        {
            throw new NotImplementedException();
        }

        public Task<dynamic> GetItemsPage(string UserId, int page)
        {
            throw new NotImplementedException();
        }

        public async Task<dynamic> GetRatesByUserId(int driverId)
        {
            var data = await _context.Rates!.Where(t => t.DriverId == driverId).ToListAsync();

            return data;
        }

        public async Task<dynamic> GetRatesByUTripId(int tripId)
        {
            var data = await _context.Rates!.Where(t => t.TripId == tripId).ToListAsync();

            return data;
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

        // public async Task<dynamic> AddAsync(dynamic type)
        // {
        //      await _context.Addresses!.AddAsync(type);

        //     await _context.SaveChangesAsync();

        //     return type;
        // }

        // public async Task<dynamic> AddRate(Rate rate)
        // {
        //      Rate? checkRate=await _context.Rates!.FirstOrDefaultAsync(t => t.UserId ==rate.UserId&&t.MarketId==rate.MarketId);
        //     Market? market = await _context.Markets!.FirstOrDefaultAsync(t => t.Id == rate.MarketId);
        //    if(checkRate==null){

        //    await _context.Rates!.AddAsync(rate);
        //     _context.SaveChanges();
        //     List<Rate> rates = await _context.Rates!.Where(t => t.MarketId == rate.MarketId).ToListAsync();

        //     //culact rate WorkShop
        //     int rateConte = rates.Count();
        //     // Console.WriteLine("rateConte"+rateConte);
        //     int stars = rates.Sum(t => t.Stare);
        //     // Console.WriteLine("stars"+stars);
        //     double totalRate= stars / rateConte;
        //     // Console.WriteLine("rate"+totalRate);
        //     market!.Rate =totalRate; 
        //     _context.SaveChanges();
        //     return new{
        //         message ="تم التقييم بنجاح ",
        //         rate =rate
        //     };
        //    }else {
        //     List<Rate> rates = await _context.Rates!.Where(t => t.MarketId == rate.MarketId).ToListAsync();
        //     checkRate.Stare =rate.Stare;
        //     int rateConte = rates.Count();
        //     // Console.WriteLine("rateConte"+rateConte);
        //     int stars = rates.Sum(t => t.Stare);
        //     // Console.WriteLine("stars"+stars);
        //     double totalRate= stars / rateConte;
        //     // Console.WriteLine("rate"+totalRate);
        //     market!.Rate =totalRate; 
        //     _context.SaveChanges();


        //     return new {
        //         message="تم تعديل التقييم ",
        //         rate =rate
        //     };
        //    }

        // }


        // public async Task<dynamic> DeleteAsync(int typeId)
        // {
        //     Address? address = await _context.Addresses!.FirstOrDefaultAsync(x => x.Id == typeId);

        //     if (address != null)
        //     {
        //         _context.Addresses!.Remove(address);

        //         await _context.SaveChangesAsync();
        //     }

        //     return address!;
        // }

        // public async Task<dynamic> GetItems(string UserId, int page)
        // {
        //     List<Address> addresses = await _context.Addresses!.OrderByDescending(t => t.DefaultAddress).Where(i => i.UserId==UserId ).ToListAsync();

        //     //  if(addresses.Count > 0){
        //     //     Address? defaultAddress= addresses!.FirstOrDefault(t => t.DefaultAddress=true);
        //     //     if(defaultAddress != null){
        //     //         addresses.Remove(defaultAddress);
        //     //         // addresses.Insert(1,defaultAddress);
        //     //     }
        //     //  }

        //     var pageResults = 20f;
        //     var pageCount = Math.Ceiling(addresses.Count() / pageResults);

        //     var items = await addresses
        //         .Skip((page - 1) * (int)pageResults)
        //         .Take((int)pageResults)
        //         .ToListAsync();



        //     BaseResponse baseResponse = new BaseResponse
        //     {
        //         Items = items,
        //         CurrentPage = page,
        //         TotalPages = (int)pageCount
        //     };

        //     return baseResponse;
        // }

        // public Task<dynamic> GitById(int typeId)
        // {
        //     throw new NotImplementedException();
        // }

        // public bool SaveChanges()
        // {
        //     return (_context.SaveChanges() >= 0);
        // }

        // public void UpdateObject(dynamic category)
        // {
        //     throw new NotImplementedException();
        // }


    }
}