// <copyright file="DatabaseFacadeMock.cs" username="Krzysztof Maraszkiewicz">
//    Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace ImplementationsUnitTest.Helpers
{
	/// <summary>
	/// DatabaseFacade mock class.
	/// </summary>
	/// <seealso cref="DatabaseFacade" />
	public class DatabaseFacadeMock : DatabaseFacade
	{
		/// <summary>
		///     The database context transaction
		/// </summary>
		private readonly IDbContextTransaction _dbContextTransaction;

		/// <summary>
		///     Initializes a new instance of the <see cref="DatabaseFacadeMock" /> class.
		/// </summary>
		/// <param name="context">The context.</param>
		/// <param name="dbContextTransaction">The database context transaction.</param>
		public DatabaseFacadeMock(DbContext context, IDbContextTransaction dbContextTransaction) : base(context)
		{
			_dbContextTransaction = dbContextTransaction;
		}

		/// <summary>
		///     Starts a new transaction.
		/// </summary>
		/// <returns>
		///     A <see cref="T:Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction" /> that represents the started
		///     transaction.
		/// </returns>
		public override IDbContextTransaction BeginTransaction()
		{
			return _dbContextTransaction;
		}

		/// <summary>
		///     Applies the outstanding operations in the current transaction to the database.
		/// </summary>
		public override void CommitTransaction()
		{
		}

		/// <summary>
		///     Discards the outstanding operations in the current transaction.
		/// </summary>
		public override void RollbackTransaction()
		{
		}
	}
}