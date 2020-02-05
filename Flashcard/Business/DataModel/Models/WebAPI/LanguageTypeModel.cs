// <copyright file="LanguageTypeModel.cs" username="Krzysztof Maraszkiewicz">
//    Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System.ComponentModel.DataAnnotations;
using DataModel.Enums;

namespace DataModel.Models.WebAPI
{
	/// <summary>
	///     LanguageTypeModel class.
	/// </summary>
	public class LanguageTypeModel
	{
		/// <summary>
		///     Gets or sets the type of the language.
		/// </summary>
		/// <value>
		///     The type of the language.
		/// </value>
		[Required]
		public LanguageTypeEnum Tag { get; set; }

		/// <summary>
		///     Gets or sets the name of the language.
		/// </summary>
		/// <value>
		///     The name of the language.
		/// </value>
		public string Name { get; set; }
	}
}