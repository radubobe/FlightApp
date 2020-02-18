using ConsoleApp2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2.Repositories
{
    public class BookingRepository: RepositoryBase<Booking>,IBookingRepository
    { public BookingRepository(Models.AppContext appContext):base(appContext)
        { }
    }
}
