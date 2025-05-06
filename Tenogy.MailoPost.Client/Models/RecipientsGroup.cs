using System.Text.Json.Serialization;

namespace MailoPost.Models;

public class RecipientsGroupModel
{
	[JsonPropertyName("id")]
	public long Id { get; set; }

	[JsonPropertyName("title")]
	public string? Title { get; set; }
}
