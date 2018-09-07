using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.Data;
using Store.Data.Entities;

namespace Store
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.Configure<CookiePolicyOptions>(options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});
			services.AddIdentity<StoreUser, IdentityRole>(cfg =>
			{
				cfg.User.RequireUniqueEmail = true;
			}	
			).AddEntityFrameworkStores<StoreContext>();

			services.AddTransient<StoreSeeder>();
			services.AddScoped<IStoreRepository, StoreRepository>();
			services.AddDbContext<StoreContext>(cfg =>
			{
				cfg.UseSqlServer(Configuration.GetConnectionString("StoreConnectionString"));
				});
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				app.UseHsts();
			}
			app.UseAuthentication();
			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseNodeModules(env);
			app.UseCookiePolicy();
			app.UseMvc(routes =>
			{

				routes.MapRoute(
					"default",
					"{controller}/{action}/{id?}",
					new { controller = "app", Action = "Index" }
					);
			});
		}
	}
}
