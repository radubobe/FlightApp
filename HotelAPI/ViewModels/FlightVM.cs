using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelAPI.ViewModels
{
    public class FlightVM
    {  
        
        public int Id { get; set; }
        public string PlaneName { get; set; }

        public int Seats { get; set; }
        public int Price { get; set; }
        public string Route { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrive { get; set; }
        public IFormFile Photo { get; set; }
    }
}
