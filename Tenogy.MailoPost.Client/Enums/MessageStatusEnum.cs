using System.Text.Json.Serialization;

namespace MailoPost.Enums;

public enum MessageStatusEnum
{
	[JsonPropertyName("queued")]
	Queued,

	[JsonPropertyName("sent")]
	Sent,

	[JsonPropertyName("delivered")]
	Delivered,

	[JsonPropertyName("skipped")]
	Skipped,

	[JsonPropertyName("soft_bounced")]
	SoftBounced,

	[JsonPropertyName("hard_bounced")]
	HardBounced,
}
