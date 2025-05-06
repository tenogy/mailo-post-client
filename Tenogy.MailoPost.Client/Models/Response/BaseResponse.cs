using System.Text.Json.Serialization;

namespace MailoPost.Models.Response;

public abstract class BaseResponse : IBaseResponse
{
	[JsonIgnore]
	public bool Success => Errors?.Any() != true;

	[JsonPropertyName("errors")]
	public IEnumerable<ErrorOfResponse>? Errors { get; set; }
}
