using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenSkyAPI.Model.Enums;

namespace OpenSkyAPI.Model
{
    public class StatesDeserializer : JsonConverter
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
                .Select(item => new StateVector
                {
                    Icao24 = GetValue<string>(item[0]),
                    Callsign = GetValue<string>(item[1]),
                    OriginCountry = GetValue<string>(item[2]),
                    LastPositionUpdate = GetValue<double>(item[3]),
                    LastContact = GetValue<double>(item[4]),
                    Longitude = GetValue<string>(item[5]),
                    Latitude = GetValue<string>(item[6]),
                    BaroAltitude = GetValue<float>(item[7]),
                    OnGround = GetValue<bool>(item[8]),
                    Velocity = GetValue<float>(item[9]),
                    Heading = GetValue<float>(item[10]),
                    VerticalRate = GetValue<int>(item[11]),
                    GeoAltitude = GetValue<string>(item[13]),
                    Squawk = GetValue<string>(item[14]),
                    Spi = GetValue<bool>(item[15]),
                    PositionSource = (PositionSource) GetValue<int>(item[16])
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