using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2.Models
{ 
    public class Booking
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public string AppUserID { get; set; }
        public bool IsCancelled { get; set; }

        public int SeatsReserved { get; set; }

        public virtual AppUser AppUser{ get; set; }
        public virtual Flight Flight { get; set; }
    }
}
