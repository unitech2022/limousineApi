using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using LimousineApi.Data;
using LimousineApi.Models;

using X.PagedList;
using LimousineApi.Models.BaseEntity;

namespace LimousineApi.Services.AddressesServices
{
    public class AddressesServices : IAddressesServices
    {
          private readonly IMapper _mapper;

       
        private readonly AppDBcontext _context;

        public AddressesServices(IMapper mapper, AppDBcontext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<dynamic> AddAsync(dynamic type)
        {
             await _context.Addresses!.AddAsync(type);

            await _context.SaveChangesAsync();

            return type;
        }

        public async Task<dynamic> DefaultAddress(int typeId,string userId)
        {

            List<Address> addresses =await _context.Addresses!.Where(t => t.UserId ==userId).ToListAsync();

            foreach (Address item in addresses)
            {
                if(item.Id == typeId){
                    item.Default=true;
                
            }else {
                item.Default=false;
            }
            }
            await  _context.SaveChangesAsync();
            Address? address=await _context.Addresses!.FirstOrDefaultAsync(t => t.Id ==typeId&& t.UserId == userId);

            return address!;
              
            
        }

        public async Task<dynamic> DeleteAsync(int typeId)
        {
            Address? address = await _context.Addresses!.FirstOrDefaultAsync(x => x.Id == typeId);

            if (address != null)
            {
                _context.Addresses!.Remove(address);

                await _context.SaveChangesAsync();
            }

            return address!;
        }

        public Task<dynamic> GetAddress(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<dynamic> GetItems(string UserId, int page)
        {
            List<Address> addresses = await _context.Addresses!.OrderByDescending(t => t.Default).Where(i => i.UserId==UserId ).ToListAsync();
           
            //  if(addresses.Count > 0){
            //     Address? defaultAddress= addresses!.FirstOrDefault(t => t.DefaultAddress=true);
            //     if(defaultAddress != null){
            //         addresses.Remove(defaultAddress);
            //         // addresses.Insert(1,defaultAddress);
            //     }
            //  }

            var pageResults = 20f;
            var pageCount = Math.Ceiling(addresses.Count() / pageResults);

            var items = await addresses
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults)
                .ToListAsync();



            BaseResponse baseResponse = new BaseResponse
            {
                Items = items,
                CurrentPage = page,
                TotalPages = (int)pageCount
            };

            return baseResponse;
        }

        public async Task<dynamic> GetItems(string UserId)
        {
            List<Address> addresses =await _context.Addresses!.Where(t => t.UserId ==UserId).ToListAsync();

            return addresses;
        }

        public Task<dynamic> GetItemsPage(string UserId, int page)
        {
            throw new NotImplementedException();
        }

        public async Task<dynamic> GitById(int typeId)
        {
            Address? address = await _context.Addresses!.FirstOrDefaultAsync(x => x.Id == typeId);
            return address!;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateObject(dynamic category)
        {
            // 
        }
    }
}