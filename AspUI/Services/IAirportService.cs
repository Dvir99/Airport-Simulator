using AspUI.Models;

namespace AspUI.Repositories
{
    public interface IAirportService
    {
        Task<List<FlightDto>> GetFlights();
        Task<TerminalDto> GetFirstTerminal();
        Task<List<TerminalDto>> GetTerminals();
        Task StartSimulator();

    }
}
