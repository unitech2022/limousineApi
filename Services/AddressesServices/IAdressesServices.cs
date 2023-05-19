using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LimousineApi.Core;

namespace LimousineApi.Services.AddressesServices
{
    public interface IAddressesServices :BaseInterface
    {
        
        Task<dynamic> DefaultAddress(int typeId,string userId);
        
    }
}