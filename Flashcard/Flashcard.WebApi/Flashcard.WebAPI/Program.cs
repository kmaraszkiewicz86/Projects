// <copyright file="Program.cs" username="Krzysztof Maraszkiewicz">
//   Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using Flashcard.WebAPI.AppStart;
using Microsoft.AspNetCore.Hosting;

namespace Flashcard.WebAPI
{
	public class Program
	{
		/// <summary>
		///     Main method.
		/// </summary>
		/// <param name="args">The arguments.</param>
		public static void Main(string[] args)
		{
			NLogBuilderHelper.Initialize(() =>
				BuildWebHost(args).Run());
		}

		/// <summary>
		///     Builds the web host.
		/// </summary>
		/// <param name="args">The arguments.</param>
		/// <returns></returns>
		public static IWebHost BuildWebHost(string[] args)
		{
			return WebHostHelper.InitializeApplication(args);
		}
	}
}