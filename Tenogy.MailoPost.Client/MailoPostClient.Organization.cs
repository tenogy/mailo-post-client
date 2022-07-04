using System.Net.Http;
using System.Threading.Tasks;
using MailoPost.Models.RequestContent;
using MailoPost.Models.Response;

namespace MailoPost
{
	public partial class MailoPostClient
	{
		#region Get

		public async Task<GetOrganizationsResponse?> GetOrganizations(GetOrganizationsRequestContent? request = null)
		{
			request ??= new GetOrganizationsRequestContent();
			return await SendRequest<GetOrganizationsRequestContent, GetOrganizationsResponse>(HttpMethod.Get, "/email/organizations", request);
		}

		public async Task<GetOrganizationByIdResponse?> GetOrganizationById(int id)
		{
			return await SendRequest<GetOrganizationByIdResponse>(HttpMethod.Get, $"/email/organizations/{id}");
		}

		public async Task<GetCurrentOrganizationResponse?> GetCurrentOrganization()
		{
			return await SendRequest<GetCurrentOrganizationResponse>(HttpMethod.Get, $"/email/organizations/current");
		}

		#endregion

		#region Create

		public async Task<CreateOrganizationResponse?> CreateOrganization(CreateOrganizationRequestContent? request)
		{
			request ??= new CreateOrganizationRequestContent();
			return await SendRequest<CreateOrganizationRequestContent, CreateOrganizationResponse>(HttpMethod.Post, "/email/organizations", request);
		}

		#endregion

		#region Edit

		public async Task<EditOrganizationResponse?> EditOrganization(EditOrganizationRequestContent? request)
		{
			request ??= new EditOrganizationRequestContent();
			return await SendRequest<EditOrganizationRequestContent, EditOrganizationResponse>(HttpMethod.Patch, $"/email/organizations/{request.Id}", request);
		}

		public async Task<SetCurrentOrganizationResponse?> SetCurrentOrganization(int id)
		{
			return await SendRequest<SetCurrentOrganizationResponse>(HttpMethod.Patch, $"/email/organizations/{id}/current");
		}

		#endregion

		#region Remove

		public async Task<RemoveOrganizationResponse?> RemoveOrganization(int id)
		{
			return await RemoveOrganization(new RemoveOrganizationRequestContent
			{
				Id = id
			});
		}

		public async Task<RemoveOrganizationResponse?> RemoveOrganization(RemoveOrganizationRequestContent? request)
		{
			request ??= new RemoveOrganizationRequestContent();
			return await SendRequest<RemoveOrganizationResponse>(HttpMethod.Delete, $"/email/organizations/{request.Id}");
		}

		#endregion
	}
}
