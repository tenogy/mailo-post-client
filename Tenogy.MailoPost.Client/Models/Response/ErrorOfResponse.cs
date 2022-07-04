using System.Text.Json.Serialization;

namespace MailoPost.Models.Response
{
	public class ErrorOfResponse
	{
		[JsonPropertyName("code")]
		public int Code { get; set; }

		[JsonPropertyName("detail")]
		public string? Detail { get; set; }
	}
}
