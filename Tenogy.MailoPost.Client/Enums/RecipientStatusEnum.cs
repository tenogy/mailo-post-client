using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using MailoPost.Helpers;

namespace MailoPost.Enums
{
	public enum RecipientStatusEnum
	{
		[JsonPropertyName("active")]
		Active,

		[JsonPropertyName("incorrect")]
		Incorrect,

		[JsonPropertyName("unconfirmed")]
		Unconfirmed,

		[JsonPropertyName("unsubscribed")]
		Unsubscribed
	}

	[JsonStringEnumConverter]
	internal class RecipientStatusEnumConverter : JsonConverter<RecipientStatusEnum>
	{
		public override RecipientStatusEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
			=> reader.EnumRead<RecipientStatusEnum>(typeToConvert);

		public override void Write(Utf8JsonWriter writer, RecipientStatusEnum value, JsonSerializerOptions options)
			=> writer.EnumWrite(value);
	}
}
