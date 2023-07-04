
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LimousineApi.Core;
using LimousineApi.Models;
using LimousineApi.ViewModels;

namespace LimousineApi.Services.WalletsServices
{
    public interface IWalletsServices :BaseInterface
    {
        
        Task<dynamic> AddWallet(Wallet wallet);
    
        Task<List<Wallet>> GetWalletByUserId(string userId);
         Task<dynamic> GetWalletByDriverId(string userId);

       
    }
}