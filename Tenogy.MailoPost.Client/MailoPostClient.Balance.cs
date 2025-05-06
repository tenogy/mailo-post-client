using MailoPost.Models.Response;

namespace MailoPost;

public partial class MailoPostClient
{
	public async Task<GetBalanceResponse?> GetBalance()
		=> await SendRequest<GetBalanceResponse>(HttpMethod.Get, method: "/email/balance");
}
