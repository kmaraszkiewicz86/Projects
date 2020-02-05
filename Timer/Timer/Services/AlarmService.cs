// <copyright file="AlarmService.cs" username="Krzysztof Maraszkiewicz">
//    Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System;
using System.Media;
using Timer.EventHandlers;

namespace Timer.Services
{
	public class AlarmService : IDisposable
	{
		/// <summary>
		///     Occurs when on error occours.
		/// </summary>
		public event EventHandler<MessegeEventArgs> OnErrorOccours;

		/// <summary>
		///     The player
		/// </summary>
		private SoundPlayer _player;

		/// <summary>
		///     Starts the play sound.
		/// </summary>
		public void StartPlaySound()
		{
			try
			{
				_player = new SoundPlayer(@".\Sounds\alarm.wav");
				_player.Play();
			}
			catch (Exception exception)
			{
				OnException(exception.Message);
			}
		}

		/// <summary>
		///     Called when exception occours.
		/// </summary>
		/// <param name="message">The message.</param>
		private void OnException(string message)
		{
			OnErrorOccours?.Invoke(this, new MessegeEventArgs(message));
		}

		/// <summary>
		///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			_player?.Stop();
			_player?.Dispose();
		}
	}
}