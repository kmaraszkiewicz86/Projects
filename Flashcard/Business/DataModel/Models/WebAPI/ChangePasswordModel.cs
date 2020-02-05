// <copyright file="ChangePasswordModel.cs" username="Krzysztof Maraszkiewicz">
//   Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace DataModel.Models.WebAPI
{
	/// <summary>
	///     Data for reset password
	/// </summary>
	public class ChangePasswordModel
	{
		/// <summary>
		///     Gets or sets the email.
		/// </summary>
		/// <value>
		///     The email.
		/// </value>
		[Required]
		public string Id { get; set; }

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