using MailoPost.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MailoPost.Tests;

[TestClass]
public sealed class Recipient : BaseTestClass
{
	[TestMethod]
	public async Task Get()
	{
		var (group, _, recipient) = await CreateTmpRecipient();
		var response = await Client.GetRecipients(group.Id);

		Assert.IsTrue(response?.Success == true && response.Collection?.FirstOrDefault()?.Id == recipient.Id);

		await Client.RemoveRecipientsGroup(group.Id);
	}

	[TestMethod]
	public async Task Search()
	{
		const string email = "test@mail.ru";
		var response = await Client.SearchRecipient(email);

		Assert.IsTrue(
			HasErrorCode(response, code: 404) ||
			response?.Success == true &&
			response.Collection?.Any(x => x.Email == email) == true
		);
	}

	[TestMethod]
	public async Task Import()
	{
		var group = await CreateTmpRecipientsGroup();
		var response = await Client.ImportRecipients(group.Id, recipients: new[] { 1, 2, 3 }.Select(x => new SimpleRecipientModel
		{
			Email = $"test-{x}@mail.ru",
		}).ToArray());

		Assert.IsTrue(response is { Success: true, ImportId: > 0 });

		await Client.RemoveRecipientsGroup(group.Id);
	}

	[TestMethod]
	public async Task Create()
	{
		var (group, _, recipient) = await CreateTmpRecipient();

		Assert.IsTrue(
			recipient is { Id: > 0 } &&
			recipient.GroupId == group.Id
		);

		await Client.RemoveRecipientsGroup(group.Id);
	}

	[TestMethod]
	public async Task Edit()
	{
		const string email = "test@mail.ru";
		var (group, _, recipient) = await CreateTmpRecipient();
		var response = await Client.EditRecipient(group.Id, recipient.Id, email);

		Assert.IsTrue(response is { Success: true, Id: > 0, Email: email });

		await Client.RemoveRecipientsGroup(group.Id);
	}

	[TestMethod]
	public async Task Remove()
	{
		var (group, _, recipient) = await CreateTmpRecipient();
		var response = await Client.RemoveRecipient(group.Id, recipient.Id);

		Assert.IsTrue(response?.Success);

		await Client.RemoveRecipientsGroup(group.Id);
	}
}
