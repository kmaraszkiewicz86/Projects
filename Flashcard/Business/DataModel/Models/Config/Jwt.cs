// <copyright file="Jwt.cs" username="Krzysztof Maraszkiewicz">
//   Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

namespace DataModel.Models.Config
{
	/// <summary>
	///     Jwt settings from configuration file
	/// </summary>
	public class Jwt
	{
		/// <summary>
		///     Gets or sets the secret key.
		/// </summary>
		/// <value>
		///     The secret key.
		/// </value>
		public string Key { get; set; }

		/// <summary>
		///     Gets or sets the issuer.
		/// </summary>
		/// <value>
		///     The issuer.
		/// </value>
		public string Issuer { get; set; }
	}
}