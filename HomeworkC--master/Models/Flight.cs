using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2.Models
{
   public class Flight
    {   public string PhotoPath { get; set; }
        public int Id { get; set; }
        public string PlaneName { get; set; }
       
        public int Seats { get; set; }
        public int Price { get; set; }
        public string Route { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrive { get; set; }
        public virtual ICollection<Booking> bookings { get; set; }
   
    }
}
