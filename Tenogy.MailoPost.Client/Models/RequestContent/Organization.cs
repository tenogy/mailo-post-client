using System.Text.Json.Serialization;

namespace MailoPost.Models.RequestContent;

public sealed class GetOrganizationsRequestContent : BaseCollectionContent;

public abstract class BaseOrganizationRequestContent : BaseContent
{
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	[JsonPropertyName("zip")]
	public string? Zip { get; set; }

	[JsonPropertyName("country")]
	public string? Country { get; set; }

	[JsonPropertyName("city")]
	public string? City { get; set; }

	[JsonPropertyName("address")]
	public string? Address { get; set; }

	[JsonPropertyName("phone")]
	public string? Phone { get; set; }
}

public sealed class CreateOrganizationRequestContent : BaseOrganizationRequestContent;

public sealed class EditOrganizationRequestContent : BaseOrganizationRequestContent
{
	public long Id { get; set; }
}

public sealed class RemoveOrganizationRequestContent : BaseContent
{
	public long Id { get; set; }
}
