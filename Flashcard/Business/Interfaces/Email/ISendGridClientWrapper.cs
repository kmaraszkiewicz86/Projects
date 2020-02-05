// <copyright file="ISendGridClientWrapper.cs" username="Krzysztof Maraszkiewicz">
//   Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using DataModel.Models.Config;
using SendGrid;

namespace Interfaces.Email
{
	/// <summary>
	///     ISendGridClientWrapper interface.
	/// </summary>
	public interface ISendGridClientWrapper
	{
		/// <summary>
		///     Gets the send grid client.
		/// </summary>
		/// <value>
		///     The send grid client.
		/// </value>
		ISendGridClient SendGridClient { get; }

		/// <summary>
		///     Gets the email settings model.
		/// </summary>
		/// <value>
		///     The email settings model.
		/// </value>
		EmailSettingsModel EmailSettingsModel { get; }
	}
}