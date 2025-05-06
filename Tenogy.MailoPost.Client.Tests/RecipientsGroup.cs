using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MailoPost.Tests;

[TestClass]
public sealed class RecipientsGroup : BaseTestClass
{
	[TestMethod]
	public async Task Get()
	{
		var response = await Client.GetRecipientsGroups();
		Assert.IsTrue(response?.Success);
	}

	[TestMethod]
	public async Task GetById()
	{
		var group = await CreateTmpRecipientsGroup();
		var response = await Client.GetRecipientsGroupsById(group.Id);

		Assert.IsTrue(
			response?.Success == true &&
			response.Title == group.Title
		);

		await Client.RemoveRecipientsGroup(group.Id);
	}

	[TestMethod]
	public async Task Create()
	{
		const string title = "CreateRecipientsGroup";
		var response = await Client.CreateRecipientsGroup(title);

		Assert.IsTrue(
			response is { Success: true, Title: title } ||
			HasErrorCode(response, code: 422)
		);

		await Client.RemoveRecipientsGroup(response?.Id ?? 0);
	}

	[TestMethod]
	public async Task Edit()
	{
		var group = await CreateTmpRecipientsGroup();

		group.Title += "-edited";

		var response = await Client.EditRecipientsGroup(group.Id, group.Title);

		Assert.IsTrue(
			response?.Success == true &&
			response.Title == group.Title
		);

		await Client.RemoveRecipientsGroup(group.Id);
	}

	[TestMethod]
	public async Task Remove()
	{
		var group = await CreateTmpRecipientsGroup();
		var response = await Client.RemoveRecipientsGroup(group.Id);

		Assert.IsTrue(response?.Success);
	}
}
