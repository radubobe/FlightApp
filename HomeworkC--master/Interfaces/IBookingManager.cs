using ConsoleApp2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2.Interfaces
{
  public  interface IBookingManager
    {
        List<Models.Booking> GetAll();
        void BookFlight(Booking book);
        void CancelBooking(int bookID);
    }
}
