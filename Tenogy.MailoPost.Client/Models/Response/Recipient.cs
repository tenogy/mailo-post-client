using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using MailoPost.Enums;

namespace MailoPost.Models.Response
{
	public class GetRecipientsResponse : BaseCollectionResponse<RecipientModel>
	{
	}

	public class SearchRecipientResponse : BaseCollectionResponse<SearchRecipientModel>
	{
		[JsonPropertyName("query")]
		public string? Query { get; set; }
	}

	public class CreateRecipientResponse : RecipientModel, IBaseResponse
	{
		[JsonIgnore]
		public bool Success => Errors?.Any() != true;

		[JsonPropertyName("errors")]
		public IEnumerable<ErrorOfResponse>? Errors { get; set; }
	}

	public class ImportRecipientsResponse : IBaseResponse
	{
		[JsonIgnore]
		public bool Success => Errors?.Any() != true;

		[JsonPropertyName("errors")]
		public IEnumerable<ErrorOfResponse>? Errors { get; set; }

		[JsonPropertyName("id")]
		public int ImportId { get; set; }

		[JsonPropertyName("status")]
		public MessageStatusEnum Status { get; set; }
	}

	public class EditRecipientResponse : RecipientModel, IBaseResponse
	{
		[JsonIgnore]
		public bool Success => Errors?.Any() != true;

		[JsonPropertyName("errors")]
		public IEnumerable<ErrorOfResponse>? Errors { get; set; }
	}

	public class RemoveRecipientResponse : BaseResponse
	{
	}
}
