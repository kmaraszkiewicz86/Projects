namespace SystemTemperatureChecker
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.panel1 = new System.Windows.Forms.Panel();
			this.itemsTreeView = new System.Windows.Forms.TreeView();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.clearTimeButton = new System.Windows.Forms.Button();
			this.clearDataButton = new System.Windows.Forms.Button();
			this.toggleTimerButton = new System.Windows.Forms.Button();
			this.updateButton = new System.Windows.Forms.Button();
			this.updateSystemTimer = new System.Windows.Forms.Timer(this.components);
			this.appStatusStrip = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.timeToUpdateToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.runTimeLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.timeChangeTimer = new System.Windows.Forms.Timer(this.components);
			this.runTimeTimer = new System.Windows.Forms.Timer(this.components);
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.appStatusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.Controls.Add(this.itemsTreeView);
			this.panel1.Location = new System.Drawing.Point(12, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(776, 466);
			this.panel1.TabIndex = 0;
			// 
			// itemsTreeView
			// 
			this.itemsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.itemsTreeView.Location = new System.Drawing.Point(0, 0);
			this.itemsTreeView.Name = "itemsTreeView";
			this.itemsTreeView.Size = new System.Drawing.Size(776, 466);
			this.itemsTreeView.TabIndex = 0;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.clearTimeButton);
			this.groupBox1.Controls.Add(this.clearDataButton);
			this.groupBox1.Controls.Add(this.toggleTimerButton);
			this.groupBox1.Controls.Add(this.updateButton);
			this.groupBox1.Location = new System.Drawing.Point(12, 484);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(776, 44);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Actions";
			// 
			// clearTimeButton
			// 
			this.clearTimeButton.Location = new System.Drawing.Point(165, 17);
			this.clearTimeButton.Name = "clearTimeButton";
			this.clearTimeButton.Size = new System.Drawing.Size(75, 23);
			this.clearTimeButton.TabIndex = 3;
			this.clearTimeButton.Text = "Clear time";
			this.clearTimeButton.UseVisualStyleBackColor = true;
			this.clearTimeButton.Click += new System.EventHandler(this.clearTimeButton_Click);
			// 
			// clearDataButton
			// 
			this.clearDataButton.Location = new System.Drawing.Point(246, 17);
			this.clearDataButton.Name = "clearDataButton";
			this.clearDataButton.Size = new System.Drawing.Size(75, 23);
			this.clearDataButton.TabIndex = 2;
			this.clearDataButton.Text = "Clear Data";
			this.clearDataButton.UseVisualStyleBackColor = true;
			this.clearDataButton.Click += new System.EventHandler(this.clearDataButton_Click);
			// 
			// toggleTimerButton
			// 
			this.toggleTimerButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.toggleTimerButton.Location = new System.Drawing.Point(84, 17);
			this.toggleTimerButton.Name = "toggleTimerButton";
			this.toggleTimerButton.Size = new System.Drawing.Size(75, 23);
			this.toggleTimerButton.TabIndex = 1;
			this.toggleTimerButton.Tag = "true";
			this.toggleTimerButton.Text = "Stop timer";
			this.toggleTimerButton.UseVisualStyleBackColor = true;
			this.toggleTimerButton.Click += new System.EventHandler(this.toggleTimerButton_Click);
			// 
			// updateButton
			// 
			this.updateButton.Dock = System.Windows.Forms.DockStyle.Left;
			this.updateButton.Location = new System.Drawing.Point(3, 16);
			this.updateButton.Name = "updateButton";
			this.updateButton.Size = new System.Drawing.Size(75, 25);
			this.updateButton.TabIndex = 0;
			this.updateButton.Text = "Update";
			this.updateButton.UseVisualStyleBackColor = true;
			this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
			// 
			// updateSystemTimer
			// 
			this.updateSystemTimer.Interval = 10000;
			this.updateSystemTimer.Tick += new System.EventHandler(this.updateSystemTimer_Tick);
			// 
			// appStatusStrip
			// 
			this.appStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.timeToUpdateToolStripStatusLabel,
            this.toolStripStatusLabel2,
            this.runTimeLabel});
			this.appStatusStrip.Location = new System.Drawing.Point(0, 531);
			this.appStatusStrip.Name = "appStatusStrip";
			this.appStatusStrip.Size = new System.Drawing.Size(800, 22);
			this.appStatusStrip.TabIndex = 2;
			this.appStatusStrip.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(91, 17);
			this.toolStripStatusLabel1.Text = "Time to update:";
			// 
			// timeToUpdateToolStripStatusLabel
			// 
			this.timeToUpdateToolStripStatusLabel.Name = "timeToUpdateToolStripStatusLabel";
			this.timeToUpdateToolStripStatusLabel.Size = new System.Drawing.Size(13, 17);
			this.timeToUpdateToolStripStatusLabel.Text = "0";
			// 
			// toolStripStatusLabel2
			// 
			this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			this.toolStripStatusLabel2.Size = new System.Drawing.Size(55, 17);
			this.toolStripStatusLabel2.Text = "Run time";
			// 
			// runTimeLabel
			// 
			this.runTimeLabel.Name = "runTimeLabel";
			this.runTimeLabel.Size = new System.Drawing.Size(49, 17);
			this.runTimeLabel.Tag = "0,0,0";
			this.runTimeLabel.Text = "00:00:00";
			// 
			// timeChangeTimer
			// 
			this.timeChangeTimer.Interval = 1000;
			this.timeChangeTimer.Tick += new System.EventHandler(this.timeChangeTimer_Tick);
			// 
			// runTimeTimer
			// 
			this.runTimeTimer.Interval = 1000;
			this.runTimeTimer.Tick += new System.EventHandler(this.runTimeTimer_Tick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 553);
			this.Controls.Add(this.appStatusStrip);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.panel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "System temperature checker";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.appStatusStrip.ResumeLayout(false);
			this.appStatusStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TreeView itemsTreeView;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button updateButton;
		private System.Windows.Forms.Timer updateSystemTimer;
		private System.Windows.Forms.StatusStrip appStatusStrip;
		private System.Windows.Forms.ToolStripStatusLabel timeToUpdateToolStripStatusLabel;
		private System.Windows.Forms.Timer timeChangeTimer;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.Button toggleTimerButton;
		private System.Windows.Forms.Button clearDataButton;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
		private System.Windows.Forms.ToolStripStatusLabel runTimeLabel;
		private System.Windows.Forms.Timer runTimeTimer;
		private System.Windows.Forms.Button clearTimeButton;
	}
}

