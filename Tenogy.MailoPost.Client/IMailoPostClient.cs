using MailoPost.Enums;
using MailoPost.Models;
using MailoPost.Models.Request;
using MailoPost.Models.RequestContent;
using MailoPost.Models.Response;

namespace MailoPost;

public interface IMailoPostClient : IDisposable
{
	#region Organization

	Task<GetBalanceResponse?> GetBalance();
	Task<GetOrganizationsResponse?> GetOrganizations(GetOrganizationsRequestContent? request = null);
	Task<GetOrganizationByIdResponse?> GetOrganizationById(long id);
	Task<GetCurrentOrganizationResponse?> GetCurrentOrganization();
	Task<CreateOrganizationResponse?> CreateOrganization(CreateOrganizationRequestContent? request);
	Task<EditOrganizationResponse?> EditOrganization(EditOrganizationRequestContent? request);
	Task<SetCurrentOrganizationResponse?> SetCurrentOrganization(long id);
	Task<RemoveOrganizationResponse?> RemoveOrganization(long id);
	Task<RemoveOrganizationResponse?> RemoveOrganization(RemoveOrganizationRequestContent? request);

	#endregion

	#region Recipient

	Task<GetRecipientsResponse?> GetRecipients(long groupId);
	Task<GetRecipientsResponse?> GetRecipients(GetRecipientsRequestContent? request);
	Task<SearchRecipientResponse?> SearchRecipient(string? email);
	Task<SearchRecipientResponse?> SearchRecipient(SearchRecipientRequestContent? request);
	Task<CreateRecipientResponse?> CreateRecipient(long groupId, string? email, IEnumerable<SimpleRecipientParameterModel>? parameters = null);
	Task<CreateRecipientResponse?> CreateRecipient(CreateRecipientRequestContent? request);
	Task<ImportRecipientsResponse?> ImportRecipients(long groupId, IEnumerable<SimpleRecipientModel> recipients, bool runTriggers = false);
	Task<ImportRecipientsResponse?> ImportRecipients(ImportRecipientsRequestContent? request);
	Task<EditRecipientResponse?> EditRecipient(long groupId, long id, string? email, IEnumerable<SimpleRecipientParameterModel>? parameters = null);
	Task<EditRecipientResponse?> EditRecipient(EditRecipientRequestContent? request);
	Task<RemoveRecipientResponse?> RemoveRecipient(long groupId, long id);
	Task<RemoveRecipientResponse?> RemoveRecipient(RemoveRecipientRequestContent? request);

	#endregion

	#region RecipientsGroup

	Task<GetRecipientsGroupsResponse?> GetRecipientsGroups(GetRecipientsGroupsRequestContent? request = null);
	Task<GetRecipientsGroupByIdResponse?> GetRecipientsGroupsById(long id);
	Task<CreateRecipientsGroupResponse?> CreateRecipientsGroup(string? title);
	Task<CreateRecipientsGroupResponse?> CreateRecipientsGroup(CreateRecipientsGroupRequestContent? request);
	Task<EditRecipientsGroupResponse?> EditRecipientsGroup(long id, string? title);
	Task<EditRecipientsGroupResponse?> EditRecipientsGroup(EditRecipientsGroupRequestContent? request);
	Task<RemoveRecipientsGroupResponse?> RemoveRecipientsGroup(long id);
	Task<RemoveRecipientsGroupResponse?> RemoveRecipientsGroup(RemoveRecipientsGroupRequestContent? request);

	#endregion

	#region RecipientsGroupParameter

	Task<GetRecipientsGroupParametersResponse?> GetRecipientsGroupParameters(long groupId);
	Task<GetRecipientsGroupParametersResponse?> GetRecipientsGroupParameters(GetRecipientsGroupParametersRequestContent? request);
	Task<CreateRecipientsGroupParameterResponse?> CreateRecipientsGroupParameter(long groupId, string? title, ParameterKindEnum? kind = null);
	Task<CreateRecipientsGroupParameterResponse?> CreateRecipientsGroupParameter(CreateRecipientsGroupParameterRequestContent? request);
	Task<EditRecipientsGroupParameterResponse?> EditRecipientsGroupParameter(long groupId, long id, string? title, ParameterKindEnum? kind = null);
	Task<EditRecipientsGroupParameterResponse?> EditRecipientsGroupParameter(EditRecipientsGroupParameterRequestContent? request);
	Task<BaseResponse?> RemoveRecipientsGroupParameter(long groupId, long id);
	Task<RemoveRecipientsGroupParameterResponse?> RemoveRecipientsGroupParameter(RemoveRecipientsGroupParameterRequestContent? request);

	#endregion
}
