using System.Text.Json.Serialization;

namespace MailoPost.Models.RequestContent;

public abstract class BaseCollectionContent : IBaseCollectionContent
{
	[JsonPropertyName("page_number")]
	public int PageNumber { get; set; } = 1;

	[JsonPropertyName("page_size")]
	public int PageSize { get; set; } = 100;
}
