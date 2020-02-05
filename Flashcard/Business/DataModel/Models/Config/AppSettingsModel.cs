// <copyright file="AppSettingsModel.cs" username="Krzysztof Maraszkiewicz">
//   Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

namespace DataModel.Models.Config
{
	/// <summary>
	///     Settin data from configuration file
	/// </summary>
	public class AppSettingsModel
	{
		/// <summary>
		///     Gets or sets the JWT settings.
		/// </summary>
		/// <value>
		///     The JWT settings.
		/// </value>
		public Jwt Jwt { get; set; }
	}
}