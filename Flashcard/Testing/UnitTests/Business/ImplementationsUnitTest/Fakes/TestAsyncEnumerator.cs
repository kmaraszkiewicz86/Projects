// <copyright file="TestAsyncEnumerator.cs" username="Krzysztof Maraszkiewicz">
//    Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ImplementationsUnitTest.Fakes
{
	/// <summary>
	/// TestAsyncEnumerator helper class.
	/// </summary>
	/// <typeparam name="TEntity">The type of the entity.</typeparam>
	/// <seealso cref="System.Collections.Generic.IAsyncEnumerator{TEntity}" />
	internal class TestAsyncEnumerator<TEntity> : IAsyncEnumerator<TEntity>
	{
		/// <summary>
		/// The inner
		/// </summary>
		private readonly IEnumerator<TEntity> _inner;

		/// <summary>
		/// Gets the current element in the iteration.
		/// </summary>
		public TEntity Current => _inner.Current;

		/// <summary>
		/// Initializes a new instance of the <see cref="TestAsyncEnumerator{TEntity}"/> class.
		/// </summary>
		/// <param name="inner">The inner.</param>
		public TestAsyncEnumerator(IEnumerator<TEntity> inner)
		{
			_inner = inner;
		}

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			_inner.Dispose();
		}

		/// <summary>
		/// Advances the enumerator to the next element in the sequence, returning the result asynchronously.
		/// </summary>
		/// <param name="cancellationToken">Cancellation token that can be used to cancel the operation.</param>
		/// <returns>
		/// Task containing the result of the operation: true if the enumerator was successfully advanced
		/// to the next element; false if the enumerator has passed the end of the sequence.
		/// </returns>
		public Task<bool> MoveNext(CancellationToken cancellationToken)
		{
			return Task.FromResult(_inner.MoveNext());
		}
	}
}