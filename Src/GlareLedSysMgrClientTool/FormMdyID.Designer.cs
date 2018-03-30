namespace Property
{
    partial class FormMdyID
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
            this.buttonSetID = new System.Windows.Forms.Button();
            this.textBoxNewID = new System.Windows.Forms.TextBox();
            this.labelTipNewID = new System.Windows.Forms.Label();
            this.comboBoxComm = new System.Windows.Forms.ComboBox();
            this.labelPcCom = new System.Windows.Forms.Label();
            this.groupBoxCommType = new System.Windows.Forms.GroupBox();
            this.radioButtonTCP = new System.Windows.Forms.RadioButton();
            this.textBoxDevPort = new System.Windows.Forms.TextBox();
            this.radioButtonCom = new System.Windows.Forms.RadioButton();
            this.textBoxTcpDevIp = new System.Windows.Forms.TextBox();
            this.labelTcpDevIp = new System.Windows.Forms.Label();
            this.labelTcpDevPort = new System.Windows.Forms.Label();
            this.groupBoxCommType.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSetID
            // 
            this.buttonSetID.Location = new System.Drawing.Point(162, 190);
            this.buttonSetID.Name = "buttonSetID";
            this.buttonSetID.Size = new System.Drawing.Size(75, 23);
            this.buttonSetID.TabIndex = 11;
            this.buttonSetID.Text = "设置";
            this.buttonSetID.UseVisualStyleBackColor = true;
            this.buttonSetID.Click += new System.EventHandler(this.buttonSetID_Click);
            // 
            // textBoxNewID
            // 
            this.textBoxNewID.Location = new System.Drawing.Point(116, 153);
            this.textBoxNewID.Name = "textBoxNewID";
            this.textBoxNewID.Size = new System.Drawing.Size(121, 21);
            this.textBoxNewID.TabIndex = 13;
            // 
            // labelTipNewID
            // 
            this.labelTipNewID.AutoSize = true;
            this.labelTipNewID.Location = new System.Drawing.Point(12, 156);
            this.labelTipNewID.Name = "labelTipNewID";
            this.labelTipNewID.Size = new System.Drawing.Size(41, 12);
            this.labelTipNewID.TabIndex = 12;
            this.labelTipNewID.Text = "输入ID";
            // 
            // comboBoxComm
            // 
            this.comboBoxComm.FormattingEnabled = true;
            this.comboBoxComm.Location = new System.Drawing.Point(113, 36);
            this.comboBoxComm.Name = "comboBoxComm";
            this.comboBoxComm.Size = new System.Drawing.Size(121, 20);
            this.comboBoxComm.TabIndex = 15;
            // 
            // labelPcCom
            // 
            this.labelPcCom.AutoSize = true;
            this.labelPcCom.BackColor = System.Drawing.Color.Transparent;
            this.labelPcCom.Font = new System.Drawing.Font("宋体", 9F);
            this.labelPcCom.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelPcCom.Location = new System.Drawing.Point(14, 39);
            this.labelPcCom.Name = "labelPcCom";
            this.labelPcCom.Size = new System.Drawing.Size(53, 12);
            this.labelPcCom.TabIndex = 14;
            this.labelPcCom.Text = "选择串口";
            // 
            // groupBoxCommType
            // 
            this.groupBoxCommType.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxCommType.Controls.Add(this.radioButtonTCP);
            this.groupBoxCommType.Controls.Add(this.comboBoxComm);
            this.groupBoxCommType.Controls.Add(this.labelPcCom);
            this.groupBoxCommType.Controls.Add(this.textBoxDevPort);
            this.groupBoxCommType.Controls.Add(this.radioButtonCom);
            this.groupBoxCommType.Controls.Add(this.textBoxTcpDevIp);
            this.groupBoxCommType.Controls.Add(this.labelTcpDevIp);
            this.groupBoxCommType.Controls.Add(this.labelTcpDevPort);
            this.groupBoxCommType.Font = new System.Drawing.Font("宋体", 9F);
            this.groupBoxCommType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBoxCommType.Location = new System.Drawing.Point(3, 12);
            this.groupBoxCommType.Name = "groupBoxCommType";
            this.groupBoxCommType.Size = new System.Drawing.Size(262, 135);
            this.groupBoxCommType.TabIndex = 18;
            this.groupBoxCommType.TabStop = false;
            this.groupBoxCommType.Text = "选择通信方式";
            // 
            // radioButtonTCP
            // 
            this.radioButtonTCP.AutoSize = true;
            this.radioButtonTCP.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonTCP.Font = new System.Drawing.Font("宋体", 9F);
            this.radioButtonTCP.Location = new System.Drawing.Point(193, 14);
            this.radioButtonTCP.Name = "radioButtonTCP";
            this.radioButtonTCP.Size = new System.Drawing.Size(41, 16);
            this.radioButtonTCP.TabIndex = 16;
            this.radioButtonTCP.Text = "TCP";
            this.radioButtonTCP.UseVisualStyleBackColor = false;
            this.radioButtonTCP.CheckedChanged += new System.EventHandler(this.radioButtonTCP_CheckedChanged);
            // 
            // textBoxDevPort
            // 
            this.textBoxDevPort.Location = new System.Drawing.Point(113, 98);
            this.textBoxDevPort.Name = "textBoxDevPort";
            this.textBoxDevPort.Size = new System.Drawing.Size(121, 21);
            this.textBoxDevPort.TabIndex = 15;
            // 
            // radioButtonCom
            // 
            this.radioButtonCom.AutoSize = true;
            this.radioButtonCom.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonCom.Checked = true;
            this.radioButtonCom.Font = new System.Drawing.Font("宋体", 9F);
            this.radioButtonCom.Location = new System.Drawing.Point(132, 14);
            this.radioButtonCom.Name = "radioButtonCom";
            this.radioButtonCom.Size = new System.Drawing.Size(41, 16);
            this.radioButtonCom.TabIndex = 16;
            this.radioButtonCom.TabStop = true;
            this.radioButtonCom.Text = "COM";
            this.radioButtonCom.UseVisualStyleBackColor = false;
            this.radioButtonCom.CheckedChanged += new System.EventHandler(this.radioButtonCom_CheckedChanged);
            // 
            // textBoxTcpDevIp
            // 
            this.textBoxTcpDevIp.Location = new System.Drawing.Point(113, 71);
            this.textBoxTcpDevIp.Name = "textBoxTcpDevIp";
            this.textBoxTcpDevIp.Size = new System.Drawing.Size(121, 21);
            this.textBoxTcpDevIp.TabIndex = 15;
            // 
            // labelTcpDevIp
            // 
            this.labelTcpDevIp.AutoSize = true;
            this.labelTcpDevIp.BackColor = System.Drawing.Color.Transparent;
            this.labelTcpDevIp.Font = new System.Drawing.Font("宋体", 9F);
            this.labelTcpDevIp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelTcpDevIp.Location = new System.Drawing.Point(14, 74);
            this.labelTcpDevIp.Name = "labelTcpDevIp";
            this.labelTcpDevIp.Size = new System.Drawing.Size(17, 12);
            this.labelTcpDevIp.TabIndex = 4;
            this.labelTcpDevIp.Text = "IP";
            // 
            // labelTcpDevPort
            // 
            this.labelTcpDevPort.AutoSize = true;
            this.labelTcpDevPort.BackColor = System.Drawing.Color.Transparent;
            this.labelTcpDevPort.Font = new System.Drawing.Font("宋体", 9F);
            this.labelTcpDevPort.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelTcpDevPort.Location = new System.Drawing.Point(14, 99);
            this.labelTcpDevPort.Name = "labelTcpDevPort";
            this.labelTcpDevPort.Size = new System.Drawing.Size(41, 12);
            this.labelTcpDevPort.TabIndex = 4;
            this.labelTcpDevPort.Text = "端口号";
            // 
            // FormMdyID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 244);
            this.Controls.Add(this.groupBoxCommType);
            this.Controls.Add(this.buttonSetID);
            this.Controls.Add(this.textBoxNewID);
            this.Controls.Add(this.labelTipNewID);
            this.Name = "FormMdyID";
            this.Text = "修改ID";
            this.Load += new System.EventHandler(this.FormMdyID_Load);
            this.groupBoxCommType.ResumeLayout(false);
            this.groupBoxCommType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSetID;
        private System.Windows.Forms.TextBox textBoxNewID;
        private System.Windows.Forms.Label labelTipNewID;
        private System.Windows.Forms.ComboBox comboBoxComm;
        private System.Windows.Forms.Label labelPcCom;
        private System.Windows.Forms.GroupBox groupBoxCommType;
        private System.Windows.Forms.RadioButton radioButtonTCP;
        private System.Windows.Forms.TextBox textBoxDevPort;
        private System.Windows.Forms.RadioButton radioButtonCom;
        private System.Windows.Forms.TextBox textBoxTcpDevIp;
        private System.Windows.Forms.Label labelTcpDevIp;
        private System.Windows.Forms.Label labelTcpDevPort;
    }
}