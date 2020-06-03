using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace D365_AzureAD_ODataQuery
{
	internal class Program
	{
		public static async Task<int> Main(string[] args)
		{
			var services = new ServiceCollection();
			ConfigureServices(services, args);

			try
			{
				await using ServiceProvider sp = services.BuildServiceProvider();
				var app = sp.GetService<Application>();
				return await app.Run(args) ? 0 : 1;
			}
			catch (Exception e)
			{
				Console.WriteLine("ERROR: " + e);
			}

			return -1;
		}

		private static void ConfigureServices(IServiceCollection services, string[] args)
		{
			IConfigurationRoot config = AddConfiguration(services, args);
			ConfigureLogging(services, config);
			services.AddSingleton<Application>();

			// Add other services
			services.AddHttpClient();
			services.AddDistributedMemoryCache();

			services.AddSingleton<IOAuth2TokenProvider<OAuth2Token>, OAuth2TokenProvider>();
		}

		private static void ConfigureLogging(IServiceCollection services, IConfigurationRoot config)
		{
			services.AddLogging(c => c.AddSerilog());
			ConfigureSerilog(config);
		}

		private static void ConfigureSerilog(IConfiguration config)
		{
			Log.Logger = new LoggerConfiguration()
				.MinimumLevel.Debug()
				.ReadFrom.Configuration(config)
				.CreateLogger();

			Log.Logger.Information("Application starting...");
		}

		private static IConfigurationRoot AddConfiguration(IServiceCollection services, string[] args)
		{
			IConfigurationBuilder configBuilder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile(path: "appsettings.json", optional: false, reloadOnChange: true)
				.AddJsonFile(path: "appsettings.local.json", optional: true, reloadOnChange: true);

			configBuilder
				.AddEnvironmentVariables()
				.AddCommandLine(args);

			IConfigurationRoot config = configBuilder.Build();
			services.AddSingleton<IConfiguration>(config);
			return config;
		}
	}
}
