using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace MailoPost.Models.Response
{
	public class GetRecipientsGroupsResponse : BaseCollectionResponse<RecipientsGroupModel>
	{
	}

	public class GetRecipientsGroupByIdResponse : RecipientsGroupModel, IBaseResponse
	{
		[JsonIgnore]
		public bool Success => Errors?.Any() != true;

		[JsonPropertyName("errors")]
		public IEnumerable<ErrorOfResponse>? Errors { get; set; }
	}

	public class CreateRecipientsGroupResponse : RecipientsGroupModel, IBaseResponse
	{
		[JsonIgnore]
		public bool Success => Errors?.Any() != true;

		[JsonPropertyName("errors")]
		public IEnumerable<ErrorOfResponse>? Errors { get; set; }
	}

	public class EditRecipientsGroupResponse : RecipientsGroupModel, IBaseResponse
	{
		[JsonIgnore]
		public bool Success => Errors?.Any() != true;

		[JsonPropertyName("errors")]
		public IEnumerable<ErrorOfResponse>? Errors { get; set; }
	}

	public class RemoveRecipientsGroupResponse : BaseResponse
	{
	}
}
