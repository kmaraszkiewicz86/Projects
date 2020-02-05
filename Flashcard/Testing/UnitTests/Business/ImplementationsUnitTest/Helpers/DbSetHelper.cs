// <copyright file="DbSetHelper.cs" username="Krzysztof Maraszkiewicz">
//    Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System.Collections.Generic;
using System.Linq;
using ImplementationsUnitTest.Fakes;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace ImplementationsUnitTest.Helpers
{
	/// <summary>
	///     DbSetHelper class.
	/// </summary>
	internal static class DbSetHelper
	{
		/// <summary>
		/// Sets the database set.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="dbSetMock">The database set mock.</param>
		/// <param name="items">The items.</param>
		/// <param name="shouldInitAsyncConfig">if set to <c>true</c> [should initialize asynchronous configuration].</param>
		public static void SetDbSet<T>(this Mock<DbSet<T>> dbSetMock, List<T> items,
			bool shouldInitAsyncConfig = true) where T : class
		{
			var entities = items.AsQueryable();

			if (shouldInitAsyncConfig)
				dbSetMock.As<IQueryable<T>>()
					.Setup(m => m.Provider)
					.Returns(new TestAsyncQueryProvider<T>(entities.Provider));
			else
				dbSetMock.As<IQueryable<T>>().Setup(m => m.Provider)
					.Returns(entities.AsQueryable().Provider);

			dbSetMock.As<IQueryable<T>>().Setup(m => m.Expression).Returns(entities.Expression);
			dbSetMock.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(entities.ElementType);
			dbSetMock.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(entities.GetEnumerator());
			dbSetMock.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(entities.GetEnumerator());
			dbSetMock.As<IAsyncEnumerable<T>>()
				.Setup(m => m.GetEnumerator())
				.Returns(new TestAsyncEnumerator<T>(entities.GetEnumerator()));
		}
	}
}