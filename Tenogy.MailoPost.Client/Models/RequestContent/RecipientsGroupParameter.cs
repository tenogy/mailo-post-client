using System.Text.Json.Serialization;
using MailoPost.Enums;

namespace MailoPost.Models.RequestContent
{
	public class GetRecipientsGroupParametersRequestContent : BaseCollectionContent
	{
		[JsonIgnore]
		public int GroupId { get; set; }
	}

	public class CreateRecipientsGroupParameterRequestContent : BaseContent
	{
		[JsonIgnore]
		public int GroupId { get; set; }

		[JsonPropertyName("title")]
		public string? Title { get; set; }

		[JsonPropertyName("kind")]
		public ParameterKindEnum? Kind { get; set; }
	}

	public class EditRecipientsGroupParameterRequestContent : CreateRecipientsGroupParameterRequestContent
	{
		[JsonIgnore]
		public int Id { get; set; }
	}

	public class RemoveRecipientsGroupParameterRequestContent : BaseContent
	{
		[JsonIgnore]
		public int GroupId { get; set; }

		[JsonIgnore]
		public int Id { get; set; }
	}
}
