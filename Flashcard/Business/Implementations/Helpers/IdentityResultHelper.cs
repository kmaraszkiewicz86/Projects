// <copyright file="IdentityResultHelper.cs" username="Krzysztof Maraszkiewicz">
//   Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using Implementations.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace Implementations.Helpers
{
	/// <summary>
	///     <see cref="IdentityResult" /> helper
	/// </summary>
	public static class IdentityResultHelper
	{
		/// <summary>
		///     Verifies the specified identity result.
		/// </summary>
		/// <param name="identityResult">The identity result.</param>
		/// <exception cref="IdentityResultException"></exception>
		public static void Verify(this IdentityResult identityResult)
		{
			if (!identityResult.Succeeded)
			{
				throw new IdentityResultException(identityResult);
			}
		}
	}
}