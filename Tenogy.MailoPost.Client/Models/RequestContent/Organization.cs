using System.Text.Json.Serialization;

namespace MailoPost.Models.RequestContent
{
	public class GetOrganizationsRequestContent : BaseCollectionContent
	{
	}

	public class CreateOrganizationRequestContent : BaseContent
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

	public class EditOrganizationRequestContent : CreateOrganizationRequestContent
	{
		public int Id { get; set; }
	}

	public class RemoveOrganizationRequestContent : BaseContent
	{
		public int Id { get; set; }
	}
}
