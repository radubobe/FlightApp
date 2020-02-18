using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2.Repositories
{
    public interface IRepositoryWrapper
    {
        IPassagerRepository Passager { get; }
        IFlightRepository Flight { get; }
        IBookingRepository Booking { get; }
        void Save();
    }
}
