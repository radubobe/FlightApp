using ConsoleApp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp2.Managers
{
    public class BookingManager : Interfaces.IBookingManager
    {
        private readonly ConsoleApp2.Models.AppContext _db;

        public BookingManager(ConsoleApp2.Models.AppContext db)
        {
            _db = db;
        }
        public void BookFlight(Booking book)
        {
           
            _db.Booking.Add(book);
            _db.SaveChanges();
        }
        public void CancelBooking(int bookID)
        {
          
            Booking book = _db.Booking.SingleOrDefault(x => x.Id == bookID);
            if (book != null)
            {
                book.IsCancelled = true;
            }
            _db.SaveChanges();
        }
        public List<Models.Booking> GetAll()
        {
            var list = _db.Booking.ToList();
            return list;
        }
    }
}
