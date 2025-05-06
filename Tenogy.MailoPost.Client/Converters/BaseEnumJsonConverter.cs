using System.Text.Json;
using System.Text.Json.Serialization;

namespace MailoPost.Converters;

internal abstract class BaseEnumJsonConverter<TEnum> : JsonConverter<TEnum> where TEnum : Enum
{
	public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		var value = reader.GetString();

		if (!string.IsNullOrWhiteSpace(value))
			foreach (var enumValue in (TEnum[])typeToConvert.GetEnumValues())
			{
				if (GetJsonPropertyName(enumValue) == value)
					return enumValue;
			}

		return default!;
	}

	public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options)
	{
		writer.WriteStringValue(GetJsonPropertyName(value));
	}

	private static string? GetJsonPropertyName(TEnum value)
	{
		var enumType = value.GetType();
		var name = Enum.GetName(enumType, value)!;
		return enumType.GetField(name)?.GetCustomAttributes(false).OfType<JsonPropertyNameAttribute>().SingleOrDefault()?.Name;
	}
}
