using System.Text.Json.Serialization;

namespace MailoPost.Enums;

public enum RecipientStatusEnum
{
	[JsonPropertyName("active")]
	Active,

	[JsonPropertyName("incorrect")]
	Incorrect,

	[JsonPropertyName("unconfirmed")]
	Unconfirmed,

	[JsonPropertyName("unsubscribed")]
	Unsubscribed,
}
