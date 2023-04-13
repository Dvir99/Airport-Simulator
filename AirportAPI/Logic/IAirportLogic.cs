using AirportAPI.Models;

namespace AirportAPI.Logic
{
    public interface IAirportLogic
    {
        List<Flight>? Flights { get; set; }
        Terminal? FirstTerminal { get; set; }
        Task AddToEntryPoint(Flight flight);
        Task NextTerminal(Flight flight, Terminal nextTerminal);
        Task ChangeFlightStatus(Flight flight);
    }
}
