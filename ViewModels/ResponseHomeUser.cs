using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LimousineApi.Models;

namespace LimousineApi.ViewModels
{
    public class ResponseHomeUser
    {
        public Trip? trip { get; set; }
       public Driver? driver { get; set; }


       public List<Address>? Addresses { get; set; }

         public UserDetailResponse? DriverDetails { get; set; }

        public UserDetailResponse? userDetail { get; set; }
        public bool tripActive { get; set; }

        public ResponseHomeUser(){
            tripActive =false;
            // اذاكان فيه حلة بالاى دى بتاعته والحال ة لا تساوى ٢
        }
    }
}