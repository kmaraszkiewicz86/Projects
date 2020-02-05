// <copyright file="WordControllerTest.cs" username="Krzysztof Maraszkiewicz">
//    Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel.Enums;
using DataModel.Models.DbModels;
using DataModel.Models.WebAPI;
using Flashcard.WebAPI.Controllers;
using FluentAssertions;
using Implementations.Exceptions;
using Interfaces.WordMgt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FlashcardWebAPIUnitTest.Controllers
{
	/// <summary>
	/// WordControllerTest unit testing class.
	/// </summary>
	[TestClass]
	public class WordControllerTest
	{
		/// <summary>
		/// The word controller
		/// </summary>
		private readonly WordController _wordController;

		/// <summary>
		/// The word service mock
		/// </summary>
		private readonly Mock<IWordService> _wordServiceMock;

		/// <summary>
		/// Gets the words.
		/// </summary>
		/// <value>
		/// The words.
		/// </value>
		private List<WordModel> _words =>
			new List<WordModel>
			{
				new WordModel
				{
					Id = 20,
					Categories = new []
					{
						new CategoryModel
						{
							Id = 1,
							Name = "CategoryTest1"
						}
					},
					LanguageType = new LanguageTypeModel
					{
						Tag = LanguageTypeEnum.EN,
						Name = "English"
					},
					Value = "Original word 1",
					TranslatedWords = new[]
					{
						new TranslatedWord
						{
							Id = 1,
							LanguageType = new LanguageTypeModel
							{
								Tag = LanguageTypeEnum.PL,
								Name = "Polish"
							},
							Value = "Translated word 1"
						},
						new TranslatedWord
						{
							Id = 2,
							LanguageType = new LanguageTypeModel
							{
								Tag = LanguageTypeEnum.PL,
								Name = "Polish"
							},
							Value = "Translated word 2"
						}
					}
				},
				new WordModel
				{
					Id = 21,
					Categories = new CategoryModel[]
					{
						new CategoryModel
						{
							Id = 2,
							Name = "CategoryTest2"
						}
					},
					LanguageType = new LanguageTypeModel
					{
						Tag = LanguageTypeEnum.EN,
						Name = "English"
					},
					Value = "Original word 2",
					TranslatedWords = new[]
					{
						new TranslatedWord
						{
							Id = 3,
							LanguageType = new LanguageTypeModel
							{
								Tag = LanguageTypeEnum.PL,
								Name = "Polish"
							},
							Value = "Translated word 3"
						}
					}
				}
			};

		/// <summary>
		/// Gets the word.
		/// </summary>
		/// <value>
		/// The word.
		/// </value>
		private WordModel _word =>
			new WordModel
			{
				Id = 21,
				Categories = new []
				{
					new CategoryModel
					{
						Id = 2,
						Name = "CategoryTest2"
					}
				},
				LanguageType = new LanguageTypeModel
				{
					Tag = LanguageTypeEnum.EN,
					Name = "English"
				},
				Value = "Original word 2",
				TranslatedWords = new[]
				{
					new TranslatedWord
					{
						Id = 3,
						LanguageType = new LanguageTypeModel
						{
							Tag = LanguageTypeEnum.PL,
							Name = "Polish"
						},
						Value = "Translated word 3"
					}
				}
			};

		/// <summary>
		/// Initializes a new instance of the <see cref="WordControllerTest"/> class.
		/// </summary>
		public WordControllerTest()
		{
			_wordServiceMock = new Mock<IWordService>();
			_wordController = new WordController(_wordServiceMock.Object);
		}

		/// <summary>
		/// Gets the parents with children test.
		/// </summary>
		[TestMethod]
		public void GetParentsWithChildrenTest()
		{
			_wordServiceMock.Setup(w => w.GetAll(It.IsAny<WordItemsType>()))
				.Returns(_words);

			var result =
				(_wordController.GetAll(WordItemsType.ParentsWithChildren) as ObjectResult).Value as
				IEnumerable<WordModel>;

			result.Should().BeEquivalentTo(_words);
		}

		/// <summary>
		/// Gets the child with parents test.
		/// </summary>
		[TestMethod]
		public void GetChildWithParentsTest()
		{
			_wordServiceMock.Setup(w => w.GetAll(It.IsAny<WordItemsType>()))
				.Returns(new List<WordModel>());

			var result =
				(_wordController.GetAll(WordItemsType.ParentsWithChildren) as ObjectResult).Value as
				IEnumerable<WordModel>;

			result.Should().BeNullOrEmpty();
		}

		/// <summary>
		/// Adds the valid data.
		/// </summary>
		[TestMethod]
		public void AddValidDataTest()
		{
			_wordServiceMock.Setup(w => w.AddAsync(It.IsAny<WordModel>()))
				.Returns(Task.FromResult(0));

			var addAction = _wordController.Add(_word);
			addAction.Wait();

			var result = addAction.Result as OkResult;
			result.StatusCode.Should().Be(200);
		}

		/// <summary>
		/// Adds the when not found exception test.
		/// </summary>
		[TestMethod]
		public void AddWhenNotFoundExceptionTest()
		{
			_wordServiceMock.Setup(w => w.AddAsync(It.IsAny<WordModel>()))
				.Returns(() => throw new NotFoundException());

			var addAction = _wordController.Add(_word);
			addAction.Wait();

			var result = addAction.Result as NotFoundObjectResult;
			result.StatusCode.Should().Be(404);
		}

		/// <summary>
		/// Adds the when model state has error test.
		/// </summary>
		[TestMethod]
		public void AddWhenModelStateHasErrorTest()
		{
			_wordServiceMock.Setup(w => w.AddAsync(It.IsAny<WordModel>()))
				.Returns(Task.CompletedTask);

			_word.Value = string.Empty;

			_wordController.ModelState.AddModelError("test", "test");

			var addAction = _wordController.Add(_word);
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
			_wordServiceMock.Setup(w => w.UpdateAsync(It.IsAny<WordModel>()))
				.Returns(Task.FromResult(0));

			var update = _wordController.Update(_word);
			update.Wait();

			var result = update.Result as OkResult;
			result.StatusCode.Should().Be(200);
		}

		/// <summary>
		/// Updates the when not found exception test.
		/// </summary>
		[TestMethod]
		public void UpdateWhenNotFoundExceptionTest()
		{
			_wordServiceMock.Setup(w => w.UpdateAsync(It.IsAny<WordModel>()))
				.Returns(() => throw new NotFoundException());

			var update = _wordController.Update(_word);
			update.Wait();

			var result = update.Result as NotFoundObjectResult;
			result.StatusCode.Should().Be(404);
		}

		/// <summary>
		/// Updates the when model state has error test.
		/// </summary>
		[TestMethod]
		public void UpdateWhenModelStateHasErrorTest()
		{
			_wordServiceMock.Setup(w => w.UpdateAsync(It.IsAny<WordModel>()))
				.Returns(Task.CompletedTask);

			_word.Value = string.Empty;

			_wordController.ModelState.AddModelError("test", "test");

			var update = _wordController.Update(_word);
			update.Wait();

			var result = update.Result as BadRequestObjectResult;
			result.StatusCode.Should().Be(400);
		}

		/// <summary>
		/// Deletes the valid data test.
		/// </summary>
		[TestMethod]
		public void DeleteValidDataTest()
		{
			_wordServiceMock.Setup(w => w.DeleteAsync(It.IsAny<int>()))
				.Returns(Task.FromResult(0));

			var delete = _wordController.Delete(1);
			delete.Wait();

			var result = delete.Result as OkResult;
			result.StatusCode.Should().Be(200);
		}

		/// <summary>
		/// Deletes the when not found exception test.
		/// </summary>
		[TestMethod]
		public void DeleteWhenNotFoundExceptionTest()
		{
			_wordServiceMock.Setup(w => w.DeleteAsync(It.IsAny<int>()))
				.Throws<NotFoundException>();

			var delete = _wordController.Delete(1);
			delete.Wait();

			var result = delete.Result as NotFoundObjectResult;
			result.StatusCode.Should().Be(404);
		}

		/// <summary>
		/// Deletes the when model state has error test.
		/// </summary>
		[TestMethod]
		public void DeleteWhenModelStateHasErrorTest()
		{
			_wordServiceMock.Setup(w => w.DeleteAsync(It.IsAny<int>()))
				.Returns(Task.FromResult(0));

			_word.Value = string.Empty;

			_wordController.ModelState.AddModelError("test", "test");

			var delete = _wordController.Delete(1);
			delete.Wait();

			var result = delete.Result as BadRequestObjectResult;
			result.StatusCode.Should().Be(400);
		}
	}
}