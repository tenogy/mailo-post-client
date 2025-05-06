using System.Text.Json.Serialization;

namespace MailoPost.Models.Response;

public sealed class GetOrganizationsResponse : BaseCollectionResponse<OrganizationModel>;

public sealed class GetOrganizationByIdResponse : OrganizationModel, IBaseResponse
{
	[JsonIgnore]
	public bool Success => Errors?.Any() != true;

	[JsonPropertyName("errors")]
	public IEnumerable<ErrorOfResponse>? Errors { get; set; }
}

public sealed class GetCurrentOrganizationResponse : OrganizationModel, IBaseResponse
{
	[JsonIgnore]
	public bool Success => Errors?.Any() != true;

	[JsonPropertyName("errors")]
	public IEnumerable<ErrorOfResponse>? Errors { get; set; }
}

public sealed class CreateOrganizationResponse : OrganizationModel, IBaseResponse
{
	[JsonIgnore]
	public bool Success => Errors?.Any() != true;

	[JsonPropertyName("errors")]
	public IEnumerable<ErrorOfResponse>? Errors { get; set; }
}

public sealed class EditOrganizationResponse : OrganizationModel, IBaseResponse
{
	[JsonIgnore]
	public bool Success => Errors?.Any() != true;

	[JsonPropertyName("errors")]
	public IEnumerable<ErrorOfResponse>? Errors { get; set; }
}

public sealed class SetCurrentOrganizationResponse : OrganizationModel, IBaseResponse
{
	[JsonIgnore]
	public bool Success => Errors?.Any() != true;

	[JsonPropertyName("errors")]
	public IEnumerable<ErrorOfResponse>? Errors { get; set; }
}

public sealed class RemoveOrganizationResponse : BaseResponse;
