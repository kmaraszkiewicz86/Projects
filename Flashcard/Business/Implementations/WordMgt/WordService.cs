// <copyright file="WordService.cs" username="Krzysztof Maraszkiewicz">
//    Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataModel.Enums;
using DataModel.Models.DbModels;
using DataModel.Models.WebAPI;
using Implementations.Exceptions;
using Implementations.Helpers;
using Implementations.Models;
using Interfaces.WordMgt;
using Microsoft.EntityFrameworkCore;

namespace Implementations.WordMgt
{
	/// <summary>
	///     Word service class.
	/// </summary>
	/// <seealso cref="IWordService" />
	public class WordService : IWordService
	{
		/// <summary>
		///     The flashcard database context
		/// </summary>
		private readonly FlashcardDbContext _flashcardDbContext;

		/// <summary>
		/// The fake service
		/// </summary>
		private bool _fakeService;

		/// <summary>
		///     Initializes a new instance of the <see cref="WordService" /> class.
		/// </summary>
		/// <param name="flashcardDbContext">The flashcard database context.</param>
		public WordService(FlashcardDbContext flashcardDbContext)
			: this(flashcardDbContext, false)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="WordService"/> class.
		/// </summary>
		/// <param name="flashcardDbContext">The flashcard database context.</param>
		/// <param name="fakeService">if set to <c>true</c> [fake service].</param>
		public WordService(FlashcardDbContext flashcardDbContext, bool fakeService)
		{
			_flashcardDbContext = flashcardDbContext;
			_fakeService = fakeService;
		}

		/// <summary>
		/// Gets all.
		/// </summary>
		/// <param name="type">The type of <see cref="WordItemsType"/> enum.</param>
		/// return <see cref="IEnumerable{WordModel}" />
		public IEnumerable<WordModel> GetAll(WordItemsType type)
		{
			switch (type)
			{
				case WordItemsType.ParentsWithChildren:
					return _flashcardDbContext.Words
						.Include(w => w.CategoriesWord)
						.ThenInclude(c => c.Category)
						.Include(w => w.LanguageType)
						.Include(w => w.ParentWord)
						.ThenInclude(pw => pw.LanguageType)
						.Include(pw => pw.TranslateChildrenWords)
						.ThenInclude(pw => pw.LanguageType)
						.Where(w => w.ParentWord == null).ToList().Select(w =>
						new WordModel
						{
							Id = w.Id,
							Categories = w.CategoriesWord.Select(cw =>
								new CategoryModel
								{
									Id = cw.CategoryId,
									Name = cw.Category.Name
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
						});

				case WordItemsType.ChildWithParents:

					return _flashcardDbContext.Words
						.Include(w => w.CategoriesWord)
						.ThenInclude(c => c.Category)
						.Include(w => w.LanguageType)
						.Include(w => w.ParentWord)
						.ThenInclude(pw => pw.LanguageType)
						.Where(w => w.ParentWord != null)
						.ToList().Select(w =>
						new WordModel
						{
							Id = w.Id,
							Categories = w.CategoriesWord.Select(cw =>
								new CategoryModel
								{
									Id = cw.CategoryId,
									Name = cw.Category.Name
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
						});
			}

			throw new BadRequestException("Unsupported type name");
		}

		/// <summary>
		/// Adds the word asynchronous.
		/// </summary>
		/// <param name="model">The model.</param>
		/// <returns>
		/// return <see cref="T:System.Threading.Tasks.Task" />
		/// </returns>
		/// <exception cref="NotFoundException">Category not found</exception>
		public async Task AddAsync(WordModel model)
		{
			if (string.IsNullOrWhiteSpace(model.Value))
			{
				throw new BadRequestException($"{nameof(model.Value)} could not be empty");
			}

			model.Categories.ThrowIfEmpty();

			var categories = _flashcardDbContext.Categories.Where(c =>
				model.Categories.Any(cm => cm.Id == c.Id));

			if (categories?.Count() == 0)
				throw new NotFoundException("You must provide at least one category");

			if (_flashcardDbContext.Words.Include(w => w.ParentWord).Any(w =>
				w.ParentWord == null && w.Value.ToString().Trim().ToLower() == model.Value.Trim().ToLower()))
			{
				throw new BadRequestException($"Word with the {model.Value} word exists");
			}

			var parentWord = await AddAsync(categories, model);

			await AddChildrenWords(categories, parentWord, model.TranslatedWords);

			try
			{
				await _flashcardDbContext.SaveChangesAsync();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		/// <summary>
		///     Updates the word asynchronous.
		/// </summary>
		/// <param name="model">The model.</param>
		/// <returns>
		///     return <see cref="T:System.Threading.Tasks.Task" />
		/// </returns>
		/// <exception cref="NotImplementedException"></exception>
		public async Task UpdateAsync(WordModel model)
		{
			using (var transaction = _flashcardDbContext.Database.BeginTransaction())
			{
				try
				{
					if (model.Id <= 0)
					{
						throw new BadRequestException("Word identifier is required");
					}

					var word = await _flashcardDbContext.Words
						.Include(w => w.LanguageType)
						.Include(w => w.TranslateChildrenWords)
						.Include(w => w.ParentWord)
						.FirstOrDefaultAsync(w => w.Id == model.Id);

					if (word == null)
					{
						throw new NotFoundException("Word item not found");
					}

					if (_flashcardDbContext.Words.Any(
						w => w.ParentWord == null && w.Id != model.Id
							&& w.Value.ToString().Trim().ToLower() == model.Value.ToString().Trim().ToLower()))
					{
						throw new BadRequestException("Word with the same original value already exists");
					}

					var shouldUpdateCategories = await MergeWordCategories(model.Categories, word);

					if (model.LanguageType.Tag.ToString() != word.LanguageType.Tag)
					{
						await ChangeLanguageTypeAsync(model.LanguageType.Tag.ToString(), word);
					}

					if (word.ParentWord == null)
					{
						await UpdateTranslatedWordsAsync(model.TranslatedWords, word, model.Categories, shouldUpdateCategories);
					}

					word.Value = model.Value;

					_flashcardDbContext.Words.Update(word);
					await _flashcardDbContext.SaveChangesAsync();
					transaction.Commit();
				}
				catch
				{
					transaction.Rollback();
					throw;
				}
			}
		}

		/// <summary>
		///     Deletes the word asynchronous.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>
		///     return <see cref="T:System.Threading.Tasks.Task" />
		/// </returns>
		/// <exception cref="NotImplementedException"></exception>
		public async Task DeleteAsync(int id)
		{
			using (var transaction = _flashcardDbContext.Database.BeginTransaction())
			{
				try
				{
					var wordToDelete = await _flashcardDbContext.Words
						.Include(w => w.TranslateChildrenWords)
						.FirstOrDefaultAsync(w => w.Id == id);

					if (wordToDelete == null)
					{
						throw new NotFoundException("Word not found");
					}

					if (wordToDelete.TranslateChildrenWords?.Count() > 0)
					{
						foreach (var translateChildrenWord in wordToDelete.TranslateChildrenWords)
						{
							_flashcardDbContext.Words.Remove(translateChildrenWord);
						}
					}

					_flashcardDbContext.Words.Remove(wordToDelete);

					await _flashcardDbContext.SaveChangesAsync();
					transaction.Commit();
				}
				catch
				{
					transaction.Rollback();
					throw;
				}
			}
		}

        /// <summary>
        /// Gets the random words.
        /// </summary>
        /// <param name="categoryId">The category identifier.</param>
        /// <param name="length">The length.</param>
        /// <returns></returns>
        /// <exception cref="NotFoundException">Category not found</exception>
        public async Task<IEnumerable<Word>> GetRandomWords(int categoryId, int length)
        {
            IEnumerable<Word> words;
            if (categoryId > 0)
            {
                if (await _flashcardDbContext.Categories.FirstOrDefaultAsync(c => c.Id == categoryId) == null)
                {
                    throw new NotFoundException("Category not found");
                }

                words = _flashcardDbContext.Words.IncludeExamTestJoins()
                    .Where(w => w.CategoriesWord.Any(c => c.CategoryId == categoryId));
            }
            else
            {
                words = _flashcardDbContext.Words.IncludeExamTestJoins();
            }

            if (words.Any())
            {
                words = words.Where(w =>
                    w.WordAnswerWords == null || w.WordAnswerWords.Any(wa =>
                        !wa.WordAnswer.IsValidAnswer && (wa.ExamTest.Created > DateTime.Now.AddMonths(-1) ||
                                                         wa.ExamTest.Updated > DateTime.Now.AddMonths(-1))));
            }

            if (words.Count() > length)
            {
                words = words.Take(length);
            }

            return words;
        }

		/// <summary>
		/// Merges the word categories.
		/// </summary>
		/// <param name="categories">The categories.</param>
		/// <param name="word">The word.</param>
		/// <returns></returns>
		/// <exception cref="NotFoundException"></exception>
		private async Task<bool> MergeWordCategories(CategoryModel[] categories, Word word)
		{
			categories.ThrowIfEmpty();

			var categoryAdded = new List<int>();

			List<CategoryWord> categoriesWord = _flashcardDbContext.CategoryWords.Where(cw => cw.WordId == word.Id)
				.ToList();

			IEnumerable<CategoryWord> categoriesToExclude =
				categoriesWord.Where(cw => categories.All(c => c.Id != cw.CategoryId));

			IEnumerable<int> categoriesIdsToInclude = categories
				.Where(c => categoriesWord.All(cw => c.Id != cw.CategoryId))
				.Select(c => c.Id);

			foreach (var categoryWord in categoriesToExclude)
			{
				_flashcardDbContext.CategoryWords.Remove(categoryWord);
			}

			foreach (var categoryId in categoriesIdsToInclude)
			{
				if (categoryAdded.Any(c => c == categoryId))
				{
					continue;
				}
				
				var category = await _flashcardDbContext.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);

				if (category == null)
				{
					throw new NotFoundException($"Could not found category with id {categoryId} for word {word.Value}");
				}

				await _flashcardDbContext.CategoryWords.AddAsync(new CategoryWord()
				{
					Category = category,
					Word = word
				});

				categoryAdded.Add(categoryId);
			}

			return (categoriesIdsToInclude.Count() + categoriesToExclude.Count()) > 0;
		}

		/// <summary>
		/// Gets the children words common asynchronous.
		/// </summary>
		/// <param name="word">The word.</param>
		/// <param name="modelTranslatedWords">The model translated words.</param>
		/// <returns></returns>
		private async Task<ICollection<Word>> GetChildrenWordsCommonAsync(Word word, TranslatedWord[] modelTranslatedWords)
		{
			var words = new List<Word>();

			var addedValues = new List<string>();

			if (modelTranslatedWords != null)
			{
				foreach (var modelTranslatedWord in modelTranslatedWords)
				{
					if (addedValues.Any(av => av.Trim().ToLower() == modelTranslatedWord.Value.Trim().ToLower()))
						continue;

					if (word.TranslateChildrenWords?.Any(t =>
						t.Value.Trim().ToLower() == modelTranslatedWord.Value.Trim().ToLower()) ?? false)
					{
						continue;
					}

					var w = new Word
					{
						LanguageType = await GetLanguageTypeAsync(modelTranslatedWord.LanguageType.Tag),
						ParentWord = word,
						Value = modelTranslatedWord.Value
					};

					words.Add(w);

					addedValues.Add(modelTranslatedWord.Value);
				}
			}

			return words;
		}

		/// <summary>
		/// Gets the language type asynchronous.
		/// </summary>
		/// <param name="languageTypeEnum">The language type enum.</param>
		/// <param name="wordName">Name of the word.</param>
		/// <returns>return <see cref="Task{LanguageType}"/></returns>
		private async Task<LanguageType> GetLanguageTypeAsync(LanguageTypeEnum languageTypeEnum, string wordName = "original word")
		{
			var languageType = await _flashcardDbContext.LanguageTypes.FirstOrDefaultAsync(l =>
				l.Tag.ToLower() == languageTypeEnum.ToString().ToLower());

			if (languageType == null)
				throw new NotFoundException($"Language type for {wordName} not found");

			return languageType;
		}

		/// <summary>
		/// Gets the type of the language.
		/// </summary>
		/// <param name="languageTypeEnum">The language type enum.</param>
		/// <param name="wordName">Name of the word.</param>
		/// <returns></returns>
		/// <exception cref="NotFoundException"></exception>
		private LanguageType GetLanguageType(LanguageTypeEnum languageTypeEnum, string wordName = "original word")
		{
			var languageType = _flashcardDbContext.LanguageTypes.FirstOrDefault(l =>
				l.Tag.ToLower() == languageTypeEnum.ToString().ToLower());

			if (languageType == null)
				throw new NotFoundException($"Language type for {wordName} not found");

			return languageType;
		}

		/// <summary>
		/// Adds the asynchronous.
		/// </summary>
		/// <param name="categories">The categories.</param>
		/// <param name="model">The model.</param>
		/// <returns></returns>
		private async Task<Word> AddAsync(IEnumerable<Category> categories, WordModel model)
		{
			return await _fakeService.ShouldUseFakeServiceAsync(async () =>
			{
				var result = await _flashcardDbContext.Words.AddAsync(await AddCategoriesAsync(new Word
				{
					LanguageType = await GetLanguageTypeAsync(model.LanguageType.Tag),
					Value = model.Value
				}, categories), CancellationToken.None);

				return result.Entity;
			}, async () => await _flashcardDbContext.Words.FirstOrDefaultAsync());
		}

		/// <summary>
		/// Adds the children words.
		/// </summary>
		/// <param name="categories">The categories.</param>
		/// <param name="parentWord">The parent word.</param>
		/// <param name="modelTranslatedWords">The model translated words.</param>
		/// <returns></returns>
		private async Task AddChildrenWords(IEnumerable<Category> categories, Word parentWord, TranslatedWord[] modelTranslatedWords)
		{
			if (modelTranslatedWords == null || modelTranslatedWords.Length == 0)
			{
				throw new BadRequestException("You must provide at least one translated word");
			}

			var savedWords = new List<string>();
			
			foreach (var childrenWord in modelTranslatedWords)
			{
				var value = childrenWord.Value;

				if (string.IsNullOrWhiteSpace(value) || savedWords.Any(v => v.Trim().ToLower() == value.Trim().ToLower()))
				{
					continue;
				}

				await AddChildrenWordAsync(categories, parentWord, childrenWord);

				savedWords.Add(value);
			}
		}

		/// <summary>
		/// Adds the children word asynchronous.
		/// </summary>
		/// <param name="categories">The categories.</param>
		/// <param name="parentWord">The parent word.</param>
		/// <param name="model">The model.</param>
		/// <returns></returns>
		private async Task AddChildrenWordAsync(IEnumerable<Category> categories, Word parentWord, TranslatedWord model)
		{
			await _flashcardDbContext.Words.AddAsync(await AddCategoriesAsync(new Word
			{
				ParentWord = parentWord,
				LanguageType = await GetLanguageTypeAsync(model.LanguageType.Tag),
				Value = model.Value
			}, categories), CancellationToken.None);
		}

		/// <summary>
		/// Adds the categories asynchronous.
		/// </summary>
		/// <param name="word">The word.</param>
		/// <param name="categories">The categories.</param>
		/// <returns></returns>
		private async Task<Word> AddCategoriesAsync(Word word, IEnumerable<Category> categories)
		{
			var categoriesWord = categories.Select(c =>
				new CategoryWord
				{
					Category = c,
					Word = word
				});

			foreach (var categoryWord in categoriesWord)
			{
				await _flashcardDbContext.CategoryWords.AddAsync(categoryWord);
			}

			word.CategoriesWord = new List<CategoryWord>(categoriesWord.ToList());

			return word;
		}

		/// <summary>
		/// Updates the translated words asynchronous.
		/// </summary>
		/// <param name="modelTranslatedWords">The model translated words.</param>
		/// <param name="word">The word.</param>
		/// <param name="categories">The categories.</param>
		/// <param name="shouldUpdateCategories">if set to <c>true</c> [should update categories].</param>
		/// <returns></returns>
		/// <exception cref="BadRequestException">Field translatedWords must have at least one element</exception>
		private async Task UpdateTranslatedWordsAsync(TranslatedWord[] modelTranslatedWords, Word word, CategoryModel[] categories, bool shouldUpdateCategories)
		{
			if (modelTranslatedWords?.Length == 0)
			{
				throw new BadRequestException("Field translatedWords must have at least one element");
			}

			IEnumerable<Word> wordsToRemove = word.TranslateChildrenWords?.Where(ch =>
				modelTranslatedWords.All(t => t.Value.ToLower().Trim() != ch.Value.ToLower().Trim()));

			IEnumerable<TranslatedWord> wordsToAdd =
				modelTranslatedWords.Where(t =>
					word.TranslateChildrenWords?.All(ch => ch.Value.ToLower().Trim() != t.Value.ToLower().Trim()) ??
					false);
			
			IEnumerable<Word> wordsToUpdateCategories = word.TranslateChildrenWords.Where(t => wordsToRemove.All(w => w.Id != t.Id));
			

			if (wordsToRemove != null)
			{
				foreach (var wordToRemove in wordsToRemove)
				{
					_flashcardDbContext.Words.Remove(wordToRemove);
				}
			}

			foreach (var wordToAdd in await GetChildrenWordsCommonAsync(word, wordsToAdd.ToArray()))
			{
				var result = _fakeService.ShouldUseFakeService(() => _flashcardDbContext.Words.Add(wordToAdd).Entity, 
					() => _flashcardDbContext.Words.FirstOrDefault());

				await MergeWordCategories(categories, result);
			}

			foreach (var wordToUpdateCategory in wordsToUpdateCategories)
			{
				await MergeWordCategories(categories, wordToUpdateCategory);
			}
		}

		/// <summary>
		/// Changes the language type asynchronous.
		/// </summary>
		/// <param name="languageTag">The language tag.</param>
		/// <param name="word">The word.</param>
		/// <returns></returns>
		/// <exception cref="BadRequestException">Language type not found</exception>
		/// <exception cref="NotFoundException">Language type not found</exception>
		private async Task ChangeLanguageTypeAsync(string languageTag, Word word)
		{
			if (string.IsNullOrWhiteSpace(languageTag))
			{
				throw new BadRequestException("Language type not found");
			}

			var languageType =
				await _flashcardDbContext.LanguageTypes.FirstOrDefaultAsync(l => l.Tag.ToLower() == languageTag.ToLower());

			if (languageType == null)
			{
				throw new NotFoundException("Language type not found");
			}

			word.LanguageType = languageType;
		}
	}
}