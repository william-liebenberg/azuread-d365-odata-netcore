using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace D365_AzureAD_ODataQuery
{
	public class Application
	{
		private readonly ILogger<Application> _logger;
		private readonly IConfiguration _config;
		private readonly IOAuth2TokenProvider<OAuth2Token> _tokenProvider;
		private readonly IHttpClientFactory _httpClientFactory;

		public Application(ILogger<Application> logger, IConfiguration config, IOAuth2TokenProvider<OAuth2Token> tokenProvider, IHttpClientFactory httpClientFactory)
		{
			_logger = logger;
			_config = config;
			_tokenProvider = tokenProvider;
			_httpClientFactory = httpClientFactory;
		}

		/// <summary>
		/// Makes a HTTP call to the OAuth2 endpoint for getting the OAuth2 token that can be used for further HTTP communication with Dynamics 365.
		/// </summary>
		public async Task<bool> Run(string[] args)
		{
			CancellationToken cancellationToken = CancellationToken.None;

			// get the auth token
			OAuth2Token token = await _tokenProvider.GetToken(cancellationToken);

			// set up our http client
			using HttpClient client = _httpClientFactory.CreateClient();
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token.TokenType, token.AccessToken);
			
			// formulate the odata query uri
			var crmBaseUrl = new Uri("https://" + _config["CrmUrl"], UriKind.Absolute);
			var apiUrl = new Uri(crmBaseUrl, "api/data/v9.1/");
			Uri odataQueryUri = new Uri(apiUrl, "systemusers").AttachParameters(new NameValueCollection
			{
				{"$filter", "contains(firstname,%27william%27)%20and%20contains(lastname,%27liebenberg%27)"}
			});

			// get the odata response
			HttpResponseMessage odataResponse = await client.GetAsync(odataQueryUri, cancellationToken);
			string odataJson = await odataResponse.Content.ReadAsStringAsync();

			// deserialize the odata json
			var systemUsers = JsonConvert.DeserializeObject<SystemUsers>(odataJson);
			SystemUser william = systemUsers.Users.First();
			_logger.LogInformation("Twitter Username: {twitterUsername}", william.SswTwitterusername);

			return await Task.FromResult(true);
		}
	}
}