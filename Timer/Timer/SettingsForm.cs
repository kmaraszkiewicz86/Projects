// <copyright file="SettingsForm.cs" username="Krzysztof Maraszkiewicz">
//    Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System;
using System.Windows.Forms;
using static Timer.Models.TimerModel;

namespace Timer
{
	/// <summary>
	/// Timer form class.
	/// </summary>
	public partial class SettingsForm : Form
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SettingsForm"/> class.
		/// </summary>
		public SettingsForm()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Handles the Load event of the SettingsForm control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void SettingsForm_Load(object sender, EventArgs e)
		{
			timePeriodNumericUpDown.Value = TimePeriod > 0 ? TimePeriod : 1;
		}

		/// <summary>
		/// Handles the Click event of the cancelButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void cancelButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		/// <summary>
		/// Handles the Click event of the saveButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void saveButton_Click(object sender, EventArgs e)
		{
			if (timePeriodNumericUpDown.Value > 0) TimePeriod = (int) timePeriodNumericUpDown.Value;

			Close();
		}
	}
}