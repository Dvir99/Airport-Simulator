using AirportAPI.Models;

namespace AirportAPI.Repositories
{
    public interface IAirportRepository
    {
        Task<List<Flight>> GetFlights();
        Task<Terminal> GetFirstTerminal();
        Task<List<Terminal>> GetTerminals();
        Task<int> AddFlight(Flight flight);
        Task SaveChanges();

    }
}
