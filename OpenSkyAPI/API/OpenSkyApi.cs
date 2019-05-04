using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Text;
using opensky_api.Configuration;
using OpenSkyAPI.Model;
using OpenSkyAPI.Model.Enums;

namespace OpenSkyAPI.API
{
    public partial class OpenSkyApi : IOpenSkyApi
    {
        private readonly bool _authenticated;
        private readonly Dictionary<REQUEST_TYPE, long> _lastRequestTime;
        private readonly string _password;
        private readonly ParameterList _queryParameters;
        private readonly string _username;

        public OpenSkyApi()
        {
            _queryParameters = new ParameterList();
            _username = null;
            _password = null;

            _lastRequestTime = new Dictionary<REQUEST_TYPE, long>
            {
                [REQUEST_TYPE.NOT_AUTH] = 0,
                [REQUEST_TYPE.AUTH] = 0
            };

            _authenticated = false;
        }

        public OpenSkyApi(string username, string password)
        {
            _username = username;
            _password = password;
            _queryParameters = new ParameterList();

            _lastRequestTime = new Dictionary<REQUEST_TYPE, long>
            {
                [REQUEST_TYPE.NOT_AUTH] = 0,
                [REQUEST_TYPE.AUTH] = 0
            };

            _authenticated = true;
        }

        #region PRIVATES

        private string CallOpenSkyAPI(string url, ParameterList queryParams)
        {
            REQUEST_TYPE requestType = _authenticated ? REQUEST_TYPE.AUTH : REQUEST_TYPE.NOT_AUTH;

            if (!CheckRateLimit(requestType))
                return null;

            string json;
            Uri uri = new Uri(url);

            try
            {
                ServicePointManager.SecurityProtocol =
                    SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                WebClient client = new WebClient
                {
                    Encoding = Encoding.UTF8,
                    Headers = {[HttpRequestHeader.ContentType] = "application/json"},
                    Proxy = null
                };

                queryParams.ForEach(dic => client.QueryString.Add(dic.Key, dic.Value));

                json = client.DownloadString(uri);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("404"))
                    return null;

                throw new Exception($"{ex.Message}");
            }

            return json;
        }

        private bool CheckRateLimit(REQUEST_TYPE type)
        {
            long t = _lastRequestTime[type];
            long now = DateTime.Now.Millisecond;
            _lastRequestTime[type] = now;
            return t == 0
                   || _authenticated && now - t < ConfigurationManager.Settings.TIMEDIFFAUTH
                   || !_authenticated && now - t < ConfigurationManager.Settings.TIMEDIFFNOAUTH;
        }

        private static ParameterList AddICAO(List<string> icao24List)
        {
            ParameterList tmp = new ParameterList();

            icao24List?.ForEach(i => tmp.Add("icao24", i));

            return tmp;
        }

        private ParameterList AddTimeAndICAO(string time, List<string> icao24List)
        {
            ParameterList tmp = new ParameterList();

            icao24List?.ForEach(i => tmp.Add("icao24", i));

            if (_authenticated)
                tmp.Add("time", time);

            return tmp;
        }

        private static ParameterList AddBoundingBoxing(BoundingBox bbox)
        {
            ParameterList tmp = new ParameterList
            {
                {"lamin", bbox.MinLatitude.ToString(CultureInfo.InvariantCulture)},
                {"lamax", bbox.MaxLatitude.ToString(CultureInfo.InvariantCulture)},
                {"lomin", bbox.MinLongitude.ToString(CultureInfo.InvariantCulture)},
                {"lomax", bbox.MaxLongitude.ToString(CultureInfo.InvariantCulture)}
            };

            return tmp;
        }

        private static ParameterList AddRecievers(List<int> recievers)
        {
            ParameterList tmp = new ParameterList();

            recievers?.ForEach(i => tmp.Add("serials", $"{i}"));

            return tmp;
        }

        private static ParameterList AddRangeTime(DateTime startDateTime, DateTime enDateTime)
        {
            ParameterList tmp = new ParameterList
            {
                {"begin", GetEpochSeconds(startDateTime)},
                {"end", GetEpochSeconds(enDateTime)}
            };

            return tmp;
        }

        private static string GetEpochSeconds(DateTime date)
        {
            TimeSpan t = date - new DateTime(1970, 1, 1);
            return t.TotalSeconds.ToString(CultureInfo.InvariantCulture);
        }

        #endregion
    }
}