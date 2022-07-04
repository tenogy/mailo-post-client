using System.Net.Http;
using System.Threading.Tasks;
using MailoPost.Models.Response;

namespace MailoPost
{
	public partial class MailoPostClient
	{
		public async Task<GetBalanceResponse?> GetBalance()
		{
			return await SendRequest<GetBalanceResponse>(HttpMethod.Get, "/email/balance");
		}
	}
}
