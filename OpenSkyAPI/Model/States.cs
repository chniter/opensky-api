using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenSkyAPI.Model
{
    [Serializable]
    public class States
    {
        [JsonProperty(PropertyName = "time")] public int Time { get; set; }

        [JsonConverter(typeof(StatesDeserializer))]
        [JsonProperty(PropertyName = "states")]
        public List<StateVector> FlightStates { get; set; }

        public override string ToString()
        {
            return $"{nameof(Time)}: {Time}, {nameof(FlightStates)}: {FlightStates}";
        }
    }
}