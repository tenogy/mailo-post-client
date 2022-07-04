using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailoPost.Enums;
using MailoPost.Models;
using MailoPost.Models.RequestContent;
using MailoPost.Models.Response;

namespace MailoPost.Tests
{
	public class Methods
	{
		protected readonly MailoPostClient Client;
		private readonly Random _random;

		public Methods()
		{
			Client = new MailoPostClient("YOUR-API-TOKEN");
			_random = new Random();
		}

		protected static bool HasErrorCode(IBaseResponse response, int code)
		{
			return response?.Errors?.Any(x => x.Code == code) == true;
		}

		protected async Task<RecipientsGroupModel> CreateTmpRecipientsGroup()
		{
			var number = _random.Next(100001);
			var title = "TmpRecipientsGroup-" + number;
			var response = await Client.CreateRecipientsGroup(title);

			if (response?.Id > 0)
				return new RecipientsGroupModel
				{
					Id = response.Id,
					Title = response.Title
				};

			return null;
		}

		protected async Task<(RecipientsGroupModel, RecipientsGroupParameterModel)> CreateTmpRecipientsGroupParameter()
		{
			var group = await CreateTmpRecipientsGroup();
			var param = await CreateTmpRecipientsGroupParameter(group.Id, ParameterKindEnum.Numeric);

			return (group, param);
		}

		protected async Task<RecipientsGroupParameterModel> CreateTmpRecipientsGroupParameter(int groupId, ParameterKindEnum kind)
		{
			var title = "Param " + kind;
			var response = await Client.CreateRecipientsGroupParameter(groupId, title, kind);

			if (response?.Id > 0)
				return new RecipientsGroupParameterModel
				{
					GroupId = response.GroupId,
					Id = response.Id,
					Title = response.Title,
					Kind = response.Kind
				};

			return null;
		}

		protected async Task<(RecipientsGroupModel, Dictionary<ParameterKindEnum, RecipientsGroupParameterModel>, RecipientModel)> CreateTmpRecipient()
		{
			var group = await CreateTmpRecipientsGroup();
			var parameters = new Dictionary<ParameterKindEnum, RecipientsGroupParameterModel>
			{
				{ ParameterKindEnum.String, await CreateTmpRecipientsGroupParameter(group.Id, ParameterKindEnum.String) },
				{ ParameterKindEnum.Numeric, await CreateTmpRecipientsGroupParameter(group.Id, ParameterKindEnum.Numeric) },
				{ ParameterKindEnum.Date, await CreateTmpRecipientsGroupParameter(group.Id, ParameterKindEnum.Date) },
				{ ParameterKindEnum.Boolean, await CreateTmpRecipientsGroupParameter(group.Id, ParameterKindEnum.Boolean) },
			};

			var response = await Client.CreateRecipient(group.Id, "i.n.efimov@mail.ru", new[]
			{
				new SimpleRecipientParameterModel { Id = parameters[ParameterKindEnum.String].Id, Value = "Hello, World!" },
				new SimpleRecipientParameterModel { Id = parameters[ParameterKindEnum.Numeric].Id, Value = 123.12 },
				new SimpleRecipientParameterModel { Id = parameters[ParameterKindEnum.Date].Id, Value = DateTime.UtcNow },
				new SimpleRecipientParameterModel { Id = parameters[ParameterKindEnum.Boolean].Id, Value = true }
			});

			if (response?.Id > 0)
				return (group, parameters, new RecipientModel
				{
					GroupId = response.GroupId,
					Id = response.Id,
					Email = response.Email,
					Confirmed = response.Confirmed,
					Status = response.Status,
					Parameters = response.Parameters
				});

			return (group, parameters, null);
		}

		protected async Task<OrganizationModel> CreateTmpOrganization()
		{
			var response = await Client.CreateOrganization(new CreateOrganizationRequestContent
			{
				Name = "ООО «Роги и копыта»",
				Zip = "150020",
				Country = "Россия",
				City = "Ярославль",
				Address = "проспект Ленина, д. 25",
				Phone = "+7 980 747 6442",
			});

			if (response?.Id > 0)
				return new OrganizationModel
				{
					Id = response.Id,
					Name = response.Name,
					Zip = response.Zip,
					Country = response.Country,
					City = response.City,
					Address = response.Address,
					Phone = response.Phone,
					Current = response.Current,
				};

			return null;
		}
	}
}
