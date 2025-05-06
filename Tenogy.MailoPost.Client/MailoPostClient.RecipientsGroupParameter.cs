using MailoPost.Enums;
using MailoPost.Models.RequestContent;
using MailoPost.Models.Response;

namespace MailoPost;

public partial class MailoPostClient
{
	#region Get

	public async Task<GetRecipientsGroupParametersResponse?> GetRecipientsGroupParameters(long groupId)
		=> await GetRecipientsGroupParameters(new GetRecipientsGroupParametersRequestContent
		{
			GroupId = groupId,
		});

	public async Task<GetRecipientsGroupParametersResponse?> GetRecipientsGroupParameters(GetRecipientsGroupParametersRequestContent? request)
	{
		request ??= new GetRecipientsGroupParametersRequestContent();
		return await SendRequest<GetRecipientsGroupParametersRequestContent, GetRecipientsGroupParametersResponse>(HttpMethod.Get, method: $"/email/lists/{request.GroupId}/parameters", request);
	}

	#endregion

	#region Create

	public async Task<CreateRecipientsGroupParameterResponse?> CreateRecipientsGroupParameter(long groupId, string? title, ParameterKindEnum? kind = null)
		=> await CreateRecipientsGroupParameter(new CreateRecipientsGroupParameterRequestContent
		{
			GroupId = groupId,
			Title = title,
			Kind = kind,
		});

	public async Task<CreateRecipientsGroupParameterResponse?> CreateRecipientsGroupParameter(CreateRecipientsGroupParameterRequestContent? request)
	{
		request ??= new CreateRecipientsGroupParameterRequestContent();
		return await SendRequest<CreateRecipientsGroupParameterRequestContent, CreateRecipientsGroupParameterResponse>(HttpMethod.Post, method: $"/email/lists/{request.GroupId}/parameters", request);
	}

	#endregion

	#region Edit

	public async Task<EditRecipientsGroupParameterResponse?> EditRecipientsGroupParameter(long groupId, long id, string? title, ParameterKindEnum? kind = null)
		=> await EditRecipientsGroupParameter(new EditRecipientsGroupParameterRequestContent
		{
			GroupId = groupId,
			Id = id,
			Title = title,
			Kind = kind,
		});

	public async Task<EditRecipientsGroupParameterResponse?> EditRecipientsGroupParameter(EditRecipientsGroupParameterRequestContent? request)
	{
		request ??= new EditRecipientsGroupParameterRequestContent();
		return await SendRequest<EditRecipientsGroupParameterRequestContent, EditRecipientsGroupParameterResponse>(HttpMethod.Patch, method: $"/email/lists/{request.GroupId}/parameters/{request.Id}", request);
	}

	#endregion

	#region Remove

	public async Task<BaseResponse?> RemoveRecipientsGroupParameter(long groupId, long id)
		=> await RemoveRecipientsGroupParameter(new RemoveRecipientsGroupParameterRequestContent
		{
			GroupId = groupId,
			Id = id,
		});

	public async Task<RemoveRecipientsGroupParameterResponse?> RemoveRecipientsGroupParameter(RemoveRecipientsGroupParameterRequestContent? request)
	{
		request ??= new RemoveRecipientsGroupParameterRequestContent();
		return await SendRequest<RemoveRecipientsGroupParameterResponse>(HttpMethod.Delete, method: $"/email/lists/{request.GroupId}/parameters/{request.Id}");
	}

	#endregion
}
