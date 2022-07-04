using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using MailoPost.Helpers;

namespace MailoPost.Enums
{
	public enum ParameterKindEnum
	{
		[JsonPropertyName("string")]
		String,

		[JsonPropertyName("numeric")]
		Numeric,

		[JsonPropertyName("date")]
		Date,

		[JsonPropertyName("boolean")]
		Boolean,

		[JsonPropertyName("geo")]
		Geo
	}

	[JsonStringEnumConverterAttribute]
	internal class RecipientsGroupParameterKindEnumConverter : JsonConverter<ParameterKindEnum>
	{
		public override ParameterKindEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
			=> reader.EnumRead<ParameterKindEnum>(typeToConvert);

		public override void Write(Utf8JsonWriter writer, ParameterKindEnum value, JsonSerializerOptions options)
			=> writer.EnumWrite(value);
	}
}
