using System.Text.Json.Serialization;

namespace MailoPost.Models.Response;

public sealed class GetRecipientsGroupsResponse : BaseCollectionResponse<RecipientsGroupModel>;

public sealed class GetRecipientsGroupByIdResponse : RecipientsGroupModel, IBaseResponse
{
	[JsonIgnore]
	public bool Success => Errors?.Any() != true;

	[JsonPropertyName("errors")]
	public IEnumerable<ErrorOfResponse>? Errors { get; set; }
}

public sealed class CreateRecipientsGroupResponse : RecipientsGroupModel, IBaseResponse
{
	[JsonIgnore]
	public bool Success => Errors?.Any() != true;

	[JsonPropertyName("errors")]
	public IEnumerable<ErrorOfResponse>? Errors { get; set; }
}

public sealed class EditRecipientsGroupResponse : RecipientsGroupModel, IBaseResponse
{
	[JsonIgnore]
	public bool Success => Errors?.Any() != true;

	[JsonPropertyName("errors")]
	public IEnumerable<ErrorOfResponse>? Errors { get; set; }
}

public sealed class RemoveRecipientsGroupResponse : BaseResponse;
