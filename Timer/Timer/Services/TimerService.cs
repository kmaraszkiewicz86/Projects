// <copyright file="TimerService.cs" username="Krzysztof Maraszkiewicz">
//    Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System;
using System.Windows.Forms;
using Timer.Enums;
using Timer.EventHandlers;
using Timer.Helpers;
using static Timer.Models.TimerModel;

namespace Timer.Services
{
	/// <summary>
	///     Timer service class
	/// </summary>
	public class TimerService
	{
		/// <summary>
		/// Occurs when occurs error.
		/// </summary>
		public event EventHandler<MessegeEventArgs> OnErrorOccours;

		/// <summary>
		/// The start timer button
		/// </summary>
		private readonly Button _startTimerButton;

		/// <summary>
		/// The stop timer button
		/// </summary>
		private readonly Button _stopTimerButton;

		/// <summary>
		/// The reset timer button
		/// </summary>
		private readonly Button _resetTimerButton;

		/// <summary>
		/// The start timer period button
		/// </summary>
		private readonly Button _startTimerPeriodButton;

		/// <summary>
		/// The stop timer period button
		/// </summary>
		private readonly Button _stopTimerPeriodButton;

		/// <summary>
		/// The reset timer period button
		/// </summary>
		private readonly Button _resetTimerPeriodButton;

		/// <summary>
		/// The timer state
		/// </summary>
		private readonly Label _timerState;

		/// <summary>
		/// The timer period state
		/// </summary>
		private readonly Label _timerPeriodState;

		/// <summary>
		/// The timer label
		/// </summary>
		private readonly Label _timerLabel;

		/// <summary>
		/// The timer elapsed label
		/// </summary>
		private readonly Label _timerElapsedLabel;

		/// <summary>
		/// The timer
		/// </summary>
		private readonly System.Windows.Forms.Timer _timer;

		/// <summary>
		/// The timer before play sound timer
		/// </summary>
		private readonly System.Windows.Forms.Timer _timerBeforePlaySoundTimer;

		/// <summary>
		/// The first run
		/// </summary>
		private bool _firstRun = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="TimerService"/> class.
		/// </summary>
		/// <param name="startTimerButton">The start timer button.</param>
		/// <param name="stopTimerButton">The stop timer button.</param>
		/// <param name="resetTimerButton">The reset timer button.</param>
		/// <param name="startTimerPeriodButton">The start timer period button.</param>
		/// <param name="stopTimerPeriodButton">The stop timer period button.</param>
		/// <param name="resetTimerPeriodButton">The reset timer period button.</param>
		/// <param name="timerState">State of the timer.</param>
		/// <param name="timerPeriodState">State of the timer period.</param>
		/// <param name="timerLabel">The timer label.</param>
		/// <param name="timerElapsedLabel">The timer elapsed label.</param>
		/// <param name="timer">The timer.</param>
		/// <param name="timerBeforePlaySoundTimer">The timer before play sound timer.</param>
		public TimerService(Button startTimerButton, Button stopTimerButton, Button resetTimerButton,
			Button startTimerPeriodButton, Button stopTimerPeriodButton,
			Button resetTimerPeriodButton, Label timerState, Label timerPeriodState, Label timerLabel,
			Label timerElapsedLabel,
			System.Windows.Forms.Timer timer, System.Windows.Forms.Timer timerBeforePlaySoundTimer)
		{
			_startTimerButton = startTimerButton;
			_stopTimerButton = stopTimerButton;
			_resetTimerButton = resetTimerButton;
			_startTimerPeriodButton = startTimerPeriodButton;
			_stopTimerPeriodButton = stopTimerPeriodButton;
			_resetTimerPeriodButton = resetTimerPeriodButton;
			_timerState = timerState;
			_timerPeriodState = timerPeriodState;
			_timerLabel = timerLabel;
			_timerElapsedLabel = timerElapsedLabel;
			_timer = timer;
			_timerBeforePlaySoundTimer = timerBeforePlaySoundTimer;
		}

		/// <summary>
		/// Manages the timer buttons.
		/// </summary>
		/// <param name="timerType">Type of the timer.</param>
		/// <param name="timerActionType">Type of the timer action.</param>
		/// <exception cref="Exception">
		/// Invalid TimerType
		/// or
		/// Invalid TimerType
		/// or
		/// Invalid TimerType
		/// or
		/// Invalid timerType
		/// </exception>
		public void ManageTimerButtons(TimerType timerType, TimerActionType timerActionType)
		{
			try
			{
				switch (timerActionType)
				{
					case TimerActionType.Start:

						switch (timerType)
						{
							case TimerType.Timer:
								ToogleTimerActivity(timerType, true);
								ToogleTimerButtonActivity(false, timerType);
								break;

							case TimerType.TimerBeforePlaySound:
								ToogleTimerActivity(timerType, true);
								ToogleTimerButtonActivity(false, timerType);
								break;

							default:
								throw new Exception("Invalid TimerType");
						}

						break;

					case TimerActionType.Stop:

						switch (timerType)
						{
							case TimerType.Timer:
								ToogleTimerActivity(timerType, false);
								ToogleTimerButtonActivity(true, timerType);
								break;

							case TimerType.TimerBeforePlaySound:
								ToogleTimerActivity(timerType, false);
								ToogleTimerButtonActivity(true, timerType);
								break;

							default:
								throw new Exception("Invalid TimerType");
						}

						break;

					case TimerActionType.Reset:

						switch (timerType)
						{
							case TimerType.Timer:
								ToogleTimerButtonActivity(false, timerType, true);
								_timerLabel.Text = "00:00";
								ToogleTimerButtonActivity(true, timerType, true);
								break;

							case TimerType.TimerBeforePlaySound:
								ToogleTimerButtonActivity(false, timerType, true);
								_timerElapsedLabel.Text =
									$"{(TimePeriod < 10 || TimePeriod == 0 ? $"0{TimePeriod}" : TimePeriod.ToString())}:00";
								ToogleTimerButtonActivity(true, timerType, true);
								break;

							default:
								throw new Exception("Invalid TimerType");
						}

						break;

					default:
						throw new Exception("Invalid timerType");
				}
			}
			catch (Exception e)
			{
				ShowError(e.Message);
			}
		}

		/// <summary>
		/// Gets the type of the timer.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <returns></returns>
		/// <exception cref="Exception">
		/// Sender has invalid type
		/// or
		/// Sender tag has not valid type
		/// </exception>
		public TimerType GetTimerType(object sender)
		{
			try
			{
				var btn = (Button)sender;

				if (btn == null) throw new Exception("Sender has invalid type");

				if (!int.TryParse(btn.Tag.ToString(), out var value)) throw new Exception("Sender tag has not valid type");

				return (TimerType)value;
			}
			catch (Exception e)
			{
				ShowError(e.Message);
				return TimerType.None;
			}
		}

		/// <summary>
		/// Timers the tick.
		/// </summary>
		/// <exception cref="Exception"></exception>
		public void TimerTick()
		{
			try
			{
				var time = _timerLabel.GetTime();

				var minutes = int.Parse(time[0]);
				var seconds = int.Parse(time[1]) + 1;

				if (seconds >= 60)
				{
					seconds = 0;
					minutes += 1;
				}

				var hourString = minutes < 10 ? $"0{minutes}" : minutes.ToString();
				var minutesString = seconds < 10 ? $"0{seconds}" : seconds.ToString();

				_timerLabel.Text = $"{hourString}:{minutesString}";
			}
			catch (Exception e)
			{
				ShowError(e.Message);
			}
		}

		/// <summary>
		/// Timers the before play sound tick.
		/// </summary>
		/// <exception cref="Exception"></exception>
		public void TimerBeforePlaySoundTick()
		{
			try
			{
				var time = _timerElapsedLabel.GetTime();

				var minutes = int.Parse(time[0]);
				var seconds = int.Parse(time[1]) - 1;


				if (seconds <= 0 && minutes > 0)
				{
					seconds = 59;
					minutes -= 1;
				}
				else if (seconds <= 0 && minutes <= 0)
				{
					if (!_firstRun)
					{
						try
						{
							ManageTimerButtons(TimerType.TimerBeforePlaySound, TimerActionType.Stop);
							new AlarmForm().ShowDialog();
						}
						catch (Exception e)
						{
							ShowError(e.Message);
						}
						finally
						{
							ManageTimerButtons(TimerType.TimerBeforePlaySound, TimerActionType.Start);
						}
					}

					minutes = TimePeriod;
					seconds = 0;
					_firstRun = false;
				}

				var hourString = minutes < 10 ? $"0{minutes}" : minutes.ToString();
				var minutesString = seconds < 10 ? $"0{seconds}" : seconds.ToString();

				_timerElapsedLabel.Text = $"{hourString}:{minutesString}";
			}
			catch (Exception e)
			{
				ShowError(e.Message);
			}
		}

		/// <summary>
		/// Toogles the timer activity.
		/// </summary>
		/// <param name="timerType">Type of the timer.</param>
		/// <param name="state">if set to <c>true</c> [state].</param>
		private void ToogleTimerActivity(TimerType timerType, bool state)
		{
			try
			{
				switch (timerType)
				{
					case TimerType.Timer:
					{
						if (state)
							_timer.Start();
						else
							_timer.Stop();
					}
						break;

					case TimerType.TimerBeforePlaySound:
					{
						if (TimePeriod <= 0)
						{
							MessageBox.Show("Before start timer set time period in settings");
							return;
						}

						if (state)
							_timerBeforePlaySoundTimer.Start();
						else
							_timerBeforePlaySoundTimer.Stop();
					}
						break;
				}
			}
			catch (Exception e)
			{
				ShowError(e.Message);
			}
		}

		/// <summary>
		/// Toogles the timer button activity.
		/// </summary>
		/// <param name="state">if set to <c>true</c> [state].</param>
		/// <param name="timerType">Type of the timer.</param>
		/// <param name="resetState">if set to <c>true</c> [reset state].</param>
		/// <exception cref="Exception">Invalid timerType</exception>
		private void ToogleTimerButtonActivity(bool state, TimerType timerType, bool resetState = false)
		{
			try
			{
				switch (timerType)
				{
					case TimerType.Timer:

						if (resetState)
						{
							_startTimerButton.Enabled = _timerState.Tag.ToString() == "start" && state;
							_stopTimerButton.Enabled = _timerState.Tag.ToString() == "stop" && state;
							_resetTimerButton.Enabled = state;
						}
						else
						{
							_startTimerButton.Enabled = state;
							_stopTimerButton.Enabled = !state;

							_timerState.Tag = state ? "start" : "stop";
						}


						break;

					case TimerType.TimerBeforePlaySound:

						if (TimePeriod <= 0) return;

						if (resetState)
						{
							_startTimerPeriodButton.Enabled = _timerPeriodState.Tag.ToString() == "start" && state;
							_stopTimerPeriodButton.Enabled = _timerPeriodState.Tag.ToString() == "stop" && state;
							_resetTimerPeriodButton.Enabled = state;
						}
						else
						{
							_startTimerPeriodButton.Enabled = state;
							_stopTimerPeriodButton.Enabled = !state;

							_timerPeriodState.Tag = state ? "start" : "stop";
						}

						break;

					default:
						ShowError("Invalid timerType");
						break;
				}
			}
			catch (Exception e)
			{
				ShowError(e.Message);
			}
		}

		/// <summary>
		/// Shows the error.
		/// </summary>
		/// <param name="message">The message.</param>
		private void ShowError(string message)
		{
			OnErrorOccours?.Invoke(this, new MessegeEventArgs(message));
		}
	}
}