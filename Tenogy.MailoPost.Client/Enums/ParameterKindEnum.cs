using System.Text.Json.Serialization;

namespace MailoPost.Enums;

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
	Geo,
}
