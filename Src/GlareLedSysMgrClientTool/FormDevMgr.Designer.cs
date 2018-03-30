namespace Property
{
    partial class FormDevMgr
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("1号设备（油价牌）");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("2号设备(温度湿度时间屏)");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("3号油价牌");
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
            this.panelViewMgrCom = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonAddOrg = new System.Windows.Forms.Button();
            this.radioButtonByOrg = new System.Windows.Forms.RadioButton();
            this.radioButtonByDev = new System.Windows.Forms.RadioButton();
            this.buttonRFresh = new System.Windows.Forms.Button();
            this.buttonAddCard = new System.Windows.Forms.Button();
            this.buttonAddPort = new System.Windows.Forms.Button();
            this.labelDevList = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonTest = new System.Windows.Forms.Button();
            this.buttonDel = new System.Windows.Forms.Button();
            this.buttonDetail = new System.Windows.Forms.Button();
            this.buttonMdy = new System.Windows.Forms.Button();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelViewMgrCom
            // 
            this.panelViewMgrCom.Location = new System.Drawing.Point(582, 0);
            this.panelViewMgrCom.Name = "panelViewMgrCom";
            this.panelViewMgrCom.Size = new System.Drawing.Size(116, 45);
            this.panelViewMgrCom.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.treeView1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(383, 496);
            this.panel2.TabIndex = 6;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 49);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "节点5";
            treeNode1.Tag = "1";
            treeNode1.Text = "1号设备（油价牌）";
            treeNode2.Name = "节点6";
            treeNode2.Tag = "2";
            treeNode2.Text = "2号设备(温度湿度时间屏)";
            treeNode3.Name = "节点0";
            treeNode3.Text = "3号油价牌";
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
            this.treeView1.Size = new System.Drawing.Size(383, 367);
            this.treeView1.TabIndex = 3;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.buttonAddOrg);
            this.panel3.Controls.Add(this.radioButtonByOrg);
            this.panel3.Controls.Add(this.radioButtonByDev);
            this.panel3.Controls.Add(this.buttonRFresh);
            this.panel3.Controls.Add(this.buttonAddCard);
            this.panel3.Controls.Add(this.buttonAddPort);
            this.panel3.Controls.Add(this.labelDevList);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(383, 49);
            this.panel3.TabIndex = 0;
            // 
            // buttonAddOrg
            // 
            this.buttonAddOrg.Location = new System.Drawing.Point(14, 12);
            this.buttonAddOrg.Name = "buttonAddOrg";
            this.buttonAddOrg.Size = new System.Drawing.Size(75, 23);
            this.buttonAddOrg.TabIndex = 7;
            this.buttonAddOrg.Text = "添加油站";
            this.buttonAddOrg.UseVisualStyleBackColor = true;
            this.buttonAddOrg.Click += new System.EventHandler(this.buttonAddOrg_Click);
            // 
            // radioButtonByOrg
            // 
            this.radioButtonByOrg.AutoSize = true;
            this.radioButtonByOrg.Checked = true;
            this.radioButtonByOrg.Location = new System.Drawing.Point(341, 12);
            this.radioButtonByOrg.Name = "radioButtonByOrg";
            this.radioButtonByOrg.Size = new System.Drawing.Size(59, 16);
            this.radioButtonByOrg.TabIndex = 5;
            this.radioButtonByOrg.TabStop = true;
            this.radioButtonByOrg.Text = "按组织";
            this.radioButtonByOrg.UseVisualStyleBackColor = true;
            this.radioButtonByOrg.Visible = false;
            this.radioButtonByOrg.CheckedChanged += new System.EventHandler(this.radioButtonByOrg_CheckedChanged);
            // 
            // radioButtonByDev
            // 
            this.radioButtonByDev.AutoSize = true;
            this.radioButtonByDev.Location = new System.Drawing.Point(341, 12);
            this.radioButtonByDev.Name = "radioButtonByDev";
            this.radioButtonByDev.Size = new System.Drawing.Size(59, 16);
            this.radioButtonByDev.TabIndex = 6;
            this.radioButtonByDev.Text = "按接口";
            this.radioButtonByDev.UseVisualStyleBackColor = true;
            this.radioButtonByDev.Visible = false;
            this.radioButtonByDev.CheckedChanged += new System.EventHandler(this.radioButtonByDev_CheckedChanged);
            // 
            // buttonRFresh
            // 
            this.buttonRFresh.Location = new System.Drawing.Point(260, 12);
            this.buttonRFresh.Name = "buttonRFresh";
            this.buttonRFresh.Size = new System.Drawing.Size(75, 23);
            this.buttonRFresh.TabIndex = 4;
            this.buttonRFresh.Text = "刷新";
            this.buttonRFresh.UseVisualStyleBackColor = true;
            this.buttonRFresh.Click += new System.EventHandler(this.buttonRFresh_Click);
            // 
            // buttonAddCard
            // 
            this.buttonAddCard.Location = new System.Drawing.Point(175, 12);
            this.buttonAddCard.Name = "buttonAddCard";
            this.buttonAddCard.Size = new System.Drawing.Size(75, 23);
            this.buttonAddCard.TabIndex = 1;
            this.buttonAddCard.Text = "添加卡";
            this.buttonAddCard.UseVisualStyleBackColor = true;
            this.buttonAddCard.Click += new System.EventHandler(this.buttonAddCard_Click);
            // 
            // buttonAddPort
            // 
            this.buttonAddPort.Location = new System.Drawing.Point(94, 12);
            this.buttonAddPort.Name = "buttonAddPort";
            this.buttonAddPort.Size = new System.Drawing.Size(75, 23);
            this.buttonAddPort.TabIndex = 1;
            this.buttonAddPort.Text = "添加端口";
            this.buttonAddPort.UseVisualStyleBackColor = true;
            this.buttonAddPort.Click += new System.EventHandler(this.buttonAddPort_Click);
            // 
            // labelDevList
            // 
            this.labelDevList.AutoSize = true;
            this.labelDevList.Location = new System.Drawing.Point(341, 12);
            this.labelDevList.Name = "labelDevList";
            this.labelDevList.Size = new System.Drawing.Size(53, 12);
            this.labelDevList.TabIndex = 0;
            this.labelDevList.Text = "设备列表";
            this.labelDevList.Visible = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.buttonOK);
            this.panel4.Controls.Add(this.buttonTest);
            this.panel4.Controls.Add(this.buttonDel);
            this.panel4.Controls.Add(this.buttonDetail);
            this.panel4.Controls.Add(this.buttonMdy);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 416);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(383, 80);
            this.panel4.TabIndex = 2;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(305, 51);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonTest
            // 
            this.buttonTest.Location = new System.Drawing.Point(3, 64);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(75, 13);
            this.buttonTest.TabIndex = 1;
            this.buttonTest.Text = "测试";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Visible = false;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // buttonDel
            // 
            this.buttonDel.Location = new System.Drawing.Point(95, 6);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(75, 23);
            this.buttonDel.TabIndex = 1;
            this.buttonDel.Text = "删除";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // buttonDetail
            // 
            this.buttonDetail.Location = new System.Drawing.Point(84, 64);
            this.buttonDetail.Name = "buttonDetail";
            this.buttonDetail.Size = new System.Drawing.Size(75, 10);
            this.buttonDetail.TabIndex = 1;
            this.buttonDetail.Text = "Detail";
            this.buttonDetail.UseVisualStyleBackColor = true;
            this.buttonDetail.Visible = false;
            this.buttonDetail.Click += new System.EventHandler(this.buttonDetail_Click);
            // 
            // buttonMdy
            // 
            this.buttonMdy.Location = new System.Drawing.Point(14, 6);
            this.buttonMdy.Name = "buttonMdy";
            this.buttonMdy.Size = new System.Drawing.Size(75, 23);
            this.buttonMdy.TabIndex = 1;
            this.buttonMdy.Text = "修改";
            this.buttonMdy.UseVisualStyleBackColor = true;
            this.buttonMdy.Click += new System.EventHandler(this.buttonMdy_Click);
            // 
            // pictureBox7
            // 
            this.pictureBox7.Location = new System.Drawing.Point(582, 0);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(116, 45);
            this.pictureBox7.TabIndex = 13;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Location = new System.Drawing.Point(582, 0);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(116, 45);
            this.pictureBox6.TabIndex = 11;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Location = new System.Drawing.Point(582, 0);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(116, 45);
            this.pictureBox5.TabIndex = 12;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(582, 0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(116, 45);
            this.pictureBox4.TabIndex = 10;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(582, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(116, 45);
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(582, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(116, 45);
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(582, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(116, 45);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // FormDevMgr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 496);
            this.Controls.Add(this.panelViewMgrCom);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel2);
            this.Name = "FormDevMgr";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Card Mgr added language";
            this.Load += new System.EventHandler(this.FormSysMgr_Load);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelViewMgrCom;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonAddPort;
        private System.Windows.Forms.Label labelDevList;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Button buttonMdy;
        private System.Windows.Forms.Button buttonAddCard;
        private System.Windows.Forms.RadioButton radioButtonByOrg;
        private System.Windows.Forms.RadioButton radioButtonByDev;
        private System.Windows.Forms.Button buttonRFresh;
        private System.Windows.Forms.Button buttonAddOrg;
        private System.Windows.Forms.Button buttonDetail;
        private System.Windows.Forms.Button buttonOK;
    }
}