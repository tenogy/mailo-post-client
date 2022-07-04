using System.Net.Http;
using System.Threading.Tasks;
using MailoPost.Models.RequestContent;
using MailoPost.Models.Response;

namespace MailoPost
{
	public partial class MailoPostClient
	{
		#region Get

		public async Task<GetRecipientsGroupsResponse?> GetRecipientsGroups(GetRecipientsGroupsRequestContent? request = null)
		{
			return await SendRequest<GetRecipientsGroupsRequestContent, GetRecipientsGroupsResponse>(HttpMethod.Get, "/email/lists", request ?? new GetRecipientsGroupsRequestContent());
		}

		public async Task<GetRecipientsGroupByIdResponse?> GetRecipientsGroupsById(int id)
		{
			return await SendRequest<GetRecipientsGroupByIdResponse>(HttpMethod.Get, $"/email/lists/{id}");
		}

		#endregion

		#region Create

		public async Task<CreateRecipientsGroupResponse?> CreateRecipientsGroup(string? title)
		{
			return await CreateRecipientsGroup(new CreateRecipientsGroupRequestContent
			{
				Title = title
			});
		}

		public async Task<CreateRecipientsGroupResponse?> CreateRecipientsGroup(CreateRecipientsGroupRequestContent? request)
		{
			return await SendRequest<CreateRecipientsGroupRequestContent, CreateRecipientsGroupResponse>(HttpMethod.Post, "/email/lists", request ?? new CreateRecipientsGroupRequestContent());
		}

		#endregion

		#region Edit

		public async Task<EditRecipientsGroupResponse?> EditRecipientsGroup(int id, string? title)
		{
			return await EditRecipientsGroup(new EditRecipientsGroupRequestContent
			{
				Id = id,
				Title = title
			});
		}

		public async Task<EditRecipientsGroupResponse?> EditRecipientsGroup(EditRecipientsGroupRequestContent? request)
		{
			request ??= new EditRecipientsGroupRequestContent();
			return await SendRequest<EditRecipientsGroupRequestContent, EditRecipientsGroupResponse>(HttpMethod.Patch, $"/email/lists/{request.Id}", request);
		}

		#endregion


		#region Remove

		public async Task<RemoveRecipientsGroupResponse?> RemoveRecipientsGroup(int id)
		{
			return await RemoveRecipientsGroup(new RemoveRecipientsGroupRequestContent
			{
				Id = id
			});
		}

		public async Task<RemoveRecipientsGroupResponse?> RemoveRecipientsGroup(RemoveRecipientsGroupRequestContent? request)
		{
			request ??= new RemoveRecipientsGroupRequestContent();
			return await SendRequest<RemoveRecipientsGroupRequestContent, RemoveRecipientsGroupResponse>(HttpMethod.Delete, $"/email/lists/{request.Id}", request);
		}

		#endregion
	}
}
