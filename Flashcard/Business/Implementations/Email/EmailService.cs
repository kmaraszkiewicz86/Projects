// <copyright file="EmailService.cs" username="Krzysztof Maraszkiewicz">
//   Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System.Threading.Tasks;
using DataModel.Models.Config;
using Interfaces.Email;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Implementations.Email
{
	/// <summary>
	///     EmailService class.
	/// </summary>
	/// <seealso cref="IEmailService" />
	public class EmailService : IEmailService
	{
		/// <summary>
		///     The email settings model
		/// </summary>
		private readonly EmailSettingsModel _emailSettingsModel;

		/// <summary>
		///     The send grid client
		/// </summary>
		private readonly ISendGridClient _sendGridClient;

		/// <summary>
		///     Initializes a new instance of the <see cref="EmailService" /> class.
		/// </summary>
		/// <param name="sendGridClient">The send grid client.</param>
		public EmailService(ISendGridClientWrapper sendGridClient)
		{
			_emailSettingsModel = sendGridClient.EmailSettingsModel;
			_sendGridClient = sendGridClient.SendGridClient;
		}

		/// <summary>
		///     Sends the asynchronous.
		/// </summary>
		/// <param name="sendGridMessage"><see cref="SendGridMessage" />.</param>
		/// <returns>
		///     <see cref="Task" />
		/// </returns>
		public async Task<string> SendAsync(SendGridMessage sendGridMessage)
		{
			sendGridMessage.From = new EmailAddress(_emailSettingsModel.Email);
			var response = await _sendGridClient.SendEmailAsync(sendGridMessage);

			return response.StatusCode.ToString();
		}	
	}
}