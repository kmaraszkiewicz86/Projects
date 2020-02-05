// <copyright file="LanguageType.cs" username="Krzysztof Maraszkiewicz">
//    Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace DataModel.Models.DbModels
{
	/// <summary>
	///     LanguageType database model class.
	/// </summary>
	public class LanguageType
	{
		/// <summary>
		///     Gets or sets the identifier.
		/// </summary>
		/// <value>
		///     The identifier.
		/// </value>
		public int Id { get; set; }

		/// <summary>
		///     Gets or sets the tag.
		/// </summary>
		/// <value>
		///     The tag.
		/// </value>
		[Required]
        [MaxLength(10)]
		public string Tag { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
	}
}