using System.Text.Json.Serialization;

namespace MailoPost.Models;

public class OrganizationModel
{
	[JsonPropertyName("id")]
	public long Id { get; set; }

	[JsonPropertyName("name")]
	public string? Name { get; set; }

	[JsonPropertyName("zip")]
	public string? Zip { get; set; }

	[JsonPropertyName("country")]
	public string? Country { get; set; }

	[JsonPropertyName("city")]
	public string? City { get; set; }

	[JsonPropertyName("address")]
	public string? Address { get; set; }

	[JsonPropertyName("phone")]
	public string? Phone { get; set; }

	[JsonPropertyName("current")]
	public bool Current { get; set; }
}
