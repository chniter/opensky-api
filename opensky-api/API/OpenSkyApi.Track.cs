using System;
using Newtonsoft.Json;
using opensky_api.Configuration;
using OpenSkyAPI.Model;

namespace OpenSkyAPI.API
{
    public partial class OpenSkyApi
    {
        public Track GetTrackByAircraft(string icao24Aircraft)
        {
            _queryParameters.Clear();

            _queryParameters.Add("icao24", icao24Aircraft);

            _queryParameters.Add("time", "0");

            return GetTrackByAircraft(_queryParameters);
        }

        public Track GetTrackByAircraft(DateTime time, string icao24Aircraft)
        {
            if ((DateTime.Now - time).Days > 30)
                throw new Exception("Range too large, more than 7 days its not allowed");

            _queryParameters.Clear();

            _queryParameters.Add("icao24", icao24Aircraft);

            _queryParameters.Add("time", GetEpochSeconds(time));

            return GetTrackByAircraft(_queryParameters);
        }

        #region PRIVATES

        private Track GetTrackByAircraft(ParameterList queryParameterList)
        {
            string url = _authenticated
                ? string.Format(ConfigurationManager.Settings.AIRCRAFT_TRACK_URI_AUTH, _username, _password)
                : ConfigurationManager.Settings.AIRCRAFT_TRACK_URI;

            string response = CallOpenSkyAPI(url, queryParameterList);

            return response == null
                ? new Track()
                : JsonConvert.DeserializeObject<Track>(response);
        }

        #endregion
    }
}