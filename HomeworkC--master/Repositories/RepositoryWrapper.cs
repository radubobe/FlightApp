using System;
using System.Collections.Generic;
using System.Text;
namespace ConsoleApp2.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private Models.AppContext _appContext;
        private IBookingRepository _booking;
        private IPassagerRepository _passager;
        private IFlightRepository _flight;
        private IUserRepository _appUser;

        public IBookingRepository Booking
        {
            get
            {
                if (_booking == null)
                {
                    _booking = new BookingRepository(_appContext);
                }

                return _booking;
            }
        }

        public IPassagerRepository Passager
        {
            get
            {
                if (_passager == null)
                {
                    _passager = new PassagerRepository(_appContext);
                }

                return _passager;
            }
        }


        public IFlightRepository Flight
        {
            get
            {
                if (_flight == null)
                {
                    _flight = new FlightRepository(_appContext);
                }

                return _flight;
            }
        }

        public IUserRepository User
        {
            get
            {
                if (_appUser == null)
                {
                    _appUser = new UserRepository(_appContext);
                }

                return _appUser;
            }
        }

        public RepositoryWrapper(Models.AppContext appContext)
        {
            _appContext = appContext;
        }

        public void Save()
        {
            _appContext.SaveChanges();
        }
    }
}
