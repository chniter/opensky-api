using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using opensky_api.Configuration;
using OpenSkyAPI.Model;

namespace OpenSkyAPI.API
{
    public partial class OpenSkyApi
    {
        public List<Flight> GetFlights(DateTime startTime, DateTime endTime)
        {
            if ((endTime - startTime).Hours > 2)
                throw new Exception("Range too large, more than 2 hours its not allowed");

            _queryParameters.Clear();

            _queryParameters.AddRange(AddRangeTime(startTime, endTime));

            return GetFlights(_queryParameters);
        }

        public List<Flight> GetFlightsByAircraft(string icao24Aircraft, DateTime startTime, DateTime endTime)
        {
            if ((endTime - startTime).Days > 30)
                throw new Exception("Range too large, more than 30 days its not allowed");

            _queryParameters.Clear();

            _queryParameters.AddRange(AddRangeTime(startTime, endTime));

            _queryParameters.Add("icao24", icao24Aircraft);

            return GetFlightsByAircraft(_queryParameters);
        }

        public List<Flight> GetFlightsArrivalsByAirport(string icao24Airport, DateTime startTime, DateTime endTime)
        {
            if ((endTime - startTime).Days > 7)
                throw new Exception("Range too large, more than 7 days its not allowed");

            _queryParameters.Clear();

            _queryParameters.AddRange(AddRangeTime(startTime, endTime));

            _queryParameters.Add("airport", icao24Airport);

            return GetFlightsArrivalsByAirport(_queryParameters);
        }

        public List<Flight> GetFlightsDeparturesByAirport(string icao24Airport, DateTime startTime, DateTime endTime)
        {
            if ((endTime - startTime).Days > 7)
                throw new Exception("Range too large, more than 7 days its not allowed");

            _queryParameters.Clear();

            _queryParameters.AddRange(AddRangeTime(startTime, endTime));

            _queryParameters.Add("airport", icao24Airport);

            return GetFlightsDeparturesByAirport(_queryParameters);
        }

        #region PRIVATES

        private List<Flight> GetFlights(ParameterList queryParameterList)
        {
            string url = _authenticated
                ? string.Format(ConfigurationManager.Settings.FLIGHTS_URI_AUTH, _username, _password)
                : ConfigurationManager.Settings.FLIGHTS_URI;

            string response = CallOpenSkyAPI(url, queryParameterList);

            return response == null
                ? new List<Flight>()
                : JsonConvert.DeserializeObject<List<Flight>>(response);
        }

        private List<Flight> GetFlightsByAircraft(ParameterList queryParameterList)
        {
            string url = _authenticated
                ? string.Format(ConfigurationManager.Settings.FLIGHTS_AIRCRAFT_URI_AUTH, _username, _password)
                : ConfigurationManager.Settings.FLIGHTS_AIRCRAFT_URI;

            string response = CallOpenSkyAPI(url, queryParameterList);

            return response == null
                ? new List<Flight>()
                : JsonConvert.DeserializeObject<List<Flight>>(response);
        }

        private List<Flight> GetFlightsArrivalsByAirport(ParameterList queryParameterList)
        {
            string url = _authenticated
                ? string.Format(ConfigurationManager.Settings.FLIGHTS_ARRIVALS_BY_AIRPORT_URI_AUTH, _username,
                    _password)
                : ConfigurationManager.Settings.FLIGHTS_ARRIVALS_BY_AIRPORT_URI;

            string response = CallOpenSkyAPI(url, queryParameterList);

            return response == null
                ? new List<Flight>()
                : JsonConvert.DeserializeObject<List<Flight>>(response);
        }

        private List<Flight> GetFlightsDeparturesByAirport(ParameterList queryParameterList)
        {
            string url = _authenticated
                ? string.Format(ConfigurationManager.Settings.FLIGHTS_DEPARTURES_BY_AIRPORT_URI_AUTH, _username,
                    _password)
                : ConfigurationManager.Settings.FLIGHTS_DEPARTURES_BY_AIRPORT_URI;

            string response = CallOpenSkyAPI(url, queryParameterList);

            return response == null
                ? new List<Flight>()
                : JsonConvert.DeserializeObject<List<Flight>>(response);
        }

        #endregion
    }
}