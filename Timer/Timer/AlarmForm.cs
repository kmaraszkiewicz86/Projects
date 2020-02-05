// <copyright file="AlarmForm.cs" username="Krzysztof Maraszkiewicz">
//    Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System;
using System.Windows.Forms;
using Timer.EventHandlers;
using Timer.Services;

namespace Timer
{
	/// <summary>
	///     Alarm windows form
	/// </summary>
	/// <seealso cref="Form" />
	public partial class AlarmForm : Form
	{
		/// <summary>
		/// The alarm service
		/// </summary>
		private AlarmService _alarmService;

		/// <summary>
		///     Initializes a new instance of the <see cref="AlarmForm" /> class.
		/// </summary>
		public AlarmForm()
		{
			InitializeComponent();
		}

		/// <summary>
		///     Handles the Click event of the okButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
		private void okButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		/// <summary>
		/// Handles the Load event of the AlarmForm control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void AlarmForm_Load(object sender, EventArgs e)
		{
			_alarmService = new AlarmService();
			_alarmService.OnErrorOccours += _alarmService_OnErrorOccours;

			_alarmService.StartPlaySound();
		}

		/// <summary>
		/// Handles the OnErrorOccours event of the _alarmService control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="MessegeEventArgs"/> instance containing the event data.</param>
		private void _alarmService_OnErrorOccours(object sender, MessegeEventArgs e)
		{
			MessageBox.Show(e.Message);
		}

		/// <summary>
		/// Handles the FormClosing event of the AlarmForm control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
		private void AlarmForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			_alarmService.Dispose();
		}
	}
}