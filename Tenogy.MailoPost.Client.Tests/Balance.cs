using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MailoPost.Tests;

[TestClass]
public sealed class Balance : BaseTestClass
{
	[TestMethod]
	public async Task Get()
	{
		var response = await Client.GetBalance();
		Assert.IsTrue(response is { Success: true, Tariff.Subscribers.Total: > 0 });
	}
}
