using AspUI.Models;

namespace AspUI.Repositories
{
    public interface IAirportService
    {
        Task<List<FlightDto>> GetFlights();
        Task<List<FlightDto>> GetDepartures();
        Task<List<FlightDto>> GetLandings();
        Task<TerminalDto> GetFirstTerminal();
        Task<List<TerminalDto>> GetTerminals();
        Task StartSimulator();

    }
}
