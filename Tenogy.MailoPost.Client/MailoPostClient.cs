using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web;
using MailoPost.Helpers;
using MailoPost.Models.Request;
using MailoPost.Models.RequestContent;
using MailoPost.Models.Response;

namespace MailoPost
{
	public partial class MailoPostClient : IMailoPostClient
	{
		private const string ApiUrl = "https://api.mailopost.ru/v1";
		private readonly string _apiToken;

		public MailoPostClient(string apiToken)
		{
			_apiToken = apiToken;

			if (string.IsNullOrWhiteSpace(_apiToken))
				throw new ArgumentNullException(nameof(apiToken));
		}

		public async Task<TResponse?> SendRequest<TResponse>(HttpMethod httpMethod, string method) where TResponse : IBaseResponse
		{
			return await SendRequest<IBaseContent, TResponse>(new BaseRequest(httpMethod, method));
		}

		public async Task<TResponse?> SendRequest<TContent, TResponse>(HttpMethod httpMethod, string method, TContent content) where TContent : IBaseContent where TResponse : IBaseResponse
		{
			return await SendRequest<TContent, TResponse>(new BaseRequest(httpMethod, method, content));
		}

		public async Task<TResponse?> SendRequest<TResponse>(IBaseRequest request) where TResponse : IBaseResponse
		{
			return await SendRequest<IBaseContent, TResponse>(request);
		}

		public async Task<TResponse?> SendRequest<TContent, TResponse>(IBaseRequest request) where TContent : IBaseContent where TResponse : IBaseResponse
		{
			try
			{
				using (var httpClient = new HttpClient())
				using (var response = await httpClient.SendAsync(GetHttpRequestMessage<TContent>(request)))
				{
					var responseString = await response.Content.ReadAsStringAsync();
					return JsonSerializer.Deserialize<TResponse>(responseString, GetJsonSerializerOptions()) ?? default!;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("MailoPost request exception: {0}", ex.StackTrace);
				return default;
			}
		}

		private HttpRequestMessage GetHttpRequestMessage<TContent>(IBaseRequest request) where TContent : IBaseContent
		{
			string url = ApiUrl + request.Method;
			string json = request.Content == null ? "{}" : JsonSerializer.Serialize((TContent)request.Content, GetJsonSerializerOptions());
			HttpContent? httpContent;

			if (request.HttpMethod == HttpMethod.Get)
			{
				Dictionary<string, object> jsonObject = JsonSerializer.Deserialize<Dictionary<string, object>>(json) ?? new Dictionary<string, object>();
				url += "?" + string.Join("&", jsonObject.Select(x => x.Key + "=" + HttpUtility.UrlEncode(x.Value.ToString())));
				httpContent = new StringContent("{}", Encoding.UTF8, "application/json");
			}
			else
			{
				httpContent = new StringContent(json, Encoding.UTF8, "application/json");
			}

			return new HttpRequestMessage
			{
				RequestUri = new Uri(url),
				Method = request.HttpMethod,
				Headers = { Authorization = new AuthenticationHeaderValue("Bearer", _apiToken) },
				Content = httpContent,
			};
		}

		private static JsonSerializerOptions GetJsonSerializerOptions()
		{
			var options = new JsonSerializerOptions();

			foreach (var converter in JsonStringEnumConverterExtension.GetJsonEnumConverters())
				options.Converters.Add(converter);

			return options;
		}
	}
}
