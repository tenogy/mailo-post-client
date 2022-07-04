using System.Globalization;

namespace MailoPost.Models
{
	public class GeoModel
	{
		public double Latitude;
		public double Longitude;

		public GeoModel(double latitude, double longitude)
		{
			Latitude = latitude;
			Longitude = longitude;
		}

		public override string ToString()
		{
			return Latitude.ToString(CultureInfo.InvariantCulture).Replace(",", ".") + "," + Longitude.ToString(CultureInfo.InvariantCulture).Replace(",", ".");
		}
	}
}
