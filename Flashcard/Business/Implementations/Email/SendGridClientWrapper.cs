// <copyright file="SendGridClientWrapper.cs" username="Krzysztof Maraszkiewicz">
//   Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using DataModel.Models.Config;
using Interfaces.Email;
using Microsoft.Extensions.Options;
using SendGrid;

namespace Implementations.Email
{
	/// <summary>
	/// </summary>
	/// <seealso cref="ISendGridClientWrapper" />
	public class SendGridClientWrapper : ISendGridClientWrapper
	{
		/// <summary>
		///     Gets the send grid client.
		/// </summary>
		/// <value>
		///     The send grid client.
		/// </value>
		public ISendGridClient SendGridClient { get; }

		/// <summary>
		///     Gets the email settings model.
		/// </summary>
		/// <value>
		///     The email settings model.
		/// </value>
		public EmailSettingsModel EmailSettingsModel { get; }

		/// <summary>
		///     Initializes a new instance of the <see cref="SendGridClientWrapper" /> class.
		/// </summary>
		/// <param name="emailSettingsModel">The email settings model.</param>
		public SendGridClientWrapper(IOptions<EmailSettingsModel> emailSettingsModel)
		{
			EmailSettingsModel = emailSettingsModel.Value;
			SendGridClient = new SendGridClient(EmailSettingsModel.ApiKey);
		}
	}
}