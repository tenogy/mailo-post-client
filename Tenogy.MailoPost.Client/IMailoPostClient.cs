using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MailoPost.Enums;
using MailoPost.Models;
using MailoPost.Models.Request;
using MailoPost.Models.RequestContent;
using MailoPost.Models.Response;

namespace MailoPost
{
	public interface IMailoPostClient
	{
		#region Send Request

		Task<TResponse?> SendRequest<TResponse>(HttpMethod httpMethod, string method) where TResponse : IBaseResponse;
		Task<TResponse?> SendRequest<TContent, TResponse>(HttpMethod httpMethod, string method, TContent content) where TContent : IBaseContent where TResponse : IBaseResponse;
		Task<TResponse?> SendRequest<TResponse>(IBaseRequest request) where TResponse : IBaseResponse;
		Task<TResponse?> SendRequest<TContent, TResponse>(IBaseRequest request) where TContent : IBaseContent where TResponse : IBaseResponse;

		#endregion

		#region Organization

		Task<GetBalanceResponse?> GetBalance();
		Task<GetOrganizationsResponse?> GetOrganizations(GetOrganizationsRequestContent? request = null);
		Task<GetOrganizationByIdResponse?> GetOrganizationById(int id);
		Task<GetCurrentOrganizationResponse?> GetCurrentOrganization();
		Task<CreateOrganizationResponse?> CreateOrganization(CreateOrganizationRequestContent? request);
		Task<EditOrganizationResponse?> EditOrganization(EditOrganizationRequestContent? request);
		Task<SetCurrentOrganizationResponse?> SetCurrentOrganization(int id);
		Task<RemoveOrganizationResponse?> RemoveOrganization(int id);
		Task<RemoveOrganizationResponse?> RemoveOrganization(RemoveOrganizationRequestContent? request);

		#endregion

		#region Recipient

		Task<GetRecipientsResponse?> GetRecipients(int groupId);
		Task<GetRecipientsResponse?> GetRecipients(GetRecipientsRequestContent? request);
		Task<SearchRecipientResponse?> SearchRecipient(string? email);
		Task<SearchRecipientResponse?> SearchRecipient(SearchRecipientRequestContent? request);
		Task<CreateRecipientResponse?> CreateRecipient(int groupId, string? email, IEnumerable<SimpleRecipientParameterModel>? parameters = null);
		Task<CreateRecipientResponse?> CreateRecipient(CreateRecipientRequestContent? request);
		Task<ImportRecipientsResponse?> ImportRecipients(int groupId, IEnumerable<SimpleRecipientModel> recipients, bool runTriggers = false);
		Task<ImportRecipientsResponse?> ImportRecipients(ImportRecipientsRequestContent? request);
		Task<EditRecipientResponse?> EditRecipient(int groupId, int id, string? email, IEnumerable<SimpleRecipientParameterModel>? parameters = null);
		Task<EditRecipientResponse?> EditRecipient(EditRecipientRequestContent? request);
		Task<RemoveRecipientResponse?> RemoveRecipient(int groupId, int id);
		Task<RemoveRecipientResponse?> RemoveRecipient(RemoveRecipientRequestContent? request);

		#endregion

		#region RecipientsGroup

		Task<GetRecipientsGroupsResponse?> GetRecipientsGroups(GetRecipientsGroupsRequestContent? request = null);
		Task<GetRecipientsGroupByIdResponse?> GetRecipientsGroupsById(int id);
		Task<CreateRecipientsGroupResponse?> CreateRecipientsGroup(string? title);
		Task<CreateRecipientsGroupResponse?> CreateRecipientsGroup(CreateRecipientsGroupRequestContent? request);
		Task<EditRecipientsGroupResponse?> EditRecipientsGroup(int id, string? title);
		Task<EditRecipientsGroupResponse?> EditRecipientsGroup(EditRecipientsGroupRequestContent? request);
		Task<RemoveRecipientsGroupResponse?> RemoveRecipientsGroup(int id);
		Task<RemoveRecipientsGroupResponse?> RemoveRecipientsGroup(RemoveRecipientsGroupRequestContent? request);

		#endregion

		#region RecipientsGroupParameter

		Task<GetRecipientsGroupParametersResponse?> GetRecipientsGroupParameters(int groupId);
		Task<GetRecipientsGroupParametersResponse?> GetRecipientsGroupParameters(GetRecipientsGroupParametersRequestContent? request);
		Task<CreateRecipientsGroupParameterResponse?> CreateRecipientsGroupParameter(int groupId, string? title, ParameterKindEnum? kind = null);
		Task<CreateRecipientsGroupParameterResponse?> CreateRecipientsGroupParameter(CreateRecipientsGroupParameterRequestContent? request);
		Task<EditRecipientsGroupParameterResponse?> EditRecipientsGroupParameter(int groupId, int id, string? title, ParameterKindEnum? kind = null);
		Task<EditRecipientsGroupParameterResponse?> EditRecipientsGroupParameter(EditRecipientsGroupParameterRequestContent? request);
		Task<BaseResponse?> RemoveRecipientsGroupParameter(int groupId, int id);
		Task<RemoveRecipientsGroupParameterResponse?> RemoveRecipientsGroupParameter(RemoveRecipientsGroupParameterRequestContent? request);

		#endregion
	}
}
