namespace Property
{
    partial class FormCfgNormalInfo
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
            this.labelTypePrivew = new System.Windows.Forms.Label();
            this.labelSelType = new System.Windows.Forms.Label();
            this.treeViewCardType = new System.Windows.Forms.TreeView();
            this.labelAddr = new System.Windows.Forms.Label();
            this.buttonRead = new System.Windows.Forms.Button();
            this.labelScreenCount = new System.Windows.Forms.Label();
            this.comboBoxShowAppend = new System.Windows.Forms.ComboBox();
            this.labelSingleOrDouble = new System.Windows.Forms.Label();
            this.comboBoxLights = new System.Windows.Forms.ComboBox();
            this.labelDigCount = new System.Windows.Forms.Label();
            this.comboBoxDigNumCount = new System.Windows.Forms.ComboBox();
            this.textBoxReadID = new System.Windows.Forms.TextBox();
            this.comboBoxScreenCount = new System.Windows.Forms.ComboBox();
            this.labelBrightenss = new System.Windows.Forms.Label();
            this.comboBoxIsDouble = new System.Windows.Forms.ComboBox();
            this.labelIsShow910 = new System.Windows.Forms.Label();
            this.labelHardVersion = new System.Windows.Forms.Label();
            this.labelFirmewareVer = new System.Windows.Forms.Label();
            this.textBoxHardVer = new System.Windows.Forms.TextBox();
            this.buttonSetCfg = new System.Windows.Forms.Button();
            this.textBoxFVer = new System.Windows.Forms.TextBox();
            this.comboBoxID = new System.Windows.Forms.ComboBox();
            this.comboBoxCom = new System.Windows.Forms.ComboBox();
            this.FormMainCfg_labelSelID = new System.Windows.Forms.Label();
            this.labelSelComm = new System.Windows.Forms.Label();
            this.oilCardScreen1 = new SevenSegTest.OilCardScreen();
            this.groupBoxSelCommType = new System.Windows.Forms.GroupBox();
            this.radioButtonTCP = new System.Windows.Forms.RadioButton();
            this.textBoxDevPort = new System.Windows.Forms.TextBox();
            this.radioButtonCom = new System.Windows.Forms.RadioButton();
            this.textBoxTcpDevIp = new System.Windows.Forms.TextBox();
            this.labelTcpDevIp = new System.Windows.Forms.Label();
            this.labelTcpDevPort = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBoxSelCommType.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTypePrivew
            // 
            this.labelTypePrivew.AutoSize = true;
            this.labelTypePrivew.Location = new System.Drawing.Point(14, 345);
            this.labelTypePrivew.Name = "labelTypePrivew";
            this.labelTypePrivew.Size = new System.Drawing.Size(77, 12);
            this.labelTypePrivew.TabIndex = 59;
            this.labelTypePrivew.Text = "Type Preview";
            // 
            // labelSelType
            // 
            this.labelSelType.AutoSize = true;
            this.labelSelType.Location = new System.Drawing.Point(14, 148);
            this.labelSelType.Name = "labelSelType";
            this.labelSelType.Size = new System.Drawing.Size(107, 12);
            this.labelSelType.TabIndex = 58;
            this.labelSelType.Text = "Mody OilCard Type";
            // 
            // treeViewCardType
            // 
            this.treeViewCardType.HideSelection = false;
            this.treeViewCardType.Location = new System.Drawing.Point(16, 172);
            this.treeViewCardType.Name = "treeViewCardType";
            this.treeViewCardType.Size = new System.Drawing.Size(268, 147);
            this.treeViewCardType.TabIndex = 60;
            this.treeViewCardType.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewCardType_AfterSelect);
            this.treeViewCardType.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeViewCardType_MouseDown);
            this.treeViewCardType.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeViewCardType_MouseUp);
            // 
            // labelAddr
            // 
            this.labelAddr.AutoSize = true;
            this.labelAddr.Location = new System.Drawing.Point(433, 181);
            this.labelAddr.Name = "labelAddr";
            this.labelAddr.Size = new System.Drawing.Size(29, 12);
            this.labelAddr.TabIndex = 44;
            this.labelAddr.Text = "Addr";
            // 
            // buttonRead
            // 
            this.buttonRead.Location = new System.Drawing.Point(481, 409);
            this.buttonRead.Name = "buttonRead";
            this.buttonRead.Size = new System.Drawing.Size(75, 23);
            this.buttonRead.TabIndex = 40;
            this.buttonRead.Text = "Read";
            this.buttonRead.UseVisualStyleBackColor = true;
            this.buttonRead.Click += new System.EventHandler(this.buttonRead_Click);
            // 
            // labelScreenCount
            // 
            this.labelScreenCount.AutoSize = true;
            this.labelScreenCount.Location = new System.Drawing.Point(433, 299);
            this.labelScreenCount.Name = "labelScreenCount";
            this.labelScreenCount.Size = new System.Drawing.Size(77, 12);
            this.labelScreenCount.TabIndex = 45;
            this.labelScreenCount.Text = "Screen Count";
            // 
            // comboBoxShowAppend
            // 
            this.comboBoxShowAppend.BackColor = System.Drawing.SystemColors.ControlDark;
            this.comboBoxShowAppend.Enabled = false;
            this.comboBoxShowAppend.FormattingEnabled = true;
            this.comboBoxShowAppend.Items.AddRange(new object[] {
            "NO",
            "YES"});
            this.comboBoxShowAppend.Location = new System.Drawing.Point(540, 383);
            this.comboBoxShowAppend.Name = "comboBoxShowAppend";
            this.comboBoxShowAppend.Size = new System.Drawing.Size(97, 20);
            this.comboBoxShowAppend.TabIndex = 56;
            // 
            // labelSingleOrDouble
            // 
            this.labelSingleOrDouble.AutoSize = true;
            this.labelSingleOrDouble.Location = new System.Drawing.Point(433, 272);
            this.labelSingleOrDouble.Name = "labelSingleOrDouble";
            this.labelSingleOrDouble.Size = new System.Drawing.Size(83, 12);
            this.labelSingleOrDouble.TabIndex = 47;
            this.labelSingleOrDouble.Text = "Single/Double";
            // 
            // comboBoxLights
            // 
            this.comboBoxLights.FormattingEnabled = true;
            this.comboBoxLights.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.comboBoxLights.Location = new System.Drawing.Point(540, 354);
            this.comboBoxLights.Name = "comboBoxLights";
            this.comboBoxLights.Size = new System.Drawing.Size(97, 20);
            this.comboBoxLights.TabIndex = 54;
            // 
            // labelDigCount
            // 
            this.labelDigCount.AutoSize = true;
            this.labelDigCount.Location = new System.Drawing.Point(433, 327);
            this.labelDigCount.Name = "labelDigCount";
            this.labelDigCount.Size = new System.Drawing.Size(65, 12);
            this.labelDigCount.TabIndex = 41;
            this.labelDigCount.Text = "Digt Count";
            // 
            // comboBoxDigNumCount
            // 
            this.comboBoxDigNumCount.BackColor = System.Drawing.SystemColors.ControlDark;
            this.comboBoxDigNumCount.Enabled = false;
            this.comboBoxDigNumCount.FormattingEnabled = true;
            this.comboBoxDigNumCount.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.comboBoxDigNumCount.Location = new System.Drawing.Point(540, 319);
            this.comboBoxDigNumCount.Name = "comboBoxDigNumCount";
            this.comboBoxDigNumCount.Size = new System.Drawing.Size(97, 20);
            this.comboBoxDigNumCount.TabIndex = 57;
            // 
            // textBoxReadID
            // 
            this.textBoxReadID.BackColor = System.Drawing.SystemColors.ControlDark;
            this.textBoxReadID.Enabled = false;
            this.textBoxReadID.Location = new System.Drawing.Point(540, 172);
            this.textBoxReadID.Name = "textBoxReadID";
            this.textBoxReadID.ReadOnly = true;
            this.textBoxReadID.Size = new System.Drawing.Size(97, 21);
            this.textBoxReadID.TabIndex = 50;
            // 
            // comboBoxScreenCount
            // 
            this.comboBoxScreenCount.FormattingEnabled = true;
            this.comboBoxScreenCount.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.comboBoxScreenCount.Location = new System.Drawing.Point(540, 291);
            this.comboBoxScreenCount.Name = "comboBoxScreenCount";
            this.comboBoxScreenCount.Size = new System.Drawing.Size(97, 20);
            this.comboBoxScreenCount.TabIndex = 53;
            // 
            // labelBrightenss
            // 
            this.labelBrightenss.AutoSize = true;
            this.labelBrightenss.Location = new System.Drawing.Point(433, 357);
            this.labelBrightenss.Name = "labelBrightenss";
            this.labelBrightenss.Size = new System.Drawing.Size(65, 12);
            this.labelBrightenss.TabIndex = 48;
            this.labelBrightenss.Text = "Brightness";
            // 
            // comboBoxIsDouble
            // 
            this.comboBoxIsDouble.FormattingEnabled = true;
            this.comboBoxIsDouble.Items.AddRange(new object[] {
            "1",
            "2"});
            this.comboBoxIsDouble.Location = new System.Drawing.Point(540, 264);
            this.comboBoxIsDouble.Name = "comboBoxIsDouble";
            this.comboBoxIsDouble.Size = new System.Drawing.Size(97, 20);
            this.comboBoxIsDouble.TabIndex = 55;
            // 
            // labelIsShow910
            // 
            this.labelIsShow910.AutoSize = true;
            this.labelIsShow910.Location = new System.Drawing.Point(433, 386);
            this.labelIsShow910.Name = "labelIsShow910";
            this.labelIsShow910.Size = new System.Drawing.Size(77, 12);
            this.labelIsShow910.TabIndex = 46;
            this.labelIsShow910.Text = "Is Show 9/10";
            // 
            // labelHardVersion
            // 
            this.labelHardVersion.AutoSize = true;
            this.labelHardVersion.Location = new System.Drawing.Point(433, 208);
            this.labelHardVersion.Name = "labelHardVersion";
            this.labelHardVersion.Size = new System.Drawing.Size(101, 12);
            this.labelHardVersion.TabIndex = 43;
            this.labelHardVersion.Text = "Hardware Version";
            // 
            // labelFirmewareVer
            // 
            this.labelFirmewareVer.AutoSize = true;
            this.labelFirmewareVer.Location = new System.Drawing.Point(433, 236);
            this.labelFirmewareVer.Name = "labelFirmewareVer";
            this.labelFirmewareVer.Size = new System.Drawing.Size(107, 12);
            this.labelFirmewareVer.TabIndex = 42;
            this.labelFirmewareVer.Text = "Firmeware Version";
            // 
            // textBoxHardVer
            // 
            this.textBoxHardVer.BackColor = System.Drawing.SystemColors.ControlDark;
            this.textBoxHardVer.Enabled = false;
            this.textBoxHardVer.Location = new System.Drawing.Point(540, 199);
            this.textBoxHardVer.Name = "textBoxHardVer";
            this.textBoxHardVer.ReadOnly = true;
            this.textBoxHardVer.Size = new System.Drawing.Size(97, 21);
            this.textBoxHardVer.TabIndex = 49;
            // 
            // buttonSetCfg
            // 
            this.buttonSetCfg.Location = new System.Drawing.Point(562, 409);
            this.buttonSetCfg.Name = "buttonSetCfg";
            this.buttonSetCfg.Size = new System.Drawing.Size(75, 23);
            this.buttonSetCfg.TabIndex = 52;
            this.buttonSetCfg.Text = "Write";
            this.buttonSetCfg.UseVisualStyleBackColor = true;
            this.buttonSetCfg.Click += new System.EventHandler(this.buttonSetCfg_Click);
            // 
            // textBoxFVer
            // 
            this.textBoxFVer.BackColor = System.Drawing.SystemColors.ControlDark;
            this.textBoxFVer.Enabled = false;
            this.textBoxFVer.Location = new System.Drawing.Point(540, 227);
            this.textBoxFVer.Name = "textBoxFVer";
            this.textBoxFVer.ReadOnly = true;
            this.textBoxFVer.Size = new System.Drawing.Size(97, 21);
            this.textBoxFVer.TabIndex = 51;
            // 
            // comboBoxID
            // 
            this.comboBoxID.FormattingEnabled = true;
            this.comboBoxID.Location = new System.Drawing.Point(389, 9);
            this.comboBoxID.Name = "comboBoxID";
            this.comboBoxID.Size = new System.Drawing.Size(121, 20);
            this.comboBoxID.TabIndex = 64;
            // 
            // comboBoxCom
            // 
            this.comboBoxCom.FormattingEnabled = true;
            this.comboBoxCom.Location = new System.Drawing.Point(76, 45);
            this.comboBoxCom.Name = "comboBoxCom";
            this.comboBoxCom.Size = new System.Drawing.Size(158, 20);
            this.comboBoxCom.TabIndex = 65;
            // 
            // FormMainCfg_labelSelID
            // 
            this.FormMainCfg_labelSelID.AutoSize = true;
            this.FormMainCfg_labelSelID.BackColor = System.Drawing.Color.Transparent;
            this.FormMainCfg_labelSelID.Location = new System.Drawing.Point(330, 17);
            this.FormMainCfg_labelSelID.Name = "FormMainCfg_labelSelID";
            this.FormMainCfg_labelSelID.Size = new System.Drawing.Size(41, 12);
            this.FormMainCfg_labelSelID.TabIndex = 62;
            this.FormMainCfg_labelSelID.Text = "选择ID";
            // 
            // labelSelComm
            // 
            this.labelSelComm.AutoSize = true;
            this.labelSelComm.BackColor = System.Drawing.Color.Transparent;
            this.labelSelComm.Location = new System.Drawing.Point(17, 48);
            this.labelSelComm.Name = "labelSelComm";
            this.labelSelComm.Size = new System.Drawing.Size(53, 12);
            this.labelSelComm.TabIndex = 63;
            this.labelSelComm.Text = "选择串口";
            // 
            // oilCardScreen1
            // 
            this.oilCardScreen1.BackColor = System.Drawing.Color.Black;
            this.oilCardScreen1.bEnableMdy = false;
            this.oilCardScreen1.bShow10_9 = false;
            this.oilCardScreen1.DigValue = "888888";
            this.oilCardScreen1.iAppend99Height = 32;
            this.oilCardScreen1.iAppend99Width = 16;
            this.oilCardScreen1.iDecmialInMain = 1;
            this.oilCardScreen1.iMainDigHeigh = 64;
            this.oilCardScreen1.iMainDigWidth = 32;
            this.oilCardScreen1.iOilCardDigCount = 6;
            this.oilCardScreen1.iShow99 = 0;
            this.oilCardScreen1.Location = new System.Drawing.Point(16, 361);
            this.oilCardScreen1.Name = "oilCardScreen1";
            this.oilCardScreen1.Size = new System.Drawing.Size(288, 67);
            this.oilCardScreen1.TabIndex = 67;
            // 
            // groupBoxSelCommType
            // 
            this.groupBoxSelCommType.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxSelCommType.Controls.Add(this.radioButtonTCP);
            this.groupBoxSelCommType.Controls.Add(this.textBoxDevPort);
            this.groupBoxSelCommType.Controls.Add(this.radioButtonCom);
            this.groupBoxSelCommType.Controls.Add(this.comboBoxCom);
            this.groupBoxSelCommType.Controls.Add(this.textBoxTcpDevIp);
            this.groupBoxSelCommType.Controls.Add(this.labelSelComm);
            this.groupBoxSelCommType.Controls.Add(this.labelTcpDevIp);
            this.groupBoxSelCommType.Controls.Add(this.labelTcpDevPort);
            this.groupBoxSelCommType.Font = new System.Drawing.Font("宋体", 9F);
            this.groupBoxSelCommType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBoxSelCommType.Location = new System.Drawing.Point(16, 9);
            this.groupBoxSelCommType.Name = "groupBoxSelCommType";
            this.groupBoxSelCommType.Size = new System.Drawing.Size(271, 124);
            this.groupBoxSelCommType.TabIndex = 68;
            this.groupBoxSelCommType.TabStop = false;
            this.groupBoxSelCommType.Text = "选择通信方式";
            // 
            // radioButtonTCP
            // 
            this.radioButtonTCP.AutoSize = true;
            this.radioButtonTCP.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonTCP.Font = new System.Drawing.Font("宋体", 9F);
            this.radioButtonTCP.Location = new System.Drawing.Point(184, 12);
            this.radioButtonTCP.Name = "radioButtonTCP";
            this.radioButtonTCP.Size = new System.Drawing.Size(41, 16);
            this.radioButtonTCP.TabIndex = 16;
            this.radioButtonTCP.Text = "TCP";
            this.radioButtonTCP.UseVisualStyleBackColor = false;
            this.radioButtonTCP.CheckedChanged += new System.EventHandler(this.radioButtonTCP_CheckedChanged);
            // 
            // textBoxDevPort
            // 
            this.textBoxDevPort.Location = new System.Drawing.Point(76, 98);
            this.textBoxDevPort.Name = "textBoxDevPort";
            this.textBoxDevPort.Size = new System.Drawing.Size(158, 21);
            this.textBoxDevPort.TabIndex = 15;
            // 
            // radioButtonCom
            // 
            this.radioButtonCom.AutoSize = true;
            this.radioButtonCom.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonCom.Checked = true;
            this.radioButtonCom.Font = new System.Drawing.Font("宋体", 9F);
            this.radioButtonCom.Location = new System.Drawing.Point(106, 12);
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
            this.textBoxTcpDevIp.Location = new System.Drawing.Point(76, 71);
            this.textBoxTcpDevIp.Name = "textBoxTcpDevIp";
            this.textBoxTcpDevIp.Size = new System.Drawing.Size(158, 21);
            this.textBoxTcpDevIp.TabIndex = 15;
            // 
            // labelTcpDevIp
            // 
            this.labelTcpDevIp.AutoSize = true;
            this.labelTcpDevIp.BackColor = System.Drawing.Color.Transparent;
            this.labelTcpDevIp.Font = new System.Drawing.Font("宋体", 9F);
            this.labelTcpDevIp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelTcpDevIp.Location = new System.Drawing.Point(14, 75);
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
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormCfgNormalInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 492);
            this.Controls.Add(this.groupBoxSelCommType);
            this.Controls.Add(this.oilCardScreen1);
            this.Controls.Add(this.comboBoxID);
            this.Controls.Add(this.FormMainCfg_labelSelID);
            this.Controls.Add(this.labelTypePrivew);
            this.Controls.Add(this.labelSelType);
            this.Controls.Add(this.treeViewCardType);
            this.Controls.Add(this.labelAddr);
            this.Controls.Add(this.buttonRead);
            this.Controls.Add(this.labelScreenCount);
            this.Controls.Add(this.comboBoxShowAppend);
            this.Controls.Add(this.labelSingleOrDouble);
            this.Controls.Add(this.comboBoxLights);
            this.Controls.Add(this.labelDigCount);
            this.Controls.Add(this.comboBoxDigNumCount);
            this.Controls.Add(this.textBoxReadID);
            this.Controls.Add(this.comboBoxScreenCount);
            this.Controls.Add(this.labelBrightenss);
            this.Controls.Add(this.comboBoxIsDouble);
            this.Controls.Add(this.labelIsShow910);
            this.Controls.Add(this.labelHardVersion);
            this.Controls.Add(this.labelFirmewareVer);
            this.Controls.Add(this.textBoxHardVer);
            this.Controls.Add(this.buttonSetCfg);
            this.Controls.Add(this.textBoxFVer);
            this.Name = "FormCfgNormalInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormSetNormalInfo added language";
            this.Load += new System.EventHandler(this.FormCfgNormalInfo_Load);
            this.groupBoxSelCommType.ResumeLayout(false);
            this.groupBoxSelCommType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTypePrivew;
        private System.Windows.Forms.Label labelSelType;
        private System.Windows.Forms.TreeView treeViewCardType;
        private System.Windows.Forms.Label labelAddr;
        private System.Windows.Forms.Button buttonRead;
        private System.Windows.Forms.Label labelScreenCount;
        private System.Windows.Forms.ComboBox comboBoxShowAppend;
        private System.Windows.Forms.Label labelSingleOrDouble;
        private System.Windows.Forms.ComboBox comboBoxLights;
        private System.Windows.Forms.Label labelDigCount;
        private System.Windows.Forms.ComboBox comboBoxDigNumCount;
        private System.Windows.Forms.TextBox textBoxReadID;
        private System.Windows.Forms.ComboBox comboBoxScreenCount;
        private System.Windows.Forms.Label labelBrightenss;
        private System.Windows.Forms.ComboBox comboBoxIsDouble;
        private System.Windows.Forms.Label labelIsShow910;
        private System.Windows.Forms.Label labelHardVersion;
        private System.Windows.Forms.Label labelFirmewareVer;
        private System.Windows.Forms.TextBox textBoxHardVer;
        private System.Windows.Forms.Button buttonSetCfg;
        private System.Windows.Forms.TextBox textBoxFVer;
        private System.Windows.Forms.ComboBox comboBoxID;
        private System.Windows.Forms.ComboBox comboBoxCom;
        private System.Windows.Forms.Label FormMainCfg_labelSelID;
        private System.Windows.Forms.Label labelSelComm;
        private SevenSegTest.OilCardScreen oilCardScreen1;
        private System.Windows.Forms.GroupBox groupBoxSelCommType;
        private System.Windows.Forms.RadioButton radioButtonTCP;
        private System.Windows.Forms.TextBox textBoxDevPort;
        private System.Windows.Forms.RadioButton radioButtonCom;
        private System.Windows.Forms.TextBox textBoxTcpDevIp;
        private System.Windows.Forms.Label labelTcpDevIp;
        private System.Windows.Forms.Label labelTcpDevPort;
        private System.Windows.Forms.Timer timer1;
    }
}