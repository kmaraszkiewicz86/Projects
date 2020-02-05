// <copyright file="Word.cs" username="Krzysztof Maraszkiewicz">
//    Copyright (c) 2019 Krzysztof Maraszkiewicz
// </copyright>

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel.Models.DbModels
{
	/// <summary>
	///     Word data model
	/// </summary>
	public class Word
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
		[Column(TypeName = "text")]
		public string Value { get; set; }

		/// <summary>
		/// Gets or sets the category word.
		/// </summary>
		/// <value>
		/// The category word.
		/// </value>
		public ICollection<CategoryWord> CategoriesWord { get; set; }

		/// <summary>
		///     Gets or sets the translate words.
		/// </summary>
		/// <value>
		///     The translate words.
		/// </value>
		public ICollection<Word> TranslateChildrenWords { get; set; }

        /// <summary>
        /// Gets or sets the exam test words.
        /// </summary>
        /// <value>
        /// The exam test words.
        /// </value>
        public ICollection<ExamTestWord> ExamTestWords { get; set; }

        /// <summary>
        /// Gets or sets the word answer words.
        /// </summary>
        /// <value>
        /// The word answer words.
        /// </value>
        public ICollection<WordAnswerWord> WordAnswerWords { get; set; }

        /// <summary>
		/// Gets or sets the parent word identifier.
		/// </summary>
		/// <value>
		/// The parent word identifier.
		/// </value>
		public int? ParentWordId { get; set; }

		/// <summary>
		/// Gets or sets the parent word.
		/// </summary>
		/// <value>
		/// The parent word.
		/// </value>
		public Word ParentWord { get; set; }

		/// <summary>
		/// Gets or sets the language type identifier.
		/// </summary>
		/// <value>
		/// The language type identifier.
		/// </value>
		[Required]
		public int LanguageTypeId { get; set; }

		/// <summary>
		/// Gets or sets the type of the language.
		/// </summary>
		/// <value>
		/// The type of the language.
		/// </value>
		public LanguageType LanguageType { get; set; }
	}
}