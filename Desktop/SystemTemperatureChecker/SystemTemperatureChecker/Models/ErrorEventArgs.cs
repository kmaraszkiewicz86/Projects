// <copyright file="ErrorEventArgs.cs" username="Krzysztof Maraszkiewicz">
//   Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System;

namespace SystemTemperatureChecker.Models
{
	/// <summary>
	/// ErrorEventArgs event args class.
	/// </summary>
	/// <seealso cref="EventArgs" />
	public class ErrorEventArgs : EventArgs
	{
		/// <summary>
		/// Gets or sets the system data collections.
		/// </summary>
		/// <value>
		/// The system data collections.
		/// </value>
		public string ErrorMessage { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="ErrorEventArgs"/> class.
		/// </summary>
		/// <param name="errorMessage">The error message.</param>
		public ErrorEventArgs(string errorMessage)
		{
			ErrorMessage = errorMessage;
		}
	}
}