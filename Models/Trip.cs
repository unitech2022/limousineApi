using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimousineApi.Models
{

    //     users id name userName deviceToken image createdAt

    // carTypes id name image price sets createdAt

    // drivers id userId lat lng carId zoneId passport drivingLicense carImage carModleId carMakeYear status(int) createdAt

    // Areas id name status createdAt

    // zones id name polygon status createdAt

    // Trips id startPoint endPoint startAddress endAdress userId driverId price carId OTP status payment createdAt
    public class Trip
    {
        public int id { get; set; }
        public int driverId { get; set; }

        public int carId { get; set; }
        public double price { get; set; }
        public string? userId { get; set; }
        public double startPointLat { get; set; }
        public double startPointLng { get; set; }

        public double endPointLat { get; set; }
        public double endPointLng { get; set; }

        public string? startAddress { get; set; }

        public string? endAddress { get; set; }

        public string? OTP { get; set; }

        public int status { get; set; }

        public int payment { get; set; }

        public DateTime CreatedAt { get; set; }

        public Trip()
        {

            CreatedAt = DateTime.UtcNow.AddHours(3);
        }
    }
}