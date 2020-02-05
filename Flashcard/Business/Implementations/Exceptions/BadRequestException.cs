// <copyright file="BadRequestException.cs" username="Krzysztof Maraszkiewicz">
//   Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System;

namespace Implementations.Exceptions
{
	/// <summary>
	///     Bad Request Exception
	/// </summary>
	/// <seealso cref="Exception" />
	public class BadRequestException : Exception
	{
		/// <summary>
		///     Initializes a new instance of the <see cref="NotFoundException" /> class.
		/// </summary>
		public BadRequestException() : this(string.Empty)
		{
		}

		/// <summary>
		///     Initializes a new instance of the <see cref="NotFoundException" /> class.
		/// </summary>
		/// <param name="message">The message that describes the error.</param>
		public BadRequestException(string message) : base(message)
		{
		}
	}
}