using System.Text.Json.Serialization;
using MailoPost.Enums;

namespace MailoPost.Models.RequestContent;

public sealed class GetRecipientsGroupParametersRequestContent : BaseCollectionContent
{
	[JsonIgnore]
	public long GroupId { get; set; }
}

public abstract class BaseRecipientsGroupParameterRequestContent : BaseContent
{
	[JsonIgnore]
	public long GroupId { get; set; }

	[JsonPropertyName("title")]
	public string? Title { get; set; }

	[JsonPropertyName("kind")]
	public ParameterKindEnum? Kind { get; set; }
}

public sealed class CreateRecipientsGroupParameterRequestContent : BaseRecipientsGroupParameterRequestContent;

public sealed class EditRecipientsGroupParameterRequestContent : BaseRecipientsGroupParameterRequestContent
{
	[JsonIgnore]
	public long Id { get; set; }
}

public sealed class RemoveRecipientsGroupParameterRequestContent : BaseContent
{
	[JsonIgnore]
	public long GroupId { get; set; }

	[JsonIgnore]
	public long Id { get; set; }
}
