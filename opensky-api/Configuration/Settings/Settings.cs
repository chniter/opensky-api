namespace opensky_api.Configuration.Settings
{
    public class GeneralSettings
    {
        public string API => "https://opensky-network.org/api";
        public string API_AUTH => "https://{0}:{1}@opensky-network.org/api";
        public string STATES_URI => $"{API}/states/all";
        public string STATES_URI_AUTH => $"{API_AUTH}/states/all";
        public string OWN_STATES_URI => $"{API}/states/own";
        public string FLIGHTS_URI => $"{API}/flights/all";
        public string FLIGHTS_URI_AUTH => $"{API_AUTH}/flights/all";
        public string FLIGHTS_AIRCRAFT_URI => $"{API}/flights/aircraft";
        public string FLIGHTS_AIRCRAFT_URI_AUTH => $"{API_AUTH}/flights/aircraft";
        public string FLIGHTS_ARRIVALS_BY_AIRPORT_URI => $"{API}/flights/arrival";
        public string FLIGHTS_ARRIVALS_BY_AIRPORT_URI_AUTH => $"{API_AUTH}/flights/arrival";
        public string FLIGHTS_DEPARTURES_BY_AIRPORT_URI => $"{API}/flights/departure";
        public string FLIGHTS_DEPARTURES_BY_AIRPORT_URI_AUTH => $"{API_AUTH}/flights/departure";
        public string AIRCRAFT_TRACK_URI => $"{API}/tracks/all";
        public string AIRCRAFT_TRACK_URI_AUTH => $"{API_AUTH}/tracks/all";
        public int TIMEDIFFAUTH => 4900;
        public int TIMEDIFFNOAUTH => 9900;
    }
}