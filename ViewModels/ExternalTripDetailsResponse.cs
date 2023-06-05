using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LimousineApi.Models;

namespace LimousineApi.ViewModels
{
    public class ExternalTripDetailsResponse
    {
        public ExternalTrip? trip { get; set; }

        public List<BookingResponse>? bookingsResponse { get; set; }

    }

       public class BookingResponse
    {
        public Booking? booking { get; set; }

        public UserDetailResponse? userDetail { get; set; }

    }



 

          public class ExternalTripDetailsUser
    {
        public ExternalTrip? trip { get; set; }

        public Driver? driver { get; set; }

         public UserDetailResponse? profileDriver { get; set; }
         

         public bool isBooking { get; set; }

    }
   
}



