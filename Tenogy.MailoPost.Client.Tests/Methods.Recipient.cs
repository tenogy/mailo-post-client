using System.Linq;
using System.Threading.Tasks;
using MailoPost.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MailoPost.Tests
{
	[TestClass]
	public class Recipient : Methods
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
			var email = "test@mail.ru";
			var response = await Client.SearchRecipient(email);

			Assert.IsTrue(
				HasErrorCode(response, 404) ||
				response?.Success == true &&
				response.Collection?.Any(x => x.Email == email) == true
			);
		}

		[TestMethod]
		public async Task Import()
		{
			var group = await CreateTmpRecipientsGroup();
			var response = await Client.ImportRecipients(group.Id, new[] { 1, 2, 3 }.Select(x => new SimpleRecipientModel
			{
				Email = $"test-{x}@mail.ru",
			}).ToArray());

			Assert.IsTrue(response?.Success == true && response.ImportId > 0);

			await Client.RemoveRecipientsGroup(group.Id);
		}

		[TestMethod]
		public async Task Create()
		{
			var (group, _, recipient) = await CreateTmpRecipient();

			Assert.IsTrue(
				recipient != null &&
				recipient.Id > 0 &&
				recipient.GroupId == group.Id
			);

			await Client.RemoveRecipientsGroup(group.Id);
		}

		[TestMethod]
		public async Task Edit()
		{
			var (group, _, recipient) = await CreateTmpRecipient();
			var response = await Client.EditRecipient(group.Id, recipient.Id, "test@mail.ru");

			Assert.IsTrue(
				response?.Success == true &&
				response.Id > 0 &&
				response.Email == "test@mail.ru"
			);

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
}
