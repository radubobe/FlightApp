using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelAPI.ViewModels
{
    public class BookingVM
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public string AppUserId { get; set; }
        public bool IsCancelled { get; set; }
        public int SeatsReserved { get; set; }

    }
}
