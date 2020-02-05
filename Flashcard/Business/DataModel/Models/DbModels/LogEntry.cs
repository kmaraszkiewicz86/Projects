// <copyright file="LogEntry.cs" username="Krzysztof Maraszkiewicz">
//   Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System;

namespace DataModel.Models.DbModels
{
	/// <summary>
	///     Represent LogEntry table in database
	/// </summary>
	public class LogEntry
	{
		/// <summary>
		///     Gets or sets the identifier.
		/// </summary>
		/// <value>
		///     The identifier.
		/// </value>
		public int Id { get; set; }

		/// <summary>
		///     Gets or sets the time stamp.
		/// </summary>
		/// <value>
		///     The time stamp.
		/// </value>
		public DateTime TimeStamp { get; set; }

		/// <summary>
		///     Gets or sets the message.
		/// </summary>
		/// <value>
		///     The message.
		/// </value>
		public string Message { get; set; }

		/// <summary>
		///     Gets or sets the level.
		/// </summary>
		/// <value>
		///     The level.
		/// </value>
		public string Level { get; set; }

		/// <summary>
		///     Gets or sets the logger.
		/// </summary>
		/// <value>
		///     The logger.
		/// </value>
		public string Logger { get; set; }
	}
}