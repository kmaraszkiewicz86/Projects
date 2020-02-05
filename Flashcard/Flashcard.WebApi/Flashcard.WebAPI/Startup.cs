// <copyright file="Startup.cs" username="Krzysztof Maraszkiewicz">
//   Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using Flashcard.WebAPI.AppStart;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Flashcard.WebAPI
{
	/// <summary>
	///     Startup class.
	/// </summary>
	public class Startup
	{
		/// <summary>
		///     The configuration
		/// </summary>
		private readonly IConfiguration _configuration;

		/// <summary>
		///     Initializes a new instance of the <see cref="Startup" /> class.
		/// </summary>
		/// <param name="env">The env.</param>
		public Startup(IHostingEnvironment env)
		{
			_configuration = env.BuildConfiguration("appsettings.json");
		}

		/// <summary>
		///     Configures the services.
		/// </summary>
		/// <param name="services">The services.</param>
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext(_configuration);
			services.AddScopedCollection();
			services.AddConfigurations(_configuration);
			services.AddIdentity();
			services.AddJwtAuthentication(_configuration);
			services.AddAuthorizationOptions();
			services.AddLocalizationItems();
			services.SetupCors();
			
			services.AddMvc().SetupJsonOptions();
		}

		/// <summary>
		///     Configures the specified application.
		/// </summary>
		/// <param name="app">The application.</param>
		/// <param name="env">The env.</param>
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseStatusCodePages();
				app.UseDeveloperExceptionPage();
			}
            else
            {
                app.UseStatusCodePages();
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("SiteCorsPolicy");

			app.UseStaticFiles();
			app.UseAuthentication();
			app.UseMvc();
		}
	}
}