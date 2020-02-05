// <copyright file="RoleModel.cs" username="Krzysztof Maraszkiewicz">
//   Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace DataModel.Models.WebAPI
{
	/// <summary>
	///     Role model data.
	/// </summary>
	public class RoleModel
	{
		/// <summary>
		///     Gets or sets the name.
		/// </summary>
		/// <value>
		///     The name.
		/// </value>
		[Required(ErrorMessage = "Test {0}")]
		[StringLength(256, ErrorMessage = "Test2 {0}")]
		public string Name { get; set; }
	}
}