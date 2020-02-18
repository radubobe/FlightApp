using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleApp2.Interfaces;
using ConsoleApp2.Models;
using ConsoleApp2.Repositories;
using HotelAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : Controller
    {
        private readonly IBookingManager bookManager;
        private readonly IBookingRepository _bookRepository;
        private readonly IFlightRepository _flightRepository;


        public BookingController(IBookingManager bookManager, IBookingRepository bookRepository, IFlightRepository flightRepository)
        {
            this.bookManager = bookManager;
            _bookRepository = bookRepository;
            _flightRepository = flightRepository;
        }

        [HttpPost]
        public void Post(Booking book)
        {
            bookManager.BookFlight(book);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBookings()
        {
            var result = await _bookRepository.GetAllAsync();
            return Ok(result);
        }

        [HttpPost("PostBookAsync")]
        public async Task<IActionResult> PostAsync(BookingVM book)
        {
            var _booking = new Booking
            {
                Id = book.Id,
                FlightId = book.FlightId,
                IsCancelled = book.IsCancelled,
                AppUserID = book.AppUserId
            };
            await _bookRepository.CreateAsync(_booking);
            return Ok();
        }

        [HttpPut]
        public Booking Put(Booking room)
        {
            return _bookRepository.Update(room);
        }

        [HttpDelete]
        public void Delete(Booking book)
        {
            _bookRepository.Delete(book);
        }
        [HttpDelete("CancelBooking")]
        public void Delete(int bookId)
        { bookManager.CancelBooking(bookId); }


        [HttpGet("MyBookings")]
        public async Task<IActionResult> MyBookingsAsync(string UserId)
        {
            // get all available bookings
            var bookings = await _bookRepository.GetAllAsync();

            List<UserReservedFlightVM> _userReservedFlightsVM = new List<UserReservedFlightVM>();

            // transform from Booking to BookingVM and take into consideration only user specific bookings
            foreach (var booking in bookings)
            {
                //if we found a booking
                if (booking.AppUserID == UserId)
                {
                    //get the flight 
                    var result = _flightRepository.GetOneByConditionAsync(u => u.Id == booking.FlightId);

                    var flight = result.Result;
                    var _userReservedFlight = new UserReservedFlightVM
                    {
                        PlaneName = flight.PlaneName,
                        Price = flight.Price,
                        Route = flight.Route,
                        Departure = flight.Departure,
                        Arrive = flight.Arrive,
                        IsCancelled = booking.IsCancelled,
                        SeatsReserved = booking.SeatsReserved,
                        BookId = booking.Id,
                        PhotoPath = flight.PhotoPath

                    };

                    _userReservedFlightsVM.Add(_userReservedFlight);

                }


            }
            return View(_userReservedFlightsVM);
        }

        [HttpGet("MakeBooking")]
        public async Task<IActionResult> MakeBooking(string flightId, string userId)
        {
            var result = _flightRepository.GetOneByConditionAsync(u => u.Id == int.Parse(flightId));
            var flight = result.Result;

            UserReservedFlightVM userReservedFlight = new UserReservedFlightVM
            {
                PlaneName = flight.PlaneName,
                Price = flight.Price,
                Route = flight.Route,
                Departure = flight.Departure,
                Arrive = flight.Arrive,
                UserId = userId,
                FlightId = flightId,
                PhotoPath = flight.PhotoPath
            };

            return View(userReservedFlight);

        }

        [HttpPost("MakeBooking")]
        public async Task<IActionResult> MakeBookingPost(string flightId, string userId)
        {
            // get the value that the user has introduced for number of reserved seats
            int reservedSeats;
            try
            {
                reservedSeats = int.Parse(Request.Form["NumberOfReservedSeats"].ToString());

            }
            catch (Exception ex)
            {
                //page for something went wrong
                return RedirectToAction("BookingFailed", "booking");

            }

            // first, check to see if the user already has a booking on that flight
            var bookingsResult = await _bookRepository.GetAllAsync();

            foreach (var booking in bookingsResult)
            {
                //if it exist, only update the number of rezerved seats
                if (booking.AppUserID == userId && booking.FlightId == int.Parse(flightId))
                {

                    var resultedFlight = _flightRepository.GetOneByConditionAsync(u => u.Id == int.Parse(flightId));
                    var flightToUpdate = resultedFlight.Result;
                    if (flightToUpdate.Seats < reservedSeats || reservedSeats <= 0)
                    {
                        return RedirectToAction("BookingFailed", "booking");
                    }

                    // update the flight by decreasing the number of seats
                    flightToUpdate.Seats -= reservedSeats;

                    // update the booking by adding the number of seats
                    booking.SeatsReserved += reservedSeats;
                    _bookRepository.Update(booking);
                    _flightRepository.Update(flightToUpdate);

                    return RedirectToAction("UpdatedBookingSuccessful", "booking");
                }

            }

            // if there is not already a booking on this flight, make one

            var result = _flightRepository.GetOneByConditionAsync(u => u.Id == int.Parse(flightId));
            var flight = result.Result;

            // decrease the number of reserved seats from the total number of the seats of the respective flight
            if (flight.Seats < reservedSeats || reservedSeats <= 0)
            {
                return RedirectToAction("BookingFailed", "booking");
            }

            flight.Seats -= reservedSeats;
            _flightRepository.Update(flight);

            var _booking = new Booking
            {
                FlightId = int.Parse(flightId),
                IsCancelled = false,
                AppUserID = userId,
                SeatsReserved = reservedSeats
            };
            await _bookRepository.CreateAsync(_booking);

            return RedirectToAction("BookingSuccessful", "booking");

        }

        [HttpGet("BookingSuccessful")]
        public IActionResult BookingSuccessful()
        {
            return View();
        }

        [HttpGet("UpdatedBookingSuccessful")]
        public IActionResult UpdatedBookingSuccessful()
        {
            return View();
        }

        [HttpGet("BookingFailed")]
        public IActionResult BookingFailed()
        {
            return View();
        }

        [HttpGet("BookingCancelSuccessful")]
        public IActionResult BookingCancelSuccessful()
        {
            return View();
        }

        [HttpPost("DeleteBooking")]
        public async Task<IActionResult> DeleteBooking(string bookingId)
        {
            var _booking = _bookRepository.GetOneByConditionAsync(u => u.Id == int.Parse(bookingId)).Result;
            var flight = _flightRepository.GetOneByConditionAsync(u => u.Id == _booking.FlightId).Result;
            flight.Seats += _booking.SeatsReserved;
           
            _flightRepository.Update(flight);

            _bookRepository.Delete(_booking);

            return RedirectToAction("BookingCancelSuccessful", "booking");
        }
    }
}