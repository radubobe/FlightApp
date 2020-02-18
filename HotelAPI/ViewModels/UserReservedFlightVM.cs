using ConsoleApp2.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelAPI.ViewModels
{
    public class UserReservedFlightVM
    {
        public string PlaneName { get; set; }
        public int Price { get; set; }
        public string Route { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrive { get; set; }
        public bool IsCancelled { get; set; }
        public int SeatsReserved { get; set; }

        public string PhotoPath { get; set; }

        public int BookId { get; set; }
        public string UserId { get; set; }
        public string FlightId { get; set; }



    }
}
