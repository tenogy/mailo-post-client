using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Web;
using MailoPost.Converters;
using MailoPost.Models.Request;
using MailoPost.Models.RequestContent;
using MailoPost.Models.Response;

namespace MailoPost;

public sealed partial class MailoPostClient : IMailoPostClient
{
	private readonly string _apiUrl = "https://api.mailopost.ru/v1";
	private readonly string _apiToken;

	private readonly HttpClient _httpClient;
	private readonly JsonSerializerOptions _defaultJsonSerializerOptions;

	public MailoPostClient(string apiToken)
	{
		_apiToken = apiToken;

		if (string.IsNullOrWhiteSpace(_apiToken))
			throw new ArgumentNullException(nameof(apiToken));

		_httpClient = LocalCreateHttpClient();
		_defaultJsonSerializerOptions = LocalCreateJsonSerializerOptions();

		return;

		HttpClient LocalCreateHttpClient()
		{
			return new HttpClient
			{
				Timeout = Timeout.InfiniteTimeSpan,
			};
		}

		JsonSerializerOptions LocalCreateJsonSerializerOptions()
		{
			var options = new JsonSerializerOptions();

			options.Converters.Add(new MessageStatusEnumConverter());
			options.Converters.Add(new ParameterKindEnumConverter());
			options.Converters.Add(new RecipientStatusEnumConverter());

			return options;
		}
	}

	private async Task<TResponse?> SendRequest<TResponse>(HttpMethod httpMethod, string method) where TResponse : IBaseResponse
		=> await SendRequest<IBaseContent, TResponse>(new DefaultRequest(httpMethod, method));

	private async Task<TResponse?> SendRequest<TContent, TResponse>(HttpMethod httpMethod, string method, TContent content) where TContent : IBaseContent where TResponse : IBaseResponse
		=> await SendRequest<TContent, TResponse>(new DefaultRequest(httpMethod, method, content));

	private async Task<TResponse?> SendRequest<TResponse>(IBaseRequest request) where TResponse : IBaseResponse
		=> await SendRequest<IBaseContent, TResponse>(request);

	public async Task<TResponse?> SendRequest<TContent, TResponse>(IBaseRequest request) where TContent : IBaseContent where TResponse : IBaseResponse
	{
		try
		{
			using var response = await _httpClient.SendAsync(GetHttpRequestMessage<TContent>(request));
			var responseString = await response.Content.ReadAsStringAsync();
			return JsonSerializer.Deserialize<TResponse>(responseString, _defaultJsonSerializerOptions) ?? default!;
		}
		catch (Exception ex)
		{
			Console.WriteLine("MailoPost request exception: {0}", ex.StackTrace);
			return default;
		}
	}

	private HttpRequestMessage GetHttpRequestMessage<TContent>(IBaseRequest request) where TContent : IBaseContent
	{
		var json = request.Content == null ? "{}" : JsonSerializer.Serialize((TContent)request.Content, _defaultJsonSerializerOptions);

		if (request.HttpMethod == HttpMethod.Get)
		{
			var jsonObject = JsonSerializer.Deserialize<Dictionary<string, object>>(json) ?? new Dictionary<string, object>();
			var url = _apiUrl + request.Method + "?" + string.Join("&", jsonObject.Select(x => x.Key + "=" + HttpUtility.UrlEncode(x.Value.ToString())));
			var httpContent = new StringContent("{}", Encoding.UTF8, "application/json");

			return new HttpRequestMessage(request.HttpMethod, url)
			{
				Headers = { Authorization = new AuthenticationHeaderValue("Bearer", _apiToken) },
				Content = httpContent,
			};
		}
		else
		{
			var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

			return new HttpRequestMessage(request.HttpMethod, requestUri: _apiUrl + request.Method)
			{
				Headers = { Authorization = new AuthenticationHeaderValue("Bearer", _apiToken) },
				Content = httpContent,
			};
		}
	}

	public void Dispose()
		=> _httpClient.Dispose();
}
