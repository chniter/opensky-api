using System;
using System.Collections.Generic;
using OpenSkyAPI.API;
using OpenSkyAPI.Model;

namespace OpenSky
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            OpenSkyApi api = new OpenSkyApi();

            States result = api.GetStates(null);

            Console.WriteLine(result);

            OpenSkyApi apiAuth = new OpenSkyApi("pmareke", "citrix");

            States result_auth = apiAuth.GetStates(null);

            Console.WriteLine(result_auth);

            List<Flight> flights
                = api.GetFlights(
                    new DateTime(2018, 01, 28, 12, 00, 00),
                    new DateTime(2018, 01, 28, 13, 00, 00)
                );

            Console.WriteLine(flights);

            List<Flight> flightsByAircraft
                = api.GetFlightsByAircraft(
                    "3c675a",
                    new DateTime(2018, 01, 29, 00, 00, 00),
                    new DateTime(2018, 01, 30, 00, 00, 00)
                );

            Console.WriteLine(flightsByAircraft);

            List<Flight> flightArrivals
                = api.GetFlightsArrivalsByAirport(
                    "EDDF",
                    new DateTime(2018, 01, 29, 12, 00, 00),
                    new DateTime(2018, 01, 29, 13, 00, 00)
                );

            Console.WriteLine(flightArrivals);

            List<Flight> flightDepartments
                = api.GetFlightsDeparturesByAirport(
                    "EDDF",
                    new DateTime(2018, 01, 29, 12, 00, 00),
                    new DateTime(2018, 01, 29, 13, 00, 00)
                );

            Console.WriteLine(flightDepartments);

            Track flightTrack = api.GetTrackByAircraft("3c4b26");

            Console.WriteLine(flightTrack);

            Console.ReadLine();
        }
    }
}