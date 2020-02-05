// <copyright file="TranslatedWord.cs" username="Krzysztof Maraszkiewicz">
//    Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace DataModel.Models.WebAPI
{
	/// <summary>
	///     TranslatedWord web api model class.
	/// </summary>
	public class TranslatedWord
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>
		/// The identifier.
		/// </value>
		public int Id { get; set; }

		/// <summary>
		///     Gets or sets the type of the language.
		/// </summary>
		/// <value>
		///     The type of the language.
		/// </value>
		[Required]
		public LanguageTypeModel LanguageType { get; set; }

		/// <summary>
		///     Gets or sets the value.
		/// </summary>
		/// <value>
		///     The value.
		/// </value>
		[Required]
		public string Value { get; set; }
	}
}