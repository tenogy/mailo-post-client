using MailoPost.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MailoPost.Tests;

[TestClass]
public sealed class RecipientsGroupParameter : BaseTestClass
{
	[TestMethod]
	public async Task Get()
	{
		var (_, parameter) = await CreateTmpRecipientsGroupParameter();
		var response = await Client.GetRecipientsGroupParameters(parameter.GroupId);

		Assert.IsTrue(response?.Success == true && response.Collection?.First().Id == parameter.Id);

		await Client.RemoveRecipientsGroup(parameter.GroupId);
	}

	[TestMethod]
	public async Task Create()
	{
		const string title = "param";
		var group = await CreateTmpRecipientsGroup();
		var response = await Client.CreateRecipientsGroupParameter(group.Id, title, ParameterKindEnum.Numeric);

		Assert.IsTrue(response is { Success: true, Title: title, Kind: ParameterKindEnum.Numeric });

		await Client.RemoveRecipientsGroup(group.Id);
	}

	[TestMethod]
	public async Task Edit()
	{
		var (_, parameter) = await CreateTmpRecipientsGroupParameter();
		parameter.Title += "-edited";
		var response = await Client.EditRecipientsGroupParameter(parameter.GroupId, parameter.Id, parameter.Title);

		Assert.IsTrue(
			response?.Success == true &&
			response.Title == parameter.Title
		);

		await Client.RemoveRecipientsGroup(parameter.GroupId);
	}

	[TestMethod]
	public async Task Remove()
	{
		var (_, parameter) = await CreateTmpRecipientsGroupParameter();
		var response = await Client.RemoveRecipientsGroupParameter(parameter.GroupId, parameter.Id);

		Assert.IsTrue(response?.Success);

		await Client.RemoveRecipientsGroup(parameter.GroupId);
	}
}
