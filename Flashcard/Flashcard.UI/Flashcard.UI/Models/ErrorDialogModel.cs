// <copyright file="ErrorDialogModel.cs" username="Krzysztof Maraszkiewicz">
//    Copyright (c) 2019 Krzysztof Maraszkiewicz
// </copyright>

namespace Flashcard.UI.Models
{
	/// <summary>
	/// </summary>
	public class ErrorDialogModel
	{
		/// <summary>
		///     Gets or sets the identifier.
		/// </summary>
		/// <value>
		///     The identifier.
		/// </value>
		public string Id { get; set; }

		/// <summary>
		///     Initializes a new instance of the <see cref="ErrorDialogModel" /> class.
		/// </summary>
		/// <param name="id">The identifier.</param>
		public ErrorDialogModel(string id)
		{
			Id = id;
		}
	}
}