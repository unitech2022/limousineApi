using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LimousineApi.Models;

namespace LimousineApi.ViewModels
{
    public class HistoryResponse
    {
        public Driver? driver { get; set; }

        public  Trip? trip { get; set; }

        public UserDetailResponse? userDetailDiver { get; set; }

        public CarType? carType { get; set; }
    }
}