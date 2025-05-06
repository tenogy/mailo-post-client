using System.Text.Json.Serialization;

namespace MailoPost.Models.Response;

public sealed class GetRecipientsGroupParametersResponse : BaseCollectionResponse<RecipientsGroupParameterModel>;

public sealed class CreateRecipientsGroupParameterResponse : RecipientsGroupParameterModel, IBaseResponse
{
	[JsonIgnore]
	public bool Success => Errors?.Any() != true;

	[JsonPropertyName("errors")]
	public IEnumerable<ErrorOfResponse>? Errors { get; set; }
}

public sealed class EditRecipientsGroupParameterResponse : RecipientsGroupParameterModel, IBaseResponse
{
	[JsonIgnore]
	public bool Success => Errors?.Any() != true;

	[JsonPropertyName("errors")]
	public IEnumerable<ErrorOfResponse>? Errors { get; set; }
}

public sealed class RemoveRecipientsGroupParameterResponse : BaseResponse;
