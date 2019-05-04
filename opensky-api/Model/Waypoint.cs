namespace OpenSkyAPI.Model
{
    public class Waypoint
    {
        public int Time { get; set; }

        public float Latitude { get; set; }

        public float Longitude { get; set; }

        public float BaroAltitude { get; set; }

        public float Heading { get; set; }

        public bool OnGround { get; set; }

        public override string ToString()
        {
            return
                $"{nameof(Time)}: {Time}, {nameof(Latitude)}: {Latitude}, {nameof(Longitude)}: {Longitude}, {nameof(BaroAltitude)}: {BaroAltitude}, {nameof(Heading)}: {Heading}, {nameof(OnGround)}: {OnGround}";
        }
    }
}