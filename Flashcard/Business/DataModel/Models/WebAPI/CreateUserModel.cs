// <copyright file="CreateUserModel.cs" username="Krzysztof Maraszkiewicz">
//   Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System.ComponentModel.DataAnnotations;
using DataModel.Properties;

namespace DataModel.Models.WebAPI
{
	/// <summary>
	///     Model to create user
	/// </summary>
	public class CreateUserModel
	{
		/// <summary>
		///     Gets or sets the name.
		/// </summary>
		/// <value>
		///     The name.
		/// </value>
		[Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
		public string Name { get; set; }

		/// <summary>
		///     Gets or sets the email.
		/// </summary>
		/// <value>
		///     The email.
		/// </value>
		[Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
		public string Email { get; set; }

		/// <summary>
		///     Gets or sets the password.
		/// </summary>
		/// <value>
		///     The password.
		/// </value>
		[Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
		public string Password { get; set; }
	}
}