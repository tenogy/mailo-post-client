using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MailoPost.Models.RequestContent
{
	public class GetRecipientsRequestContent : BaseCollectionContent
	{
		[JsonIgnore]
		public int GroupId { get; set; }
	}

	public class SearchRecipientRequestContent : BaseCollectionContent
	{
		[JsonPropertyName("email")]
		public string? Email { get; set; }
	}

	public class CreateRecipientRequestContent : BaseContent
	{
		[JsonIgnore]
		public int GroupId { get; set; }

		[JsonPropertyName("email")]
		public string? Email { get; set; }

		[JsonPropertyName("unconfirmed")]
		public bool? Unconfirmed { get; set; }

		[JsonPropertyName("values")]
		public IEnumerable<SimpleRecipientParameterModel>? Parameters { get; set; }
	}

	public class ImportRecipientsRequestContent : BaseContent
	{
		[JsonIgnore]
		public int GroupId { get; set; }

		[JsonPropertyName("recipients")]
		public IEnumerable<SimpleRecipientModel>? Recipients { get; set; }

		[JsonPropertyName("run_triggers")]
		public bool RunTriggers { get; set; }
	}

	public class EditRecipientRequestContent : CreateRecipientRequestContent
	{
		[JsonIgnore]
		public int Id { get; set; }
	}

	public class RemoveRecipientRequestContent : BaseContent
	{
		[JsonIgnore]
		public int GroupId { get; set; }

		[JsonIgnore]
		public int Id { get; set; }
	}
}
