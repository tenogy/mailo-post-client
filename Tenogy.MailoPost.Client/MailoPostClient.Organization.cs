using MailoPost.Models.RequestContent;
using MailoPost.Models.Response;

namespace MailoPost;

public partial class MailoPostClient
{
	#region Get

	public async Task<GetOrganizationsResponse?> GetOrganizations(GetOrganizationsRequestContent? request = null)
	{
		request ??= new GetOrganizationsRequestContent();
		return await SendRequest<GetOrganizationsRequestContent, GetOrganizationsResponse>(HttpMethod.Get, method: "/email/organizations", request);
	}

	public async Task<GetOrganizationByIdResponse?> GetOrganizationById(long id)
		=> await SendRequest<GetOrganizationByIdResponse>(HttpMethod.Get, method: $"/email/organizations/{id}");

	public async Task<GetCurrentOrganizationResponse?> GetCurrentOrganization()
		=> await SendRequest<GetCurrentOrganizationResponse>(HttpMethod.Get, method: "/email/organizations/current");

	#endregion

	#region Create

	public async Task<CreateOrganizationResponse?> CreateOrganization(CreateOrganizationRequestContent? request)
	{
		request ??= new CreateOrganizationRequestContent();
		return await SendRequest<CreateOrganizationRequestContent, CreateOrganizationResponse>(HttpMethod.Post, method: "/email/organizations", request);
	}

	#endregion

	#region Edit

	public async Task<EditOrganizationResponse?> EditOrganization(EditOrganizationRequestContent? request)
	{
		request ??= new EditOrganizationRequestContent();
		return await SendRequest<EditOrganizationRequestContent, EditOrganizationResponse>(HttpMethod.Patch, method: $"/email/organizations/{request.Id}", request);
	}

	public async Task<SetCurrentOrganizationResponse?> SetCurrentOrganization(long id)
		=> await SendRequest<SetCurrentOrganizationResponse>(HttpMethod.Patch, method: $"/email/organizations/{id}/current");

	#endregion

	#region Remove

	public async Task<RemoveOrganizationResponse?> RemoveOrganization(long id)
		=> await RemoveOrganization(new RemoveOrganizationRequestContent
		{
			Id = id,
		});

	public async Task<RemoveOrganizationResponse?> RemoveOrganization(RemoveOrganizationRequestContent? request)
	{
		request ??= new RemoveOrganizationRequestContent();
		return await SendRequest<RemoveOrganizationResponse>(HttpMethod.Delete, method: $"/email/organizations/{request.Id}");
	}

	#endregion
}
