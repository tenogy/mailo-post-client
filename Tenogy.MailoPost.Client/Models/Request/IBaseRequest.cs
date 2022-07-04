using System.Net.Http;
using MailoPost.Models.RequestContent;

namespace MailoPost.Models.Request
{
	public interface IBaseRequest
	{
		HttpMethod HttpMethod { get; set; }
		string? Method { get; set; }
		IBaseContent? Content { get; set; }
	}
}
