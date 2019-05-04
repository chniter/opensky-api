using System;
using OpenSkyAPI.Model.Enums;

namespace OpenSkyAPI.Model
{
    [Serializable]
    public class StateVector
    {
        public string Icao24 { get; set; }

        public string Callsign { get; set; }

        public string OriginCountry { get; set; }

        public double? LastPositionUpdate { get; set; }

        public double? LastContact { get; set; }

        public string Longitude { get; set; }

        public string Latitude { get; set; }

        public float? BaroAltitude { get; set; }

        public bool? OnGround { get; set; }

        public float? Velocity { get; set; }

        public float? Heading { get; set; }

        public int? VerticalRate { get; set; }

        public string GeoAltitude { get; set; }

        public string Squawk { get; set; }

        public bool? Spi { get; set; }

        public PositionSource? PositionSource { get; set; }

        public override string ToString()
        {
            return
                $"{nameof(Icao24)}: {Icao24}, {nameof(Callsign)}: {Callsign}, {nameof(OriginCountry)}: {OriginCountry}, {nameof(LastPositionUpdate)}: {LastPositionUpdate}, {nameof(LastContact)}: {LastContact}, {nameof(Longitude)}: {Longitude}, {nameof(Latitude)}: {Latitude}, {nameof(BaroAltitude)}: {BaroAltitude}, {nameof(OnGround)}: {OnGround}, {nameof(Velocity)}: {Velocity}, {nameof(Heading)}: {Heading}, {nameof(VerticalRate)}: {VerticalRate}, {nameof(GeoAltitude)}: {GeoAltitude}, {nameof(Squawk)}: {Squawk}, {nameof(Spi)}: {Spi}, {nameof(PositionSource)}: {PositionSource}";
        }
    }
}