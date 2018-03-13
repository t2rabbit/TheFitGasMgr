namespace IOServer
{
	partial class FormMain
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.listViewDevModuleCmd = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3 = new System.Windows.Forms.Panel();
            this.调光的命令 = new System.Windows.Forms.Button();
            this.buttonRestart = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonDevCmdClear = new System.Windows.Forms.Button();
            this.checkBoxDevCmd = new System.Windows.Forms.CheckBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.listViewDeviceStatus = new System.Windows.Forms.ListView();
            this.portNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.deviceName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColUpDateTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.timerUpdateStatus = new System.Windows.Forms.Timer(this.components);
            this.timerGetTopLog = new System.Windows.Forms.Timer(this.components);
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(7, 12);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 3;
            this.buttonStart.Text = "启动";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(88, 12);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 5;
            this.buttonStop.Text = "停止";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // listViewDevModuleCmd
            // 
            this.listViewDevModuleCmd.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader4,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewDevModuleCmd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewDevModuleCmd.FullRowSelect = true;
            this.listViewDevModuleCmd.HideSelection = false;
            this.listViewDevModuleCmd.Location = new System.Drawing.Point(0, 395);
            this.listViewDevModuleCmd.Name = "listViewDevModuleCmd";
            this.listViewDevModuleCmd.Size = new System.Drawing.Size(786, 215);
            this.listViewDevModuleCmd.TabIndex = 8;
            this.listViewDevModuleCmd.UseCompatibleStateImageBehavior = false;
            this.listViewDevModuleCmd.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "方向";
            this.columnHeader1.Width = 94;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "端口名";
            this.columnHeader4.Width = 108;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "时间";
            this.columnHeader2.Width = 98;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "数据";
            this.columnHeader3.Width = 384;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.调光的命令);
            this.panel3.Controls.Add(this.buttonRestart);
            this.panel3.Controls.Add(this.textBox2);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.buttonStart);
            this.panel3.Controls.Add(this.buttonStop);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(786, 48);
            this.panel3.TabIndex = 9;
            // 
            // 调光的命令
            // 
            this.调光的命令.Location = new System.Drawing.Point(647, 11);
            this.调光的命令.Name = "调光的命令";
            this.调光的命令.Size = new System.Drawing.Size(75, 23);
            this.调光的命令.TabIndex = 14;
            this.调光的命令.Text = "调光的命令";
            this.调光的命令.UseVisualStyleBackColor = true;
            this.调光的命令.Click += new System.EventHandler(this.调光的命令_Click);
            // 
            // buttonRestart
            // 
            this.buttonRestart.Location = new System.Drawing.Point(493, 11);
            this.buttonRestart.Name = "buttonRestart";
            this.buttonRestart.Size = new System.Drawing.Size(75, 23);
            this.buttonRestart.TabIndex = 13;
            this.buttonRestart.Text = "Restart";
            this.buttonRestart.UseVisualStyleBackColor = true;
            this.buttonRestart.Click += new System.EventHandler(this.buttonRestart_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(336, 14);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(271, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "GRPS Port";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.listViewDevModuleCmd);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 48);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(786, 610);
            this.panel4.TabIndex = 10;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.buttonDevCmdClear);
            this.panel6.Controls.Add(this.checkBoxDevCmd);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 361);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(786, 34);
            this.panel6.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "数据采集";
            // 
            // buttonDevCmdClear
            // 
            this.buttonDevCmdClear.Location = new System.Drawing.Point(142, 2);
            this.buttonDevCmdClear.Name = "buttonDevCmdClear";
            this.buttonDevCmdClear.Size = new System.Drawing.Size(75, 23);
            this.buttonDevCmdClear.TabIndex = 0;
            this.buttonDevCmdClear.Text = "清空";
            this.buttonDevCmdClear.UseVisualStyleBackColor = true;
            this.buttonDevCmdClear.Click += new System.EventHandler(this.buttonDevCmdClear_Click);
            // 
            // checkBoxDevCmd
            // 
            this.checkBoxDevCmd.AutoSize = true;
            this.checkBoxDevCmd.Location = new System.Drawing.Point(88, 6);
            this.checkBoxDevCmd.Name = "checkBoxDevCmd";
            this.checkBoxDevCmd.Size = new System.Drawing.Size(48, 16);
            this.checkBoxDevCmd.TabIndex = 1;
            this.checkBoxDevCmd.Text = "暂停";
            this.checkBoxDevCmd.UseVisualStyleBackColor = true;
            this.checkBoxDevCmd.CheckedChanged += new System.EventHandler(this.checkBoxDevCmd_CheckedChanged);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.listViewDeviceStatus);
            this.panel5.Controls.Add(this.panel1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(786, 361);
            this.panel5.TabIndex = 9;
            // 
            // listViewDeviceStatus
            // 
            this.listViewDeviceStatus.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.portNo,
            this.deviceName,
            this.columnHeader5,
            this.ColUpDateTime,
            this.columnHeader6,
            this.ColStatus});
            this.listViewDeviceStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewDeviceStatus.FullRowSelect = true;
            this.listViewDeviceStatus.Location = new System.Drawing.Point(0, 83);
            this.listViewDeviceStatus.Name = "listViewDeviceStatus";
            this.listViewDeviceStatus.Size = new System.Drawing.Size(786, 278);
            this.listViewDeviceStatus.TabIndex = 1;
            this.listViewDeviceStatus.UseCompatibleStateImageBehavior = false;
            this.listViewDeviceStatus.View = System.Windows.Forms.View.Details;
            // 
            // portNo
            // 
            this.portNo.Text = "网关名/ID";
            this.portNo.Width = 87;
            // 
            // deviceName
            // 
            this.deviceName.Text = "设备名称/ID";
            this.deviceName.Width = 111;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "网关信息/控制器地址";
            this.columnHeader5.Width = 173;
            // 
            // ColUpDateTime
            // 
            this.ColUpDateTime.Text = "状态更新时间";
            this.ColUpDateTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ColUpDateTime.Width = 230;
            // 
            // ColStatus
            // 
            this.ColStatus.Text = "设备状态";
            this.ColStatus.Width = 102;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(786, 83);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "设备状态表";
            // 
            // timerUpdateStatus
            // 
            this.timerUpdateStatus.Interval = 3000;
            this.timerUpdateStatus.Tick += new System.EventHandler(this.timerUpdateStatus_Tick);
            // 
            // timerGetTopLog
            // 
            this.timerGetTopLog.Enabled = true;
            this.timerGetTopLog.Interval = 1000;
            this.timerGetTopLog.Tick += new System.EventHandler(this.timerGetTopLog_Tick);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "DevLineIndex";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 658);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Name = "FormMain";
            this.Text = "NetLabelMgrIOServer V0.91";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
		private System.Windows.Forms.ListView listViewDevModuleCmd;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Timer timerUpdateStatus;
		private System.Windows.Forms.ListView listViewDeviceStatus;
		private System.Windows.Forms.ColumnHeader portNo;
		private System.Windows.Forms.ColumnHeader deviceName;
		private System.Windows.Forms.ColumnHeader ColUpDateTime;
		private System.Windows.Forms.ColumnHeader ColStatus;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox checkBoxDevCmd;
		private System.Windows.Forms.Button buttonDevCmdClear;
		private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonRestart;
        private System.Windows.Forms.Button 调光的命令;
        private System.Windows.Forms.Timer timerGetTopLog;
        private System.Windows.Forms.ColumnHeader columnHeader6;
	}
}

