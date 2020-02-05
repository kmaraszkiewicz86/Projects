// <copyright file="WordModel.cs" username="Krzysztof Maraszkiewicz">
//    Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System.ComponentModel.DataAnnotations;
using DataModel.Models.DbModels;

namespace DataModel.Models.WebAPI
{
	/// <summary>
	///     WordModel database model class.
	/// </summary>
	public class WordModel
	{
		/// <summary>
		///     Gets or sets the identifier.
		/// </summary>
		/// <value>
		///     The identifier.
		/// </value>
		public int Id { get; set; }

		/// <summary>
		/// Gets or sets the categories.
		/// </summary>
		/// <value>
		/// The categories.
		/// </value>
		public virtual CategoryModel[] Categories { get; set; }

		/// <summary>
		/// Gets or sets the value.
		/// </summary>
		/// <value>
		/// The value.
		/// </value>
		[Required]
		public string Value { get; set; }

		/// <summary>
		///     Gets or sets the original language.
		/// </summary>
		/// <value>
		///     The original language.
		/// </value>
		public virtual LanguageTypeModel LanguageType { get; set; }

		/// <summary>
		///     Gets or sets the translated words.
		/// </summary>
		/// <value>
		///     The translated words.
		/// </value>
		public TranslatedWord[] TranslatedWords { get; set; }
	}
}