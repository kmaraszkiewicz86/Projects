// <copyright file="ResetPasswordModel.cs" username="Krzysztof Maraszkiewicz">
//   Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace DataModel.Models.WebAPI
{
	/// <summary>
	///     Data for resetting password
	/// </summary>
	public class ResetPasswordModel
	{
		/// <summary>
		///     Gets or sets the email.
		/// </summary>
		/// <value>
		///     The email.
		/// </value>
		[Required]
		public string Email { get; set; }
	}
}