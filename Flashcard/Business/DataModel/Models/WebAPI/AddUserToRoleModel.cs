// <copyright file="AddUserToRoleModel.cs" username="Krzysztof Maraszkiewicz">
//   Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace DataModel.Models.WebAPI
{
	/// <summary>
	///     Add user to role model data
	/// </summary>
	public class AddUserToRoleModel
	{
		/// <summary>
		///     Gets or sets the username.
		/// </summary>
		/// <value>
		///     The username.
		/// </value>
		[Required]
		public string Username { get; set; }

		/// <summary>
		///     Gets or sets the name of the role.
		/// </summary>
		/// <value>
		///     The name of the role.
		/// </value>
		[Required]
		public string RoleName { get; set; }
	}
}