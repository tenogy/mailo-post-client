using MailoPost.Models.RequestContent;

namespace MailoPost.Models.Request;

public abstract class BaseRequest : IBaseRequest
{
	public HttpMethod HttpMethod { get; set; }

	public string? Method { get; set; }

	public IBaseContent? Content { get; set; }

	protected BaseRequest(HttpMethod httpMethod, string method, IBaseContent? content = null)
	{
		HttpMethod = httpMethod;
		Method = method;
		Content = content;
	}
}
