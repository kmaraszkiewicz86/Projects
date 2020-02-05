// <copyright file="HostingEnvironmentHelper.cs" username="Krzysztof Maraszkiewicz">
//   Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Flashcard.WebAPI.AppStart
{
	/// <summary>
	///     Hosting environment helper
	/// </summary>
	public static class HostingEnvironmentHelper
	{
		/// <summary>
		///     Builds the configuration.
		/// </summary>
		/// <param name="env">The env.</param>
		/// <param name="appSettingFileName">Name of the application setting file.</param>
		/// <returns></returns>
		public static IConfiguration BuildConfiguration(this IHostingEnvironment env, string appSettingFileName)
		{
			return new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile(appSettingFileName)
				.Build();
		}
	}
}