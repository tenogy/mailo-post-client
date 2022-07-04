using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace MailoPost.Models.Response
{
	public class BaseCollectionResponse<TItem> : IBaseCollectionResponse<TItem> where TItem : class
	{
		[JsonIgnore]
		public bool Success => Errors?.Any() != true;

		[JsonPropertyName("errors")]
		public IEnumerable<ErrorOfResponse>? Errors { get; set; }

		[JsonPropertyName("total_count")]
		public int TotalCount { get; set; }

		[JsonPropertyName("total_pages")]
		public int TotalPages { get; set; }

		[JsonPropertyName("page_number")]
		public int PageNumber { get; set; }

		[JsonPropertyName("page_size")]
		public int PageSize { get; set; }

		[JsonPropertyName("collection")]
		public IEnumerable<TItem>? Collection { get; set; }
	}
}
