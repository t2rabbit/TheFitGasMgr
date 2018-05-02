namespace GlareSysDataCenter.FromAddMdys
{
    partial class FormAddCard
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
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.comboBoxProject = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxGroup = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxOrg = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxScreenCount = new System.Windows.Forms.ComboBox();
            this.ScreenTipNames = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxScreenName1 = new System.Windows.Forms.TextBox();
            this.textBoxScreenName2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxScreenName3 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxScreenName4 = new System.Windows.Forms.TextBox();
            this.textBoxScreenName5 = new System.Windows.Forms.TextBox();
            this.textBoxScreenName6 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxScreenName7 = new System.Windows.Forms.TextBox();
            this.textBoxScreenName8 = new System.Windows.Forms.TextBox();
            this.textBoxScreenName9 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.labelScreenName8 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.textBoxScreenName10 = new System.Windows.Forms.TextBox();
            this.textBoxScreenName11 = new System.Windows.Forms.TextBox();
            this.textBoxScreenName12 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.comboBoxNumCount = new System.Windows.Forms.ComboBox();
            this.comboBoxPointIndex = new System.Windows.Forms.ComboBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxConnSn = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.comboBoxCardModeType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(130, 12);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(224, 21);
            this.textBoxName.TabIndex = 22;
            // 
            // comboBoxProject
            // 
            this.comboBoxProject.FormattingEnabled = true;
            this.comboBoxProject.Location = new System.Drawing.Point(130, 97);
            this.comboBoxProject.Name = "comboBoxProject";
            this.comboBoxProject.Size = new System.Drawing.Size(224, 20);
            this.comboBoxProject.TabIndex = 19;
            this.comboBoxProject.SelectedIndexChanged += new System.EventHandler(this.comboBoxProject_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "Project:";
            // 
            // comboBoxGroup
            // 
            this.comboBoxGroup.FormattingEnabled = true;
            this.comboBoxGroup.Location = new System.Drawing.Point(130, 67);
            this.comboBoxGroup.Name = "comboBoxGroup";
            this.comboBoxGroup.Size = new System.Drawing.Size(224, 20);
            this.comboBoxGroup.TabIndex = 20;
            this.comboBoxGroup.SelectedIndexChanged += new System.EventHandler(this.comboBoxGroup_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "Group:";
            // 
            // comboBoxOrg
            // 
            this.comboBoxOrg.FormattingEnabled = true;
            this.comboBoxOrg.Location = new System.Drawing.Point(130, 41);
            this.comboBoxOrg.Name = "comboBoxOrg";
            this.comboBoxOrg.Size = new System.Drawing.Size(224, 20);
            this.comboBoxOrg.TabIndex = 21;
            this.comboBoxOrg.SelectedIndexChanged += new System.EventHandler(this.comboBoxOrg_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 18;
            this.label5.Text = "Org:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(310, 415);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 23;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(229, 415);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 24;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "ScreenCount";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 215);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "NumCount（数字）";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 242);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 12);
            this.label8.TabIndex = 17;
            this.label8.Text = "PointCount(小数点）";
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
            this.comboBoxScreenCount.Location = new System.Drawing.Point(130, 179);
            this.comboBoxScreenCount.Name = "comboBoxScreenCount";
            this.comboBoxScreenCount.Size = new System.Drawing.Size(224, 20);
            this.comboBoxScreenCount.TabIndex = 25;
            // 
            // ScreenTipNames
            // 
            this.ScreenTipNames.AutoSize = true;
            this.ScreenTipNames.Location = new System.Drawing.Point(11, 284);
            this.ScreenTipNames.Name = "ScreenTipNames";
            this.ScreenTipNames.Size = new System.Drawing.Size(89, 12);
            this.ScreenTipNames.TabIndex = 26;
            this.ScreenTipNames.Text = "ScreenTipNames";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 302);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 27;
            this.label9.Text = "1#";
            // 
            // textBoxScreenName1
            // 
            this.textBoxScreenName1.Location = new System.Drawing.Point(45, 299);
            this.textBoxScreenName1.Name = "textBoxScreenName1";
            this.textBoxScreenName1.Size = new System.Drawing.Size(85, 21);
            this.textBoxScreenName1.TabIndex = 22;
            // 
            // textBoxScreenName2
            // 
            this.textBoxScreenName2.Location = new System.Drawing.Point(172, 299);
            this.textBoxScreenName2.Name = "textBoxScreenName2";
            this.textBoxScreenName2.Size = new System.Drawing.Size(85, 21);
            this.textBoxScreenName2.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(149, 302);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 12);
            this.label10.TabIndex = 27;
            this.label10.Text = "2#";
            // 
            // textBoxScreenName3
            // 
            this.textBoxScreenName3.Location = new System.Drawing.Point(300, 299);
            this.textBoxScreenName3.Name = "textBoxScreenName3";
            this.textBoxScreenName3.Size = new System.Drawing.Size(85, 21);
            this.textBoxScreenName3.TabIndex = 22;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(268, 302);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 12);
            this.label11.TabIndex = 27;
            this.label11.Text = "3#";
            // 
            // textBoxScreenName4
            // 
            this.textBoxScreenName4.Location = new System.Drawing.Point(45, 326);
            this.textBoxScreenName4.Name = "textBoxScreenName4";
            this.textBoxScreenName4.Size = new System.Drawing.Size(85, 21);
            this.textBoxScreenName4.TabIndex = 22;
            // 
            // textBoxScreenName5
            // 
            this.textBoxScreenName5.Location = new System.Drawing.Point(172, 326);
            this.textBoxScreenName5.Name = "textBoxScreenName5";
            this.textBoxScreenName5.Size = new System.Drawing.Size(85, 21);
            this.textBoxScreenName5.TabIndex = 22;
            // 
            // textBoxScreenName6
            // 
            this.textBoxScreenName6.Location = new System.Drawing.Point(300, 326);
            this.textBoxScreenName6.Name = "textBoxScreenName6";
            this.textBoxScreenName6.Size = new System.Drawing.Size(85, 21);
            this.textBoxScreenName6.TabIndex = 22;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(22, 329);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 12);
            this.label12.TabIndex = 27;
            this.label12.Text = "4#";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(149, 329);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(17, 12);
            this.label13.TabIndex = 27;
            this.label13.Text = "5#";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(268, 329);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(17, 12);
            this.label14.TabIndex = 27;
            this.label14.Text = "6#";
            // 
            // textBoxScreenName7
            // 
            this.textBoxScreenName7.Location = new System.Drawing.Point(45, 353);
            this.textBoxScreenName7.Name = "textBoxScreenName7";
            this.textBoxScreenName7.Size = new System.Drawing.Size(85, 21);
            this.textBoxScreenName7.TabIndex = 22;
            // 
            // textBoxScreenName8
            // 
            this.textBoxScreenName8.Location = new System.Drawing.Point(172, 353);
            this.textBoxScreenName8.Name = "textBoxScreenName8";
            this.textBoxScreenName8.Size = new System.Drawing.Size(85, 21);
            this.textBoxScreenName8.TabIndex = 22;
            // 
            // textBoxScreenName9
            // 
            this.textBoxScreenName9.Location = new System.Drawing.Point(300, 353);
            this.textBoxScreenName9.Name = "textBoxScreenName9";
            this.textBoxScreenName9.Size = new System.Drawing.Size(85, 21);
            this.textBoxScreenName9.TabIndex = 22;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(22, 356);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(17, 12);
            this.label15.TabIndex = 27;
            this.label15.Text = "7#";
            // 
            // labelScreenName8
            // 
            this.labelScreenName8.AutoSize = true;
            this.labelScreenName8.Location = new System.Drawing.Point(149, 356);
            this.labelScreenName8.Name = "labelScreenName8";
            this.labelScreenName8.Size = new System.Drawing.Size(17, 12);
            this.labelScreenName8.TabIndex = 27;
            this.labelScreenName8.Text = "8#";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(268, 356);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(17, 12);
            this.label17.TabIndex = 27;
            this.label17.Text = "9#";
            // 
            // textBoxScreenName10
            // 
            this.textBoxScreenName10.Location = new System.Drawing.Point(45, 380);
            this.textBoxScreenName10.Name = "textBoxScreenName10";
            this.textBoxScreenName10.Size = new System.Drawing.Size(85, 21);
            this.textBoxScreenName10.TabIndex = 22;
            // 
            // textBoxScreenName11
            // 
            this.textBoxScreenName11.Location = new System.Drawing.Point(172, 380);
            this.textBoxScreenName11.Name = "textBoxScreenName11";
            this.textBoxScreenName11.Size = new System.Drawing.Size(85, 21);
            this.textBoxScreenName11.TabIndex = 22;
            // 
            // textBoxScreenName12
            // 
            this.textBoxScreenName12.Location = new System.Drawing.Point(300, 380);
            this.textBoxScreenName12.Name = "textBoxScreenName12";
            this.textBoxScreenName12.Size = new System.Drawing.Size(85, 21);
            this.textBoxScreenName12.TabIndex = 22;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(22, 383);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(23, 12);
            this.label18.TabIndex = 27;
            this.label18.Text = "10#";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(149, 383);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(23, 12);
            this.label19.TabIndex = 27;
            this.label19.Text = "11#";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(268, 383);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(23, 12);
            this.label20.TabIndex = 27;
            this.label20.Text = "12#";
            // 
            // comboBoxNumCount
            // 
            this.comboBoxNumCount.FormattingEnabled = true;
            this.comboBoxNumCount.Items.AddRange(new object[] {
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
            this.comboBoxNumCount.Location = new System.Drawing.Point(130, 205);
            this.comboBoxNumCount.Name = "comboBoxNumCount";
            this.comboBoxNumCount.Size = new System.Drawing.Size(224, 20);
            this.comboBoxNumCount.TabIndex = 25;
            // 
            // comboBoxPointIndex
            // 
            this.comboBoxPointIndex.FormattingEnabled = true;
            this.comboBoxPointIndex.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.comboBoxPointIndex.Location = new System.Drawing.Point(130, 234);
            this.comboBoxPointIndex.Name = "comboBoxPointIndex";
            this.comboBoxPointIndex.Size = new System.Drawing.Size(224, 20);
            this.comboBoxPointIndex.TabIndex = 25;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(130, 150);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(224, 21);
            this.textBoxPassword.TabIndex = 30;
            // 
            // textBoxConnSn
            // 
            this.textBoxConnSn.Location = new System.Drawing.Point(130, 123);
            this.textBoxConnSn.Name = "textBoxConnSn";
            this.textBoxConnSn.Size = new System.Drawing.Size(224, 21);
            this.textBoxConnSn.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 28;
            this.label2.Text = "MgrPassword";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(11, 126);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(59, 12);
            this.label16.TabIndex = 29;
            this.label16.Text = "SnForConn";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(11, 268);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(71, 12);
            this.label21.TabIndex = 17;
            this.label21.Text = "GlModelType";
            // 
            // comboBoxCardModeType
            // 
            this.comboBoxCardModeType.FormattingEnabled = true;
            this.comboBoxCardModeType.Items.AddRange(new object[] {
            "GL-888888",
            "GL-88888",
            "GL-8888",
            "GL-888",
            "GL-888-8",
            "GL-8888-8",
            "GL-88888-8",
            "GL-88-88",
            "GL-888-88",
            "GL-8888-88",
            "GL-888888-910",
            "GL-88888-910",
            "GL-8888-910",
            "GL-888-910"});
            this.comboBoxCardModeType.Location = new System.Drawing.Point(130, 260);
            this.comboBoxCardModeType.Name = "comboBoxCardModeType";
            this.comboBoxCardModeType.Size = new System.Drawing.Size(224, 20);
            this.comboBoxCardModeType.TabIndex = 25;
            // 
            // FormAddCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 450);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxConnSn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.labelScreenName8);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.ScreenTipNames);
            this.Controls.Add(this.comboBoxCardModeType);
            this.Controls.Add(this.comboBoxPointIndex);
            this.Controls.Add(this.comboBoxNumCount);
            this.Controls.Add(this.comboBoxScreenCount);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.textBoxScreenName12);
            this.Controls.Add(this.textBoxScreenName11);
            this.Controls.Add(this.textBoxScreenName9);
            this.Controls.Add(this.textBoxScreenName8);
            this.Controls.Add(this.textBoxScreenName6);
            this.Controls.Add(this.textBoxScreenName10);
            this.Controls.Add(this.textBoxScreenName5);
            this.Controls.Add(this.textBoxScreenName7);
            this.Controls.Add(this.textBoxScreenName3);
            this.Controls.Add(this.textBoxScreenName4);
            this.Controls.Add(this.textBoxScreenName2);
            this.Controls.Add(this.textBoxScreenName1);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.comboBoxProject);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBoxGroup);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxOrg);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Name = "FormAddCard";
            this.Text = "FormAddCard";
            this.Load += new System.EventHandler(this.FormAddCard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.ComboBox comboBoxProject;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxGroup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxOrg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxScreenCount;
        private System.Windows.Forms.Label ScreenTipNames;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxScreenName1;
        private System.Windows.Forms.TextBox textBoxScreenName2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxScreenName3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxScreenName4;
        private System.Windows.Forms.TextBox textBoxScreenName5;
        private System.Windows.Forms.TextBox textBoxScreenName6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBoxScreenName7;
        private System.Windows.Forms.TextBox textBoxScreenName8;
        private System.Windows.Forms.TextBox textBoxScreenName9;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label labelScreenName8;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBoxScreenName10;
        private System.Windows.Forms.TextBox textBoxScreenName11;
        private System.Windows.Forms.TextBox textBoxScreenName12;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox comboBoxNumCount;
        private System.Windows.Forms.ComboBox comboBoxPointIndex;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxConnSn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox comboBoxCardModeType;
    }
}