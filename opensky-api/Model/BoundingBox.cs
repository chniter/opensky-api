using System;

namespace OpenSkyAPI.Model
{
    /**
	 * Represents a bounding box of WGS84 coordinates (decimal degrees) that encompasses a certain area. It is
	 * defined by a lower and upper bound for latitude and longitude.
	 */
    public class BoundingBox
    {
        /**
		 * Create a bounding box, given the lower and upper bounds for latitude and longitude.
		 */
        private BoundingBox(double minLatitude, double maxLatitude, double minLongitude, double maxLongitude)
        {
            CheckLatitude(minLatitude);
            CheckLatitude(maxLatitude);
            CheckLongitude(minLongitude);
            CheckLongitude(maxLongitude);

            MinLatitude = minLatitude;
            MinLongitude = minLongitude;
            MaxLatitude = maxLatitude;
            MaxLongitude = maxLongitude;
        }

        public double MinLatitude { get; set; }
        public double MinLongitude { get; set; }
        public double MaxLatitude { get; set; }
        public double MaxLongitude { get; set; }

        private static void CheckLatitude(double lat)
        {
            if (lat < -90 || lat > 90) throw new Exception($"Illegal latitude {lat}. Must be within [-90, 90]");
        }

        private static void CheckLongitude(double lon)
        {
            if (lon < -180 || lon > 180) throw new Exception($"Illegal longitude {lon}. Must be within [-90, 90]");
        }

        public override string ToString()
        {
            return
                $"{nameof(MinLatitude)}: {MinLatitude}, {nameof(MinLongitude)}: {MinLongitude}, {nameof(MaxLatitude)}: {MaxLatitude}, {nameof(MaxLongitude)}: {MaxLongitude}";
        }
    }
}