// <copyright file="WebHostHelper.cs" username="Krzysztof Maraszkiewicz">
//   Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace Flashcard.WebAPI.AppStart
{
	public class WebHostHelper
	{
		/// <summary>
		///     Initializes the application.
		/// </summary>
		/// <param name="args">The arguments.</param>
		/// <returns></returns>
		public static IWebHost InitializeApplication(string[] args)
		{
			return WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>()
				.ConfigureLogging(logging =>
				{
					logging.ClearProviders();
					logging.SetMinimumLevel(LogLevel.Trace);
					logging.AddNLog();
				})
				.Build();
		}
	}
}