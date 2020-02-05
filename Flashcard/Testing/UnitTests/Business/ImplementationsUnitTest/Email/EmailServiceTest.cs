// <copyright file="EmailServiceTest.cs" username="Krzysztof Maraszkiewicz">
//   Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System.Net;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Implementations.Email;
using Interfaces.Email;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SendGrid;
using SendGrid.Helpers.Mail;
using static ImplementationsUnitTest.Helpers.SettingsModelMockHelper;

namespace ImplementationsUnitTest.Email
{
	[TestClass]
	public class EmailServiceTest
	{
		/// <summary>
		/// The email service
		/// </summary>
		private readonly EmailService _emailService;

		/// <summary>
		///     The send grid client
		/// </summary>
		private readonly Mock<ISendGridClientWrapper> _sendGridClientWrapperMock;

		/// <summary>
		///     The send grid client mock
		/// </summary>
		private readonly Mock<ISendGridClient> _sendGridClientMock;

		/// <summary>
		/// Gets the send grid message.
		/// </summary>
		/// <value>
		/// The send grid message.
		/// </value>
		private static SendGridMessage SendGridMessage
		{
			get
			{
				var sendGridMessage = new SendGridMessage
				{
					Subject = "Test subject",
					PlainTextContent = "Test messsage"
				};

				sendGridMessage.AddTo(new EmailAddress("test@test.pl"));

				return sendGridMessage;
			}
		}

		/// <summary>
		///     Initializes a new instance of the <see cref="EmailServiceTest" /> class.
		/// </summary>
		public EmailServiceTest()
		{
			_sendGridClientWrapperMock = new Mock<ISendGridClientWrapper>();
			_sendGridClientMock = new Mock<ISendGridClient>();

			_sendGridClientWrapperMock.Setup(s => s.EmailSettingsModel).Returns(EmailSettingsModel);
			_sendGridClientWrapperMock.Setup(s => s.SendGridClient).Returns(_sendGridClientMock.Object);

			_emailService = new EmailService(_sendGridClientWrapperMock.Object);
		}

		/// <summary>
		/// Sends the test.
		/// </summary>
		[TestMethod]
		public void SendTest()
		{
			SendCommon(HttpStatusCode.Accepted);
		}

		/// <summary>
		/// Test send after failed send.
		/// </summary>
		[TestMethod]
		public void FailedSendTest()
		{
			SendCommon(HttpStatusCode.Forbidden);
		}

		/// <summary>
		/// Sends the common.
		/// </summary>
		/// <param name="statusCode">The status code.</param>
		private void SendCommon(HttpStatusCode statusCode)
		{
			_sendGridClientMock.Setup(s => s.SendEmailAsync(It.IsAny<SendGridMessage>(), It.IsAny<CancellationToken>()))
				.Returns(GetResponseTask(statusCode));

			var result = _emailService.SendAsync(SendGridMessage);
			result.Wait();

			result.Result.Should().Be(statusCode.ToString());
		}

		/// <summary>
		/// Gets the response task.
		/// </summary>
		/// <param name="statusCode">The status code.</param>
		/// <returns></returns>
		private static Task<Response> GetResponseTask(HttpStatusCode statusCode)
		{
			return Task.FromResult(new Response(statusCode, null, null));
		}
	}
}