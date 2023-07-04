using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimousineApi.Models
{
    public class Wallet
    {
        public int Id { get; set; }

        public string? UserIdTo { get; set; }

        public string? UserIdFrom { get; set; }

        public string? UserName { get; set; }

        public double Amount { get; set; }

        public string? Desc { get; set; }

        public DateTime CreateAt { get; set; }

        public Wallet()
        {

            CreateAt = DateTime.UtcNow.AddHours(3);



        }


    }
}