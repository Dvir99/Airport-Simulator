using FlightsGenerator.Models;
using System.Net.Http.Json;


HttpClient client = new() { BaseAddress = new Uri("http://localhost:5059") };


System.Timers.Timer timer = new System.Timers.Timer(25000);
timer.Elapsed += async (s, e) => await CreateFlight();
timer.Start();

Console.ReadLine();


async Task CreateFlight()
{
    var flight = new FlightDto();
    var response = await client.PostAsJsonAsync("api/Flights", flight);
    if (response.IsSuccessStatusCode)
        Console.WriteLine($"Flight No. {flight.Code} Posted To API");
}

