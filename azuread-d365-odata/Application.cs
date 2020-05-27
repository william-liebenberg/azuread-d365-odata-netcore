using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace D365_AzureAD_ODataQuery
{
	public class Application
	{
		private readonly ILogger<Application> _logger;

		private readonly string _azureTenantId;
		private readonly string _applicationId;
		private readonly string _applicationSecret;
		private readonly string _scope;
		private readonly string _tokenUrl;

		public Application(ILogger<Application> logger, IConfiguration config)
		{
			_logger = logger;

			_applicationId = config["ApplicationId"];
			_applicationSecret = config["ApplicationSecret"];

			_azureTenantId = config["AzureTenantId"];
			_tokenUrl = $"https://login.microsoftonline.com/{_azureTenantId}/oauth2/v2.0/token";
			
			string crmUrl = config["CrmUrl"];
			string scope = config["Scope"];
			_scope = $"https://{crmUrl}/{scope}";
		}

		public async Task<bool> Run(string[] args)
		{
			_logger.LogInformation("Hello world!");
			_logger.LogInformation("ApplicationId: " + _applicationId);
			_logger.LogInformation("TokenUrl: " + _tokenUrl);
			_logger.LogInformation("Scope: " + _scope);
			return await Task.FromResult(true);
		}
	}
}