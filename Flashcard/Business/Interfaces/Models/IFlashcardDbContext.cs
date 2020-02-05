// <copyright file="IFlashcardDbContext.cs" username="Krzysztof Maraszkiewicz">
//    Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using DataModel.Models.DbModels;
using Microsoft.EntityFrameworkCore;

namespace Interfaces.Models
{
	/// <summary>
	///     FlashcardDbContext interface.
	/// </summary>
	public interface IFlashcardDbContext
	{
		/// <summary>
		///     Gets or sets the log entries table context.
		/// </summary>
		/// <value>
		///     The log entries table context.
		/// </value>
		DbSet<LogEntry> LogEntries { get; set; }

		/// <summary>
		///     Gets or sets the categories.
		/// </summary>
		/// <value>
		///     The categories.
		/// </value>
		DbSet<Category> Categories { get; set; }
	}
}