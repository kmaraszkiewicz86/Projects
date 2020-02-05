// <copyright file="TestAsyncEnumerable.cs" username="Krzysztof Maraszkiewicz">
//    Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ImplementationsUnitTest.Fakes
{
	/// <summary>
	///     TestAsyncEnumerable helper class.
	/// </summary>
	/// <typeparam name="TEntity">The type of the entity.</typeparam>
	/// <seealso cref="System.Linq.EnumerableQuery{TEntity}" />
	/// <seealso cref="System.Collections.Generic.IAsyncEnumerable{TEntity}" />
	/// <seealso cref="System.Linq.IQueryable{TEntity}" />
	internal class TestAsyncEnumerable<TEntity> : EnumerableQuery<TEntity>, IAsyncEnumerable<TEntity>,
		IQueryable<TEntity>
	{
		IQueryProvider IQueryable.Provider => new TestAsyncQueryProvider<TEntity>(this);

		/// <summary>
		///     Initializes a new instance of the <see cref="TestAsyncEnumerable{TEntity}" /> class.
		/// </summary>
		/// <param name="enumerable">A collection to associate with the new instance.</param>
		public TestAsyncEnumerable(IEnumerable<TEntity> enumerable)
			: base(enumerable)
		{
		}

		/// <summary>
		///     Initializes a new instance of the <see cref="TestAsyncEnumerable{TEntity}" /> class.
		/// </summary>
		/// <param name="expression">An expression tree to associate with the new instance.</param>
		public TestAsyncEnumerable(Expression expression)
			: base(expression)
		{
		}

		/// <summary>
		///     Gets an asynchronous enumerator over the sequence.
		/// </summary>
		/// <returns>
		///     Enumerator for asynchronous enumeration over the sequence.
		/// </returns>
		public IAsyncEnumerator<TEntity> GetEnumerator()
		{
			return new TestAsyncEnumerator<TEntity>(this.AsEnumerable().GetEnumerator());
		}
	}
}