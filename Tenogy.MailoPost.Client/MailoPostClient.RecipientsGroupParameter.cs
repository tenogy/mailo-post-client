using System.Net.Http;
using System.Threading.Tasks;
using MailoPost.Enums;
using MailoPost.Models.RequestContent;
using MailoPost.Models.Response;

namespace MailoPost
{
	public partial class MailoPostClient
	{
		#region Get

		public async Task<GetRecipientsGroupParametersResponse?> GetRecipientsGroupParameters(int groupId)
		{
			return await GetRecipientsGroupParameters(new GetRecipientsGroupParametersRequestContent
			{
				GroupId = groupId
			});
		}

		public async Task<GetRecipientsGroupParametersResponse?> GetRecipientsGroupParameters(GetRecipientsGroupParametersRequestContent? request)
		{
			request ??= new GetRecipientsGroupParametersRequestContent();
			return await SendRequest<GetRecipientsGroupParametersRequestContent, GetRecipientsGroupParametersResponse>(HttpMethod.Get, $"/email/lists/{request.GroupId}/parameters", request);
		}

		#endregion

		#region Create

		public async Task<CreateRecipientsGroupParameterResponse?> CreateRecipientsGroupParameter(int groupId, string? title, ParameterKindEnum? kind = null)
		{
			return await CreateRecipientsGroupParameter(new CreateRecipientsGroupParameterRequestContent
			{
				GroupId = groupId,
				Title = title,
				Kind = kind
			});
		}

		public async Task<CreateRecipientsGroupParameterResponse?> CreateRecipientsGroupParameter(CreateRecipientsGroupParameterRequestContent? request)
		{
			request ??= new CreateRecipientsGroupParameterRequestContent();
			return await SendRequest<CreateRecipientsGroupParameterRequestContent, CreateRecipientsGroupParameterResponse>(HttpMethod.Post, $"/email/lists/{request.GroupId}/parameters", request);
		}

		#endregion

		#region Edit

		public async Task<EditRecipientsGroupParameterResponse?> EditRecipientsGroupParameter(int groupId, int id, string? title, ParameterKindEnum? kind = null)
		{
			return await EditRecipientsGroupParameter(new EditRecipientsGroupParameterRequestContent
			{
				GroupId = groupId,
				Id = id,
				Title = title,
				Kind = kind
			});
		}

		public async Task<EditRecipientsGroupParameterResponse?> EditRecipientsGroupParameter(EditRecipientsGroupParameterRequestContent? request)
		{
			request ??= new EditRecipientsGroupParameterRequestContent();
			return await SendRequest<EditRecipientsGroupParameterRequestContent, EditRecipientsGroupParameterResponse>(HttpMethod.Patch, $"/email/lists/{request.GroupId}/parameters/{request.Id}", request);
		}

		#endregion

		#region Remove

		public async Task<BaseResponse?> RemoveRecipientsGroupParameter(int groupId, int id)
		{
			return await RemoveRecipientsGroupParameter(new RemoveRecipientsGroupParameterRequestContent
			{
				GroupId = groupId,
				Id = id
			});
		}

		public async Task<RemoveRecipientsGroupParameterResponse?> RemoveRecipientsGroupParameter(RemoveRecipientsGroupParameterRequestContent? request)
		{
			request ??= new RemoveRecipientsGroupParameterRequestContent();
			return await SendRequest<RemoveRecipientsGroupParameterResponse>(HttpMethod.Delete, $"/email/lists/{request.GroupId}/parameters/{request.Id}");
		}

		#endregion
	}
}
