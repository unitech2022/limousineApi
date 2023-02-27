using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LimousineApi.Data;
using Microsoft.EntityFrameworkCore;

namespace LimousineApi.Services.CarTypesService
{

    public class CarTypesService : ICarTypesService
    {

            private readonly IMapper _mapper;
        private readonly AppDBcontext _context;

           public CarTypesService(IMapper mapper, AppDBcontext context)
        {
            _mapper = mapper;

            _context = context;
        }

        public async  Task<dynamic> AddAsync(dynamic type)
        {
           await _context.CarTypes!.AddAsync(type);

            await _context.SaveChangesAsync();

            return type;
        }

        public Task<dynamic> DeleteAsync(int typeId)
        {
            throw new NotImplementedException();
        }

        public async Task<dynamic> GetItems(string UserId)
        {
           var carTypes = await _context.CarTypes!.ToListAsync();

            return carTypes;
        }
        

        public async Task<dynamic> GetCarTypes()
        {
           var carTypes = await _context.CarTypes!.ToListAsync();

            return carTypes;
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
    }
}