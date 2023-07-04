using System;
using Microsoft.AspNetCore.Identity;

namespace LimousineApi.Models
{
    public class Driver
    {
        public int Id { get; set; }

        public string? UserId { get; set; }

        public double? Lat { get; set; }
        public double? Lng { get; set; }
        public int ZoneId { get; set; }
        public string? Passport { get; set; }
        public string? DrivingLicense { get; set; }
        public string? CarImage { get; set; }
        public int CarModelId { get; set; }

        public string? CarMakeYear { get; set; }

        public int Status { get; set; }

        public double? Rate { get; set; }

        public double? Wallet { get; set; }
        public DateTime CreatedAt { get; set; }

        public Driver()
        {
			Lat =0.0;
			Lng=0.0;
            Rate=0.0;
            Wallet=0.0;

            CreatedAt = DateTime.UtcNow.AddHours(3);
        }

    }
}