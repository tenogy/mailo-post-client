using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MailoPost.Helpers
{
	internal class JsonStringEnumConverterAttribute : Attribute
	{
	}

	internal static class JsonStringEnumConverterExtension
	{
		public static TEnum EnumRead<TEnum>(this Utf8JsonReader reader, Type typeToConvert) where TEnum : Enum
		{
			var value = reader.GetString();

			if (!string.IsNullOrWhiteSpace(value))
				foreach (var enumValue in (TEnum[])typeToConvert.GetEnumValues())
				{
					if (enumValue.GetJsonPropertyName() == value)
						return enumValue;
				}

			return default!;
		}

		public static void EnumWrite(this Utf8JsonWriter writer, Enum value)
		{
			writer.WriteStringValue(value.GetJsonPropertyName());
		}

		private static string? GetJsonPropertyName(this Enum value)
		{
			var enumType = value.GetType();
			var name = Enum.GetName(enumType, value)!;
			return enumType.GetField(name)?.GetCustomAttributes(false).OfType<JsonPropertyNameAttribute>().SingleOrDefault()?.Name;
		}

		public static IEnumerable<JsonConverter> GetJsonEnumConverters()
		{
			return typeof(MailoPostClient).Assembly.GetTypes()
				.Where(type => type.GetCustomAttributes(typeof(JsonStringEnumConverterAttribute), true).Length > 0)
				.Select(x => (JsonConverter)Activator.CreateInstance(x)!)
				.ToArray();
		}
	}
}
