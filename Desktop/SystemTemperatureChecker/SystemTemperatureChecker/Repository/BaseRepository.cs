// <copyright file="BaseRepository.cs" username="Krzysztof Maraszkiewicz">
//   Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System;
using SystemTemperatureChecker.Database;

namespace SystemTemperatureChecker.Repository
{
	/// <summary>
	/// Base database repository.
	/// </summary>
	public abstract class BaseRepository
	{
		/// <summary>
		/// Called when <paramref name="onAction"/> call to database.
		/// </summary>
		/// <param name="onAction">The on action.</param>
		public void OnConnection(Action<SystemTemperatureCheckerDbContext> onAction)
		{
			using (var client = new SystemTemperatureCheckerDbContext())
			{
				using (var transaction = client.Database.BeginTransaction())
				{
					try
					{
						onAction(client);
						transaction.Commit();
					}
					catch (Exception)
					{
						transaction.Rollback();
					}
				}
			}
		}

		/// <summary>
		/// Called when Called when <paramref name="onAction"/> call to database.
		/// </summary>
		/// <typeparam name="TReturnType">The type of the eturn type.</typeparam>
		/// <param name="onAction">The on action.</param>
		/// <returns></returns>
		public TReturnType OnConnection<TReturnType>(Func<SystemTemperatureCheckerDbContext, TReturnType> onAction)
		{
			TReturnType retunType = default(TReturnType);

			OnConnection(client => { retunType = onAction(client); });

			return retunType;
		}
	}
}