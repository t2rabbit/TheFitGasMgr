namespace Property
{
    partial class FormLedConfig
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
            this.comboBoxShowAppend = new System.Windows.Forms.ComboBox();
            this.comboBoxLights = new System.Windows.Forms.ComboBox();
            this.comboBoxDigNumCount = new System.Windows.Forms.ComboBox();
            this.comboBoxScreenCount = new System.Windows.Forms.ComboBox();
            this.comboBoxIsDouble = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxCurOilCard = new System.Windows.Forms.TextBox();
            this.buttonSetCfg = new System.Windows.Forms.Button();
            this.textBoxFVer = new System.Windows.Forms.TextBox();
            this.textBoxHardVer = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxReadID = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonRead = new System.Windows.Forms.Button();
            this.buttonSaveToDB = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.treeViewOilType = new System.Windows.Forms.TreeView();
            this.oilScreen1 = new SevenSegTest.OilScreen();
            this.buttonLoadByDB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxShowAppend
            // 
            this.comboBoxShowAppend.Enabled = false;
            this.comboBoxShowAppend.FormattingEnabled = true;
            this.comboBoxShowAppend.Items.AddRange(new object[] {
            "No",
            "Yes"});
            this.comboBoxShowAppend.Location = new System.Drawing.Point(418, 228);
            this.comboBoxShowAppend.Name = "comboBoxShowAppend";
            this.comboBoxShowAppend.Size = new System.Drawing.Size(97, 20);
            this.comboBoxShowAppend.TabIndex = 30;
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
            "8",
            "9"});
            this.comboBoxLights.Location = new System.Drawing.Point(418, 254);
            this.comboBoxLights.Name = "comboBoxLights";
            this.comboBoxLights.Size = new System.Drawing.Size(97, 20);
            this.comboBoxLights.TabIndex = 29;
            // 
            // comboBoxDigNumCount
            // 
            this.comboBoxDigNumCount.Enabled = false;
            this.comboBoxDigNumCount.FormattingEnabled = true;
            this.comboBoxDigNumCount.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.comboBoxDigNumCount.Location = new System.Drawing.Point(418, 202);
            this.comboBoxDigNumCount.Name = "comboBoxDigNumCount";
            this.comboBoxDigNumCount.Size = new System.Drawing.Size(97, 20);
            this.comboBoxDigNumCount.TabIndex = 31;
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
            this.comboBoxScreenCount.Location = new System.Drawing.Point(418, 174);
            this.comboBoxScreenCount.Name = "comboBoxScreenCount";
            this.comboBoxScreenCount.Size = new System.Drawing.Size(97, 20);
            this.comboBoxScreenCount.TabIndex = 33;
            // 
            // comboBoxIsDouble
            // 
            this.comboBoxIsDouble.FormattingEnabled = true;
            this.comboBoxIsDouble.Items.AddRange(new object[] {
            "1",
            "2"});
            this.comboBoxIsDouble.Location = new System.Drawing.Point(418, 138);
            this.comboBoxIsDouble.Name = "comboBoxIsDouble";
            this.comboBoxIsDouble.Size = new System.Drawing.Size(97, 20);
            this.comboBoxIsDouble.TabIndex = 32;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(149, 12);
            this.label9.TabIndex = 28;
            this.label9.Text = "Current Selected OilCard";
            // 
            // textBoxCurOilCard
            // 
            this.textBoxCurOilCard.Location = new System.Drawing.Point(171, 16);
            this.textBoxCurOilCard.Name = "textBoxCurOilCard";
            this.textBoxCurOilCard.ReadOnly = true;
            this.textBoxCurOilCard.Size = new System.Drawing.Size(238, 21);
            this.textBoxCurOilCard.TabIndex = 27;
            // 
            // buttonSetCfg
            // 
            this.buttonSetCfg.Location = new System.Drawing.Point(440, 375);
            this.buttonSetCfg.Name = "buttonSetCfg";
            this.buttonSetCfg.Size = new System.Drawing.Size(75, 23);
            this.buttonSetCfg.TabIndex = 26;
            this.buttonSetCfg.Text = "Write";
            this.buttonSetCfg.UseVisualStyleBackColor = true;
            this.buttonSetCfg.Click += new System.EventHandler(this.buttonSetCfg_Click);
            // 
            // textBoxFVer
            // 
            this.textBoxFVer.Enabled = false;
            this.textBoxFVer.Location = new System.Drawing.Point(418, 111);
            this.textBoxFVer.Name = "textBoxFVer";
            this.textBoxFVer.ReadOnly = true;
            this.textBoxFVer.Size = new System.Drawing.Size(91, 21);
            this.textBoxFVer.TabIndex = 24;
            // 
            // textBoxHardVer
            // 
            this.textBoxHardVer.Enabled = false;
            this.textBoxHardVer.Location = new System.Drawing.Point(418, 86);
            this.textBoxHardVer.Name = "textBoxHardVer";
            this.textBoxHardVer.ReadOnly = true;
            this.textBoxHardVer.Size = new System.Drawing.Size(91, 21);
            this.textBoxHardVer.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(309, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 12);
            this.label6.TabIndex = 17;
            this.label6.Text = "Firmeware Version";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(309, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 12);
            this.label5.TabIndex = 18;
            this.label5.Text = "Hardware Version";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Enabled = false;
            this.label12.Location = new System.Drawing.Point(306, 233);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 12);
            this.label12.TabIndex = 15;
            this.label12.Text = "Is Show 9/10";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(306, 259);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 16;
            this.label11.Text = "Brightness";
            // 
            // textBoxReadID
            // 
            this.textBoxReadID.Enabled = false;
            this.textBoxReadID.Location = new System.Drawing.Point(418, 59);
            this.textBoxReadID.Name = "textBoxReadID";
            this.textBoxReadID.ReadOnly = true;
            this.textBoxReadID.Size = new System.Drawing.Size(91, 21);
            this.textBoxReadID.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Enabled = false;
            this.label10.Location = new System.Drawing.Point(306, 207);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 22;
            this.label10.Text = "Digt Count";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(306, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 12);
            this.label4.TabIndex = 21;
            this.label4.Text = "Single/Double";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(306, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 20;
            this.label3.Text = "Screen Count";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(311, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 19;
            this.label2.Text = "Addr";
            // 
            // buttonRead
            // 
            this.buttonRead.Location = new System.Drawing.Point(359, 375);
            this.buttonRead.Name = "buttonRead";
            this.buttonRead.Size = new System.Drawing.Size(75, 23);
            this.buttonRead.TabIndex = 14;
            this.buttonRead.Text = "Read";
            this.buttonRead.UseVisualStyleBackColor = true;
            this.buttonRead.Click += new System.EventHandler(this.buttonRead_Click);
            // 
            // buttonSaveToDB
            // 
            this.buttonSaveToDB.Location = new System.Drawing.Point(440, 331);
            this.buttonSaveToDB.Name = "buttonSaveToDB";
            this.buttonSaveToDB.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveToDB.TabIndex = 14;
            this.buttonSaveToDB.Text = "Save To DB";
            this.buttonSaveToDB.UseVisualStyleBackColor = true;
            this.buttonSaveToDB.Click += new System.EventHandler(this.buttonSaveToDB_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 12);
            this.label1.TabIndex = 34;
            this.label1.Text = "Mody OilCard Type";
            // 
            // treeViewOilType
            // 
            this.treeViewOilType.HideSelection = false;
            this.treeViewOilType.Location = new System.Drawing.Point(10, 92);
            this.treeViewOilType.Name = "treeViewOilType";
            this.treeViewOilType.Size = new System.Drawing.Size(268, 147);
            this.treeViewOilType.TabIndex = 35;
            this.treeViewOilType.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // oilScreen1
            // 
            this.oilScreen1.BAppend10_9 = false;
            this.oilScreen1.BAppend99 = true;
            this.oilScreen1.iAppendCount = 2;
            this.oilScreen1.IDigHeight = 40;
            this.oilScreen1.IDigWidth = 30;
            this.oilScreen1.iIndexOfPoint = 1;
            this.oilScreen1.iMainCount = 6;
            this.oilScreen1.Location = new System.Drawing.Point(10, 254);
            this.oilScreen1.Name = "oilScreen1";
            this.oilScreen1.Size = new System.Drawing.Size(184, 52);
            this.oilScreen1.strValue = "1.2.3.4.5.6";
            this.oilScreen1.TabIndex = 36;
            // 
            // buttonLoadByDB
            // 
            this.buttonLoadByDB.Location = new System.Drawing.Point(359, 331);
            this.buttonLoadByDB.Name = "buttonLoadByDB";
            this.buttonLoadByDB.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadByDB.TabIndex = 14;
            this.buttonLoadByDB.Text = "Load By DB";
            this.buttonLoadByDB.UseVisualStyleBackColor = true;
            this.buttonLoadByDB.Click += new System.EventHandler(this.buttonLoadByDB_Click);
            // 
            // FormLedConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 423);
            this.Controls.Add(this.oilScreen1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.treeViewOilType);
            this.Controls.Add(this.comboBoxShowAppend);
            this.Controls.Add(this.comboBoxLights);
            this.Controls.Add(this.comboBoxDigNumCount);
            this.Controls.Add(this.comboBoxScreenCount);
            this.Controls.Add(this.comboBoxIsDouble);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxCurOilCard);
            this.Controls.Add(this.buttonSetCfg);
            this.Controls.Add(this.textBoxFVer);
            this.Controls.Add(this.textBoxHardVer);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBoxReadID);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonLoadByDB);
            this.Controls.Add(this.buttonSaveToDB);
            this.Controls.Add(this.buttonRead);
            this.Name = "FormLedConfig";
            this.Text = "OilCard Config";
            this.Load += new System.EventHandler(this.FormLedConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxShowAppend;
        private System.Windows.Forms.ComboBox comboBoxLights;
        private System.Windows.Forms.ComboBox comboBoxDigNumCount;
        private System.Windows.Forms.ComboBox comboBoxScreenCount;
        private System.Windows.Forms.ComboBox comboBoxIsDouble;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxCurOilCard;
        private System.Windows.Forms.Button buttonSetCfg;
        private System.Windows.Forms.TextBox textBoxFVer;
        private System.Windows.Forms.TextBox textBoxHardVer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxReadID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonRead;
        private System.Windows.Forms.Button buttonSaveToDB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView treeViewOilType;
        private SevenSegTest.OilScreen oilScreen1;
        private System.Windows.Forms.Button buttonLoadByDB;
    }
}