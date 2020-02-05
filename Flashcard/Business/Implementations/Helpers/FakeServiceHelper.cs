// <copyright file="FakeServiceHelper.cs" username="Krzysztof Maraszkiewicz">
//    Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System;
using System.Threading.Tasks;

namespace Implementations.Helpers
{
	/// <summary>
	///     Fake service injector helper class
	/// </summary>
	public static class FakeServiceHelper
	{
		/// <summary>
		/// Should use fake service asynchronous.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <param name="fakeService">if set to <c>true</c> [fake service].</param>
		/// <param name="action">The action.</param>
		/// <param name="defaultValueAction">The default value action.</param>
		/// <returns>Value of <see cref="Task{TModel}" /></returns>
		public static async Task<TModel> ShouldUseFakeServiceAsync<TModel>(this bool fakeService, Func<Task<TModel>> action,
			Func<Task<TModel>> defaultValueAction)
			where TModel : class
		{
			if (!fakeService) return await action();

			return await defaultValueAction();
		}

		/// <summary>
		/// Should use fake service.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <param name="fakeService">if set to <c>true</c> [fake service].</param>
		/// <param name="action">The action.</param>
		/// <param name="defaultValueAction">The default value action.</param>
		/// <returns>Value of <typeparamref name="TModel"/></returns>
		public static TModel ShouldUseFakeService<TModel>(this bool fakeService, Func<TModel> action,
			Func<TModel> defaultValueAction)
			where TModel : class
		{
			if (!fakeService) return action();

			return defaultValueAction();
		}
	}
}