using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace D365_AzureAD_ODataQuery
{
	public class OAuth2IoAuth2TokenProvider : IOAuth2TokenProvider<OAuth2Token>
	{
		private readonly ILogger<OAuth2IoAuth2TokenProvider> _logger;
		private readonly IHttpClientFactory _clientFactory;
		private readonly IDistributedCache _cache;

		private readonly string _applicationId;
		private readonly string _applicationSecret;
		private readonly string _scope;
		private readonly string _tokenUrl;
		private readonly string _cacheKey = "Token_" + Guid.NewGuid().ToString("N");

		public OAuth2IoAuth2TokenProvider(
			ILogger<OAuth2IoAuth2TokenProvider> logger,
			IConfiguration config,
			IHttpClientFactory clientFactory,
			IDistributedCache cache)
		{
			_logger = logger;
			_clientFactory = clientFactory;
			_cache = cache;

			_applicationId = config["ApplicationId"];
			_applicationSecret = config["ApplicationSecret"];

			string azureTenantId = config["AzureTenantId"];
			_tokenUrl = $"https://login.microsoftonline.com/{azureTenantId}/oauth2/v2.0/token";

			string crmUrl = config["CrmUrl"];
			string scope = config["Scope"];
			_scope = $"https://{crmUrl}/{scope}";
		}

		public async Task<OAuth2Token> GetToken(CancellationToken cancellationToken)
		{
			// return the cached token if it exists
			byte[] cachedTokenBytes = await _cache.GetAsync(_cacheKey, cancellationToken);
			if (cachedTokenBytes != null)
			{
				string cachedTokenJson = Encoding.UTF8.GetString(cachedTokenBytes);
				var cachedToken = JsonConvert.DeserializeObject<OAuth2Token>(cachedTokenJson);
				_logger.LogDebug("CACHE HIT: Returning Cached token!");
				return cachedToken;
			}

			// Fetch a fresh token
			using HttpClient client = _clientFactory.CreateClient();

			byte[] authHeaderBytes = Encoding.UTF8.GetBytes($"{_applicationId}:{_applicationSecret}");
			string encodedAuthHeader = Convert.ToBase64String(authHeaderBytes);
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", encodedAuthHeader);
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

			var content = new FormUrlEncodedContent(new[]
			{
				new KeyValuePair<string, string>("grant_type", "client_credentials"),
				new KeyValuePair<string, string>("scope", _scope)
			});

			HttpResponseMessage resp = await client.PostAsync(new Uri(_tokenUrl), content, cancellationToken);

			byte[] tokenBytes = await resp.Content.ReadAsByteArrayAsync();
			string respContent = await resp.Content.ReadAsStringAsync();
			var token = JsonConvert.DeserializeObject<OAuth2Token>(respContent);

			_logger.LogDebug("CACHE MISS: Adding token to Cache!");

			// Cache the new token and expire it after the specified timespan
			await _cache.SetAsync(_cacheKey, tokenBytes, new DistributedCacheEntryOptions()
			{
				AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(token.ExpiresIn)
			}, cancellationToken);

			return token;
		}
	}
}