using AirportAPI.Data;
using AirportAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AirportAPI.Repositories
{
    public class AirportRepository : IAirportRepository
    {
        private readonly AirportContext data;

        public AirportRepository(AirportContext data)
        {
            this.data = data;
        }

        public async Task<List<Flight>> GetFlights()
        {
            return await data.Flights.ToListAsync();
        }

        public async Task<Terminal> GetFirstTerminal()
        {
            return await data.Terminals.FirstOrDefaultAsync(t => t.Number == 1);
        }

        public async Task<List<Terminal>> GetTerminals()
        {
            return await data.Terminals.ToListAsync();
        }

        public async Task<int> AddFlight(Flight flight)
        {
            await data.Flights.AddAsync(flight);
            var res = await data.SaveChangesAsync();
            return res;
        }

        public async Task SaveChanges()
        {
            await data.SaveChangesAsync();
        }
    }
}
