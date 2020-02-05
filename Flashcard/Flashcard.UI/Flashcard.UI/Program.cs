// <copyright file="Program.cs" username="Krzysztof Maraszkiewicz">
//    Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Flashcard.UI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateWebHostBuilder(args).Build().Run();
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args)
		{
			return WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>();
		}
	}
}