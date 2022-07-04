using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using MailoPost.Helpers;

namespace MailoPost.Enums
{
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

	[JsonStringEnumConverter]
	internal class MessageStatusEnumConverter : JsonConverter<MessageStatusEnum>
	{
		public override MessageStatusEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
			=> reader.EnumRead<MessageStatusEnum>(typeToConvert);

		public override void Write(Utf8JsonWriter writer, MessageStatusEnum value, JsonSerializerOptions options)
			=> writer.EnumWrite(value);
	}
}
