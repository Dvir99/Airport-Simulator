using AspUI.Models;

namespace AspUI.Repositories
{
    public class AirportService : IAirportService
    {
        private readonly HttpClient _client;

        public AirportService()
        {
            _client = new() { BaseAddress = new Uri("http://localhost:5059") };
        }

        public async Task<List<FlightDto>> GetFlights()
        {
            var flights = await _client.GetFromJsonAsync<List<FlightDto>>("api/Flights/flights");
            return flights != null ? flights : null!;
        }

        public async Task<TerminalDto> GetFirstTerminal()
        {
            var terminal = await _client.GetFromJsonAsync<TerminalDto>("api/Flights/terminal");
            return terminal != null ? terminal : null!;

        }
        public async Task<List<TerminalDto>> GetTerminals()
        {
            var terminals = await _client.GetFromJsonAsync<List<TerminalDto>>("api/Flights/terminals");
            return terminals != null ? terminals : null!;

        }

        public async Task StartSimulator()
        {
            await _client.GetAsync("api/Flights/start");
        }
    }
}
