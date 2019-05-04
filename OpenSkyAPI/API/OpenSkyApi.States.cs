using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using opensky_api.Configuration;
using OpenSkyAPI.Model;

namespace OpenSkyAPI.API
{
    public partial class OpenSkyApi
    {
        public States GetStates(DateTime time, List<string> icao24Transponder)
        {
            _queryParameters.Clear();

            _queryParameters.AddRange(AddTimeAndICAO(GetEpochSeconds(time), icao24Transponder));

            return GetStates(_queryParameters);
        }

        public States GetStates(DateTime time, List<string> icao24Transponder, BoundingBox boundingBox)
        {
            _queryParameters.Clear();

            _queryParameters.AddRange(AddBoundingBoxing(boundingBox));

            return GetStates(time, icao24Transponder);
        }

        public States GetOwnStates(DateTime time, List<string> icao24)
        {
            if (!_authenticated) throw new Exception("Anonymous access of 'myStates' not allowed");

            _queryParameters.Clear();

            _queryParameters.AddRange(AddTimeAndICAO(GetEpochSeconds(time), icao24));

            return GetOwnStates(_queryParameters);
        }

        public States GetOwnStates(DateTime time, List<string> icao24, List<int> recievers)
        {
            if (!_authenticated) throw new Exception("Anonymous access of 'myStates' not allowed");

            _queryParameters.Clear();

            _queryParameters.AddRange(AddRecievers(recievers));

            return GetOwnStates(time, icao24);
        }

        public States GetStates(List<string> icao24Transponder)
        {
            _queryParameters.Clear();

            _queryParameters.AddRange(AddICAO(icao24Transponder));

            return GetStates(_queryParameters);
        }

        #region PRIVATES

        private States GetStates(ParameterList queryParameterList)
        {
            string url = _authenticated
                ? string.Format(ConfigurationManager.Settings.STATES_URI_AUTH, _username, _password)
                : ConfigurationManager.Settings.STATES_URI;

            string response = CallOpenSkyAPI(url, queryParameterList);

            return response == null
                ? new States()
                : JsonConvert.DeserializeObject<States>(response);
        }

        private States GetOwnStates(ParameterList queryParameterList)
        {
            string url = string.Format(ConfigurationManager.Settings.OWN_STATES_URI, _username, _password);

            string response = CallOpenSkyAPI(url, queryParameterList);

            return response == null
                ? new States()
                : JsonConvert.DeserializeObject<States>(response);
        }

        #endregion
    }
}