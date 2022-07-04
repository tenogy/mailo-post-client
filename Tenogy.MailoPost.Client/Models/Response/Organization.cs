using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace MailoPost.Models.Response
{
	public class GetOrganizationsResponse : BaseCollectionResponse<OrganizationModel>
	{
	}

	public class GetOrganizationByIdResponse : OrganizationModel, IBaseResponse
	{
		[JsonIgnore]
		public bool Success => Errors?.Any() != true;

		[JsonPropertyName("errors")]
		public IEnumerable<ErrorOfResponse>? Errors { get; set; }
	}

	public class GetCurrentOrganizationResponse : OrganizationModel, IBaseResponse
	{
		[JsonIgnore]
		public bool Success => Errors?.Any() != true;

		[JsonPropertyName("errors")]
		public IEnumerable<ErrorOfResponse>? Errors { get; set; }
	}

	public class CreateOrganizationResponse : OrganizationModel, IBaseResponse
	{
		[JsonIgnore]
		public bool Success => Errors?.Any() != true;

		[JsonPropertyName("errors")]
		public IEnumerable<ErrorOfResponse>? Errors { get; set; }
	}

	public class EditOrganizationResponse : OrganizationModel, IBaseResponse
	{
		[JsonIgnore]
		public bool Success => Errors?.Any() != true;

		[JsonPropertyName("errors")]
		public IEnumerable<ErrorOfResponse>? Errors { get; set; }
	}

	public class SetCurrentOrganizationResponse : EditOrganizationResponse
	{
	}

	public class RemoveOrganizationResponse : BaseResponse
	{
	}
}
