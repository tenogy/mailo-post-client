using MailoPost.Models.RequestContent;

namespace MailoPost.Models.Request;

public sealed class DefaultRequest : BaseRequest
{
	public DefaultRequest(HttpMethod httpMethod, string method, IBaseContent? content = null) : base(httpMethod, method, content)
	{
	}
}
