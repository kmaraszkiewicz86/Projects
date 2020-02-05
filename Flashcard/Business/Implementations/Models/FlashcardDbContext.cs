// <copyright file="FlashcardDbContext.cs" username="Krzysztof Maraszkiewicz">
//   Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using DataModel.Models.DbModels;
using Interfaces.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Implementations.Models
{
	/// <summary>
	///     Initliazes database context
	/// </summary>
	/// <seealso cref="IdentityDbContext{TUser}" />
	public class FlashcardDbContext : IdentityDbContext<User>, IFlashcardDbContext
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="FlashcardDbContext"/> class.
		/// </summary>
		public FlashcardDbContext()
		{
			
		}

		/// <summary>
		///     Initializes a new instance of <see cref="T:Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext" />.
		/// </summary>
		/// <param name="options">The options to be used by a <see cref="T:Microsoft.EntityFrameworkCore.DbContext" />.</param>
		public FlashcardDbContext(DbContextOptions options) : base(options)
		{
			
		}

		/// <summary>
		///     Gets or sets the log entries table context.
		/// </summary>
		/// <value>
		///     The log entries table context.
		/// </value>
		public virtual DbSet<LogEntry> LogEntries { get; set; }

		/// <summary>
		/// Gets or sets the categories.
		/// </summary>
		/// <value>
		/// The categories.
		/// </value>
		public virtual DbSet<Category> Categories { get; set; }

		/// <summary>
		/// Gets or sets the words.
		/// </summary>
		/// <value>
		/// The words.
		/// </value>
		public virtual DbSet<Word> Words { get; set; }

		/// <summary>
		/// Gets or sets the language types.
		/// </summary>
		/// <value>
		/// The language types.
		/// </value>
		public virtual DbSet<LanguageType> LanguageTypes { get; set; }

		/// <summary>
		/// Gets or sets the category words.
		/// </summary>
		/// <value>
		/// The category words.
		/// </value>
		public virtual DbSet<CategoryWord> CategoryWords { get; set; }

        /// <summary>
        /// Gets or sets the word answers.
        /// </summary>
        /// <value>
        /// The word answers.
        /// </value>
        public virtual DbSet<WordAnswer> WordAnswers { get; set; }

        /// <summary>
        /// Gets or sets the exam tests.
        /// </summary>
        /// <value>
        /// The exam tests.
        /// </value>
        public virtual DbSet<ExamTest> ExamTests { get; set; }

        /// <summary>
        /// Gets or sets the exam test words.
        /// </summary>
        /// <value>
        /// The exam test words.
        /// </value>
        public virtual DbSet<ExamTestWord> ExamTestWords { get; set; }

        /// <summary>
        /// Gets or sets the word answer words.
        /// </summary>
        /// <value>
        /// The word answer words.
        /// </value>
        public virtual DbSet<WordAnswerWord> WordAnswerWords { get; set; }
	}
}