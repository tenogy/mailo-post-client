using System.Text.Json.Serialization;

namespace MailoPost.Models.Response;

public sealed class ErrorOfResponse
{
	[JsonPropertyName("code")]
	public int Code { get; set; }

	[JsonPropertyName("detail")]
	public string? Detail { get; set; }
}
