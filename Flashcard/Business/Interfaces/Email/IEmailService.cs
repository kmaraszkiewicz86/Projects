// <copyright file="IEmailService.cs" username="Krzysztof Maraszkiewicz">
//   Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System.Threading.Tasks;
using SendGrid.Helpers.Mail;

namespace Interfaces.Email
{
	/// <summary>
	///     IEmailService interface.
	/// </summary>
	public interface IEmailService
	{
		/// <summary>
		///     Sends the asynchronous.
		/// </summary>
		/// <param name="sendGridMessage"><see cref="SendGridMessage" />.</param>
		/// <returns>
		///     <see cref="Task" />
		/// </returns>
		Task<string> SendAsync(SendGridMessage sendGridMessage);
	}
}