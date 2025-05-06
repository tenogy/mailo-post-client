using System.Text.Json.Serialization;

namespace MailoPost.Models.Response;

public sealed class GetBalanceResponse : BalanceModel, IBaseResponse
{
	[JsonIgnore]
	public bool Success => Errors?.Any() != true;

	[JsonPropertyName("errors")]
	public IEnumerable<ErrorOfResponse>? Errors { get; set; }
}
