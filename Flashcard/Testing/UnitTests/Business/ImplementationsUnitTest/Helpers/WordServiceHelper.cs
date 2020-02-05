// <copyright file="WordServiceHelper.cs" username="Krzysztof Maraszkiewicz">
//    Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using DataModel.Enums;
using DataModel.Models.DbModels;
using DataModel.Models.WebAPI;
using Implementations.Models;
using Implementations.WordMgt;
using ImplementationsUnitTest.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Moq;

namespace ImplementationsUnitTest.Helpers
{
	/// <summary>
	///     WordService helper class.
	/// </summary>
	internal class WordServiceHelper
	{
		/// <summary>
		/// Gets the word service.
		/// </summary>
		/// <value>
		/// The word service.
		/// </value>
		public WordService WordService { get; private set; }

		/// <summary>
		///     The flashcard database context mock
		/// </summary>
		public Mock<FlashcardDbContext> FlashcardDbContextMock { get; private set; }

		/// <summary>
		/// Gets the word model mock.
		/// </summary>
		/// <value>
		/// The word model mock.
		/// </value>
		public Mock<WordModel> WordModelMock { get; private set; }

		/// <summary>
		/// Gets the word database set mock.
		/// </summary>
		/// <value>
		/// The word database set mock.
		/// </value>
		public Mock<DbSet<Word>> WordDbSetMock { get; private set; }

		/// <summary>
		/// Gets the category database set mock.
		/// </summary>
		/// <value>
		/// The category database set mock.
		/// </value>
		public Mock<DbSet<Category>> CategoryDbSetMock { get; private set; }

		/// <summary>
		/// Gets the category word database set mock.
		/// </summary>
		/// <value>
		/// The category word database set mock.
		/// </value>
		public Mock<DbSet<CategoryWord>> CategoryWordDbSetMock { get; private set; }

		/// <summary>
		/// Gets the language type database set mock.
		/// </summary>
		/// <value>
		/// The language type database set mock.
		/// </value>
		public Mock<DbSet<LanguageType>> LanguageTypeDbSetMock { get; private set; }

		/// <summary>
		/// Gets the database context transaction mock.
		/// </summary>
		/// <value>
		/// The database context transaction mock.
		/// </value>
		public Mock<IDbContextTransaction> DbContextTransactionMock { get; private set; }

		/// <summary>
		/// Gets the database context mock.
		/// </summary>
		/// <value>
		/// The database context mock.
		/// </value>
		public Mock<DbContext> DbContextMock { get; private set; }

		/// <summary>
		/// Gets the categories.
		/// </summary>
		/// <value>
		/// The categories.
		/// </value>
		public List<Category> Categories
		{
			get
			{
				var categories = new List<Category>();

				for (int index = 1; index <= 5; index++)
				{
					categories.Add(new Category
					{
						Id = index,
						Name = $"CategoryTest{index}"
					});
				}

				return categories;
			}
		}

		/// <summary>
		/// Gets the category words.
		/// </summary>
		/// <value>
		/// The category words.
		/// </value>
		public List<CategoryWord> CategoryWords
		{
			get
			{
				var categoryWords = new List<CategoryWord>();

				for (int index = 1; index <= 5; index++)
				{
					categoryWords.Add(new CategoryWord
					{
						Id = index,
						Category = Categories[index - 1],
						WordId = index,
						Word = Words[index - 1]
					});
				}

				return categoryWords;
			}
		}

		/// <summary>
		/// Gets the language types.
		/// </summary>
		/// <value>
		/// The language types.
		/// </value>
		public List<LanguageType> LanguageTypes =>
			new List<LanguageType>
			{
				new LanguageType
				{
					Id = 1,
					Name = "Polish",
					Tag = "PL"
				},
				new LanguageType
				{
					Id = 2,
					Name = "English",
					Tag = "EN"
				}
			};

		/// <summary>
		/// Gets the word.
		/// </summary>
		/// <value>
		/// The word.
		/// </value>
		public Word Word =>
			Words.First();
		
		/// <summary>
		/// Gets the words.
		/// </summary>
		/// <value>
		/// The words.
		/// </value>
		public List<Word> Words
		{
			get
			{
				var items = new List<Word>();
				
				for (var index = 1; index <= 5; index++)
				{
					var word = new Word
					{
						Id = index,
						LanguageTypeId = LanguageTypes[1].Id,
						LanguageType = LanguageTypes[1],
						Value = $"Original test word {index}"
					};

					items.Add(word);

					word.CategoriesWord = new List<CategoryWord>()
					{
						new CategoryWord
						{
							Id = index,
							Category = Categories[index - 1],
							CategoryId = Categories[index - 1].Id,
							Word = word,
							WordId = word.Id
						}
					};
				}

				var itemCount = items.Count;

				for (var itemIndex = 0; itemIndex < itemCount; itemIndex++)
				{
					var item = items[itemIndex];

					item.TranslateChildrenWords = new List<Word>();

					for (int index = 1; index <= 3; index++)
					{
						var translatedWord = new Word
						{
							Id = items.Count + index,
							LanguageTypeId = LanguageTypes[0].Id,
							LanguageType = LanguageTypes[0],
							Value = $"Translated test word {item.Id + index}",
							ParentWordId = item.Id,
							ParentWord = item
						};

						translatedWord.CategoriesWord = new List<CategoryWord>
						{
							new CategoryWord
							{
								Id = index,
								Category = Categories[item.Id - 1],
								CategoryId = Categories[item.Id - 1].Id,
								Word = translatedWord,
								WordId = translatedWord.Id
							}
						};

						items.Add(translatedWord);

						item.TranslateChildrenWords.Add(translatedWord);
					}
				}

				return items;
			}
		}

		/// <summary>
		/// Gets the child with parents words model.
		/// </summary>
		/// <value>
		/// The child with parents words model.
		/// </value>
		public List<WordModel> ChildWithParentsWordsModel => Words
			.Where(w => w.ParentWord != null)
			.ToList().Select(w =>
				new WordModel
				{
					Id = w.Id,
					Categories = w.CategoriesWord.Select(wTemp => new CategoryModel
					{
						Id = wTemp.Category.Id,
						Name = wTemp.Category.Name
					}).ToArray(),
					LanguageType = new LanguageTypeModel
					{
						Tag = Enum.Parse<LanguageTypeEnum>(w.LanguageType.Tag),
						Name = w.LanguageType.Name
					},
					Value = w.Value,
					TranslatedWords = new[]
					{
						new TranslatedWord
						{
							Id = w.ParentWord.Id,
							LanguageType = new LanguageTypeModel
							{
								Tag = Enum.Parse<LanguageTypeEnum>(w.ParentWord.LanguageType.Tag),
								Name = w.ParentWord.LanguageType.Name
							},
							Value = w.ParentWord.Value
						}
					}
				}).ToList();

		/// <summary>
		/// Gets the parents with children words model.
		/// </summary>
		/// <value>
		/// The parents with children words model.
		/// </value>
		public List<WordModel> ParentsWithChildrenWordsModel =>
			Words.Where(w => w.ParentWord == null).Select(w =>
				new WordModel
				{
					Id = w.Id,
					Categories = w.CategoriesWord.Select(wTemp => new CategoryModel
					{
						Id = wTemp.Category.Id,
						Name = wTemp.Category.Name
					}).ToArray(),
					LanguageType = new LanguageTypeModel
					{
						Tag = Enum.Parse<LanguageTypeEnum>(w.LanguageType.Tag),
						Name = w.LanguageType.Name
					},
					Value = w.Value,
					TranslatedWords = w.TranslateChildrenWords?.ToList().Select(ch =>
						new TranslatedWord
						{
							Id = ch.Id,
							LanguageType = new LanguageTypeModel
							{
								Tag = Enum.Parse<LanguageTypeEnum>(ch.LanguageType.Tag),
								Name = ch.LanguageType.Name
							},
							Value = ch.Value

						}).ToArray()
				}).ToList();

		/// <summary>
		/// Gets the word model.
		/// </summary>
		/// <param name="wordModelDataType">Type of the invalid word model data.</param>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		public WordModel GetWordModel(WordModelDataType wordModelDataType = WordModelDataType.None)
		{
			Word word = wordModelDataType == WordModelDataType.WordAsChildWord
				? Words.First().TranslateChildrenWords.First()
				: Words.First();
			
			var wordModel = new WordModel
			{
				Id = wordModelDataType == WordModelDataType.WordNoExists? 999 : word.Id,
				Categories = new []
				{
					new CategoryModel
					{
						Id = wordModelDataType == WordModelDataType.CategoryNoExists
							? 999
							: wordModelDataType == WordModelDataType.UpdatingValidData
								? Categories.Last().Id
								: word.CategoriesWord.First().CategoryId
					}
				},
				Value = word.Value + " New",
				LanguageType = new LanguageTypeModel
				{
					Tag = wordModelDataType == WordModelDataType.UpdatingValidData 
						? word.LanguageType.Tag == "EN" 
							? LanguageTypeEnum.PL 
							: LanguageTypeEnum.EN
						: Enum.Parse<LanguageTypeEnum>(word.LanguageType.Tag)
				},
				TranslatedWords = (wordModelDataType == WordModelDataType.WordAsChildWord 
				                   || wordModelDataType == WordModelDataType.EmptyTranslatedWordsCollection) 
					? new TranslatedWord[] { } 
					: word.TranslateChildrenWords.Select(item =>
					new TranslatedWord
					{
						Id = item.Id,
						LanguageType = new LanguageTypeModel
						{
							Name = item.LanguageType.Name,
							Tag = Enum.Parse<LanguageTypeEnum>(item.LanguageType.Tag)
						},
						Value = wordModelDataType == WordModelDataType.EmptyTranslatedWordValue 
							? string.Empty 
							: item.Value + "New"
					}).ToArray()
			};

			switch (wordModelDataType)
			{
				case WordModelDataType.EmptyOriginalValue:
					wordModel.Value = string.Empty;
					break;

				case WordModelDataType.OriginalValueExists:
					wordModel.Value = Words[1].Value;
					break;
			}

			return wordModel;
		}

		/// <summary>
		/// Initializes the specified should initialize asynchronous configuration.
		/// </summary>
		/// <param name="shouldInitAsyncConfig">if set to <c>true</c> [should initialize asynchronous configuration].</param>
		/// <param name="shouldSetEmptyCollection">if set to <c>true</c> [should set empty collection].</param>
		public void Initialize(bool shouldInitAsyncConfig = true, bool shouldSetEmptyCollection = false)
		{
			FlashcardDbContextMock = new Mock<FlashcardDbContext>();
			WordDbSetMock = new Mock<DbSet<Word>>();
			CategoryDbSetMock = new Mock<DbSet<Category>>();
			CategoryWordDbSetMock = new Mock<DbSet<CategoryWord>>();
			LanguageTypeDbSetMock = new Mock<DbSet<LanguageType>>();
			DbContextTransactionMock = new Mock<IDbContextTransaction>();
			DbContextMock = new Mock<DbContext>();

			var databaseFacadeMock = new DatabaseFacadeMock(DbContextMock.Object, 
				DbContextTransactionMock.Object);

			List<Word> words = new List<Word>();

			if (!shouldSetEmptyCollection)
				words = Words;

			WordDbSetMock.SetDbSet(words, shouldInitAsyncConfig);
			CategoryDbSetMock.SetDbSet(Categories, shouldInitAsyncConfig);
			CategoryWordDbSetMock.SetDbSet(CategoryWords, shouldInitAsyncConfig);
			LanguageTypeDbSetMock.SetDbSet(LanguageTypes, shouldInitAsyncConfig);

			FlashcardDbContextMock.Setup(f => f.Database).Returns(databaseFacadeMock);

			FlashcardDbContextMock.Setup(f => f.Set<Word>())
				.Returns(WordDbSetMock.Object);

			FlashcardDbContextMock.Setup(f => f.Set<Category>())
				.Returns(CategoryDbSetMock.Object);

			FlashcardDbContextMock.Setup(f => f.Set<CategoryWord>())
				.Returns(CategoryWordDbSetMock.Object);

			FlashcardDbContextMock.Setup(f => f.Set<LanguageType>())
				.Returns(LanguageTypeDbSetMock.Object);

			FlashcardDbContextMock.Setup(f => f.Words).Returns(WordDbSetMock.Object);
			FlashcardDbContextMock.Setup(f => f.Categories).Returns(CategoryDbSetMock.Object);
			FlashcardDbContextMock.Setup(f => f.CategoryWords).Returns(CategoryWordDbSetMock.Object);
			FlashcardDbContextMock.Setup(f => f.LanguageTypes).Returns(LanguageTypeDbSetMock.Object);
			WordService = new WordService(FlashcardDbContextMock.Object, true);
		}
	}
}