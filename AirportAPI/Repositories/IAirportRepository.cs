using AirportAPI.Models;

namespace AirportAPI.Repositories
{
    public interface IAirportRepository
    {
        Task<List<Flight>> GetFlights();
        Task<List<Flight>> GetDepartures();
        Task<List<Flight>> GetLandings();
        Task<Terminal> GetFirstTerminal();
        Task<List<Terminal>> GetTerminals();
        Task<int> AddFlight(Flight flight);
        Task SaveChanges();

    }
}
