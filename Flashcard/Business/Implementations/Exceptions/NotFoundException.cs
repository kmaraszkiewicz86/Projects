// <copyright file="NotFoundException.cs" username="Krzysztof Maraszkiewicz">
//   Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System;

namespace Implementations.Exceptions
{
	/// <summary>
	///     Not found exception
	/// </summary>
	/// <seealso cref="Exception" />
	public class NotFoundException : Exception
	{
		/// <summary>
		///     Initializes a new instance of the <see cref="NotFoundException" /> class.
		/// </summary>
		public NotFoundException() : this(string.Empty)
		{
		}

		/// <summary>
		///     Initializes a new instance of the <see cref="NotFoundException" /> class.
		/// </summary>
		/// <param name="message">The message that describes the error.</param>
		public NotFoundException(string message) : base(message)
		{
		}
	}
}