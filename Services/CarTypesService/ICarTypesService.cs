using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LimousineApi.Core;

namespace LimousineApi.Services.CarTypesService
{
    public interface ICarTypesService :BaseInterface
    {
        Task<dynamic> GetCarTypes();
    }
}