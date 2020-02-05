// <copyright file="ChangeUserPasswordModel.cs" username="Krzysztof Maraszkiewicz">
//   Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace DataModel.Models.WebAPI
{
	/// <summary>
	///     Data for reset user password
	/// </summary>
	public class ChangeUserPasswordModel
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
		///     Gets or sets the current password.
		/// </summary>
		/// <value>
		///     The current password.
		/// </value>
		[Required]
		public string CurrentPassword { get; set; }

		/// <summary>
		///     Gets or sets the new password.
		/// </summary>
		/// <value>
		///     The new password.
		/// </value>
		[Required]
		public string NewPassword { get; set; }

		/// <summary>
		///     Gets or sets the re password.
		/// </summary>
		/// <value>
		///     The re password.
		/// </value>
		[Required]
		[Compare("NewPassword")]
		public string RePassword { get; set; }
	}
}