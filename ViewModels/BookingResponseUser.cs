using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LimousineApi.Models;

namespace LimousineApi.ViewModels
{
    public class BonkingResponseUser
    {
        public ExternalTrip? trip { get; set; }

        public Booking? booking { get; set; }
    }
}