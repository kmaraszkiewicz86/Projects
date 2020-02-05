// <copyright file="MvcBuilderHelper.cs" username="Krzysztof Maraszkiewicz">
//    Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Flashcard.WebAPI.AppStart
{
	/// <summary>
	/// <see cref="IMvcBuilder"/> extension class.
	/// </summary>
	public static class MvcBuilderHelper
	{
		/// <summary>
		/// Setups the json options.
		/// </summary>
		/// <param name="mvcBuilder">The MVC builder.</param>
		public static void SetupJsonOptions(this IMvcBuilder mvcBuilder)
		{
			mvcBuilder.AddJsonOptions(options =>
			{
				options.SerializerSettings.Converters.Add(new StringEnumConverter());
				options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
			});
		}
	}
}