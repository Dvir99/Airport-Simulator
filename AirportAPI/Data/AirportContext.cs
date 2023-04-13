using AirportAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AirportAPI.Data
{
    public class AirportContext : DbContext
    {
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<Terminal> Terminals { get; set; }
        public virtual DbSet<Logger> Logger { get; set; }
        public AirportContext(DbContextOptions<AirportContext> options) : base(options) { }

    }
}
