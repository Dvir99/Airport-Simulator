# Airport Simulator

This is a fully independant software, containing 3 projects:

1. AirportApi - The server, listening to GET and POST requests
2. FlightsGenerator - A console app that create new flights and sends them with post request to the api
3. AspUI - User Interface, responsible to show the progress of flights in our airport.

So.. how does it work?

The airport is divided into 8 Terminals (stations) with different waiting time on each one:

1-3: On-air terminal

4: The runway

5: Way station

6-7: Passengers terminal

8: Way station

Each flight starts at terminal 1 until its landing on terminal 4

The flight starts to head towards the passengers terminals and enter one of them (6/7)

After that flight is loaded with passengers, it goes to terminal 8 to prepare to takeoff

Last station is terminal 4, the runway, where the flight takes off and finish the track.


This is the airport's track. Each terminal can be occupied by 1 flight only, so if a terminal is already occupied, next flight will wait.

Every few seconds a new flight will be sent to the api (POST request) and there it'll start moving through the airport, making few flights move simultaneously in the airport.

All you got to do is to run the project, open the asp web-app on browser and wait for flights to come!

P.S: all the details about the flights, their progress and the terminals are saved in the Sql-Server database.

