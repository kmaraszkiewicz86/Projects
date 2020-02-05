// <copyright file="OnMessageShownEventArgs.cs" username="Krzysztof Maraszkiewicz">
//    Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System;

namespace Timer.EventHandlers
{
	/// <summary>
	/// </summary>
	/// <seealso cref="System.EventArgs" />
	public class MessegeEventArgs : EventArgs
	{
		/// <summary>
		///     Gets or sets the message.
		/// </summary>
		/// <value>
		///     The message.
		/// </value>
		public string Message { get; set; }

		/// <summary>
		///     Initializes a new instance of the <see cref="MessegeEventArgs" /> class.
		/// </summary>
		/// <param name="message">The message.</param>
		public MessegeEventArgs(string message)
		{
			Message = message;
		}
	}
}