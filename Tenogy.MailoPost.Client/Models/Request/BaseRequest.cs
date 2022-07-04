using System.Net.Http;
using MailoPost.Models.RequestContent;

namespace MailoPost.Models.Request
{
	public class BaseRequest : IBaseRequest
	{
		public HttpMethod HttpMethod { get; set; }

		public string? Method { get; set; }

		public IBaseContent? Content { get; set; }

		public BaseRequest(HttpMethod httpMethod, string method, IBaseContent? content = default)
		{
			HttpMethod = httpMethod;
			Method = method;
			Content = content;
		}
	}
}
