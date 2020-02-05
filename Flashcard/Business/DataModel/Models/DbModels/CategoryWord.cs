// <copyright file="CategoryWord.cs" username="Krzysztof Maraszkiewicz">
//    Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace DataModel.Models.DbModels
{
	/// <summary>
	/// CategoryWord database model
	/// </summary>
	public class CategoryWord
	{
		/// <summary>
		///     Gets or sets the identifier.
		/// </summary>
		/// <value>
		///     The identifier.
		/// </value>
		public int Id { get; set; }

		/// <summary>
		///     Gets or sets the category identifier.
		/// </summary>
		/// <value>
		///     The category identifier.
		/// </value>
		[Required]
		public int CategoryId { get; set; }

		/// <summary>
		///     Gets or sets the category.
		/// </summary>
		/// <value>
		///     The category.
		/// </value>
		public Category Category { get; set; }

		/// <summary>
		///     Gets or sets the word identifier.
		/// </summary>
		/// <value>
		///     The word identifier.
		/// </value>
		[Required]
		public int WordId { get; set; }

		/// <summary>
		///     Gets or sets the word.
		/// </summary>
		/// <value>
		///     The word.
		/// </value>
		public Word Word { get; set; }
	}
}