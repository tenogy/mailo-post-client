using System.Globalization;

namespace MailoPost.Models;

public sealed class GeoModel
{
	public double Latitude { get; set; }
	public double Longitude { get; set; }

	public GeoModel(double latitude, double longitude)
	{
		Latitude = latitude;
		Longitude = longitude;
	}

	public override string ToString()
		=> Latitude.ToString(CultureInfo.InvariantCulture).Replace(",", ".") + "," + Longitude.ToString(CultureInfo.InvariantCulture).Replace(",", ".");
}
