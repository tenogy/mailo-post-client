using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MailoPost.Models;
using MailoPost.Models.RequestContent;
using MailoPost.Models.Response;

namespace MailoPost
{
	public partial class MailoPostClient
	{
		#region Get

		public async Task<GetRecipientsResponse?> GetRecipients(int groupId)
		{
			return await GetRecipients(new GetRecipientsRequestContent
			{
				GroupId = groupId
			});
		}

		public async Task<GetRecipientsResponse?> GetRecipients(GetRecipientsRequestContent? request)
		{
			request ??= new GetRecipientsRequestContent();
			return await SendRequest<GetRecipientsRequestContent, GetRecipientsResponse>(HttpMethod.Get, $"/email/lists/{request.GroupId}/recipients", request);
		}

		#endregion

		#region Search

		public async Task<SearchRecipientResponse?> SearchRecipient(string? email)
		{
			return await SearchRecipient(new SearchRecipientRequestContent
			{
				Email = email
			});
		}

		public async Task<SearchRecipientResponse?> SearchRecipient(SearchRecipientRequestContent? request)
		{
			request ??= new SearchRecipientRequestContent();
			return await SendRequest<SearchRecipientRequestContent, SearchRecipientResponse>(HttpMethod.Get, "/email/recipients/search", request);
		}

		#endregion

		#region Create

		public async Task<CreateRecipientResponse?> CreateRecipient(int groupId, string? email, IEnumerable<SimpleRecipientParameterModel>? parameters = null)
		{
			return await CreateRecipient(new CreateRecipientRequestContent
			{
				GroupId = groupId,
				Email = email,
				Parameters = parameters
			});
		}

		public async Task<CreateRecipientResponse?> CreateRecipient(CreateRecipientRequestContent? request)
		{
			request ??= new CreateRecipientRequestContent();
			return await SendRequest<CreateRecipientRequestContent, CreateRecipientResponse>(HttpMethod.Post, $"/email/lists/{request.GroupId}/recipients", request);
		}

		#endregion

		#region Import

		public async Task<ImportRecipientsResponse?> ImportRecipients(int groupId, IEnumerable<SimpleRecipientModel> recipients, bool runTriggers = false)
		{
			return await ImportRecipients(new ImportRecipientsRequestContent
			{
				GroupId = groupId,
				Recipients = recipients,
				RunTriggers = runTriggers
			});
		}

		public async Task<ImportRecipientsResponse?> ImportRecipients(ImportRecipientsRequestContent? request)
		{
			request ??= new ImportRecipientsRequestContent();
			return await SendRequest<ImportRecipientsRequestContent, ImportRecipientsResponse>(HttpMethod.Post, $"/email/lists/{request.GroupId}/recipients/imports", request);
		}

		#endregion

		#region Edit

		public async Task<EditRecipientResponse?> EditRecipient(int groupId, int id, string? email, IEnumerable<SimpleRecipientParameterModel>? parameters = null)
		{
			return await EditRecipient(new EditRecipientRequestContent
			{
				GroupId = groupId,
				Id = id,
				Email = email,
				Parameters = parameters
			});
		}

		public async Task<EditRecipientResponse?> EditRecipient(EditRecipientRequestContent? request)
		{
			request ??= new EditRecipientRequestContent();
			return await SendRequest<EditRecipientRequestContent, EditRecipientResponse>(HttpMethod.Patch, $"/email/lists/{request.GroupId}/recipients/{request.Id}", request);
		}

		#endregion

		#region Remove

		public async Task<RemoveRecipientResponse?> RemoveRecipient(int groupId, int id)
		{
			return await RemoveRecipient(new RemoveRecipientRequestContent
			{
				GroupId = groupId,
				Id = id
			});
		}

		public async Task<RemoveRecipientResponse?> RemoveRecipient(RemoveRecipientRequestContent? request)
		{
			request ??= new RemoveRecipientRequestContent();
			return await SendRequest<RemoveRecipientRequestContent, RemoveRecipientResponse>(HttpMethod.Delete, $"/email/lists/{request.GroupId}/recipients/{request.Id}", request);
		}

		#endregion
	}
}
