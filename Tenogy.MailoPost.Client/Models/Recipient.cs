using System.Text.Json;
using System.Text.Json.Serialization;
using MailoPost.Enums;

namespace MailoPost.Models;

public class RecipientModel
{
	[JsonPropertyName("list_id")]
	public long GroupId { get; set; }

	[JsonPropertyName("id")]
	public long Id { get; set; }

	[JsonPropertyName("email")]
	public string? Email { get; set; }

	[JsonPropertyName("confirmed")]
	public bool Confirmed { get; set; }

	[JsonPropertyName("status")]
	public RecipientStatusEnum Status { get; set; }

	[JsonPropertyName("values")]
	public IEnumerable<RecipientParameterModel>? Parameters { get; set; }
}

public sealed class SearchRecipientModel
{
	[JsonPropertyName("email")]
	public string? Email { get; set; }

	[JsonPropertyName("recipients")]
	public IEnumerable<SearchRecipientInfoModel>? Recipients { get; set; }
}

public sealed class SearchRecipientInfoModel
{
	[JsonPropertyName("list_id")]
	public long GroupId { get; set; }

	[JsonPropertyName("list_title")]
	public string? GroupTitle { get; set; }

	[JsonPropertyName("recipient_id")]
	public long Id { get; set; }
}

public sealed class SimpleRecipientModel
{
	[JsonPropertyName("email")]
	public string? Email { get; set; }

	[JsonPropertyName("values")]
	public IEnumerable<SimpleRecipientParameterModel>? Parameters { get; set; }
}

public sealed class SimpleRecipientParameterModel
{
	[JsonPropertyName("parameter_id")]
	public long Id { get; set; }

	[JsonPropertyName("value"), JsonConverter(typeof(JsonSimpleRecipientParameterValueConverter))]
	public object? Value { get; set; }
}

internal class JsonSimpleRecipientParameterValueConverter : JsonConverter<object>
{
	public override object? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		return reader.GetString();
	}

	public override void Write(Utf8JsonWriter writer, object? value, JsonSerializerOptions options)
	{
		switch (value)
		{
			// Numeric
			case int valueInt:
				writer.WriteNumberValue(valueInt);
				break;
			case uint valueUInt:
				writer.WriteNumberValue(valueUInt);
				break;
			case long valueLong:
				writer.WriteNumberValue(valueLong);
				break;
			case ulong valueULong:
				writer.WriteNumberValue(valueULong);
				break;
			case double valueDouble:
				writer.WriteNumberValue(valueDouble);
				break;
			case decimal valueDecimal:
				writer.WriteNumberValue(valueDecimal);
				break;
			case float valueFloat:
				writer.WriteNumberValue(valueFloat);
				break;
			// Date
			case DateTime valueDate:
				var dt = new DateTime(valueDate.Year, valueDate.Month, valueDate.Day, valueDate.Hour, valueDate.Minute, valueDate.Second, DateTimeKind.Utc);
				writer.WriteStringValue(dt.ToString("dd.MM.yyyy HH:mm"));
				break;
			// Boolean
			case bool valueBool:
				writer.WriteStringValue(valueBool ? "true" : "false");
				break;
			// Geo
			case GeoModel valueGeo:
				writer.WriteStringValue(valueGeo.ToString());
				break;
			// String
			default:
				writer.WriteStringValue(value?.ToString());
				break;
		}
	}
}
