// <copyright file="TestAsyncQueryProvider.cs" username="Krzysztof Maraszkiewicz">
//    Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace ImplementationsUnitTest.Fakes
{
	/// <summary>
	/// TestAsyncQueryProvider helper class.
	/// </summary>
	/// <typeparam name="TEntity">The type of the entity.</typeparam>
	/// <seealso cref="Microsoft.EntityFrameworkCore.Query.Internal.IAsyncQueryProvider" />
	internal class TestAsyncQueryProvider<TEntity> : IAsyncQueryProvider
	{
		/// <summary>
		/// The inner
		/// </summary>
		private readonly IQueryProvider _inner;

		/// <summary>
		/// Initializes a new instance of the <see cref="TestAsyncQueryProvider{TEntity}"/> class.
		/// </summary>
		/// <param name="inner">The inner.</param>
		internal TestAsyncQueryProvider(IQueryProvider inner)
		{
			_inner = inner;
		}

		/// <summary>
		/// Constructs an <see cref="T:System.Linq.IQueryable"></see> object that can evaluate the query represented by a specified expression tree.
		/// </summary>
		/// <param name="expression">An expression tree that represents a LINQ query.</param>
		/// <returns>
		/// An <see cref="T:System.Linq.IQueryable"></see> that can evaluate the query represented by the specified expression tree.
		/// </returns>
		public IQueryable CreateQuery(Expression expression)
		{
			return new TestAsyncEnumerable<TEntity>(expression);
		}

		/// <summary>
		/// Constructs an <see cref="T:System.Linq.IQueryable`1"></see> object that can evaluate the query represented by a specified expression tree.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements of the <see cref="T:System.Linq.IQueryable`1"></see> that is returned.</typeparam>
		/// <param name="expression">An expression tree that represents a LINQ query.</param>
		/// <returns>
		/// An <see cref="T:System.Linq.IQueryable`1"></see> that can evaluate the query represented by the specified expression tree.
		/// </returns>
		public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
		{
			return new TestAsyncEnumerable<TElement>(expression);
		}

		/// <summary>
		/// Executes the query represented by a specified expression tree.
		/// </summary>
		/// <param name="expression">An expression tree that represents a LINQ query.</param>
		/// <returns>
		/// The value that results from executing the specified query.
		/// </returns>
		public object Execute(Expression expression)
		{
			return _inner.Execute(expression);
		}

		/// <summary>
		/// Executes the strongly-typed query represented by a specified expression tree.
		/// </summary>
		/// <typeparam name="TResult">The type of the value that results from executing the query.</typeparam>
		/// <param name="expression">An expression tree that represents a LINQ query.</param>
		/// <returns>
		/// The value that results from executing the specified query.
		/// </returns>
		public TResult Execute<TResult>(Expression expression)
		{
			return _inner.Execute<TResult>(expression);
		}

		/// <summary>
		/// This API supports the Entity Framework Core infrastructure and is not intended to be used
		/// directly from your code. This API may change or be removed in future releases.
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="expression"></param>
		/// <returns></returns>
		public IAsyncEnumerable<TResult> ExecuteAsync<TResult>(Expression expression)
		{
			return new TestAsyncEnumerable<TResult>(expression);
		}

		/// <summary>
		/// This API supports the Entity Framework Core infrastructure and is not intended to be used
		/// directly from your code. This API may change or be removed in future releases.
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="expression"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public Task<TResult> ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken)
		{
			return Task.FromResult(Execute<TResult>(expression));
		}
	}
}