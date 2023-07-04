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
using LimousineApi.ViewModels;
using WajedApi.Helpers;

namespace LimousineApi.Services.WalletsServices
{
    public class WalletsServices : IWalletsServices
    {
        private readonly IMapper _mapper;


        private readonly AppDBcontext _context;

        public WalletsServices(IMapper mapper, AppDBcontext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public Task<dynamic> AddAsync(dynamic type)
        {
            throw new NotImplementedException();
        }

        public async Task<dynamic> AddWallet(Wallet wallet)
        {
         await  _context.Wallets!.AddAsync(wallet);

         return wallet;
        }

        public Task<dynamic> DeleteAsync(int typeId)
        {
            throw new NotImplementedException();
        }

        public Task<dynamic> GetItems(string UserId)
        {
            throw new NotImplementedException();
        }

        public Task<dynamic> GetItemsPage(string UserId, int page)
        {
            throw new NotImplementedException();
        }

        public async Task<dynamic> GetWalletByDriverId(string userId)
        {
            User? user=await _context.Users.FirstOrDefaultAsync(t=>t.Id==userId);
            Driver? driver=await _context.Drivers!.FirstOrDefaultAsync(t=>t.UserId==userId);
           List<Wallet> wallets =await _context.Wallets!.Where(t=>t.UserIdTo==userId || t.UserIdFrom==userId).ToListAsync();

           UserDetailResponse userDetailResponse=_mapper.Map<UserDetailResponse>(user);

           return  new {
            user = userDetailResponse,
            wallets= wallets,
            driver=driver
           };
        }

        public Task<List<Wallet>> GetWalletByUserId(string userId)
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