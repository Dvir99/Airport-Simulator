using AirportAPI.Data;
using AirportAPI.Models;
using AirportAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AirportAPI.Logic
{
    public class AirportLogic : IAirportLogic
    {
        public List<Flight>? Flights { get; set; }
        public Terminal? FirstTerminal { get; set; }

        private readonly AirportContext _data;

        public AirportLogic(AirportContext data)
        {
            _data = data;
        }

        public async Task AddToEntryPoint(Flight flight)
        {
            if (flight.IsDeparture)
            {
                return;
            }
            else
            {
                if (FirstTerminal.FlightId != 0)
                {
                    Thread.Sleep(8000);
                    await AddToEntryPoint(flight);
                }
                else
                {
                    if (!flight.IsDeparture)
                    {
                        FirstTerminal.FlightId = flight.Id;
                        await _data.SaveChangesAsync();
                        await NextTerminal(flight, FirstTerminal);
                    }
                }
            }
        }

        public async Task NextTerminal(Flight flight, Terminal terminal)
        {
            var log = new Logger { Flight = flight, Terminal = terminal, In = DateTime.Now };
            await _data.Logger.AddAsync(log);
            Print($"Flight No. {flight.Code} Reached Terminal {terminal.Number} ({DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")})");

            Thread.Sleep(terminal.WaitTime * 1000);
            var nextTerminal = await _data.Terminals.FirstOrDefaultAsync(t => terminal.NextTerm.HasFlag(t.CurrentTerm));
            if (terminal.CurrentTerm == TerminalNum.Fou && flight.IsDeparture)
            {
                log.Out = DateTime.Now;
                terminal.FlightId = 0;
                Print($"Flight No. {flight.Code}: DEPARTURE from {terminal.Number} successfully! ({DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")})");
                flight.Status = "Departed";
                await _data.SaveChangesAsync();
                return;
            }
            else if (nextTerminal?.FlightId == 0)
            {
                nextTerminal!.FlightId = flight.Id;
                terminal.FlightId = 0;
                log.Out = DateTime.Now;
                await _data.SaveChangesAsync();


            }
            if (terminal.CurrentTerm == TerminalNum.Fou && !flight.IsDeparture)
            {
                flight.Status = "Landed";
                await _data.SaveChangesAsync();
            }
            if (terminal.CurrentTerm == TerminalNum.Fiv)
            {
                flight.Status = "Heading to Passengers Terminal";
                await _data.SaveChangesAsync();
            }
            if (terminal.CurrentTerm == TerminalNum.Eig)
            {
                flight.Status = "Preparing to Takeoff";
                await _data.SaveChangesAsync();
            }
            if (terminal.CurrentTerm == TerminalNum.Six || terminal.CurrentTerm == TerminalNum.Sev)
            {
                await ChangeFlightStatus(flight);

            }
            await NextTerminal(flight, nextTerminal!);

        }

        public async Task ChangeFlightStatus(Flight flight)
        {
            flight.IsDeparture = true;
            flight.Status = "Loading Passengers";
            await _data.SaveChangesAsync();
        }


        public static void Print(string message)
        {
            Console.Out.WriteLine();
            Console.Out.WriteLine("-------------------------------------------------------------");
            Console.WriteLine(message);
            Console.Out.WriteLine("-------------------------------------------------------------");
            Console.Out.WriteLine();
        }
    }
}
