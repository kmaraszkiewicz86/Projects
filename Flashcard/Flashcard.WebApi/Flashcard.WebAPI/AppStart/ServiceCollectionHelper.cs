// <copyright file="ServiceCollectionHelper.cs" username="Krzysztof Maraszkiewicz">
//   Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DataModel.Models.Config;
using DataModel.Models.DbModels;
using Implementations.Account;
using Implementations.Authorization;
using Implementations.CategoryMgt;
using Implementations.Email;
using Implementations.ExamTestMgt;
using Implementations.Models;
using Implementations.Role;
using Implementations.WordMgt;
using Interfaces.Account;
using Interfaces.Authorization;
using Interfaces.CategoryMgt;
using Interfaces.Email;
using Interfaces.ExamTestMgt;
using Interfaces.Models;
using Interfaces.Role;
using Interfaces.WordMgt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Flashcard.WebAPI.AppStart
{
	/// <summary>
	///     Service collection helper
	/// </summary>
	public static class ServiceCollectionHelper
	{
		/// <summary>
		///     Adds the scoped collection.
		/// </summary>
		/// <param name="services">The services.</param>
		/// <returns>
		///     <see cref="IServiceCollection" />
		/// </returns>
		public static IServiceCollection AddScopedCollection(this IServiceCollection services)
		{
			services.AddScoped<ITokenService, TokenService>();
			services.AddScoped<IFlashcardDbContext, FlashcardDbContext>();
			services.AddScoped<ICategoryService, CategoryService>();
			services.AddScoped<IRoleService, RoleService>();
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IEmailService, EmailService>();
			services.AddScoped<ISendGridClientWrapper, SendGridClientWrapper>();
			services.AddScoped<IWordService, WordService>();
			services.AddScoped<IExamTestService, ExamTestService>();

            return services;
		}

		/// <summary>
		///     Adds the configurations.
		/// </summary>
		/// <param name="services">The services.</param>
		/// <param name="configuration">The configuration.</param>
		/// <returns>
		///     <see cref="IServiceCollection" />
		/// </returns>
		public static IServiceCollection AddConfigurations(this IServiceCollection services,
			IConfiguration configuration)
		{
			services.Configure<AppSettingsModel>(configuration);
			services.Configure<EmailSettingsModel>(configuration.GetSection("Email"));
			services.Configure<SettingsModel>(configuration.GetSection("Settings"));


			return services;
		}

		/// <summary>
		///     Adds the identity.
		/// </summary>
		/// <param name="services">The services.</param>
		/// <returns>
		///     <see cref="IServiceCollection" />
		/// </returns>
		public static IServiceCollection AddIdentity(this IServiceCollection services)
		{
			services.AddIdentity<User, IdentityRole>(options =>
				{
					options.User.RequireUniqueEmail = true;
					options.Password.RequiredLength = 3;
					options.Password.RequireNonAlphanumeric = false;
					options.Password.RequireLowercase = false;
					options.Password.RequireUppercase = false;
					options.Password.RequireDigit = false;
				})
				.AddEntityFrameworkStores<FlashcardDbContext>()
				.AddDefaultTokenProviders();

			return services;
		}

		/// <summary>
		///     Adds the JWT authentication.
		/// </summary>
		/// <param name="services">The services.</param>
		/// <param name="configuration">The configuration.</param>
		/// <returns>
		///     <see cref="IServiceCollection" />
		/// </returns>
		public static IServiceCollection AddJwtAuthentication(this IServiceCollection services,
			IConfiguration configuration)
		{
			JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); // => remove default claims
			services
				.AddAuthentication(options =>
				{
					options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
					options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
					options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				})
				.AddJwtBearer(cfg =>
				{
					cfg.RequireHttpsMetadata = false;
					cfg.SaveToken = true;
					cfg.TokenValidationParameters = new TokenValidationParameters
					{
						ValidIssuer = configuration["Jwt:Issuer"],
						ValidAudience = configuration["Jwt:Issuer"],
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
						ClockSkew = TimeSpan.Zero // remove delay of token when expire
					};
				});

			return services;
		}

		/// <summary>
		///     Adds the database context.
		/// </summary>
		/// <param name="services">The services.</param>
		/// <param name="configuration">The configuration.</param>
		/// <returns>
		///     <see cref="IServiceCollection" />
		/// </returns>
		public static IServiceCollection AddDbContext(this IServiceCollection services,
			IConfiguration configuration)
		{
			services.AddDbContext<FlashcardDbContext>(options =>
				options.UseSqlServer(
					configuration["Flashcard:ConnectionStrings:Default"],
					b => b.MigrationsAssembly("Flashcard.WebAPI")));

			return services;
		}

		/// <summary>
		///     Adds the authorization options.
		/// </summary>
		/// <param name="services">The services.</param>
		/// <returns>
		///     <see cref="IServiceCollection" />
		/// </returns>
		public static IServiceCollection AddAuthorizationOptions(this IServiceCollection services)
		{
			services.AddAuthorization(options =>
			{
				options.AddPolicy("Admin", policy =>
					policy.RequireClaim(ClaimTypes.Role, "admin"));

				options.AddPolicy("User", policy =>
					policy.RequireClaim(ClaimTypes.Role, "admin", "user"));
			});

			return services;
		}

		public static void AddLocalizationItems(this IServiceCollection services)
		{
			services.AddLocalization(opts => opts.ResourcesPath = "Resources");

			services.Configure<RequestLocalizationOptions>(
				opts =>
				{
					var supportedCultures = new List<CultureInfo>
					{
						new CultureInfo("en-GB"),
						new CultureInfo("en-US"),
						new CultureInfo("en")
					};

					opts.DefaultRequestCulture = new RequestCulture("en");
					// Formatting numbers, dates, etc.
					opts.SupportedCultures = supportedCultures;
					// UI strings that we have localized.
					opts.SupportedUICultures = supportedCultures;
				});
		}

		/// <summary>
		/// Setups the cors.
		/// </summary>
		/// <param name="services">The services.</param>
		public static void SetupCors(this IServiceCollection services)
		{
			// ********************
			// Setup CORS
			// ********************
			var corsBuilder = new CorsPolicyBuilder();
			corsBuilder.AllowAnyHeader();
			corsBuilder.AllowAnyMethod();
			corsBuilder.AllowAnyOrigin(); // For anyone access.
			//corsBuilder.WithOrigins("http://localhost:56573"); // for a specific url. Don't add a forward slash on the end!
			corsBuilder.AllowCredentials();

			services.AddCors(options =>
			{
				options.AddPolicy("SiteCorsPolicy", corsBuilder.Build());
			});
		}
	}
}