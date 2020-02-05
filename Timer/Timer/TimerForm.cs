// <copyright file="Form1.cs" username="Krzysztof Maraszkiewicz">
//    Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System;
using System.Windows.Forms;
using Timer.Enums;
using Timer.EventHandlers;
using Timer.Services;
using static Timer.Models.TimerModel;

namespace Timer
{
	/// <summary>
	/// Timer main form window
	/// </summary>
	/// <seealso cref="System.Windows.Forms.Form" />
	public partial class TimerForm : Form
	{
		/// <summary>
		/// The timer service
		/// </summary>
		private TimerService _timerService;

		/// <summary>
		/// Initializes a new instance of the <see cref="TimerForm"/> class.
		/// </summary>
		public TimerForm()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Handles the Load event of the Form1 control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void Form1_Load(object sender, EventArgs e)
		{
			_timerService = new TimerService(startTimerButton, stopTimerButton, resetTimerButton, startTimerPeriodButton, stopTimerPeriodButton,
				resetTimerPeriodButton, timerState, timerPeriodState, timerLabel, timerElapsedLabel, timer, timerBeforePlaySoundTimer);

			_timerService.OnErrorOccours += _timerService_OnErrorOccours;
		}

		/// <summary>
		/// Handles the OnErrorOccours event of the _timerService control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="MessegeEventArgs"/> instance containing the event data.</param>
		private void _timerService_OnErrorOccours(object sender, MessegeEventArgs e)
		{
			MessageBox.Show(e.Message);
		}

		/// <summary>
		/// Handles the Click event of the settingsToolStripMenuItem control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new SettingsForm().ShowDialog();
		}

		/// <summary>
		/// Handles the Click event of the startTimerButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void startTimerButton_Click(object sender, EventArgs e)
		{
			var timerType = _timerService.GetTimerType(sender);
			_timerService.ManageTimerButtons(timerType, TimerActionType.Start);

			if (timerType == TimerType.TimerBeforePlaySound && TimePeriod > 0)
			{
				_timerService.ManageTimerButtons(TimerType.Timer, TimerActionType.Start);
			}
		}

		/// <summary>
		/// Handles the Click event of the stopTimerButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void stopTimerButton_Click(object sender, EventArgs e)
		{
			var timerType = _timerService.GetTimerType(sender);

			_timerService.ManageTimerButtons(timerType, TimerActionType.Stop);

			if (timerType == TimerType.TimerBeforePlaySound && TimePeriod > 0)
			{
				_timerService.ManageTimerButtons(TimerType.Timer, TimerActionType.Stop);
			}
		}

		/// <summary>
		/// Handles the Click event of the resetTimerButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void resetTimerButton_Click(object sender, EventArgs e)
		{
			var tag = Convert.ToInt32(((Button) sender).Tag);
			_timerService.ManageTimerButtons((TimerType) tag, TimerActionType.Reset);
		}

		/// <summary>
		/// Handles the Tick event of the timer control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void timer_Tick(object sender, EventArgs e)
		{
			_timerService.TimerTick();
		}

		/// <summary>
		/// Handles the Tick event of the timerBeforePlaySound control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void timerBeforePlaySound_Tick(object sender, EventArgs e)
		{
			_timerService.TimerBeforePlaySoundTick();
		}
	}
}