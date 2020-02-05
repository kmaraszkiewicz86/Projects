namespace Timer
{
	partial class TimerForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.label4 = new System.Windows.Forms.Label();
			this.timerElapsedLabel = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip2 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.timerLabel = new System.Windows.Forms.Label();
			this.timerBeforePlaySoundTimer = new System.Windows.Forms.Timer(this.components);
			this.startTimerButton = new System.Windows.Forms.Button();
			this.stopTimerButton = new System.Windows.Forms.Button();
			this.resetTimerButton = new System.Windows.Forms.Button();
			this.resetTimerPeriodButton = new System.Windows.Forms.Button();
			this.stopTimerPeriodButton = new System.Windows.Forms.Button();
			this.startTimerPeriodButton = new System.Windows.Forms.Button();
			this.timerState = new System.Windows.Forms.Label();
			this.timerPeriodState = new System.Windows.Forms.Label();
			this.menuStrip1.SuspendLayout();
			this.menuStrip2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label4.Location = new System.Drawing.Point(12, 98);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(252, 42);
			this.label4.TabIndex = 0;
			this.label4.Text = "Time elapsed:";
			// 
			// timerElapsedLabel
			// 
			this.timerElapsedLabel.AutoSize = true;
			this.timerElapsedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.timerElapsedLabel.Location = new System.Drawing.Point(259, 98);
			this.timerElapsedLabel.Name = "timerElapsedLabel";
			this.timerElapsedLabel.Size = new System.Drawing.Size(112, 42);
			this.timerElapsedLabel.TabIndex = 1;
			this.timerElapsedLabel.Text = "00:00";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
			this.menuStrip1.Location = new System.Drawing.Point(0, 24);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(624, 24);
			this.menuStrip1.TabIndex = 2;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 20);
			// 
			// menuStrip2
			// 
			this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.menuStrip2.Location = new System.Drawing.Point(0, 0);
			this.menuStrip2.Name = "menuStrip2";
			this.menuStrip2.Size = new System.Drawing.Size(624, 24);
			this.menuStrip2.TabIndex = 3;
			this.menuStrip2.Text = "menuStrip2";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
			this.settingsToolStripMenuItem.Text = "Settings";
			this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
			// 
			// timer
			// 
			this.timer.Interval = 1000;
			this.timer.Tick += new System.EventHandler(this.timer_Tick);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label1.Location = new System.Drawing.Point(12, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(122, 42);
			this.label1.TabIndex = 4;
			this.label1.Text = "Timer:";
			// 
			// timerLabel
			// 
			this.timerLabel.AutoSize = true;
			this.timerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.timerLabel.Location = new System.Drawing.Point(259, 56);
			this.timerLabel.Name = "timerLabel";
			this.timerLabel.Size = new System.Drawing.Size(112, 42);
			this.timerLabel.TabIndex = 5;
			this.timerLabel.Text = "00:00";
			// 
			// timerBeforePlaySoundTimer
			// 
			this.timerBeforePlaySoundTimer.Interval = 1000;
			this.timerBeforePlaySoundTimer.Tick += new System.EventHandler(this.timerBeforePlaySound_Tick);
			// 
			// startTimerButton
			// 
			this.startTimerButton.Location = new System.Drawing.Point(368, 72);
			this.startTimerButton.Name = "startTimerButton";
			this.startTimerButton.Size = new System.Drawing.Size(75, 23);
			this.startTimerButton.TabIndex = 6;
			this.startTimerButton.Tag = "1";
			this.startTimerButton.Text = "Start";
			this.startTimerButton.UseVisualStyleBackColor = true;
			this.startTimerButton.Click += new System.EventHandler(this.startTimerButton_Click);
			// 
			// stopTimerButton
			// 
			this.stopTimerButton.Enabled = false;
			this.stopTimerButton.Location = new System.Drawing.Point(449, 72);
			this.stopTimerButton.Name = "stopTimerButton";
			this.stopTimerButton.Size = new System.Drawing.Size(75, 23);
			this.stopTimerButton.TabIndex = 7;
			this.stopTimerButton.Tag = "1";
			this.stopTimerButton.Text = "Stop";
			this.stopTimerButton.UseVisualStyleBackColor = true;
			this.stopTimerButton.Click += new System.EventHandler(this.stopTimerButton_Click);
			// 
			// resetTimerButton
			// 
			this.resetTimerButton.Location = new System.Drawing.Point(532, 72);
			this.resetTimerButton.Name = "resetTimerButton";
			this.resetTimerButton.Size = new System.Drawing.Size(75, 23);
			this.resetTimerButton.TabIndex = 8;
			this.resetTimerButton.Tag = "1";
			this.resetTimerButton.Text = "Reset";
			this.resetTimerButton.UseVisualStyleBackColor = true;
			this.resetTimerButton.Click += new System.EventHandler(this.resetTimerButton_Click);
			// 
			// resetTimerPeriodButton
			// 
			this.resetTimerPeriodButton.Location = new System.Drawing.Point(532, 114);
			this.resetTimerPeriodButton.Name = "resetTimerPeriodButton";
			this.resetTimerPeriodButton.Size = new System.Drawing.Size(75, 23);
			this.resetTimerPeriodButton.TabIndex = 11;
			this.resetTimerPeriodButton.Tag = "2";
			this.resetTimerPeriodButton.Text = "Reset";
			this.resetTimerPeriodButton.UseVisualStyleBackColor = true;
			this.resetTimerPeriodButton.Click += new System.EventHandler(this.resetTimerButton_Click);
			// 
			// stopTimerPeriodButton
			// 
			this.stopTimerPeriodButton.Enabled = false;
			this.stopTimerPeriodButton.Location = new System.Drawing.Point(449, 114);
			this.stopTimerPeriodButton.Name = "stopTimerPeriodButton";
			this.stopTimerPeriodButton.Size = new System.Drawing.Size(75, 23);
			this.stopTimerPeriodButton.TabIndex = 10;
			this.stopTimerPeriodButton.Tag = "2";
			this.stopTimerPeriodButton.Text = "Stop";
			this.stopTimerPeriodButton.UseVisualStyleBackColor = true;
			this.stopTimerPeriodButton.Click += new System.EventHandler(this.stopTimerButton_Click);
			// 
			// startTimerPeriodButton
			// 
			this.startTimerPeriodButton.Location = new System.Drawing.Point(368, 114);
			this.startTimerPeriodButton.Name = "startTimerPeriodButton";
			this.startTimerPeriodButton.Size = new System.Drawing.Size(75, 23);
			this.startTimerPeriodButton.TabIndex = 9;
			this.startTimerPeriodButton.Tag = "2";
			this.startTimerPeriodButton.Text = "Start";
			this.startTimerPeriodButton.UseVisualStyleBackColor = true;
			this.startTimerPeriodButton.Click += new System.EventHandler(this.startTimerButton_Click);
			// 
			// timerState
			// 
			this.timerState.AutoSize = true;
			this.timerState.Location = new System.Drawing.Point(140, 72);
			this.timerState.Name = "timerState";
			this.timerState.Size = new System.Drawing.Size(0, 13);
			this.timerState.TabIndex = 12;
			this.timerState.Tag = "start";
			// 
			// timerPeriodState
			// 
			this.timerPeriodState.AutoSize = true;
			this.timerPeriodState.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.timerPeriodState.Location = new System.Drawing.Point(253, 114);
			this.timerPeriodState.Name = "timerPeriodState";
			this.timerPeriodState.Size = new System.Drawing.Size(0, 13);
			this.timerPeriodState.TabIndex = 13;
			this.timerPeriodState.Tag = "start";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(624, 149);
			this.Controls.Add(this.timerPeriodState);
			this.Controls.Add(this.timerState);
			this.Controls.Add(this.resetTimerPeriodButton);
			this.Controls.Add(this.stopTimerPeriodButton);
			this.Controls.Add(this.startTimerPeriodButton);
			this.Controls.Add(this.resetTimerButton);
			this.Controls.Add(this.stopTimerButton);
			this.Controls.Add(this.startTimerButton);
			this.Controls.Add(this.timerLabel);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.timerElapsedLabel);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.menuStrip2);
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TimerForm";
			this.Text = "Timer";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.menuStrip2.ResumeLayout(false);
			this.menuStrip2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label timerElapsedLabel;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.MenuStrip menuStrip2;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
		private System.Windows.Forms.Timer timer;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label timerLabel;
		private System.Windows.Forms.Timer timerBeforePlaySoundTimer;
		private System.Windows.Forms.Button startTimerButton;
		private System.Windows.Forms.Button stopTimerButton;
		private System.Windows.Forms.Button resetTimerButton;
		private System.Windows.Forms.Button resetTimerPeriodButton;
		private System.Windows.Forms.Button stopTimerPeriodButton;
		private System.Windows.Forms.Button startTimerPeriodButton;
		private System.Windows.Forms.Label timerState;
		private System.Windows.Forms.Label timerPeriodState;
	}
}

