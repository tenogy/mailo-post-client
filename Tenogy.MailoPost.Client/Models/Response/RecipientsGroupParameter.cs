using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace MailoPost.Models.Response
{
	public class GetRecipientsGroupParametersResponse : BaseCollectionResponse<RecipientsGroupParameterModel>
	{
	}

	public class CreateRecipientsGroupParameterResponse : RecipientsGroupParameterModel, IBaseResponse
	{
		[JsonIgnore]
		public bool Success => Errors?.Any() != true;

		[JsonPropertyName("errors")]
		public IEnumerable<ErrorOfResponse>? Errors { get; set; }
	}

	public class EditRecipientsGroupParameterResponse : RecipientsGroupParameterModel, IBaseResponse
	{
		[JsonIgnore]
		public bool Success => Errors?.Any() != true;

		[JsonPropertyName("errors")]
		public IEnumerable<ErrorOfResponse>? Errors { get; set; }
	}

	public class RemoveRecipientsGroupParameterResponse : BaseResponse
	{
	}
}
