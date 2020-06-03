using Newtonsoft.Json;

namespace D365_AzureAD_ODataQuery
{
	public class OAuth2Token
	{
		[JsonProperty("token_type")]
		public string TokenType { get; set; }

		[JsonProperty("expires_in")]
		public long ExpiresIn { get; set; }

		[JsonProperty("ext_expires_in")]
		public long ExtExpiresIn { get; set; }

		[JsonProperty("access_token")]
		public string AccessToken { get; set; }
	}
}