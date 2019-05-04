using System;
using System.Collections.Generic;
using OpenSkyAPI.Model;

namespace OpenSkyAPI.API
{
    public interface IOpenSkyApi
    {
        States GetStates(DateTime time, List<string> icao24Transponder);

        States GetStates(DateTime time, List<string> icao24Transponder, BoundingBox boundingBox);

        States GetOwnStates(DateTime time, List<string> icao24Transponder);

        States GetOwnStates(DateTime time, List<string> icao24Transponder, List<int> recievers);

        List<Flight> GetFlights(DateTime startTime, DateTime endTime);

        List<Flight> GetFlightsByAircraft(string icao24Aircraft, DateTime startTime, DateTime endTime);

        List<Flight> GetFlightsArrivalsByAirport(string icao24Airport, DateTime startTime, DateTime endTime);

        List<Flight> GetFlightsDeparturesByAirport(string icao24Airport, DateTime startTime, DateTime endTime);

        Track GetTrackByAircraft(string icao24Aircraft);

        Track GetTrackByAircraft(DateTime time, string icao24Aircraft);
    }
}