// <copyright file="CategoryControllerTest.cs" username="Krzysztof Maraszkiewicz">
//    Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel.Models.DbModels;
using Flashcard.WebAPI.Controllers;
using FluentAssertions;
using Implementations.Exceptions;
using Interfaces.CategoryMgt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FlashcardWebAPIUnitTest.Controllers
{
	/// <summary>
	/// CategoryControllerTest unit testing class.
	/// </summary>
	[TestClass]
	public class CategoryControllerTest
	{
		/// <summary>
		/// The category controller
		/// </summary>
		private readonly CategoryController _categoryController;

		/// <summary>
		/// The category service mock
		/// </summary>
		private readonly Mock<ICategoryService> _categoryServiceMock;

		/// <summary>
		/// Gets the categories.
		/// </summary>
		/// <value>
		/// The categories.
		/// </value>
		private IEnumerable<Category> _categories =>
			new List<Category>
			{
				new Category
				{
					Id = 1,
					Name = "test1"
				},
				new Category
				{
					Id = 2,
					Name = "test2"
				},
				new Category
				{
					Id = 3,
					Name = "test3"
				}
			};

		/// <summary>
		/// Gets the category.
		/// </summary>
		/// <value>
		/// The category.
		/// </value>
		private Category _category =>
			new Category
			{
				Name = "test1"
			};

		/// <summary>
		/// Initializes a new instance of the <see cref="CategoryControllerTest"/> class.
		/// </summary>
		public CategoryControllerTest()
		{
			_categoryServiceMock = new Mock<ICategoryService>();
			_categoryController = new CategoryController(_categoryServiceMock.Object);
		}

		/// <summary>
		/// Gets all test.
		/// </summary>
		[TestMethod]
		public void GetAllTest()
		{
			_categoryServiceMock.Setup(c => c.GetAll()).Returns(_categories);
			var result = (_categoryController.GetAll() as ObjectResult).Value as IEnumerable<Category>;

			result.Should().BeEquivalentTo(_categories);
		}

		/// <summary>
		/// Gets the empty data test.
		/// </summary>
		[TestMethod]
		public void GetAllEmptyDataTest()
		{
			_categoryServiceMock.Setup(c => c.GetAll()).Returns(new List<Category>());
			var result = (_categoryController.GetAll() as ObjectResult).Value as IEnumerable<Category>;

			result.Should().BeEmpty();
		}

		/// <summary>
		/// Adds the valid data test.
		/// </summary>
		[TestMethod]
		public void AddValidDataTest()
		{
			_categoryServiceMock.Setup(c => c.AddAsync(It.IsAny<Category>())).Returns(Task.CompletedTask);
			var addAction = _categoryController.Add(_category);
			addAction.Wait();

			var result = addAction.Result as OkResult;
			result.StatusCode.Should().Be(200);
		}

		/// <summary>
		/// Adds data when model state is invalid test.
		/// </summary>
		[TestMethod]
		public void AddWhenModelStateIsInvalidTest()
		{
			_categoryServiceMock.Setup(c => c.AddAsync(It.IsAny<Category>())).Returns(Task.CompletedTask);

			_categoryController.ModelState.AddModelError("test", "test");

			var addAction = _categoryController.Add(new Category());
			addAction.Wait();

			var result = addAction.Result as BadRequestObjectResult;
			result.StatusCode.Should().Be(400);
		}

		/// <summary>
		/// Adds data when bad request exception thrown test.
		/// </summary>
		[TestMethod]
		public void AddWhenBadRequestExceptionThrownTest()
		{
			_categoryServiceMock.Setup(c => c.AddAsync(It.IsAny<Category>())).Throws<BadRequestException>();

			var addAction = _categoryController.Add(_category);
			addAction.Wait();

			var result = addAction.Result as BadRequestObjectResult;
			result.StatusCode.Should().Be(400);
		}

		/// <summary>
		/// Updates the valid data test.
		/// </summary>
		[TestMethod]
		public void UpdateValidDataTest()
		{
			_categoryServiceMock.Setup(c => c.UpdateAsync(It.IsAny<int>(), It.IsAny<Category>()))
				.Returns(Task.CompletedTask);

			var updateAction = _categoryController.Update(1, _category);
			updateAction.Wait();

			var result = updateAction.Result as OkResult;
			result.StatusCode.Should().Be(200);
		}

		/// <summary>
		/// Updates data when model state is invalid test.
		/// </summary>
		[TestMethod]
		public void UpdateWhenModelStateIsInvalidTest()
		{
			_categoryServiceMock.Setup(c => c.UpdateAsync(It.IsAny<int>(), It.IsAny<Category>()))
				.Throws<BadRequestException>();

			_categoryController.ModelState.AddModelError("test", "test");

			var updateAction = _categoryController.Update(1, new Category());
			updateAction.Wait();

			var result = updateAction.Result as BadRequestObjectResult;
			result.StatusCode.Should().Be(400);
		}

		/// <summary>
		/// Updates data when bad request exception thrown test.
		/// </summary>
		[TestMethod]
		public void UpdateWhenBadRequestExceptionThrownTest()
		{
			_categoryServiceMock.Setup(c => c.UpdateAsync(It.IsAny<int>(), It.IsAny<Category>()))
				.Throws<BadRequestException>();

			var updateAction = _categoryController.Update(1, _category);
			updateAction.Wait();

			var result = updateAction.Result as BadRequestObjectResult;
			result.StatusCode.Should().Be(400);
		}

		/// <summary>
		/// Updates data when not found exception thrown test.
		/// </summary>
		[TestMethod]
		public void UpdateWhenNotFoundExceptionThrownTest()
		{
			_categoryServiceMock.Setup(c => c.UpdateAsync(It.IsAny<int>(), It.IsAny<Category>()))
				.Throws<NotFoundException>();

			var updateAction = _categoryController.Update(1, _category);
			updateAction.Wait();

			var result = updateAction.Result as NotFoundObjectResult;
			result.StatusCode.Should().Be(404);
		}

		/// <summary>
		/// Deletes the valid data test.
		/// </summary>
		[TestMethod]
		public void DeleteValidDataTest()
		{
			_categoryServiceMock.Setup(c => c.DeleteAsync(It.IsAny<int>()))
				.Returns(Task.CompletedTask);

			var addAction = _categoryController.Delete(1);
			addAction.Wait();

			var result = addAction.Result as OkResult;
			result.StatusCode.Should().Be(200);
		}

		/// <summary>
		/// Deletes data when not found exception thrown test.
		/// </summary>
		[TestMethod]
		public void DeleteWhenNotFoundExceptionThrownTest()
		{
			_categoryServiceMock.Setup(c => c.DeleteAsync(It.IsAny<int>()))
				.Throws<NotFoundException>();

			var addAction = _categoryController.Delete(1);
			addAction.Wait();

			var result = addAction.Result as NotFoundObjectResult;
			result.StatusCode.Should().Be(404);
		}
	}
}