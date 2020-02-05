// <copyright file="CategoryServiceHelper.cs" username="Krzysztof Maraszkiewicz">
//    Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System.Collections.Generic;
using DataModel.Models.DbModels;
using Implementations.CategoryMgt;
using Implementations.Models;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace ImplementationsUnitTest.Helpers
{
	/// <summary>
	///     CategoryServiceHelper helper class.
	/// </summary>
	internal class CategoryServiceHelper
	{
		/// <summary>
		///     The category service
		/// </summary>
		public CategoryService CategoryService { get; private set; }

		/// <summary>
		///     The flashcard database context mock
		/// </summary>
		public Mock<FlashcardDbContext> FlashcardDbContextMock { get; private set; }

		/// <summary>
		///     The category database set mock
		/// </summary>
		public Mock<DbSet<Category>> CategoryDbSetMock { get; private set; }

		/// <summary>
		///     Gets or sets the categories.
		/// </summary>
		/// <value>
		///     The categories.
		/// </value>
		public List<Category> Categories { get; } = new List<Category>
		{
			new Category
			{
				Id = 1,
				Name = "test"
			},
			new Category
			{
				Id = 2,
				Name = "test1"
			},
			new Category
			{
				Id = 3,
				Name = "test2"
			},
			new Category
			{
				Id = 4,
				Name = "test3"
			}
		};

		/// <summary>
		/// Initializes the specified should initialize asynchronous configuration.
		/// </summary>
		/// <param name="shouldInitAsyncConfig">if set to <c>true</c> [should initialize asynchronous configuration].</param>
		public void Initialize(bool shouldInitAsyncConfig = true)
		{
			FlashcardDbContextMock = new Mock<FlashcardDbContext>();
			CategoryDbSetMock = new Mock<DbSet<Category>>();

			CategoryDbSetMock.SetDbSet(Categories, shouldInitAsyncConfig);

			FlashcardDbContextMock.Setup(f => f.Set<Category>())
				.Returns(CategoryDbSetMock.Object);

			FlashcardDbContextMock.Setup(f => f.Categories).Returns(CategoryDbSetMock.Object);
			CategoryService = new CategoryService(FlashcardDbContextMock.Object);
		}
	}
}