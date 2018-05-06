namespace GlareSysDataCenter
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonCfgDbMgr = new System.Windows.Forms.Button();
            this.buttonRefreshDbData = new System.Windows.Forms.Button();
            this.buttonShowLog = new System.Windows.Forms.Button();
            this.buttonFunTest = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.backgroundWorkerLoading = new System.ComponentModel.BackgroundWorker();
            this.timerRestartTcpServer = new System.Windows.Forms.Timer(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listViewCardList = new System.Windows.Forms.ListView();
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader22 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader23 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader25 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader26 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader27 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader28 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel5 = new System.Windows.Forms.Panel();
            this.buttonFilter = new System.Windows.Forms.Button();
            this.comboBoxSelGroup = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxSelOrg = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.timerGetStatus = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonCfgDbMgr);
            this.panel1.Controls.Add(this.buttonRefreshDbData);
            this.panel1.Controls.Add(this.buttonShowLog);
            this.panel1.Controls.Add(this.buttonFunTest);
            this.panel1.Controls.Add(this.buttonStop);
            this.panel1.Controls.Add(this.buttonStart);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 56);
            this.panel1.TabIndex = 0;
            // 
            // buttonCfgDbMgr
            // 
            this.buttonCfgDbMgr.Location = new System.Drawing.Point(344, 4);
            this.buttonCfgDbMgr.Name = "buttonCfgDbMgr";
            this.buttonCfgDbMgr.Size = new System.Drawing.Size(75, 23);
            this.buttonCfgDbMgr.TabIndex = 4;
            this.buttonCfgDbMgr.Text = "信息管理";
            this.buttonCfgDbMgr.UseVisualStyleBackColor = true;
            this.buttonCfgDbMgr.Click += new System.EventHandler(this.buttonCfgDbMgr_Click);
            // 
            // buttonRefreshDbData
            // 
            this.buttonRefreshDbData.Location = new System.Drawing.Point(247, 4);
            this.buttonRefreshDbData.Name = "buttonRefreshDbData";
            this.buttonRefreshDbData.Size = new System.Drawing.Size(75, 23);
            this.buttonRefreshDbData.TabIndex = 3;
            this.buttonRefreshDbData.Text = "刷新数据库";
            this.buttonRefreshDbData.UseVisualStyleBackColor = true;
            this.buttonRefreshDbData.Click += new System.EventHandler(this.buttonRefreshDbData_Click);
            // 
            // buttonShowLog
            // 
            this.buttonShowLog.Location = new System.Drawing.Point(496, 4);
            this.buttonShowLog.Name = "buttonShowLog";
            this.buttonShowLog.Size = new System.Drawing.Size(75, 23);
            this.buttonShowLog.TabIndex = 2;
            this.buttonShowLog.Text = "显示日志";
            this.buttonShowLog.UseVisualStyleBackColor = true;
            this.buttonShowLog.Click += new System.EventHandler(this.buttonShowLog_Click);
            // 
            // buttonFunTest
            // 
            this.buttonFunTest.Location = new System.Drawing.Point(605, 4);
            this.buttonFunTest.Name = "buttonFunTest";
            this.buttonFunTest.Size = new System.Drawing.Size(75, 23);
            this.buttonFunTest.TabIndex = 1;
            this.buttonFunTest.Text = "功能测试";
            this.buttonFunTest.UseVisualStyleBackColor = true;
            this.buttonFunTest.Click += new System.EventHandler(this.buttonFunTest_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(94, 4);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 0;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(13, 4);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 418);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 32);
            this.panel2.TabIndex = 1;
            // 
            // backgroundWorkerLoading
            // 
            this.backgroundWorkerLoading.WorkerReportsProgress = true;
            this.backgroundWorkerLoading.WorkerSupportsCancellation = true;
            this.backgroundWorkerLoading.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerLoading_DoWork);
            // 
            // timerRestartTcpServer
            // 
            this.timerRestartTcpServer.Interval = 30000;
            this.timerRestartTcpServer.Tick += new System.EventHandler(this.timerRestartTcpServer_Tick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tabControl1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 56);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(800, 362);
            this.panel3.TabIndex = 6;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 362);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listViewCardList);
            this.tabPage1.Controls.Add(this.panel5);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 336);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "列表显示";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listViewCardList
            // 
            this.listViewCardList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader20,
            this.columnHeader21,
            this.columnHeader22,
            this.columnHeader23,
            this.columnHeader25,
            this.columnHeader26,
            this.columnHeader27,
            this.columnHeader28});
            this.listViewCardList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewCardList.Location = new System.Drawing.Point(3, 78);
            this.listViewCardList.Name = "listViewCardList";
            this.listViewCardList.Size = new System.Drawing.Size(786, 255);
            this.listViewCardList.TabIndex = 2;
            this.listViewCardList.UseCompatibleStateImageBehavior = false;
            this.listViewCardList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "序号";
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "油卡ID";
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "油卡名称";
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "SN";
            this.columnHeader18.Width = 109;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "所属油站";
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "所属区域";
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "所属企业";
            // 
            // columnHeader23
            // 
            this.columnHeader23.Text = "型号";
            // 
            // columnHeader25
            // 
            this.columnHeader25.Text = "屏幕数量";
            // 
            // columnHeader26
            // 
            this.columnHeader26.Text = "小数点位置";
            // 
            // columnHeader27
            // 
            this.columnHeader27.Text = "各屏幕备注";
            this.columnHeader27.Width = 80;
            // 
            // columnHeader28
            // 
            this.columnHeader28.Text = "屏幕当前内容";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.buttonFilter);
            this.panel5.Controls.Add(this.comboBoxSelGroup);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.comboBoxSelOrg);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(786, 75);
            this.panel5.TabIndex = 0;
            // 
            // buttonFilter
            // 
            this.buttonFilter.Location = new System.Drawing.Point(288, 40);
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.Size = new System.Drawing.Size(75, 23);
            this.buttonFilter.TabIndex = 22;
            this.buttonFilter.Text = "筛选";
            this.buttonFilter.UseVisualStyleBackColor = true;
            this.buttonFilter.Click += new System.EventHandler(this.buttonFilter_Click);
            // 
            // comboBoxSelGroup
            // 
            this.comboBoxSelGroup.FormattingEnabled = true;
            this.comboBoxSelGroup.Location = new System.Drawing.Point(115, 40);
            this.comboBoxSelGroup.Name = "comboBoxSelGroup";
            this.comboBoxSelGroup.Size = new System.Drawing.Size(121, 20);
            this.comboBoxSelGroup.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "区域";
            // 
            // comboBoxSelOrg
            // 
            this.comboBoxSelOrg.FormattingEnabled = true;
            this.comboBoxSelOrg.Location = new System.Drawing.Point(115, 13);
            this.comboBoxSelOrg.Name = "comboBoxSelOrg";
            this.comboBoxSelOrg.Size = new System.Drawing.Size(121, 20);
            this.comboBoxSelOrg.TabIndex = 21;
            this.comboBoxSelOrg.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelOrg_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 17;
            this.label9.Text = "公司";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormMain";
            this.Text = "DataCenter";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonStart;
        private System.ComponentModel.BackgroundWorker backgroundWorkerLoading;
        private System.Windows.Forms.Button buttonFunTest;
        private System.Windows.Forms.Button buttonShowLog;
        private System.Windows.Forms.Timer timerRestartTcpServer;
        private System.Windows.Forms.Button buttonRefreshDbData;
        private System.Windows.Forms.Button buttonCfgDbMgr;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox comboBoxSelGroup;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxSelOrg;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonFilter;
        private System.Windows.Forms.ListView listViewCardList;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        private System.Windows.Forms.ColumnHeader columnHeader21;
        private System.Windows.Forms.ColumnHeader columnHeader22;
        private System.Windows.Forms.ColumnHeader columnHeader23;
        private System.Windows.Forms.ColumnHeader columnHeader25;
        private System.Windows.Forms.ColumnHeader columnHeader26;
        private System.Windows.Forms.ColumnHeader columnHeader27;
        private System.Windows.Forms.ColumnHeader columnHeader28;
        private System.Windows.Forms.Timer timerGetStatus;
    }
}

