using System.Text.Json.Serialization;

namespace MailoPost.Models.RequestContent
{
	public class GetRecipientsGroupsRequestContent : BaseCollectionContent
	{
	}

	public class CreateRecipientsGroupRequestContent : BaseContent
	{
		[JsonPropertyName("title")]
		public string? Title { get; set; }
	}

	public class EditRecipientsGroupRequestContent : CreateRecipientsGroupRequestContent
	{
		[JsonIgnore]
		public int Id { get; set; }
	}

	public class RemoveRecipientsGroupRequestContent : BaseContent
	{
		[JsonIgnore]
		public int Id { get; set; }
	}
}
