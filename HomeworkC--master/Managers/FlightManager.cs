using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp2.Managers
{

    public class FlightManager : Interfaces.IFlightManager
    {
        private readonly ConsoleApp2.Models.AppContext _db;

        public FlightManager(ConsoleApp2.Models.AppContext db)
        {
            _db = db;
        }

        public List<Models.Flight> GetAll()
        {
            var list = _db.Flight.ToList();
            return list;
            
        }

        public Models.Flight AddFlight(Models.Flight flight)
        {
            flight.Id = 0;
            var newFlight = _db.Flight.Add(flight);
            _db.SaveChanges();
            return newFlight.Entity;

        }

    }
}
