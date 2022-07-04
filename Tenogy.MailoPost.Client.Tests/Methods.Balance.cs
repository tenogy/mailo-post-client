using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MailoPost.Tests
{
	[TestClass]
	public class Balance : Methods
	{
		[TestMethod]
		public async Task Get()
		{
			var response = await Client.GetBalance();
			Assert.IsTrue(
				response?.Success == true &&
				response.Tariff.Subscribers.Total > 0
			);
		}
	}
}
