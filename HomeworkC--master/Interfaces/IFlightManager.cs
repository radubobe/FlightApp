using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2.Interfaces
{
    public interface IFlightManager
    {
        List<Models.Flight> GetAll();
        Models.Flight AddFlight(Models.Flight flight);
       
    }
}
