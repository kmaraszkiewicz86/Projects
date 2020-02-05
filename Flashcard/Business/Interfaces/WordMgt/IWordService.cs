// <copyright file="IWordService.cs" username="Krzysztof Maraszkiewicz">
//    Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel.Enums;
using DataModel.Models.DbModels;
using DataModel.Models.WebAPI;

namespace Interfaces.WordMgt
{
	/// <summary>
	///     IWordService interface.
	/// </summary>
	public interface IWordService
	{
		/// <summary>
		/// Gets all.
		/// </summary>
		/// <param name="type">The type of <see cref="WordItemsType"/> enum.</param>
		/// return <see cref="IEnumerable{WordModel}" />
		IEnumerable<WordModel> GetAll(WordItemsType type);

		/// <summary>
		///     Adds the word asynchronous.
		/// </summary>
		/// <param name="model">The model.</param>
		/// <returns>return <see cref="Task" /></returns>
		Task AddAsync(WordModel model);

		/// <summary>
		///     Deletes the word asynchronous.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>return <see cref="Task" /></returns>
		Task DeleteAsync(int id);

		/// <summary>
		///     Updates the word asynchronous.
		/// </summary>
		/// <param name="model">The model.</param>
		/// <returns>return <see cref="Task" /></returns>
		Task UpdateAsync(WordModel model);

        /// <summary>
        /// Gets the random words.
        /// </summary>
        /// <param name="categoryId">The category identifier.</param>
        /// <param name="length">The length.</param>
        /// <returns></returns>
        Task<IEnumerable<Word>> GetRandomWords(int categoryId, int length);
    }
}