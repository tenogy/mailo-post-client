using System;
using System.Globalization;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using MailoPost.Enums;

namespace MailoPost.Models
{
	public class RecipientParameterModel
	{
		[JsonPropertyName("parameter_id")]
		public int Id { get; set; }

		[JsonPropertyName("kind")]
		public ParameterKindEnum Kind { get; set; }

		[JsonPropertyName("value")]
		public object? Value { get; set; }

		public string? GetStringValue()
		{
			return Kind == ParameterKindEnum.String ? Value?.ToString() : null;
		}

		public int? GetIntValue()
		{
			if (Kind != ParameterKindEnum.Numeric || Value == null || !decimal.TryParse(Value.ToString()?.Replace(".", ","), out var result)) return null;
			return (int)result;
		}

		public float? GetFloatValue()
		{
			if (Kind != ParameterKindEnum.Numeric || Value == null || !float.TryParse(Value.ToString()?.Replace(".", ","), out var result)) return null;
			return result;
		}

		public double? GetDoubleValue()
		{
			if (Kind != ParameterKindEnum.Numeric || Value == null || !double.TryParse(Value.ToString()?.Replace(".", ","), out var result)) return null;
			return result;
		}

		public decimal? GetDecimalValue()
		{
			if (Kind != ParameterKindEnum.Numeric || Value == null || !decimal.TryParse(Value.ToString()?.Replace(".", ","), out var result)) return null;
			return result;
		}

		public DateTime? GetDateTimeValue()
		{
			if (Kind != ParameterKindEnum.Date || Value == null || !DateTime.TryParse(Value.ToString(), out var result)) return null;
			return result;
		}

		public bool? GetBooleanValue()
		{
			if (Kind != ParameterKindEnum.Date || Value == null || !bool.TryParse(Value.ToString(), out var result)) return null;
			return result;
		}
	}
}
