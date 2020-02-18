using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ConsoleApp2.Interfaces;
using ConsoleApp2.Models;
using ConsoleApp2.Repositories;
using HotelAPI.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : Controller
    {
        private readonly IFlightManager _manager;
        private readonly IFlightRepository _flightRepository;
        
        private readonly IHostingEnvironment hostingEnvironment;


        public FlightController (IFlightManager manager,IFlightRepository flightRepository,IHostingEnvironment hostingEnvironment)
        {
            _manager = manager;

            _flightRepository = flightRepository;
            this.hostingEnvironment = hostingEnvironment;
        }
       

        [HttpGet]
        public IEnumerable<Flight> Get()
        {
             return _manager.GetAll();

        }

       

        [HttpGet("GetAllFlights")]
        public async Task<IActionResult> GetAllFlightsAsync()
        {
            List<Flight> result = await _flightRepository.GetAllAsync();
            return Ok(result);
        }

        [HttpPost]
        public void Post(FlightVM flight)
        {

            var _flight = new Flight { Id = flight.Id, PlaneName = flight.PlaneName, Seats = flight.Seats, Route = flight.Route };
           _manager.AddFlight(_flight);
        }

        [HttpPost("PostFlightAsync")]
        public async Task<IActionResult> PostAsync(FlightVM flight)
        {
            var _flight = new Flight { Id = flight.Id, PlaneName = flight.PlaneName, Seats = flight.Seats, Route = flight.Route };

            await _flightRepository.CreateAsync(_flight);
            return Ok();
        }

        [HttpPut]
        public Flight Put(Flight flight)
        {
            return _flightRepository.Update(flight);
        }

        [HttpPost("DeleteFlight")]
        public IActionResult DeleteFlight(string id)
        {
            
            
           _flightRepository.DeleteFlight(int.Parse(id));


            return RedirectToAction("AdminFlightView", "flight");


        }


        [HttpGet("AdminFlightView")]
        public ActionResult AdminFlightView()
        {
            var model = _manager.GetAll();
            return View(model);
        }

        [HttpGet("UserFlightView")]
        public ActionResult UserFlightView()
        {
            var model = _manager.GetAll();
            return View(model);
        }

        [HttpGet("CreateFlight")]
        public ViewResult CreateFlight()
        {
            return View();
        }

        // public async Task<FlightVM> Add([FromBody]FlightVM flight)
        [HttpPost("CreateFlight")]
        
        public async Task<IActionResult> CreateFlight([FromForm] FlightVM model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;

               
                if (model.Photo != null)
                {
                   
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    string[] splitwords = model.Photo.FileName.Split("\\");
                    uniqueFileName = splitwords[splitwords.Count()-1];
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                Flight newFlight = new Flight
                {
                    Id = model.Id,
                    PlaneName = model.PlaneName,

                    Seats = model.Seats,
                    Price = model.Price,
                    Route = model.Route,
                    Departure = model.Departure,
                    Arrive = model.Arrive,

                    // Store the file name in PhotoPath property of the flight object
                    // which gets saved to the Flight database table
                    PhotoPath = uniqueFileName
                };

                await _flightRepository.CreateAsync(newFlight);
                return RedirectToAction("AdminFlightView", "flight");

            }
            return View();

        }
    }
   


}
