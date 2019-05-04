using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenSkyAPI.Model
{
    public class Track
    {
        [JsonProperty(PropertyName = "icao24")]
        public string Icao24 { get; set; }

        [JsonProperty(PropertyName = "startTime")]
        public long? StartTime { get; set; }

        [JsonProperty(PropertyName = "endTime")]
        public long? EndTime { get; set; }

        [JsonProperty(PropertyName = "callsign")]
        public string Calllsign { get; set; }

        [JsonProperty(PropertyName = "path")]
        [JsonConverter(typeof(WaypointsSerializer))]
        public List<Waypoint> Path { get; set; }

        public override string ToString()
        {
            return
                $"{nameof(Icao24)}: {Icao24}, {nameof(StartTime)}: {StartTime}, {nameof(EndTime)}: {EndTime}, {nameof(Calllsign)}: {Calllsign}, {nameof(Path)}: {Path}";
        }
    }
}