namespace IOServer
{
	partial class FormCfg
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
			this.buttonSave = new System.Windows.Forms.Button();
			this.checkBoxUploadDataStart = new System.Windows.Forms.CheckBox();
			this.checkBoxGetDevDataStart = new System.Windows.Forms.CheckBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.textBoxHdesc121SendHeartbeat = new System.Windows.Forms.TextBox();
			this.textBoxHdesc121LiveTimes = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.cmbEnabled = new System.Windows.Forms.ComboBox();
			this.txt3GConnection = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.txtTranPeroid = new System.Windows.Forms.TextBox();
			this.txtPickupPeriod = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.txtVersion = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtGateWayID = new System.Windows.Forms.TextBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.textBoxCommServerIP = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.textBoxCommServerPort = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtCenterIP = new System.Windows.Forms.TextBox();
			this.txtCenterPort2 = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtTimeOut = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtCenterPort1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.checkBoxEnableDC = new System.Windows.Forms.CheckBox();
			this.buttonOK = new System.Windows.Forms.Button();
			this.groupBox5.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(413, 390);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 0;
			this.buttonSave.Text = "修改";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// checkBoxUploadDataStart
			// 
			this.checkBoxUploadDataStart.AutoSize = true;
			this.checkBoxUploadDataStart.Location = new System.Drawing.Point(16, 372);
			this.checkBoxUploadDataStart.Name = "checkBoxUploadDataStart";
			this.checkBoxUploadDataStart.Size = new System.Drawing.Size(108, 16);
			this.checkBoxUploadDataStart.TabIndex = 22;
			this.checkBoxUploadDataStart.Text = "运行后直接上传";
			this.checkBoxUploadDataStart.UseVisualStyleBackColor = true;
			// 
			// checkBoxGetDevDataStart
			// 
			this.checkBoxGetDevDataStart.AutoSize = true;
			this.checkBoxGetDevDataStart.Location = new System.Drawing.Point(16, 394);
			this.checkBoxGetDevDataStart.Name = "checkBoxGetDevDataStart";
			this.checkBoxGetDevDataStart.Size = new System.Drawing.Size(108, 16);
			this.checkBoxGetDevDataStart.TabIndex = 23;
			this.checkBoxGetDevDataStart.Text = "运行后直接采集";
			this.checkBoxGetDevDataStart.UseVisualStyleBackColor = true;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.textBoxHdesc121SendHeartbeat);
			this.groupBox5.Controls.Add(this.textBoxHdesc121LiveTimes);
			this.groupBox5.Controls.Add(this.label14);
			this.groupBox5.Controls.Add(this.label15);
			this.groupBox5.Location = new System.Drawing.Point(16, 314);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(546, 52);
			this.groupBox5.TabIndex = 21;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "HDESC 心跳检测";
			// 
			// textBoxHdesc121SendHeartbeat
			// 
			this.textBoxHdesc121SendHeartbeat.Location = new System.Drawing.Point(365, 18);
			this.textBoxHdesc121SendHeartbeat.Name = "textBoxHdesc121SendHeartbeat";
			this.textBoxHdesc121SendHeartbeat.ReadOnly = true;
			this.textBoxHdesc121SendHeartbeat.Size = new System.Drawing.Size(139, 21);
			this.textBoxHdesc121SendHeartbeat.TabIndex = 12;
			// 
			// textBoxHdesc121LiveTimes
			// 
			this.textBoxHdesc121LiveTimes.Location = new System.Drawing.Point(87, 15);
			this.textBoxHdesc121LiveTimes.Name = "textBoxHdesc121LiveTimes";
			this.textBoxHdesc121LiveTimes.ReadOnly = true;
			this.textBoxHdesc121LiveTimes.Size = new System.Drawing.Size(161, 21);
			this.textBoxHdesc121LiveTimes.TabIndex = 12;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(250, 21);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(101, 12);
			this.label14.TabIndex = 3;
			this.label14.Text = "主动发送心跳时长";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(7, 17);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(77, 12);
			this.label15.TabIndex = 1;
			this.label15.Text = "认为掉线时长";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.cmbEnabled);
			this.groupBox4.Controls.Add(this.txt3GConnection);
			this.groupBox4.Controls.Add(this.label12);
			this.groupBox4.Controls.Add(this.label13);
			this.groupBox4.Location = new System.Drawing.Point(16, 256);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(546, 52);
			this.groupBox4.TabIndex = 20;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "无线上网卡设置";
			// 
			// cmbEnabled
			// 
			this.cmbEnabled.FormattingEnabled = true;
			this.cmbEnabled.Items.AddRange(new object[] {
            "否",
            "是"});
			this.cmbEnabled.Location = new System.Drawing.Point(338, 19);
			this.cmbEnabled.Name = "cmbEnabled";
			this.cmbEnabled.Size = new System.Drawing.Size(161, 20);
			this.cmbEnabled.TabIndex = 13;
			// 
			// txt3GConnection
			// 
			this.txt3GConnection.Location = new System.Drawing.Point(85, 15);
			this.txt3GConnection.Name = "txt3GConnection";
			this.txt3GConnection.Size = new System.Drawing.Size(161, 21);
			this.txt3GConnection.TabIndex = 12;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(250, 21);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(53, 12);
			this.label12.TabIndex = 3;
			this.label12.Text = "是否启用";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(12, 18);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(53, 12);
			this.label13.TabIndex = 1;
			this.label13.Text = "连接名称";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.txtTranPeroid);
			this.groupBox2.Controls.Add(this.txtPickupPeriod);
			this.groupBox2.Controls.Add(this.label11);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Controls.Add(this.txtVersion);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.txtGateWayID);
			this.groupBox2.Location = new System.Drawing.Point(15, 124);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(546, 71);
			this.groupBox2.TabIndex = 19;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "数据网关";
			// 
			// txtTranPeroid
			// 
			this.txtTranPeroid.Location = new System.Drawing.Point(87, 44);
			this.txtTranPeroid.Name = "txtTranPeroid";
			this.txtTranPeroid.ReadOnly = true;
			this.txtTranPeroid.Size = new System.Drawing.Size(161, 21);
			this.txtTranPeroid.TabIndex = 14;
			// 
			// txtPickupPeriod
			// 
			this.txtPickupPeriod.Location = new System.Drawing.Point(343, 47);
			this.txtPickupPeriod.Name = "txtPickupPeriod";
			this.txtPickupPeriod.ReadOnly = true;
			this.txtPickupPeriod.Size = new System.Drawing.Size(161, 21);
			this.txtPickupPeriod.TabIndex = 11;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(13, 50);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(71, 12);
			this.label11.TabIndex = 13;
			this.label11.Text = "传输周期(s)";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(251, 53);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(95, 12);
			this.label10.TabIndex = 10;
			this.label10.Text = "采集频度(次/秒)";
			// 
			// txtVersion
			// 
			this.txtVersion.Location = new System.Drawing.Point(339, 20);
			this.txtVersion.Name = "txtVersion";
			this.txtVersion.Size = new System.Drawing.Size(161, 21);
			this.txtVersion.TabIndex = 8;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(259, 26);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(41, 12);
			this.label6.TabIndex = 7;
			this.label6.Text = "版本号";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 23);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(17, 12);
			this.label4.TabIndex = 3;
			this.label4.Text = "ID";
			// 
			// txtGateWayID
			// 
			this.txtGateWayID.BackColor = System.Drawing.SystemColors.Window;
			this.txtGateWayID.Location = new System.Drawing.Point(87, 17);
			this.txtGateWayID.Name = "txtGateWayID";
			this.txtGateWayID.Size = new System.Drawing.Size(161, 21);
			this.txtGateWayID.TabIndex = 2;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.textBoxCommServerIP);
			this.groupBox3.Controls.Add(this.label16);
			this.groupBox3.Controls.Add(this.textBoxCommServerPort);
			this.groupBox3.Controls.Add(this.label17);
			this.groupBox3.Location = new System.Drawing.Point(16, 201);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(546, 49);
			this.groupBox3.TabIndex = 17;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "通信管理服务器";
			// 
			// textBoxCommServerIP
			// 
			this.textBoxCommServerIP.Location = new System.Drawing.Point(87, 15);
			this.textBoxCommServerIP.Name = "textBoxCommServerIP";
			this.textBoxCommServerIP.Size = new System.Drawing.Size(161, 21);
			this.textBoxCommServerIP.TabIndex = 12;
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(259, 21);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(29, 12);
			this.label16.TabIndex = 3;
			this.label16.Text = "端口";
			// 
			// textBoxCommServerPort
			// 
			this.textBoxCommServerPort.Location = new System.Drawing.Point(342, 15);
			this.textBoxCommServerPort.Name = "textBoxCommServerPort";
			this.textBoxCommServerPort.ReadOnly = true;
			this.textBoxCommServerPort.Size = new System.Drawing.Size(161, 21);
			this.textBoxCommServerPort.TabIndex = 2;
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(12, 18);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(41, 12);
			this.label17.TabIndex = 1;
			this.label17.Text = "IP地址";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.checkBoxEnableDC);
			this.groupBox1.Controls.Add(this.txtCenterIP);
			this.groupBox1.Controls.Add(this.txtCenterPort2);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.txtTimeOut);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtCenterPort1);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(15, 6);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(546, 112);
			this.groupBox1.TabIndex = 18;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "数据中心";
			// 
			// txtCenterIP
			// 
			this.txtCenterIP.Location = new System.Drawing.Point(84, 53);
			this.txtCenterIP.Name = "txtCenterIP";
			this.txtCenterIP.Size = new System.Drawing.Size(161, 21);
			this.txtCenterIP.TabIndex = 12;
			// 
			// txtCenterPort2
			// 
			this.txtCenterPort2.Location = new System.Drawing.Point(339, 85);
			this.txtCenterPort2.Name = "txtCenterPort2";
			this.txtCenterPort2.ReadOnly = true;
			this.txtCenterPort2.Size = new System.Drawing.Size(161, 21);
			this.txtCenterPort2.TabIndex = 9;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(256, 88);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(53, 12);
			this.label9.TabIndex = 8;
			this.label9.Text = "命令端口";
			// 
			// txtTimeOut
			// 
			this.txtTimeOut.Location = new System.Drawing.Point(84, 85);
			this.txtTimeOut.Name = "txtTimeOut";
			this.txtTimeOut.ReadOnly = true;
			this.txtTimeOut.Size = new System.Drawing.Size(161, 21);
			this.txtTimeOut.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 88);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(71, 12);
			this.label3.TabIndex = 4;
			this.label3.Text = "超时时间(s)";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(256, 59);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 12);
			this.label2.TabIndex = 3;
			this.label2.Text = "数据端口";
			// 
			// txtCenterPort1
			// 
			this.txtCenterPort1.Location = new System.Drawing.Point(339, 53);
			this.txtCenterPort1.Name = "txtCenterPort1";
			this.txtCenterPort1.ReadOnly = true;
			this.txtCenterPort1.Size = new System.Drawing.Size(161, 21);
			this.txtCenterPort1.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 12);
			this.label1.TabIndex = 1;
			this.label1.Text = "IP地址";
			// 
			// checkBoxEnableDC
			// 
			this.checkBoxEnableDC.AutoSize = true;
			this.checkBoxEnableDC.Location = new System.Drawing.Point(15, 20);
			this.checkBoxEnableDC.Name = "checkBoxEnableDC";
			this.checkBoxEnableDC.Size = new System.Drawing.Size(72, 16);
			this.checkBoxEnableDC.TabIndex = 15;
			this.checkBoxEnableDC.Text = "是否启用";
			this.checkBoxEnableDC.UseVisualStyleBackColor = true;
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(494, 390);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 24;
			this.buttonOK.Text = "完成";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// FormCfg
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(580, 427);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.checkBoxUploadDataStart);
			this.Controls.Add(this.checkBoxGetDevDataStart);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.buttonSave);
			this.Name = "FormCfg";
			this.Text = "FormCfg";
			this.Load += new System.EventHandler(this.FormCfg_Load);
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.CheckBox checkBoxUploadDataStart;
		private System.Windows.Forms.CheckBox checkBoxGetDevDataStart;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.TextBox textBoxHdesc121SendHeartbeat;
		private System.Windows.Forms.TextBox textBoxHdesc121LiveTimes;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.ComboBox cmbEnabled;
		private System.Windows.Forms.TextBox txt3GConnection;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox txtTranPeroid;
		private System.Windows.Forms.TextBox txtPickupPeriod;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtVersion;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtGateWayID;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox textBoxCommServerIP;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox textBoxCommServerPort;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtCenterIP;
		private System.Windows.Forms.TextBox txtCenterPort2;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtTimeOut;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtCenterPort1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox checkBoxEnableDC;
		private System.Windows.Forms.Button buttonOK;
	}
}