using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace MailoPost.Models.Response
{
	public class GetBalanceResponse : BalanceModel, IBaseResponse
	{
		[JsonIgnore]
		public bool Success => Errors?.Any() != true;

		[JsonPropertyName("errors")]
		public IEnumerable<ErrorOfResponse>? Errors { get; set; }
	}
}
