using MailoPost.Models;
using MailoPost.Models.RequestContent;
using MailoPost.Models.Response;

namespace MailoPost;

public partial class MailoPostClient
{
	#region Get

	public async Task<GetRecipientsResponse?> GetRecipients(long groupId)
		=> await GetRecipients(new GetRecipientsRequestContent
		{
			GroupId = groupId,
		});

	public async Task<GetRecipientsResponse?> GetRecipients(GetRecipientsRequestContent? request)
	{
		request ??= new GetRecipientsRequestContent();
		return await SendRequest<GetRecipientsRequestContent, GetRecipientsResponse>(HttpMethod.Get, method: $"/email/lists/{request.GroupId}/recipients", request);
	}

	#endregion

	#region Search

	public async Task<SearchRecipientResponse?> SearchRecipient(string? email)
		=> await SearchRecipient(new SearchRecipientRequestContent
		{
			Email = email,
		});

	public async Task<SearchRecipientResponse?> SearchRecipient(SearchRecipientRequestContent? request)
	{
		request ??= new SearchRecipientRequestContent();
		return await SendRequest<SearchRecipientRequestContent, SearchRecipientResponse>(HttpMethod.Get, method: "/email/recipients/search", request);
	}

	#endregion

	#region Create

	public async Task<CreateRecipientResponse?> CreateRecipient(long groupId, string? email, IEnumerable<SimpleRecipientParameterModel>? parameters = null)
		=> await CreateRecipient(new CreateRecipientRequestContent
		{
			GroupId = groupId,
			Email = email,
			Parameters = parameters,
		});

	public async Task<CreateRecipientResponse?> CreateRecipient(CreateRecipientRequestContent? request)
	{
		request ??= new CreateRecipientRequestContent();
		return await SendRequest<CreateRecipientRequestContent, CreateRecipientResponse>(HttpMethod.Post, method: $"/email/lists/{request.GroupId}/recipients", request);
	}

	#endregion

	#region Import

	public async Task<ImportRecipientsResponse?> ImportRecipients(long groupId, IEnumerable<SimpleRecipientModel> recipients, bool runTriggers = false)
		=> await ImportRecipients(new ImportRecipientsRequestContent
		{
			GroupId = groupId,
			Recipients = recipients,
			RunTriggers = runTriggers,
		});

	public async Task<ImportRecipientsResponse?> ImportRecipients(ImportRecipientsRequestContent? request)
	{
		request ??= new ImportRecipientsRequestContent();
		return await SendRequest<ImportRecipientsRequestContent, ImportRecipientsResponse>(HttpMethod.Post, method: $"/email/lists/{request.GroupId}/recipients/imports", request);
	}

	#endregion

	#region Edit

	public async Task<EditRecipientResponse?> EditRecipient(long groupId, long id, string? email, IEnumerable<SimpleRecipientParameterModel>? parameters = null)
		=> await EditRecipient(new EditRecipientRequestContent
		{
			GroupId = groupId,
			Id = id,
			Email = email,
			Parameters = parameters,
		});

	public async Task<EditRecipientResponse?> EditRecipient(EditRecipientRequestContent? request)
	{
		request ??= new EditRecipientRequestContent();
		return await SendRequest<EditRecipientRequestContent, EditRecipientResponse>(HttpMethod.Patch, method: $"/email/lists/{request.GroupId}/recipients/{request.Id}", request);
	}

	#endregion

	#region Remove

	public async Task<RemoveRecipientResponse?> RemoveRecipient(long groupId, long id)
		=> await RemoveRecipient(new RemoveRecipientRequestContent
		{
			GroupId = groupId,
			Id = id,
		});

	public async Task<RemoveRecipientResponse?> RemoveRecipient(RemoveRecipientRequestContent? request)
	{
		request ??= new RemoveRecipientRequestContent();
		return await SendRequest<RemoveRecipientRequestContent, RemoveRecipientResponse>(HttpMethod.Delete, method: $"/email/lists/{request.GroupId}/recipients/{request.Id}", request);
	}

	#endregion
}
