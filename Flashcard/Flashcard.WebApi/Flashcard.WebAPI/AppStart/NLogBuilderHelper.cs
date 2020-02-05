// <copyright file="NLogBuilderHelper.cs" username="Krzysztof Maraszkiewicz">
//   Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System;
using NLog;
using NLog.Web;

namespace Flashcard.WebAPI.AppStart
{
	/// <summary>
	///     NLogBuilder helper class.
	/// </summary>
	public static class NLogBuilderHelper
	{
		/// <summary>
		///     Initializes NLogBuilder.
		/// </summary>
		/// <param name="action">The action.</param>
		public static void Initialize(Action action)
		{
			var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
			try
			{
				logger.Debug("init main");
				action();
			}
			catch (Exception ex)
			{
				//NLog: catch setup errors
				logger.Error(ex, "Stopped program because of exception");
				throw;
			}
			finally
			{
				// Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
				LogManager.Shutdown();
			}
		}
	}
}