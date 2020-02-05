// <copyright file="ReportItemsEventArgs.cs" username="Krzysztof Maraszkiewicz">
//   Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System;
using System.Collections.Generic;

namespace SystemTemperatureChecker.Models
{
	/// <summary>
	/// ReportItemsEventArgs event args class.
	/// </summary>
	/// <seealso cref="EventArgs" />
	public class ReportItemsEventArgs : EventArgs
	{
		/// <summary>
		/// Gets or sets the system data collections.
		/// </summary>
		/// <value>
		/// The system data collections.
		/// </value>
		public Dictionary<string, List<SystemDataItem>> SystemDataCollections { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="ReportItemsEventArgs"/> class.
		/// </summary>
		/// <param name="systemDataCollections">The system data collections.</param>
		public ReportItemsEventArgs(Dictionary<string, List<SystemDataItem>> systemDataCollections)
		{
			SystemDataCollections = systemDataCollections;
		}
	}
}