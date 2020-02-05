// <copyright file="CategoryServiceTests.cs" username="Krzysztof Maraszkiewicz">
//    Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System;
using DataModel.Models.DbModels;
using FluentAssertions;
using Implementations.Exceptions;
using ImplementationsUnitTest.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImplementationsUnitTest.CategoryMgt
{
	/// <summary>
	/// CategoryServiceTests unit testing class.
	/// </summary>
	[TestClass]
	public class CategoryServiceTests
	{
		/// <summary>
		/// The category service helper
		/// </summary>
		private readonly CategoryServiceHelper _categoryServiceHelper;

		/// <summary>
		///     Initializes a new instance of the <see cref="CategoryServiceTests" /> class.
		/// </summary>
		public CategoryServiceTests()
		{
			_categoryServiceHelper = new CategoryServiceHelper();
		}

		/// <summary>
		///     Adds the valid data test.
		/// </summary>
		[TestMethod]
		public void AddValidDataTest()
		{
			_categoryServiceHelper.Initialize();

			var addAsync = _categoryServiceHelper.CategoryService.AddAsync(new Category
			{
				Name = "test123"
			});

			addAsync.Wait();
		}

		/// <summary>
		/// Adds the duplicate data test.
		/// </summary>
		[TestMethod]
		public void AddDuplicateDataTest()
		{
			_categoryServiceHelper.Initialize();

			Action func = () =>
			{
				var addAsync = _categoryServiceHelper.CategoryService.AddAsync(new Category
				{
					Name = "test"
				});

				addAsync.Wait();
			};

			func.Should().Throw<BadRequestException>();
		}

		/// <summary>
		/// Updates the valid data test.
		/// </summary>
		[TestMethod]
		public void UpdateValidDataTest()
		{
			_categoryServiceHelper.Initialize();

			var updateAsync = _categoryServiceHelper.CategoryService.UpdateAsync(1, new Category
			{
				Name = "test123"
			});

			updateAsync.Wait();
		}

		/// <summary>
		/// Updates the no exist data test.
		/// </summary>
		[TestMethod]
		public void UpdateNoExistDataTest()
		{
			_categoryServiceHelper.Initialize();

			Action func = () =>
			{
				var updateAsync = _categoryServiceHelper.CategoryService.UpdateAsync(100, new Category
				{
					Name = "test123"
				});

				updateAsync.Wait();
			};

			func.Should().Throw<NotFoundException>();
		}

		/// <summary>
		/// Updates the exist data test.
		/// </summary>
		[TestMethod]
		public void UpdateExistDataTest()
		{
			_categoryServiceHelper.Initialize();

			Action func = () =>
			{
				var updateAsync = _categoryServiceHelper.CategoryService.UpdateAsync(1, new Category
				{
					Name = "test2"
				});

				updateAsync.Wait();
			};

			func.Should().Throw<BadRequestException>();
		}

		/// <summary>
		/// Updates the data with the same name test.
		/// </summary>
		[TestMethod]
		public void UpdateDataWithTheSameNameTest()
		{
			_categoryServiceHelper.Initialize();
			
			var updateAsync = _categoryServiceHelper.CategoryService.UpdateAsync(1, new Category
			{
				Name = "test"
			});

			updateAsync.Wait();
		}

		/// <summary>
		/// Deletes the item test.
		/// </summary>
		[TestMethod]
		public void DeleteItemTest()
		{
			_categoryServiceHelper.Initialize();

			var deleteAsync = _categoryServiceHelper.CategoryService.DeleteAsync(1);

			deleteAsync.Wait();
		}

		/// <summary>
		/// Deletes the no exists element test.
		/// </summary>
		[TestMethod]
		public void DeleteNoExistsElementTest()
		{
			_categoryServiceHelper.Initialize();

			Action func = () =>
			{
				var deleteAsync = _categoryServiceHelper.CategoryService.DeleteAsync(999);

				deleteAsync.Wait();
			};

			func.Should().Throw<NotFoundException>();
		}

		/// <summary>
		/// Gets all elements test.
		/// </summary>
		[TestMethod]
		public void GetAllElementsTest()
		{
			_categoryServiceHelper.Initialize(false);

			var items = _categoryServiceHelper.CategoryService.GetAll();

			items.Should().BeEquivalentTo(_categoryServiceHelper.Categories);
		}
	}
}