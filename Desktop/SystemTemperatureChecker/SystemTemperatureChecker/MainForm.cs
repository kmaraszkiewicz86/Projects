// <copyright file="MainForm.cs" username="Krzysztof Maraszkiewicz">
//   Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SystemTemperatureChecker.Core;
using SystemTemperatureChecker.Models;

namespace SystemTemperatureChecker
{
	/// <summary>
	/// MainForm from class.
	/// </summary>
	/// <seealso cref="Form" />
	public partial class MainForm : Form
	{
		/// <summary>
		/// The system information
		/// </summary>
		private SystemInfo _systemInfo;

		/// <summary>
		/// Initializes a new instance of the <see cref="MainForm"/> class.
		/// </summary>
		public MainForm()
		{
			InitializeComponent();
			_systemInfo = new SystemInfo();
			_systemInfo.ReportItemsEventHandler += _systemInfo_ReportItemsEventHandler;
			_systemInfo.ErrorEventArgsEventHandler += _systemInfo_ErrorEventArgsEventHandler;
			updateSystemTimer.Start();
			timeChangeTimer.Start();
			runTimeTimer.Start();
			timeToUpdateToolStripStatusLabel.Text = (updateSystemTimer.Interval / 1000).ToString();
			_systemInfo.GetSystemTemperatureInformation();
		}

		/// <summary>
		/// Handles the ErrorEventArgsEventHandler event of the _systemInfo control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="ErrorEventArgs"/> instance containing the event data.</param>
		/// <exception cref="NotImplementedException"></exception>
		private void _systemInfo_ErrorEventArgsEventHandler(object sender, ErrorEventArgs e)
		{
			if (InvokeRequired)
			{
				Invoke(new Action<ErrorEventArgs>(ShowError), e);
			}
			else
			{
				ShowError(e);
			}
		}

		private void ShowError(ErrorEventArgs e)
		{
			MessageBox.Show(e.ErrorMessage, "Error");
		}

		/// <summary>
		/// Handles the ReportItemsEventHandler event of the _systemInfo control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="ReportItemsEventArgs"/> instance containing the event data.</param>
		private void _systemInfo_ReportItemsEventHandler(object sender, ReportItemsEventArgs e)
		{
			if (InvokeRequired)
			{
				Invoke(new Action<object, ReportItemsEventArgs>(FillItemsTreeView), sender, e);
			}
			else
			{
				FillItemsTreeView(sender, e);
			}
		}

		/// <summary>
		/// Fills the items TreeView.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="ReportItemsEventArgs"/> instance containing the event data.</param>
		private void FillItemsTreeView(object sender, ReportItemsEventArgs e)
		{
			try
			{
				if (itemsTreeView.Nodes.Count > 0)
				{
					itemsTreeView.Nodes.Clear();
				}

				foreach (KeyValuePair<string, List<SystemDataItem>> keyValuePair in e.SystemDataCollections)
				{
					var treeNodes = new List<TreeNode>();

					keyValuePair.Value?.ForEach(item =>
						treeNodes.Add(new TreeNode(
							$"Name => {item.Name}, Type => {item.Type}, Value(Curr,MinValue,MaxValue) => ({item.Value}, {item.MinValue}, {item.MaxValue})")));

					var treeNode = new TreeNode(keyValuePair.Key, treeNodes.ToArray());
					itemsTreeView.Nodes.Add(treeNode);
					itemsTreeView.ExpandAll();
				}
			}
			catch (Exception err)
			{
				MessageBox.Show($"An error occurred while querying for WMI data: {err.Message}");
			}
		}

		/// <summary>
		/// Handles the Tick event of the updateSystemTimer control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void updateSystemTimer_Tick(object sender, EventArgs e)
		{
			timeToUpdateToolStripStatusLabel.Text = (updateSystemTimer.Interval / 1000).ToString();
			_systemInfo.GetSystemTemperatureInformation();
		}

		/// <summary>
		/// Handles the Tick event of the timeChangeTimer control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void timeChangeTimer_Tick(object sender, EventArgs e)
		{
			timeToUpdateToolStripStatusLabel.Text =
				(Convert.ToInt32(timeToUpdateToolStripStatusLabel.Text) - 1).ToString();
		}

		/// <summary>
		/// Handles the Click event of the updateButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void updateButton_Click(object sender, EventArgs e)
		{
			_systemInfo.GetSystemTemperatureInformation();
			timeToUpdateToolStripStatusLabel.Text = (updateSystemTimer.Interval / 1000).ToString();

			if (Convert.ToBoolean(toggleTimerButton.Tag))
			{
				updateSystemTimer.Stop();
				updateSystemTimer.Start();
				timeChangeTimer.Stop();
				timeChangeTimer.Start();
			}
		}

		/// <summary>
		/// Handles the Click event of the toggleTimerButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void toggleTimerButton_Click(object sender, EventArgs e)
		{
			if (Convert.ToBoolean(toggleTimerButton.Tag))
			{
				timeToUpdateToolStripStatusLabel.Text = (updateSystemTimer.Interval / 1000).ToString();
				updateSystemTimer.Stop();
				timeChangeTimer.Stop();
				toggleTimerButton.Tag = false;
				toggleTimerButton.Text = "Start timer";
			}
			else
			{
				timeToUpdateToolStripStatusLabel.Text = (updateSystemTimer.Interval / 1000).ToString();
				updateSystemTimer.Start();
				timeChangeTimer.Start();
				toggleTimerButton.Tag = true;
				toggleTimerButton.Text = "Stop timer";
			}
		}

		/// <summary>
		/// Handles the Click event of the clearDataButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void clearDataButton_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are You sure?", "Alert", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				if (itemsTreeView.Nodes.Count > 0)
				{
					itemsTreeView.Nodes.Clear();
				}

				_systemInfo.ClearDatabase();
			}
		}

		/// <summary>
		/// Handles the Click event of the clearTimeButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void clearTimeButton_Click(object sender, EventArgs e)
		{
			runTimeTimer.Stop();

			runTimeLabel.Tag = "0,0,0";
			runTimeLabel.Text = "00:00:00";

			runTimeTimer.Start();
		}

		/// <summary>
		/// Handles the Tick event of the runTimeTimer control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void runTimeTimer_Tick(object sender, EventArgs e)
		{
			var timeArray = runTimeLabel.Tag.ToString().Split(',');

			var hour = Convert.ToInt32(timeArray[0]);
			var minutes = Convert.ToInt32(timeArray[1]);
			var seconds = Convert.ToInt32(timeArray[2]) + 1;

			if (seconds >= 60)
			{
				seconds = 0;
				minutes += 1;
			}

			if (minutes >= 60)
			{
				minutes = 0;
				hour += 1;
			}

			runTimeLabel.Tag = $"{hour},{minutes},{seconds}";
			runTimeLabel.Text = $"{GetTimeWithZero(hour)}:{GetTimeWithZero(minutes)}:{GetTimeWithZero(seconds)}";
		}

		/// <summary>
		/// Gets the time with zero.
		/// </summary>
		/// <param name="time">The time.</param>
		/// <returns></returns>
		private static string GetTimeWithZero(int time)
		{
			var timeInString = time.ToString();
			if (timeInString.Length == 1)
			{
				timeInString = $"0{timeInString}";
			}

			return timeInString;
		}

		/// <summary>
		/// Handles the FormClosing event of the Form1 control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (_systemInfo != null)
			{
				_systemInfo.ReportItemsEventHandler -= _systemInfo_ReportItemsEventHandler;
				updateSystemTimer.Stop();
				timeChangeTimer.Stop();
				runTimeTimer.Stop();
			}

			_systemInfo = null;
		}
	}
}