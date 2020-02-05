// <copyright file="EmailSettingsModel.cs" username="Krzysztof Maraszkiewicz">
//   Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

namespace DataModel.Models.Config
{
	/// <summary>
	///     EmailSettingsModel class.
	/// </summary>
	public class EmailSettingsModel
	{
		/// <summary>
		///     Gets or sets the hostname.
		/// </summary>
		/// <value>
		///     The hostname.
		/// </value>
		public string Email { get; set; }

		/// <summary>
		///     Gets or sets the username.
		/// </summary>
		/// <value>
		///     The username.
		/// </value>
		public string ApiKey { get; set; }
	}
}