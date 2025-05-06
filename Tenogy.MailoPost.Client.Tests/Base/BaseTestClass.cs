using MailoPost.Enums;
using MailoPost.Models;
using MailoPost.Models.RequestContent;
using MailoPost.Models.Response;

namespace MailoPost.Tests;

public abstract class BaseTestClass
{
	protected readonly MailoPostClient Client = new(apiToken: "7a42be55497991bcc64f22c17b319f68");
	protected readonly Random Rnd = Random.Shared;

	protected static bool HasErrorCode(IBaseResponse? response, int code)
		=> response?.Errors?.Any(x => x.Code == code) == true;

	protected static string GetErrorMessage(IBaseResponse? response)
		=> " " + string.Join("; ", response?.Errors?.Select(error => $"{error.Code} - {error.Detail}") ?? []);

	protected async Task<RecipientsGroupModel> CreateTmpRecipientsGroup()
	{
		var title = "TmpRecipientsGroup-" + Rnd.Next(100001);
		var response = await Client.CreateRecipientsGroup(title);

		if (response is null || response.Id == 0)
			throw new InvalidOperationException("CreateTmpRecipientsGroup failed." + GetErrorMessage(response));

		return new RecipientsGroupModel
		{
			Id = response.Id,
			Title = response.Title,
		};
	}

	protected async Task<(RecipientsGroupModel, RecipientsGroupParameterModel)> CreateTmpRecipientsGroupParameter()
	{
		var group = await CreateTmpRecipientsGroup();
		var parameter = await CreateTmpRecipientsGroupParameter(group.Id, ParameterKindEnum.Numeric);

		return (group, parameter);
	}

	protected async Task<RecipientsGroupParameterModel> CreateTmpRecipientsGroupParameter(long groupId, ParameterKindEnum kind)
	{
		var title = "Param " + kind;
		var response = await Client.CreateRecipientsGroupParameter(groupId, title, kind);

		if (response is null || response.Id == 0)
			throw new InvalidOperationException("CreateTmpRecipientsGroupParameter failed." + GetErrorMessage(response));

		return new RecipientsGroupParameterModel
		{
			GroupId = response.GroupId,
			Id = response.Id,
			Title = response.Title,
			Kind = response.Kind,
		};
	}

	protected async Task<(RecipientsGroupModel group, Dictionary<ParameterKindEnum, RecipientsGroupParameterModel> parameters, RecipientModel recipient)> CreateTmpRecipient()
	{
		var group = await CreateTmpRecipientsGroup();

		var parameters = new Dictionary<ParameterKindEnum, RecipientsGroupParameterModel>
		{
			{ ParameterKindEnum.String, await CreateTmpRecipientsGroupParameter(group.Id, ParameterKindEnum.String) },
			{ ParameterKindEnum.Numeric, await CreateTmpRecipientsGroupParameter(group.Id, ParameterKindEnum.Numeric) },
			{ ParameterKindEnum.Date, await CreateTmpRecipientsGroupParameter(group.Id, ParameterKindEnum.Date) },
			{ ParameterKindEnum.Boolean, await CreateTmpRecipientsGroupParameter(group.Id, ParameterKindEnum.Boolean) },
		};

		var response = await Client.CreateRecipient(group.Id, email: "i.n.efimov@mail.ru", [
			new SimpleRecipientParameterModel { Id = parameters[ParameterKindEnum.String].Id, Value = "Hello, World!" },
			new SimpleRecipientParameterModel { Id = parameters[ParameterKindEnum.Numeric].Id, Value = 123.12 },
			new SimpleRecipientParameterModel { Id = parameters[ParameterKindEnum.Date].Id, Value = DateTime.UtcNow },
			new SimpleRecipientParameterModel { Id = parameters[ParameterKindEnum.Boolean].Id, Value = true },
		]);

		if (response is null || response.Id == 0)
			throw new InvalidOperationException("CreateTmpRecipient failed." + GetErrorMessage(response));

		return (group, parameters, new RecipientModel
		{
			GroupId = response.GroupId,
			Id = response.Id,
			Email = response.Email,
			Confirmed = response.Confirmed,
			Status = response.Status,
			Parameters = response.Parameters,
		});
	}

	protected async Task<OrganizationModel> CreateTmpOrganization()
	{
		var response = await Client.CreateOrganization(new CreateOrganizationRequestContent
		{
			Name = "ООО «Рога и копыта»",
			Zip = "150020",
			Country = "Россия",
			City = "Ярославль",
			Address = "проспект Ленина, д. 25",
			Phone = "+7 980 747 6442",
		});

		if (response is null || response.Id == 0)
			throw new InvalidOperationException("CreateTmpOrganization failed.");

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
	}
}
