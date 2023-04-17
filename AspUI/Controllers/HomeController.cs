using AspUI.Models;
using AspUI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace AspUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAirportService _airportService;

        public HomeController(IAirportService repos)
        {
            _airportService = repos;
        }

        public async Task<IActionResult> Landings() 
        {
            var flights = await _airportService.GetLandings();
            return View(flights);
        }
        public async Task<IActionResult> Departures()
        {
            var flights = await _airportService.GetDepartures();
            return View(flights);
        }
        public async Task<IActionResult> Terminals()
        {
            var terminals = await _airportService.GetTerminals();
            ViewBag.Flights = _airportService.GetFlights();
            return View(terminals);
        }

    }
}