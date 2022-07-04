using System.Linq;
using System.Threading.Tasks;
using MailoPost.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MailoPost.Tests
{
	[TestClass]
	public class RecipientsGroupParameter : Methods
	{
		[TestMethod]
		public async Task Get()
		{
			var (_, parameter) = await CreateTmpRecipientsGroupParameter();
			var response = await Client.GetRecipientsGroupParameters(parameter.GroupId);

			Assert.IsTrue(response?.Success == true && response.Collection?.FirstOrDefault()?.Id == parameter.Id);

			await Client.RemoveRecipientsGroup(parameter.GroupId);
		}

		[TestMethod]
		public async Task Create()
		{
			var group = await CreateTmpRecipientsGroup();
			var response = await Client.CreateRecipientsGroupParameter(group.Id, "PARAM", ParameterKindEnum.Numeric);

			Assert.IsTrue(
				response?.Success == true &&
				response.Title == "PARAM" &&
				response.Kind == ParameterKindEnum.Numeric
			);

			await Client.RemoveRecipientsGroup(group.Id);
		}

		[TestMethod]
		public async Task Edit()
		{
			var (_, parameter) = await CreateTmpRecipientsGroupParameter();
			parameter.Title += " Edited";
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
}
