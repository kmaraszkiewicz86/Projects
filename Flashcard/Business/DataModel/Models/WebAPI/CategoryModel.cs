// <copyright file="CategoryModel.cs" username="Krzysztof Maraszkiewicz">
//    Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

namespace DataModel.Models.WebAPI
{
	/// <summary>
	///     Category Web API model
	/// </summary>
	public class CategoryModel
	{
		/// <summary>
		///     Gets or sets the identifier.
		/// </summary>
		/// <value>
		///     The identifier.
		/// </value>
		public int Id { get; set; }

		/// <summary>
		///     Gets or sets the name.
		/// </summary>
		/// <value>
		///     The name.
		/// </value>
		public string Name { get; set; }
	}
}