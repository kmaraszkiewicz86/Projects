// <copyright file="ModelStateException.cs" username="Krzysztof Maraszkiewicz">
//   Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System;

namespace Implementations.Exceptions
{
	/// <summary>
	///     ModelState exception
	/// </summary>
	/// <seealso cref="System.Exception" />
	public class ModelStateException : Exception
	{
		/// <summary>
		///     Initializes a new instance of the <see cref="ModelStateException" /> class.
		/// </summary>
		/// <param name="message">The message.</param>
		public ModelStateException(string message) : base(message)
		{
		}
	}
}