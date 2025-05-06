using MailoPost.Models.RequestContent;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MailoPost.Tests;

[TestClass]
public sealed class Organization : BaseTestClass
{
	[TestMethod]
	public async Task Get()
	{
		var organization = await CreateTmpOrganization();
		var response = await Client.GetOrganizations();

		Assert.IsTrue(
			response?.Success == true &&
			response.Collection?.Any(x => x.Id == organization.Id) == true
		);

		await Client.RemoveOrganization(organization.Id);
	}

	[TestMethod]
	public async Task GetById()
	{
		var organization = await CreateTmpOrganization();
		var response = await Client.GetOrganizationById(organization.Id);

		Assert.IsTrue(
			response?.Success == true &&
			response.Id == organization.Id
		);

		await Client.RemoveOrganization(organization.Id);
	}

	[TestMethod]
	public async Task GetCurrent()
	{
		var organization = await CreateTmpOrganization();
		await Client.SetCurrentOrganization(organization.Id);
		var response = await Client.GetCurrentOrganization();

		Assert.IsTrue(
			response?.Success == true &&
			response.Id == organization.Id
		);

		await Client.RemoveOrganization(organization.Id);
	}

	[TestMethod]
	public async Task SetCurrent()
	{
		var organization = await CreateTmpOrganization();
		var response = await Client.SetCurrentOrganization(organization.Id);

		Assert.IsTrue(
			response?.Success == true &&
			response.Id == organization.Id
		);

		await Client.RemoveOrganization(organization.Id);
	}

	[TestMethod]
	public async Task Create()
	{
		var organization = await CreateTmpOrganization();

		Assert.IsTrue(organization?.Id > 0);

		await Client.RemoveOrganization(organization.Id);
	}

	[TestMethod]
	public async Task Edit()
	{
		var organization = await CreateTmpOrganization();

		organization.Name += "-edited";

		var response = await Client.EditOrganization(new EditOrganizationRequestContent
		{
			Id = organization.Id,
			Name = organization.Name,
		});

		Assert.IsTrue(response?.Success == true && response.Name == organization.Name);

		await Client.RemoveOrganization(organization.Id);
	}

	[TestMethod]
	public async Task Remove()
	{
		var organization = await CreateTmpOrganization();
		var response = await Client.RemoveOrganization(organization.Id);

		Assert.IsTrue(response?.Success);
	}
}
