// <copyright file="Category.cs" username="Krzysztof Maraszkiewicz">
//    Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace DataModel.Models.DbModels
{
	/// <summary>
	///     Data model from Categories db table
	/// </summary>
	public class Category
	{
		/// <summary>
		///     Gets or sets the identifier.
		/// </summary>
		/// <value>
		///     The identifier.
		/// </value>
		public int Id { get; set; }

		/// <summary>
		///     Gets or sets the name.
		/// </summary>
		/// <value>
		///     The name.
		/// </value>
		[Required]
		[MinLength(3)]
		[MaxLength(150)]
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the category word.
		/// </summary>
		/// <value>
		/// The category word.
		/// </value>
		[JsonIgnore]
		public ICollection<CategoryWord> CategoriesWord { get; set; }
	}
}