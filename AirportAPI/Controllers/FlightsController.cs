using AirportAPI.Data;
using AirportAPI.Logic;
using AirportAPI.Models;
using AirportAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace AirportAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly IAirportRepository _repos;
        private readonly IAirportLogic _logic;

        public FlightsController(IAirportRepository repos, IAirportLogic logic)
        {
            _repos = repos;
            _logic = logic;
        }
        #region Http GET Calls

        [HttpGet("flights")]
        public async Task<List<Flight>> GetFlights() => await _repos.GetFlights();
        [HttpGet("departures")]
        public async Task<List<Flight>> GetDepartures() => await _repos.GetDepartures();
        [HttpGet("landings")]
        public async Task<List<Flight>> GetLandings() => await _repos.GetLandings();

        [HttpGet("terminal")]
        public async Task<Terminal> GetFirstTerminal() => await _repos.GetFirstTerminal();

        [HttpGet("terminals")]
        public async Task<List<Terminal>> GetTerminals() => await _repos.GetTerminals();

        #endregion

        [HttpPost]
        public async Task AddFlight(Flight flight)
        {
            Console.WriteLine($"POST Req From Flight No. {flight.Code}");
            _logic.FirstTerminal = await _repos.GetFirstTerminal();
            await _repos.AddFlight(flight);
            try
            {
                await _logic.AddToEntryPoint(flight);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
