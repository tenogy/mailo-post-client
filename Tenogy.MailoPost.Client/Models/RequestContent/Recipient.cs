using System.Text.Json.Serialization;

namespace MailoPost.Models.RequestContent;

public sealed class GetRecipientsRequestContent : BaseCollectionContent
{
	[JsonIgnore]
	public long GroupId { get; set; }
}

public sealed class SearchRecipientRequestContent : BaseCollectionContent
{
	[JsonPropertyName("email")]
	public string? Email { get; set; }
}

public abstract class BaseRecipientRequestContent : BaseContent
{
	[JsonIgnore]
	public long GroupId { get; set; }

	[JsonPropertyName("email")]
	public string? Email { get; set; }

	[JsonPropertyName("unconfirmed")]
	public bool? Unconfirmed { get; set; }

	[JsonPropertyName("values")]
	public IEnumerable<SimpleRecipientParameterModel>? Parameters { get; set; }
}

public sealed class CreateRecipientRequestContent : BaseRecipientRequestContent;

public sealed class ImportRecipientsRequestContent : BaseContent
{
	[JsonIgnore]
	public long GroupId { get; set; }

	[JsonPropertyName("recipients")]
	public IEnumerable<SimpleRecipientModel>? Recipients { get; set; }

	[JsonPropertyName("run_triggers")]
	public bool RunTriggers { get; set; }
}

public sealed class EditRecipientRequestContent : BaseRecipientRequestContent
{
	[JsonIgnore]
	public long Id { get; set; }
}

public sealed class RemoveRecipientRequestContent : BaseContent
{
	[JsonIgnore]
	public long GroupId { get; set; }

	[JsonIgnore]
	public long Id { get; set; }
}
