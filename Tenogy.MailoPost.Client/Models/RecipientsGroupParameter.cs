using System.Text.Json.Serialization;
using MailoPost.Enums;

namespace MailoPost.Models;

public class RecipientsGroupParameterModel
{
	[JsonPropertyName("list_id")]
	public long GroupId { get; set; }

	[JsonPropertyName("id")]
	public long Id { get; set; }

	[JsonPropertyName("title")]
	public string? Title { get; set; }

	[JsonPropertyName("kind")]
	public ParameterKindEnum Kind { get; set; }
}
