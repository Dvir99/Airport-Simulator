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

        public async Task<IActionResult> Index() 
        {
            var flights = await _airportService.GetFlights();
            return View(flights);
        }
        public async Task<IActionResult> Privacy()
        {
            var terminals = await _airportService.GetTerminals();
            ViewBag.Flights = _airportService.GetFlights();
            return View(terminals);
        }
       
    }
}