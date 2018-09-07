using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Store.Data;

namespace Store
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var host = CreateWebHostBuilder(args).Build();


			RunSeeding(host);
			host.Run();
		}

		private static void RunSeeding(IWebHost host)
		{
			var scopeFactory = host.Services.GetService<IServiceScopeFactory>();
			using (var scope = scopeFactory.CreateScope())
			{
				var seeder = scope.ServiceProvider.GetService<StoreSeeder>();
				seeder.Seed();
			}
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.ConfigureAppConfiguration(SetupConfiguration)
				.UseStartup<Startup>();

		private static void SetupConfiguration(WebHostBuilderContext ctx, IConfigurationBuilder configBuilder)
		{
			configBuilder.Sources.Clear();
			configBuilder.AddJsonFile("config.json", false, true)
						 .AddEnvironmentVariables();
		}
	}
}
