using System.Text.Json.Serialization;
using MailoPost.Enums;

namespace MailoPost.Models.Response;

public sealed class GetRecipientsResponse : BaseCollectionResponse<RecipientModel>;

public sealed class SearchRecipientResponse : BaseCollectionResponse<SearchRecipientModel>
{
	[JsonPropertyName("query")]
	public string? Query { get; set; }
}

public sealed class CreateRecipientResponse : RecipientModel, IBaseResponse
{
	[JsonIgnore]
	public bool Success => Errors?.Any() != true;

	[JsonPropertyName("errors")]
	public IEnumerable<ErrorOfResponse>? Errors { get; set; }
}

public sealed class ImportRecipientsResponse : IBaseResponse
{
	[JsonIgnore]
	public bool Success => Errors?.Any() != true;

	[JsonPropertyName("errors")]
	public IEnumerable<ErrorOfResponse>? Errors { get; set; }

	[JsonPropertyName("id")]
	public long ImportId { get; set; }

	[JsonPropertyName("status")]
	public MessageStatusEnum Status { get; set; }
}

public sealed class EditRecipientResponse : RecipientModel, IBaseResponse
{
	[JsonIgnore]
	public bool Success => Errors?.Any() != true;

	[JsonPropertyName("errors")]
	public IEnumerable<ErrorOfResponse>? Errors { get; set; }
}

public sealed class RemoveRecipientResponse : BaseResponse;
