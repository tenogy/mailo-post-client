using System.Text.Json.Serialization;

namespace MailoPost.Models.RequestContent;

public sealed class GetRecipientsGroupsRequestContent : BaseCollectionContent;

public abstract class BaseRecipientsGroupRequestContent : BaseContent
{
	[JsonPropertyName("title")]
	public string? Title { get; set; }
}

public sealed class CreateRecipientsGroupRequestContent : BaseRecipientsGroupRequestContent;

public sealed class EditRecipientsGroupRequestContent : BaseRecipientsGroupRequestContent
{
	[JsonIgnore]
	public long Id { get; set; }
}

public sealed class RemoveRecipientsGroupRequestContent : BaseContent
{
	[JsonIgnore]
	public long Id { get; set; }
}
