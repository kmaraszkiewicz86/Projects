// <copyright file="CategoryService.cs" username="Krzysztof Maraszkiewicz">
//    Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using Implementations.Exceptions;
using Implementations.Models;
using Interfaces.CategoryMgt;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel.Models.DbModels;

namespace Implementations.CategoryMgt
{
	/// <summary>
	///     Category service for manage Categories db table
	/// </summary>
	/// <seealso cref="ICategoryService" />
	public class CategoryService : ICategoryService
	{
		/// <summary>
		///     The flashcard database context
		/// </summary>
		private readonly FlashcardDbContext _flashcardDbContext;

		/// <summary>
		///     Initializes a new instance of the <see cref="CategoryService" /> class.
		/// </summary>
		/// <param name="flashcardDbContext">The flashcard database context.</param>
		public CategoryService(FlashcardDbContext flashcardDbContext)
		{
			_flashcardDbContext = flashcardDbContext;
		}

		/// <summary>
		/// Adds the specified category.
		/// </summary>
		/// <param name="categoryModel">The category.</param>
		/// <returns></returns>
		public async Task AddAsync(Category categoryModel)
		{
			var category = await _flashcardDbContext.Categories.FirstOrDefaultAsync(c =>
				c.Name.Trim().ToLower() == categoryModel.Name.Trim().ToLower());

			CheckCategoryName(category);
			
			await _flashcardDbContext.Categories.AddAsync(new Category
			{
				Name = categoryModel.Name
			});

			_flashcardDbContext.SaveChanges();
		}

		/// <summary>
		/// Updates the specified category by <paramref name="id" />.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="categoryModel">The category model.</param>
		/// <returns></returns>
		/// <exception cref="NotFoundException"></exception>
		/// <exception cref="BadRequestException"></exception>
		public async Task UpdateAsync(int id, Category categoryModel)
		{
			var category = await _flashcardDbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);

			if (category == null) throw new NotFoundException();

			CheckCategoryName(await _flashcardDbContext.Categories.FirstOrDefaultAsync(c =>
				c.Id != id && c.Name.Trim().ToLower() == categoryModel.Name.Trim().ToLower()));

			if (category.Name == categoryModel.Name)
				return;

			category.Name = categoryModel.Name;
			_flashcardDbContext.Categories.Update(category);

			_flashcardDbContext.SaveChanges();
		}

		/// <summary>
		///     Deletes the specified category by identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <exception cref="NotFoundException"></exception>
		public async Task DeleteAsync(int id)
		{
			var category = await _flashcardDbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);

			if (category == null) throw new NotFoundException();

			_flashcardDbContext.Categories.Remove(category);

			_flashcardDbContext.SaveChanges();
		}

		/// <summary>
		///     Gets all categories.
		/// </summary>
		/// <returns>
		///     <see cref="T:System.Collections.Generic.IEnumerable`1" />
		/// </returns>
		public IEnumerable<Category> GetAll()
		{
			return _flashcardDbContext.Categories;
		}

		/// <summary>
		/// Checks the name of the category.
		/// </summary>
		/// <param name="category">The category.</param>
		/// <exception cref="BadRequestException"></exception>
		private void CheckCategoryName(Category category)
		{
			if (category != null) throw new BadRequestException($"Category with {category.Name} name exists");
		}
	}
}