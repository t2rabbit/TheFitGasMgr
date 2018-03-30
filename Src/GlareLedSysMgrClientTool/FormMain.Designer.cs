namespace Property
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("1号设备（油价牌）");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("2号设备（温湿度时间）");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("3号温湿度时间");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("串口1", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("计算机串口", new System.Windows.Forms.TreeNode[] {
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("1号设备");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("2号设备");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("192.168.0.11", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("以太网设备", new System.Windows.Forms.TreeNode[] {
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("路口LED");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("站内LED");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("九沟加油站GPRS", new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode11});
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("油价牌");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("市新加油站GPRS", new System.Windows.Forms.TreeNode[] {
            treeNode13});
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("GPRS设备", new System.Windows.Forms.TreeNode[] {
            treeNode12,
            treeNode14});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("1号设备（油价牌）");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("2号设备（温湿度时间）");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("3号温湿度时间");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("串口1", new System.Windows.Forms.TreeNode[] {
            treeNode16,
            treeNode17,
            treeNode18});
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("计算机串口", new System.Windows.Forms.TreeNode[] {
            treeNode19});
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("1号设备");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("2号设备");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("192.168.0.11", new System.Windows.Forms.TreeNode[] {
            treeNode21,
            treeNode22});
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("以太网设备", new System.Windows.Forms.TreeNode[] {
            treeNode23});
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("路口LED");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("站内LED");
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("九沟加油站GPRS", new System.Windows.Forms.TreeNode[] {
            treeNode25,
            treeNode26});
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("油价牌");
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("市新加油站GPRS", new System.Windows.Forms.TreeNode[] {
            treeNode28});
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("GPRS设备", new System.Windows.Forms.TreeNode[] {
            treeNode27,
            treeNode29});
            this.mainscript = new System.Windows.Forms.MenuStrip();
            this.SysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DevMgrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CfgToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.简体中文ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.繁体中文ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.英语ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelWsLeft = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.radioButtonListByOrg = new System.Windows.Forms.RadioButton();
            this.radioButtonListByItf = new System.Windows.Forms.RadioButton();
            this.buttonRFresh = new System.Windows.Forms.Button();
            this.labelDevList = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonTCPServerStop = new System.Windows.Forms.Button();
            this.buttonStartTCP = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelGPRSServerStat = new System.Windows.Forms.Label();
            this.labelGprsInfo = new System.Windows.Forms.Label();
            this.panelWorkSpace = new System.Windows.Forms.Panel();
            this.timerUpdateGPRSDev = new System.Windows.Forms.Timer(this.components);
            this.panelLog = new System.Windows.Forms.Panel();
            this.listViewLogForDC = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel5 = new System.Windows.Forms.Panel();
            this.buttonClearLog = new System.Windows.Forms.Button();
            this.labelLogFilType1 = new System.Windows.Forms.Label();
            this.textBoxFiltc3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBoxShowLog = new System.Windows.Forms.CheckBox();
            this.textBoxFiltc2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxFiltLogM = new System.Windows.Forms.TextBox();
            this.textBoxFiltC1 = new System.Windows.Forms.TextBox();
            this.labelLogFilMod = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPageCtrlPanel = new System.Windows.Forms.TabPage();
            this.treeViewOrgMoniter = new System.Windows.Forms.TreeView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.buttonRefreshCenOrg = new System.Windows.Forms.Button();
            this.labelOilStaList = new System.Windows.Forms.Label();
            this.buttonStartDC = new System.Windows.Forms.Button();
            this.buttonShowHideLog = new System.Windows.Forms.Button();
            this.timerUpdateOrg = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonExSelLanguage = new System.Windows.Forms.Button();
            this.buttonSysUserMgr = new System.Windows.Forms.Button();
            this.buttonDevMgr = new System.Windows.Forms.Button();
            this.contextMenuStripLanguage = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.timerSendEMailOrReset = new System.Windows.Forms.Timer(this.components);
            this.mainscript.SuspendLayout();
            this.panelWsLeft.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelLog.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPageCtrlPanel.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainscript
            // 
            this.mainscript.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.mainscript.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SysToolStripMenuItem,
            this.ToolToolStripMenuItem,
            this.SettingToolStripMenuItem,
            this.HelpToolStripMenuItem,
            this.languageToolStripMenuItem});
            this.mainscript.Location = new System.Drawing.Point(0, 0);
            this.mainscript.Name = "mainscript";
            this.mainscript.Size = new System.Drawing.Size(673, 24);
            this.mainscript.TabIndex = 8;
            this.mainscript.Visible = false;
            // 
            // SysToolStripMenuItem
            // 
            this.SysToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DevMgrToolStripMenuItem});
            this.SysToolStripMenuItem.Name = "SysToolStripMenuItem";
            this.SysToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.SysToolStripMenuItem.Text = "系统(&S)";
            // 
            // DevMgrToolStripMenuItem
            // 
            this.DevMgrToolStripMenuItem.Name = "DevMgrToolStripMenuItem";
            this.DevMgrToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.DevMgrToolStripMenuItem.Text = "设备管理(&D)";
            this.DevMgrToolStripMenuItem.Click += new System.EventHandler(this.DevMgrToolStripMenuItem_Click);
            // 
            // ToolToolStripMenuItem
            // 
            this.ToolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CfgToolToolStripMenuItem});
            this.ToolToolStripMenuItem.Name = "ToolToolStripMenuItem";
            this.ToolToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.ToolToolStripMenuItem.Text = "工具(&T)";
            // 
            // CfgToolToolStripMenuItem
            // 
            this.CfgToolToolStripMenuItem.Name = "CfgToolToolStripMenuItem";
            this.CfgToolToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.CfgToolToolStripMenuItem.Text = "配置工具(&C)";
            this.CfgToolToolStripMenuItem.Click += new System.EventHandler(this.CfgToolToolStripMenuItem_Click);
            // 
            // SettingToolStripMenuItem
            // 
            this.SettingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConTypeToolStripMenuItem});
            this.SettingToolStripMenuItem.Name = "SettingToolStripMenuItem";
            this.SettingToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.SettingToolStripMenuItem.Text = "设置(&C)";
            // 
            // ConTypeToolStripMenuItem
            // 
            this.ConTypeToolStripMenuItem.Name = "ConTypeToolStripMenuItem";
            this.ConTypeToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.ConTypeToolStripMenuItem.Text = "连接方式(&T)";
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.HelpToolStripMenuItem.Text = "帮助(&H)";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.简体中文ToolStripMenuItem,
            this.繁体中文ToolStripMenuItem,
            this.英语ToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.languageToolStripMenuItem.Text = "语言(&L)";
            // 
            // 简体中文ToolStripMenuItem
            // 
            this.简体中文ToolStripMenuItem.Name = "简体中文ToolStripMenuItem";
            this.简体中文ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.简体中文ToolStripMenuItem.Text = "简体中文";
            this.简体中文ToolStripMenuItem.Click += new System.EventHandler(this.简体中文ToolStripMenuItem_Click);
            // 
            // 繁体中文ToolStripMenuItem
            // 
            this.繁体中文ToolStripMenuItem.Name = "繁体中文ToolStripMenuItem";
            this.繁体中文ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.繁体中文ToolStripMenuItem.Text = "繁体中文";
            // 
            // 英语ToolStripMenuItem
            // 
            this.英语ToolStripMenuItem.Name = "英语ToolStripMenuItem";
            this.英语ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.英语ToolStripMenuItem.Text = "English";
            // 
            // panelWsLeft
            // 
            this.panelWsLeft.Controls.Add(this.treeView1);
            this.panelWsLeft.Controls.Add(this.panel3);
            this.panelWsLeft.Controls.Add(this.panel4);
            this.panelWsLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelWsLeft.Location = new System.Drawing.Point(0, 0);
            this.panelWsLeft.Name = "panelWsLeft";
            this.panelWsLeft.Size = new System.Drawing.Size(387, 454);
            this.panelWsLeft.TabIndex = 2;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.HideSelection = false;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(0, 64);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "节点5";
            treeNode1.Tag = "1";
            treeNode1.Text = "1号设备（油价牌）";
            treeNode2.Name = "节点6";
            treeNode2.Tag = "2";
            treeNode2.Text = "2号设备（温湿度时间）";
            treeNode3.Name = "节点0";
            treeNode3.Tag = "2";
            treeNode3.Text = "3号温湿度时间";
            treeNode4.Name = "节点4";
            treeNode4.Text = "串口1";
            treeNode5.Name = "节点0";
            treeNode5.Text = "计算机串口";
            treeNode6.Name = "节点8";
            treeNode6.Text = "1号设备";
            treeNode7.Name = "节点9";
            treeNode7.Text = "2号设备";
            treeNode8.Name = "节点7";
            treeNode8.Text = "192.168.0.11";
            treeNode9.Name = "节点1";
            treeNode9.Text = "以太网设备";
            treeNode10.Name = "节点11";
            treeNode10.Text = "路口LED";
            treeNode11.Name = "节点12";
            treeNode11.Text = "站内LED";
            treeNode12.Name = "节点10";
            treeNode12.Text = "九沟加油站GPRS";
            treeNode13.Name = "节点14";
            treeNode13.Text = "油价牌";
            treeNode14.Name = "节点13";
            treeNode14.Text = "市新加油站GPRS";
            treeNode15.Name = "节点2";
            treeNode15.Text = "GPRS设备";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode9,
            treeNode15});
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(387, 314);
            this.treeView1.TabIndex = 3;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "bullet_ball_yellow.png");
            this.imageList1.Images.SetKeyName(1, "bullet_ball_green.png");
            this.imageList1.Images.SetKeyName(2, "bullet_triangle_yellow.png");
            this.imageList1.Images.SetKeyName(3, "bullet_triangle_green.png");
            this.imageList1.Images.SetKeyName(4, "bullet_square_blue.png");
            this.imageList1.Images.SetKeyName(5, "bullet_square_green.png");
            this.imageList1.Images.SetKeyName(6, "bullet_square_red.png");
            this.imageList1.Images.SetKeyName(7, "bullet_square_yellow.png");
            this.imageList1.Images.SetKeyName(8, "bullet_triangle_blue.png");
            this.imageList1.Images.SetKeyName(9, "bullet_triangle_red.png");
            this.imageList1.Images.SetKeyName(10, "bullet_ball_blue.png");
            this.imageList1.Images.SetKeyName(11, "bullet_ball_red.png");
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pictureBox8);
            this.panel3.Controls.Add(this.radioButtonListByOrg);
            this.panel3.Controls.Add(this.radioButtonListByItf);
            this.panel3.Controls.Add(this.buttonRFresh);
            this.panel3.Controls.Add(this.labelDevList);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(387, 64);
            this.panel3.TabIndex = 0;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::Property.Properties.Resources.bullet_triangle_yellow;
            this.pictureBox8.Location = new System.Drawing.Point(3, 3);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(32, 32);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 9;
            this.pictureBox8.TabStop = false;
            // 
            // radioButtonListByOrg
            // 
            this.radioButtonListByOrg.AutoSize = true;
            this.radioButtonListByOrg.Location = new System.Drawing.Point(168, 10);
            this.radioButtonListByOrg.Name = "radioButtonListByOrg";
            this.radioButtonListByOrg.Size = new System.Drawing.Size(59, 16);
            this.radioButtonListByOrg.TabIndex = 3;
            this.radioButtonListByOrg.TabStop = true;
            this.radioButtonListByOrg.Text = "按组织";
            this.radioButtonListByOrg.UseVisualStyleBackColor = true;
            this.radioButtonListByOrg.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButtonListByItf
            // 
            this.radioButtonListByItf.AutoSize = true;
            this.radioButtonListByItf.Checked = true;
            this.radioButtonListByItf.Location = new System.Drawing.Point(103, 10);
            this.radioButtonListByItf.Name = "radioButtonListByItf";
            this.radioButtonListByItf.Size = new System.Drawing.Size(59, 16);
            this.radioButtonListByItf.TabIndex = 3;
            this.radioButtonListByItf.TabStop = true;
            this.radioButtonListByItf.Text = "按接口";
            this.radioButtonListByItf.UseVisualStyleBackColor = true;
            this.radioButtonListByItf.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // buttonRFresh
            // 
            this.buttonRFresh.Location = new System.Drawing.Point(233, 5);
            this.buttonRFresh.Name = "buttonRFresh";
            this.buttonRFresh.Size = new System.Drawing.Size(75, 23);
            this.buttonRFresh.TabIndex = 2;
            this.buttonRFresh.Text = "刷新";
            this.buttonRFresh.UseVisualStyleBackColor = true;
            this.buttonRFresh.Click += new System.EventHandler(this.buttonRFresh_Click);
            // 
            // labelDevList
            // 
            this.labelDevList.AutoSize = true;
            this.labelDevList.Location = new System.Drawing.Point(41, 14);
            this.labelDevList.Name = "labelDevList";
            this.labelDevList.Size = new System.Drawing.Size(53, 12);
            this.labelDevList.TabIndex = 1;
            this.labelDevList.Text = "设备列表";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.buttonTCPServerStop);
            this.panel4.Controls.Add(this.buttonStartTCP);
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Controls.Add(this.labelGPRSServerStat);
            this.panel4.Controls.Add(this.labelGprsInfo);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 378);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(387, 76);
            this.panel4.TabIndex = 2;
            // 
            // buttonTCPServerStop
            // 
            this.buttonTCPServerStop.Location = new System.Drawing.Point(93, 48);
            this.buttonTCPServerStop.Name = "buttonTCPServerStop";
            this.buttonTCPServerStop.Size = new System.Drawing.Size(75, 23);
            this.buttonTCPServerStop.TabIndex = 10;
            this.buttonTCPServerStop.Text = "停止";
            this.buttonTCPServerStop.UseVisualStyleBackColor = true;
            this.buttonTCPServerStop.Click += new System.EventHandler(this.buttonTCPServerStop_Click);
            // 
            // buttonStartTCP
            // 
            this.buttonStartTCP.Location = new System.Drawing.Point(12, 48);
            this.buttonStartTCP.Name = "buttonStartTCP";
            this.buttonStartTCP.Size = new System.Drawing.Size(75, 23);
            this.buttonStartTCP.TabIndex = 10;
            this.buttonStartTCP.Text = "启动";
            this.buttonStartTCP.UseVisualStyleBackColor = true;
            this.buttonStartTCP.Click += new System.EventHandler(this.buttonStartTCP_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Property.Properties.Resources.bullet_triangle_yellow;
            this.pictureBox1.Location = new System.Drawing.Point(3, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // labelGPRSServerStat
            // 
            this.labelGPRSServerStat.AutoSize = true;
            this.labelGPRSServerStat.Location = new System.Drawing.Point(193, 53);
            this.labelGPRSServerStat.Name = "labelGPRSServerStat";
            this.labelGPRSServerStat.Size = new System.Drawing.Size(89, 12);
            this.labelGPRSServerStat.TabIndex = 1;
            this.labelGPRSServerStat.Text = "GPRS服务器状态";
            // 
            // labelGprsInfo
            // 
            this.labelGprsInfo.AutoSize = true;
            this.labelGprsInfo.Location = new System.Drawing.Point(41, 19);
            this.labelGprsInfo.Name = "labelGprsInfo";
            this.labelGprsInfo.Size = new System.Drawing.Size(89, 12);
            this.labelGprsInfo.TabIndex = 1;
            this.labelGprsInfo.Text = "GPRS服务器信息";
            // 
            // panelWorkSpace
            // 
            this.panelWorkSpace.BackColor = System.Drawing.Color.Gainsboro;
            this.panelWorkSpace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWorkSpace.Location = new System.Drawing.Point(387, 0);
            this.panelWorkSpace.Name = "panelWorkSpace";
            this.panelWorkSpace.Padding = new System.Windows.Forms.Padding(4);
            this.panelWorkSpace.Size = new System.Drawing.Size(539, 454);
            this.panelWorkSpace.TabIndex = 6;
            // 
            // timerUpdateGPRSDev
            // 
            this.timerUpdateGPRSDev.Interval = 1000;
            this.timerUpdateGPRSDev.Tick += new System.EventHandler(this.timerUpdateGPRSDev_Tick);
            // 
            // panelLog
            // 
            this.panelLog.Controls.Add(this.listViewLogForDC);
            this.panelLog.Controls.Add(this.panel5);
            this.panelLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelLog.Location = new System.Drawing.Point(0, 223);
            this.panelLog.Name = "panelLog";
            this.panelLog.Size = new System.Drawing.Size(665, 231);
            this.panelLog.TabIndex = 0;
            // 
            // listViewLogForDC
            // 
            this.listViewLogForDC.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader4,
            this.columnHeader5});
            this.listViewLogForDC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewLogForDC.FullRowSelect = true;
            this.listViewLogForDC.Location = new System.Drawing.Point(0, 46);
            this.listViewLogForDC.Name = "listViewLogForDC";
            this.listViewLogForDC.Size = new System.Drawing.Size(665, 185);
            this.listViewLogForDC.TabIndex = 1;
            this.listViewLogForDC.UseCompatibleStateImageBehavior = false;
            this.listViewLogForDC.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ORG";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "LOGDT";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "c1";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "c2";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "c3";
            this.columnHeader8.Width = 43;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "MSG";
            this.columnHeader4.Width = 281;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "OTHINFO";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.buttonClearLog);
            this.panel5.Controls.Add(this.labelLogFilType1);
            this.panel5.Controls.Add(this.textBoxFiltc3);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.checkBoxShowLog);
            this.panel5.Controls.Add(this.textBoxFiltc2);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.textBoxFiltLogM);
            this.panel5.Controls.Add(this.textBoxFiltC1);
            this.panel5.Controls.Add(this.labelLogFilMod);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(665, 46);
            this.panel5.TabIndex = 2;
            // 
            // buttonClearLog
            // 
            this.buttonClearLog.Location = new System.Drawing.Point(66, 14);
            this.buttonClearLog.Name = "buttonClearLog";
            this.buttonClearLog.Size = new System.Drawing.Size(75, 23);
            this.buttonClearLog.TabIndex = 27;
            this.buttonClearLog.Text = "清空日志 ";
            this.buttonClearLog.UseVisualStyleBackColor = true;
            this.buttonClearLog.Click += new System.EventHandler(this.buttonClearLog_Click);
            // 
            // labelLogFilType1
            // 
            this.labelLogFilType1.AutoSize = true;
            this.labelLogFilType1.Location = new System.Drawing.Point(234, 3);
            this.labelLogFilType1.Name = "labelLogFilType1";
            this.labelLogFilType1.Size = new System.Drawing.Size(35, 12);
            this.labelLogFilType1.TabIndex = 23;
            this.labelLogFilType1.Text = "类型1";
            this.labelLogFilType1.Visible = false;
            // 
            // textBoxFiltc3
            // 
            this.textBoxFiltc3.Location = new System.Drawing.Point(234, 3);
            this.textBoxFiltc3.Name = "textBoxFiltc3";
            this.textBoxFiltc3.Size = new System.Drawing.Size(47, 21);
            this.textBoxFiltc3.TabIndex = 18;
            this.textBoxFiltc3.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(234, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 22;
            this.label5.Text = "类型3";
            this.label5.Visible = false;
            // 
            // checkBoxShowLog
            // 
            this.checkBoxShowLog.AutoSize = true;
            this.checkBoxShowLog.Checked = true;
            this.checkBoxShowLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowLog.Location = new System.Drawing.Point(12, 16);
            this.checkBoxShowLog.Name = "checkBoxShowLog";
            this.checkBoxShowLog.Size = new System.Drawing.Size(48, 16);
            this.checkBoxShowLog.TabIndex = 26;
            this.checkBoxShowLog.Text = "暂停";
            this.checkBoxShowLog.UseVisualStyleBackColor = true;
            // 
            // textBoxFiltc2
            // 
            this.textBoxFiltc2.Location = new System.Drawing.Point(234, 3);
            this.textBoxFiltc2.Name = "textBoxFiltc2";
            this.textBoxFiltc2.Size = new System.Drawing.Size(59, 21);
            this.textBoxFiltc2.TabIndex = 19;
            this.textBoxFiltc2.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(234, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 24;
            this.label4.Text = "类型2";
            this.label4.Visible = false;
            // 
            // textBoxFiltLogM
            // 
            this.textBoxFiltLogM.Location = new System.Drawing.Point(234, 3);
            this.textBoxFiltLogM.Name = "textBoxFiltLogM";
            this.textBoxFiltLogM.Size = new System.Drawing.Size(69, 21);
            this.textBoxFiltLogM.TabIndex = 20;
            this.textBoxFiltLogM.Visible = false;
            // 
            // textBoxFiltC1
            // 
            this.textBoxFiltC1.Location = new System.Drawing.Point(234, 3);
            this.textBoxFiltC1.Name = "textBoxFiltC1";
            this.textBoxFiltC1.Size = new System.Drawing.Size(48, 21);
            this.textBoxFiltC1.TabIndex = 21;
            this.textBoxFiltC1.Visible = false;
            // 
            // labelLogFilMod
            // 
            this.labelLogFilMod.AutoSize = true;
            this.labelLogFilMod.Location = new System.Drawing.Point(234, 3);
            this.labelLogFilMod.Name = "labelLogFilMod";
            this.labelLogFilMod.Size = new System.Drawing.Size(29, 12);
            this.labelLogFilMod.TabIndex = 25;
            this.labelLogFilMod.Text = "模块";
            this.labelLogFilMod.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPageCtrlPanel);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 59);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(934, 480);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panelWorkSpace);
            this.tabPage1.Controls.Add(this.panelWsLeft);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(926, 454);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "控制面板";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPageCtrlPanel
            // 
            this.tabPageCtrlPanel.Controls.Add(this.treeViewOrgMoniter);
            this.tabPageCtrlPanel.Controls.Add(this.panel6);
            this.tabPageCtrlPanel.Controls.Add(this.panelLog);
            this.tabPageCtrlPanel.Location = new System.Drawing.Point(4, 22);
            this.tabPageCtrlPanel.Name = "tabPageCtrlPanel";
            this.tabPageCtrlPanel.Size = new System.Drawing.Size(665, 454);
            this.tabPageCtrlPanel.TabIndex = 0;
            this.tabPageCtrlPanel.Text = "中心面板";
            this.tabPageCtrlPanel.UseVisualStyleBackColor = true;
            // 
            // treeViewOrgMoniter
            // 
            this.treeViewOrgMoniter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewOrgMoniter.HideSelection = false;
            this.treeViewOrgMoniter.ImageIndex = 0;
            this.treeViewOrgMoniter.ImageList = this.imageList1;
            this.treeViewOrgMoniter.Location = new System.Drawing.Point(0, 39);
            this.treeViewOrgMoniter.Name = "treeViewOrgMoniter";
            treeNode16.Name = "节点5";
            treeNode16.Tag = "1";
            treeNode16.Text = "1号设备（油价牌）";
            treeNode17.Name = "节点6";
            treeNode17.Tag = "2";
            treeNode17.Text = "2号设备（温湿度时间）";
            treeNode18.Name = "节点0";
            treeNode18.Tag = "2";
            treeNode18.Text = "3号温湿度时间";
            treeNode19.Name = "节点4";
            treeNode19.Text = "串口1";
            treeNode20.Name = "节点0";
            treeNode20.Text = "计算机串口";
            treeNode21.Name = "节点8";
            treeNode21.Text = "1号设备";
            treeNode22.Name = "节点9";
            treeNode22.Text = "2号设备";
            treeNode23.Name = "节点7";
            treeNode23.Text = "192.168.0.11";
            treeNode24.Name = "节点1";
            treeNode24.Text = "以太网设备";
            treeNode25.Name = "节点11";
            treeNode25.Text = "路口LED";
            treeNode26.Name = "节点12";
            treeNode26.Text = "站内LED";
            treeNode27.Name = "节点10";
            treeNode27.Text = "九沟加油站GPRS";
            treeNode28.Name = "节点14";
            treeNode28.Text = "油价牌";
            treeNode29.Name = "节点13";
            treeNode29.Text = "市新加油站GPRS";
            treeNode30.Name = "节点2";
            treeNode30.Text = "GPRS设备";
            this.treeViewOrgMoniter.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode20,
            treeNode24,
            treeNode30});
            this.treeViewOrgMoniter.SelectedImageIndex = 7;
            this.treeViewOrgMoniter.Size = new System.Drawing.Size(665, 184);
            this.treeViewOrgMoniter.TabIndex = 4;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.buttonRefreshCenOrg);
            this.panel6.Controls.Add(this.labelOilStaList);
            this.panel6.Controls.Add(this.buttonStartDC);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(665, 39);
            this.panel6.TabIndex = 5;
            // 
            // buttonRefreshCenOrg
            // 
            this.buttonRefreshCenOrg.Location = new System.Drawing.Point(317, 10);
            this.buttonRefreshCenOrg.Name = "buttonRefreshCenOrg";
            this.buttonRefreshCenOrg.Size = new System.Drawing.Size(75, 23);
            this.buttonRefreshCenOrg.TabIndex = 3;
            this.buttonRefreshCenOrg.Text = "刷新";
            this.buttonRefreshCenOrg.UseVisualStyleBackColor = true;
            this.buttonRefreshCenOrg.Click += new System.EventHandler(this.buttonRefreshCenOrg_Click);
            // 
            // labelOilStaList
            // 
            this.labelOilStaList.AutoSize = true;
            this.labelOilStaList.Location = new System.Drawing.Point(8, 15);
            this.labelOilStaList.Name = "labelOilStaList";
            this.labelOilStaList.Size = new System.Drawing.Size(65, 12);
            this.labelOilStaList.TabIndex = 1;
            this.labelOilStaList.Text = "加油站列表";
            // 
            // buttonStartDC
            // 
            this.buttonStartDC.Enabled = false;
            this.buttonStartDC.Location = new System.Drawing.Point(236, 10);
            this.buttonStartDC.Name = "buttonStartDC";
            this.buttonStartDC.Size = new System.Drawing.Size(75, 23);
            this.buttonStartDC.TabIndex = 0;
            this.buttonStartDC.Text = "启动";
            this.buttonStartDC.UseVisualStyleBackColor = true;
            this.buttonStartDC.Click += new System.EventHandler(this.buttonStartDC_Click);
            // 
            // buttonShowHideLog
            // 
            this.buttonShowHideLog.Location = new System.Drawing.Point(253, 20);
            this.buttonShowHideLog.Name = "buttonShowHideLog";
            this.buttonShowHideLog.Size = new System.Drawing.Size(106, 23);
            this.buttonShowHideLog.TabIndex = 5;
            this.buttonShowHideLog.Text = "显示/隐藏日志";
            this.buttonShowHideLog.UseVisualStyleBackColor = true;
            this.buttonShowHideLog.Click += new System.EventHandler(this.buttonShowHideLog_Click);
            // 
            // timerUpdateOrg
            // 
            this.timerUpdateOrg.Enabled = true;
            this.timerUpdateOrg.Interval = 10000;
            this.timerUpdateOrg.Tick += new System.EventHandler(this.timerUpdateOrg_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(934, 22);
            this.statusStrip1.TabIndex = 28;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonExSelLanguage);
            this.panel1.Controls.Add(this.buttonShowHideLog);
            this.panel1.Controls.Add(this.buttonSysUserMgr);
            this.panel1.Controls.Add(this.buttonDevMgr);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(934, 59);
            this.panel1.TabIndex = 29;
            // 
            // buttonExSelLanguage
            // 
            this.buttonExSelLanguage.BackColor = System.Drawing.SystemColors.Control;
            this.buttonExSelLanguage.Font = new System.Drawing.Font("宋体", 9F);
            this.buttonExSelLanguage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonExSelLanguage.Location = new System.Drawing.Point(392, 20);
            this.buttonExSelLanguage.Name = "buttonExSelLanguage";
            this.buttonExSelLanguage.Size = new System.Drawing.Size(106, 23);
            this.buttonExSelLanguage.TabIndex = 16;
            this.buttonExSelLanguage.Text = "Language";
            this.buttonExSelLanguage.UseVisualStyleBackColor = false;
            this.buttonExSelLanguage.Click += new System.EventHandler(this.buttonExSelLanguage_Click);
            // 
            // buttonSysUserMgr
            // 
            this.buttonSysUserMgr.Location = new System.Drawing.Point(125, 20);
            this.buttonSysUserMgr.Name = "buttonSysUserMgr";
            this.buttonSysUserMgr.Size = new System.Drawing.Size(106, 23);
            this.buttonSysUserMgr.TabIndex = 0;
            this.buttonSysUserMgr.Text = "用户管理";
            this.buttonSysUserMgr.UseVisualStyleBackColor = true;
            this.buttonSysUserMgr.Click += new System.EventHandler(this.buttonSysUserMgr_Click);
            // 
            // buttonDevMgr
            // 
            this.buttonDevMgr.Location = new System.Drawing.Point(12, 20);
            this.buttonDevMgr.Name = "buttonDevMgr";
            this.buttonDevMgr.Size = new System.Drawing.Size(106, 23);
            this.buttonDevMgr.TabIndex = 0;
            this.buttonDevMgr.Text = "设备管理";
            this.buttonDevMgr.UseVisualStyleBackColor = true;
            this.buttonDevMgr.Click += new System.EventHandler(this.buttonDevMgr_Click);
            // 
            // contextMenuStripLanguage
            // 
            this.contextMenuStripLanguage.Name = "contextMenuStripLanguage";
            this.contextMenuStripLanguage.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStripLanguage.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripLanguage_Opening);
            // 
            // timerSendEMailOrReset
            // 
            this.timerSendEMailOrReset.Interval = 10000;
            this.timerSendEMailOrReset.Tick += new System.EventHandler(this.timerSendEMailOrReset_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 561);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mainscript);
            this.Controls.Add(this.statusStrip1);
            this.MainMenuStrip = this.mainscript;
            this.Name = "FormMain";
            this.Text = "格莱光电子LED管理软件";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.mainscript.ResumeLayout(false);
            this.mainscript.PerformLayout();
            this.panelWsLeft.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelLog.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPageCtrlPanel.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainscript;
        private System.Windows.Forms.ToolStripMenuItem SysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ConTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.Panel panelWsLeft;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStripMenuItem CfgToolToolStripMenuItem;
        private System.Windows.Forms.Panel panelWorkSpace;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 简体中文ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 繁体中文ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 英语ToolStripMenuItem;
        private System.Windows.Forms.Label labelDevList;
        private System.Windows.Forms.ToolStripMenuItem DevMgrToolStripMenuItem;
        private System.Windows.Forms.Button buttonRFresh;
        private System.Windows.Forms.RadioButton radioButtonListByItf;
        private System.Windows.Forms.RadioButton radioButtonListByOrg;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelGprsInfo;
        private System.Windows.Forms.Button buttonStartTCP;
        private System.Windows.Forms.Button buttonTCPServerStop;
        private System.Windows.Forms.Label labelGPRSServerStat;
        private System.Windows.Forms.Timer timerUpdateGPRSDev;
        private System.Windows.Forms.Panel panelLog;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ListView listViewLogForDC;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button buttonClearLog;
        private System.Windows.Forms.Label labelLogFilType1;
        private System.Windows.Forms.TextBox textBoxFiltc3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBoxShowLog;
        private System.Windows.Forms.TextBox textBoxFiltc2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxFiltLogM;
        private System.Windows.Forms.TextBox textBoxFiltC1;
        private System.Windows.Forms.Label labelLogFilMod;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPageCtrlPanel;
        private System.Windows.Forms.TreeView treeViewOrgMoniter;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button buttonStartDC;
        private System.Windows.Forms.Label labelOilStaList;
        private System.Windows.Forms.Timer timerUpdateOrg;
        private System.Windows.Forms.Button buttonRefreshCenOrg;
        private System.Windows.Forms.Button buttonShowHideLog;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonDevMgr;
        private System.Windows.Forms.Button buttonExSelLanguage;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripLanguage;
        private System.Windows.Forms.Button buttonSysUserMgr;
        private System.Windows.Forms.Timer timerSendEMailOrReset;
    }
}

