using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OpenSkyAPI.Model
{
    public class WaypointsSerializer : JsonConverter
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            JArray obj = JArray.Load(reader);

            return obj.Children()
                .Select(item => new Waypoint
                {
                    Time = GetValue<int>(item[0]),
                    Longitude = GetValue<float>(item[1]),
                    Latitude = GetValue<float>(item[2]),
                    BaroAltitude = GetValue<float>(item[3]),
                    Heading = GetValue<float>(item[4]),
                    OnGround = GetValue<bool>(item[5])
                }).ToList();
        }

        private static T GetValue<T>(JToken item)
        {
            return item.Type == JTokenType.Null ? default(T) : item.Value<T>();
        }

        public override bool CanConvert(Type objectType)
        {
            return false;
        }
    }
}