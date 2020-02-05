// <copyright file="ChangePasswordAfterResetModel.cs" username="Krzysztof Maraszkiewicz">
//   Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace DataModel.Models.WebAPI
{
	/// <summary>
	///     ChangePasswordAfterResetModel class.
	/// </summary>
	public class ChangePasswordAfterResetModel
	{
		/// <summary>
		///     Gets or sets the user identifier.
		/// </summary>
		/// <value>
		///     The user identifier.
		/// </value>
		[Required]
		public string UserId { get; set; }

		/// <summary>
		///     Gets or sets the token.
		/// </summary>
		/// <value>
		///     The token.
		/// </value>
		[Required]
		public string Token { get; set; }

		/// <summary>
		///     Gets or sets the new password.
		/// </summary>
		/// <value>
		///     The new password.
		/// </value>
		[Required]
		public string NewPassword { get; set; }
	}
}