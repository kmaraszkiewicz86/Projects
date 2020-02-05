// <copyright file="IdentityResultException.cs" username="Krzysztof Maraszkiewicz">
//   Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System;
using Microsoft.AspNetCore.Identity;

namespace Implementations.Exceptions
{
	/// <summary>
	///     Identity result exception
	/// </summary>
	/// <seealso cref="System.Exception" />
	public class IdentityResultException : Exception
	{
		/// <summary>
		///     Initializes a new instance of the <see cref="IdentityResultException" /> class.
		/// </summary>
		/// <param name="identityResult">The identity result.</param>
		public IdentityResultException(IdentityResult identityResult)
		{
			IdentityResult = identityResult;
		}

		/// <summary>
		///     Gets or sets the identity result.
		/// </summary>
		/// <value>
		///     The identity result.
		/// </value>
		public IdentityResult IdentityResult { get; set; }
	}
}