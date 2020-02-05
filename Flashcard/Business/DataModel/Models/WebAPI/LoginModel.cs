// <copyright file="LoginModel.cs" username="Krzysztof Maraszkiewicz">
//   Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System.ComponentModel.DataAnnotations;
using DataModel.Properties;

namespace DataModel.Models.WebAPI
{
	/// <summary>
	///     Login data model
	/// </summary>
	public class LoginModel
	{
		/// <summary>
		///     Gets or sets the username.
		/// </summary>
		/// <value>
		///     The username.
		/// </value>
		[Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
		public string Username { get; set; }

		/// <summary>
		///     Gets or sets the password.
		/// </summary>
		/// <value>
		///     The password.
		/// </value>
		[Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
		[StringLength(256, MinimumLength = 3, ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "MaxLength")]
		public string Password { get; set; }
	}
}