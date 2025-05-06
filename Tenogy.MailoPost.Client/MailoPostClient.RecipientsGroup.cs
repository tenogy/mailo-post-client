using MailoPost.Models.RequestContent;
using MailoPost.Models.Response;

namespace MailoPost;

public partial class MailoPostClient
{
	#region Get

	public async Task<GetRecipientsGroupsResponse?> GetRecipientsGroups(GetRecipientsGroupsRequestContent? request = null)
		=> await SendRequest<GetRecipientsGroupsRequestContent, GetRecipientsGroupsResponse>(HttpMethod.Get, method: "/email/lists", request ?? new GetRecipientsGroupsRequestContent());

	public async Task<GetRecipientsGroupByIdResponse?> GetRecipientsGroupsById(long id)
		=> await SendRequest<GetRecipientsGroupByIdResponse>(HttpMethod.Get, method: $"/email/lists/{id}");

	#endregion

	#region Create

	public async Task<CreateRecipientsGroupResponse?> CreateRecipientsGroup(string? title)
		=> await CreateRecipientsGroup(new CreateRecipientsGroupRequestContent
		{
			Title = title,
		});

	public async Task<CreateRecipientsGroupResponse?> CreateRecipientsGroup(CreateRecipientsGroupRequestContent? request)
		=> await SendRequest<CreateRecipientsGroupRequestContent, CreateRecipientsGroupResponse>(HttpMethod.Post, method: "/email/lists", request ?? new CreateRecipientsGroupRequestContent());

	#endregion

	#region Edit

	public async Task<EditRecipientsGroupResponse?> EditRecipientsGroup(long id, string? title)
		=> await EditRecipientsGroup(new EditRecipientsGroupRequestContent
		{
			Id = id,
			Title = title,
		});

	public async Task<EditRecipientsGroupResponse?> EditRecipientsGroup(EditRecipientsGroupRequestContent? request)
	{
		request ??= new EditRecipientsGroupRequestContent();
		return await SendRequest<EditRecipientsGroupRequestContent, EditRecipientsGroupResponse>(HttpMethod.Patch, method: $"/email/lists/{request.Id}", request);
	}

	#endregion

	#region Remove

	public async Task<RemoveRecipientsGroupResponse?> RemoveRecipientsGroup(long id)
		=> await RemoveRecipientsGroup(new RemoveRecipientsGroupRequestContent
		{
			Id = id,
		});

	public async Task<RemoveRecipientsGroupResponse?> RemoveRecipientsGroup(RemoveRecipientsGroupRequestContent? request)
	{
		request ??= new RemoveRecipientsGroupRequestContent();
		return await SendRequest<RemoveRecipientsGroupRequestContent, RemoveRecipientsGroupResponse>(HttpMethod.Delete, method: $"/email/lists/{request.Id}", request);
	}

	#endregion
}
