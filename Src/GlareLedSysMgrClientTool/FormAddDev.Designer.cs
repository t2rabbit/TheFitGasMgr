namespace Property
{
    partial class FormAddDev
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
            this.labelDevType = new System.Windows.Forms.Label();
            this.groupBoxPortDetailInfo = new System.Windows.Forms.GroupBox();
            this.panelTcpServerInfo = new System.Windows.Forms.Panel();
            this.textBoxTcpServerPort = new System.Windows.Forms.TextBox();
            this.labelTcpSeverPort = new System.Windows.Forms.Label();
            this.textBoxTcpServerIP = new System.Windows.Forms.TextBox();
            this.labelTcpServerIP = new System.Windows.Forms.Label();
            this.panelSerailInfo = new System.Windows.Forms.Panel();
            this.labelComPort = new System.Windows.Forms.Label();
            this.comboBoxSerialCom = new System.Windows.Forms.ComboBox();
            this.panelTcpClientInfo = new System.Windows.Forms.Panel();
            this.textBoxTCPClientID = new System.Windows.Forms.TextBox();
            this.labelGprsClientInfo = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.radioButtonSerial = new System.Windows.Forms.RadioButton();
            this.radioButtonTcpClient = new System.Windows.Forms.RadioButton();
            this.radioButtonTcpServer = new System.Windows.Forms.RadioButton();
            this.labelPortName = new System.Windows.Forms.Label();
            this.textBoxPortName = new System.Windows.Forms.TextBox();
            this.labelSelOilStation = new System.Windows.Forms.Label();
            this.comboBoxSelOilStation = new System.Windows.Forms.ComboBox();
            this.groupBoxPortDetailInfo.SuspendLayout();
            this.panelTcpServerInfo.SuspendLayout();
            this.panelSerailInfo.SuspendLayout();
            this.panelTcpClientInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelDevType
            // 
            this.labelDevType.AutoSize = true;
            this.labelDevType.Location = new System.Drawing.Point(12, 54);
            this.labelDevType.Name = "labelDevType";
            this.labelDevType.Size = new System.Drawing.Size(53, 12);
            this.labelDevType.TabIndex = 0;
            this.labelDevType.Text = "端口类型";
            // 
            // groupBoxPortDetailInfo
            // 
            this.groupBoxPortDetailInfo.Controls.Add(this.panelTcpServerInfo);
            this.groupBoxPortDetailInfo.Controls.Add(this.panelSerailInfo);
            this.groupBoxPortDetailInfo.Controls.Add(this.panelTcpClientInfo);
            this.groupBoxPortDetailInfo.Location = new System.Drawing.Point(12, 131);
            this.groupBoxPortDetailInfo.Name = "groupBoxPortDetailInfo";
            this.groupBoxPortDetailInfo.Size = new System.Drawing.Size(331, 110);
            this.groupBoxPortDetailInfo.TabIndex = 4;
            this.groupBoxPortDetailInfo.TabStop = false;
            this.groupBoxPortDetailInfo.Text = "端口详细参数";
            this.groupBoxPortDetailInfo.Enter += new System.EventHandler(this.groupBoxPortDetailInfo_Enter);
            // 
            // panelTcpServerInfo
            // 
            this.panelTcpServerInfo.Controls.Add(this.textBoxTcpServerPort);
            this.panelTcpServerInfo.Controls.Add(this.labelTcpSeverPort);
            this.panelTcpServerInfo.Controls.Add(this.textBoxTcpServerIP);
            this.panelTcpServerInfo.Controls.Add(this.labelTcpServerIP);
            this.panelTcpServerInfo.Location = new System.Drawing.Point(127, 19);
            this.panelTcpServerInfo.Name = "panelTcpServerInfo";
            this.panelTcpServerInfo.Padding = new System.Windows.Forms.Padding(5);
            this.panelTcpServerInfo.Size = new System.Drawing.Size(240, 65);
            this.panelTcpServerInfo.TabIndex = 6;
            // 
            // textBoxTcpServerPort
            // 
            this.textBoxTcpServerPort.Location = new System.Drawing.Point(80, 36);
            this.textBoxTcpServerPort.Name = "textBoxTcpServerPort";
            this.textBoxTcpServerPort.Size = new System.Drawing.Size(119, 21);
            this.textBoxTcpServerPort.TabIndex = 1;
            // 
            // labelTcpSeverPort
            // 
            this.labelTcpSeverPort.AutoSize = true;
            this.labelTcpSeverPort.Location = new System.Drawing.Point(8, 41);
            this.labelTcpSeverPort.Name = "labelTcpSeverPort";
            this.labelTcpSeverPort.Size = new System.Drawing.Size(53, 12);
            this.labelTcpSeverPort.TabIndex = 2;
            this.labelTcpSeverPort.Text = "服务端口";
            // 
            // textBoxTcpServerIP
            // 
            this.textBoxTcpServerIP.Location = new System.Drawing.Point(80, 9);
            this.textBoxTcpServerIP.Name = "textBoxTcpServerIP";
            this.textBoxTcpServerIP.Size = new System.Drawing.Size(119, 21);
            this.textBoxTcpServerIP.TabIndex = 0;
            // 
            // labelTcpServerIP
            // 
            this.labelTcpServerIP.AutoSize = true;
            this.labelTcpServerIP.Location = new System.Drawing.Point(8, 14);
            this.labelTcpServerIP.Name = "labelTcpServerIP";
            this.labelTcpServerIP.Size = new System.Drawing.Size(53, 12);
            this.labelTcpServerIP.TabIndex = 2;
            this.labelTcpServerIP.Text = "服务器IP";
            // 
            // panelSerailInfo
            // 
            this.panelSerailInfo.Controls.Add(this.labelComPort);
            this.panelSerailInfo.Controls.Add(this.comboBoxSerialCom);
            this.panelSerailInfo.Location = new System.Drawing.Point(6, 19);
            this.panelSerailInfo.Name = "panelSerailInfo";
            this.panelSerailInfo.Padding = new System.Windows.Forms.Padding(5);
            this.panelSerailInfo.Size = new System.Drawing.Size(240, 51);
            this.panelSerailInfo.TabIndex = 5;
            // 
            // labelComPort
            // 
            this.labelComPort.AutoSize = true;
            this.labelComPort.Location = new System.Drawing.Point(2, 8);
            this.labelComPort.Name = "labelComPort";
            this.labelComPort.Size = new System.Drawing.Size(41, 12);
            this.labelComPort.TabIndex = 0;
            this.labelComPort.Text = "串口号";
            // 
            // comboBoxSerialCom
            // 
            this.comboBoxSerialCom.FormattingEnabled = true;
            this.comboBoxSerialCom.Location = new System.Drawing.Point(72, 5);
            this.comboBoxSerialCom.Name = "comboBoxSerialCom";
            this.comboBoxSerialCom.Size = new System.Drawing.Size(121, 20);
            this.comboBoxSerialCom.TabIndex = 0;
            // 
            // panelTcpClientInfo
            // 
            this.panelTcpClientInfo.Controls.Add(this.textBoxTCPClientID);
            this.panelTcpClientInfo.Controls.Add(this.labelGprsClientInfo);
            this.panelTcpClientInfo.Location = new System.Drawing.Point(4, 81);
            this.panelTcpClientInfo.Name = "panelTcpClientInfo";
            this.panelTcpClientInfo.Padding = new System.Windows.Forms.Padding(5);
            this.panelTcpClientInfo.Size = new System.Drawing.Size(240, 65);
            this.panelTcpClientInfo.TabIndex = 6;
            // 
            // textBoxTCPClientID
            // 
            this.textBoxTCPClientID.Location = new System.Drawing.Point(80, 9);
            this.textBoxTCPClientID.Name = "textBoxTCPClientID";
            this.textBoxTCPClientID.Size = new System.Drawing.Size(119, 21);
            this.textBoxTCPClientID.TabIndex = 0;
            // 
            // labelGprsClientInfo
            // 
            this.labelGprsClientInfo.AutoSize = true;
            this.labelGprsClientInfo.Location = new System.Drawing.Point(8, 14);
            this.labelGprsClientInfo.Name = "labelGprsClientInfo";
            this.labelGprsClientInfo.Size = new System.Drawing.Size(65, 12);
            this.labelGprsClientInfo.TabIndex = 2;
            this.labelGprsClientInfo.Text = "客户端标识";
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(187, 279);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(270, 279);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // radioButtonSerial
            // 
            this.radioButtonSerial.AutoSize = true;
            this.radioButtonSerial.Checked = true;
            this.radioButtonSerial.Location = new System.Drawing.Point(12, 76);
            this.radioButtonSerial.Name = "radioButtonSerial";
            this.radioButtonSerial.Size = new System.Drawing.Size(47, 16);
            this.radioButtonSerial.TabIndex = 1;
            this.radioButtonSerial.TabStop = true;
            this.radioButtonSerial.Text = "串口";
            this.radioButtonSerial.UseVisualStyleBackColor = true;
            this.radioButtonSerial.CheckedChanged += new System.EventHandler(this.radioButtonSerial_CheckedChanged);
            // 
            // radioButtonTcpClient
            // 
            this.radioButtonTcpClient.AutoSize = true;
            this.radioButtonTcpClient.Location = new System.Drawing.Point(102, 76);
            this.radioButtonTcpClient.Name = "radioButtonTcpClient";
            this.radioButtonTcpClient.Size = new System.Drawing.Size(113, 16);
            this.radioButtonTcpClient.TabIndex = 2;
            this.radioButtonTcpClient.TabStop = true;
            this.radioButtonTcpClient.Text = "TCP客户端(GPRS)";
            this.radioButtonTcpClient.UseVisualStyleBackColor = true;
            this.radioButtonTcpClient.CheckedChanged += new System.EventHandler(this.radioButtonTcpClient_CheckedChanged);
            // 
            // radioButtonTcpServer
            // 
            this.radioButtonTcpServer.AutoSize = true;
            this.radioButtonTcpServer.Location = new System.Drawing.Point(225, 76);
            this.radioButtonTcpServer.Name = "radioButtonTcpServer";
            this.radioButtonTcpServer.Size = new System.Drawing.Size(77, 16);
            this.radioButtonTcpServer.TabIndex = 3;
            this.radioButtonTcpServer.TabStop = true;
            this.radioButtonTcpServer.Text = "TCP服务器";
            this.radioButtonTcpServer.UseVisualStyleBackColor = true;
            this.radioButtonTcpServer.CheckedChanged += new System.EventHandler(this.radioButtonTcpServer_CheckedChanged);
            // 
            // labelPortName
            // 
            this.labelPortName.AutoSize = true;
            this.labelPortName.Location = new System.Drawing.Point(12, 107);
            this.labelPortName.Name = "labelPortName";
            this.labelPortName.Size = new System.Drawing.Size(41, 12);
            this.labelPortName.TabIndex = 7;
            this.labelPortName.Text = "端口名";
            // 
            // textBoxPortName
            // 
            this.textBoxPortName.Location = new System.Drawing.Point(99, 104);
            this.textBoxPortName.Name = "textBoxPortName";
            this.textBoxPortName.Size = new System.Drawing.Size(203, 21);
            this.textBoxPortName.TabIndex = 4;
            // 
            // labelSelOilStation
            // 
            this.labelSelOilStation.AutoSize = true;
            this.labelSelOilStation.Location = new System.Drawing.Point(14, 13);
            this.labelSelOilStation.Name = "labelSelOilStation";
            this.labelSelOilStation.Size = new System.Drawing.Size(65, 12);
            this.labelSelOilStation.TabIndex = 9;
            this.labelSelOilStation.Text = "选择加油站";
            // 
            // comboBoxSelOilStation
            // 
            this.comboBoxSelOilStation.FormattingEnabled = true;
            this.comboBoxSelOilStation.Location = new System.Drawing.Point(119, 10);
            this.comboBoxSelOilStation.Name = "comboBoxSelOilStation";
            this.comboBoxSelOilStation.Size = new System.Drawing.Size(183, 20);
            this.comboBoxSelOilStation.TabIndex = 0;
            // 
            // FormAddDev
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(463, 366);
            this.Controls.Add(this.comboBoxSelOilStation);
            this.Controls.Add(this.labelSelOilStation);
            this.Controls.Add(this.textBoxPortName);
            this.Controls.Add(this.labelPortName);
            this.Controls.Add(this.radioButtonTcpServer);
            this.Controls.Add(this.radioButtonTcpClient);
            this.Controls.Add(this.radioButtonSerial);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.groupBoxPortDetailInfo);
            this.Controls.Add(this.labelDevType);
            this.Name = "FormAddDev";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加端口 added languange xml";
            this.Load += new System.EventHandler(this.FormAddDev_Load);
            this.groupBoxPortDetailInfo.ResumeLayout(false);
            this.panelTcpServerInfo.ResumeLayout(false);
            this.panelTcpServerInfo.PerformLayout();
            this.panelSerailInfo.ResumeLayout(false);
            this.panelSerailInfo.PerformLayout();
            this.panelTcpClientInfo.ResumeLayout(false);
            this.panelTcpClientInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDevType;
        private System.Windows.Forms.GroupBox groupBoxPortDetailInfo;
        private System.Windows.Forms.Label labelComPort;
        private System.Windows.Forms.Label labelTcpServerIP;
        private System.Windows.Forms.Panel panelTcpClientInfo;
        private System.Windows.Forms.TextBox textBoxTCPClientID;
        private System.Windows.Forms.Label labelGprsClientInfo;
        private System.Windows.Forms.Panel panelTcpServerInfo;
        private System.Windows.Forms.TextBox textBoxTcpServerPort;
        private System.Windows.Forms.Label labelTcpSeverPort;
        private System.Windows.Forms.TextBox textBoxTcpServerIP;
        private System.Windows.Forms.Panel panelSerailInfo;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.RadioButton radioButtonSerial;
        private System.Windows.Forms.RadioButton radioButtonTcpClient;
        private System.Windows.Forms.RadioButton radioButtonTcpServer;
        private System.Windows.Forms.Label labelPortName;
        private System.Windows.Forms.TextBox textBoxPortName;
        private System.Windows.Forms.Label labelSelOilStation;
        private System.Windows.Forms.ComboBox comboBoxSelOilStation;
        private System.Windows.Forms.ComboBox comboBoxSerialCom;
    }
}