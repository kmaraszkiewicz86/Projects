// <copyright file="ICategoryService.cs" username="Krzysztof Maraszkiewicz">
//    Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel.Models.DbModels;

namespace Interfaces.CategoryMgt
{
	/// <summary>
	/// Category service for manage Categories db table
	/// </summary>
	public interface ICategoryService
	{
		/// <summary>
		/// Adds the specified category.
		/// </summary>
		/// <param name="categoryModel">The category.</param>
		Task AddAsync(Category categoryModel);

		/// <summary>
		/// Updates the specified category by <paramref name="id"/>.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="categoryModel">The category model.</param>
		/// <returns></returns>
		Task UpdateAsync(int id, Category categoryModel);

		/// <summary>
		/// Deletes the specified category by identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		Task DeleteAsync(int id);

		/// <summary>
		/// Gets all categories.
		/// </summary>
		/// <returns><see cref="IEnumerable{Category}"/></returns>
		IEnumerable<Category> GetAll();
	}
}