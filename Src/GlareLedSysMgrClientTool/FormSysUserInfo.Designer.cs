namespace Property
{
    partial class FormSysUserInfo
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
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelAuth = new System.Windows.Forms.Label();
            this.labelOil = new System.Windows.Forms.Label();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.comboBoxAuth = new System.Windows.Forms.ComboBox();
            this.comboBoxOilStation = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(70, 172);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(151, 172);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(22, 28);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(41, 12);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "用户名";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(22, 60);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(29, 12);
            this.labelPassword.TabIndex = 1;
            this.labelPassword.Text = "密码";
            // 
            // labelAuth
            // 
            this.labelAuth.AutoSize = true;
            this.labelAuth.Location = new System.Drawing.Point(22, 93);
            this.labelAuth.Name = "labelAuth";
            this.labelAuth.Size = new System.Drawing.Size(29, 12);
            this.labelAuth.TabIndex = 1;
            this.labelAuth.Text = "权限";
            // 
            // labelOil
            // 
            this.labelOil.AutoSize = true;
            this.labelOil.Location = new System.Drawing.Point(22, 125);
            this.labelOil.Name = "labelOil";
            this.labelOil.Size = new System.Drawing.Size(77, 12);
            this.labelOil.TabIndex = 1;
            this.labelOil.Text = "分配到加油站";
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(105, 25);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(121, 21);
            this.textBoxUserName.TabIndex = 2;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(105, 57);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(121, 21);
            this.textBoxPassword.TabIndex = 2;
            // 
            // comboBoxAuth
            // 
            this.comboBoxAuth.FormattingEnabled = true;
            this.comboBoxAuth.Items.AddRange(new object[] {
            "普通",
            "高级"});
            this.comboBoxAuth.Location = new System.Drawing.Point(105, 84);
            this.comboBoxAuth.Name = "comboBoxAuth";
            this.comboBoxAuth.Size = new System.Drawing.Size(121, 20);
            this.comboBoxAuth.TabIndex = 3;
            // 
            // comboBoxOilStation
            // 
            this.comboBoxOilStation.FormattingEnabled = true;
            this.comboBoxOilStation.Location = new System.Drawing.Point(105, 122);
            this.comboBoxOilStation.Name = "comboBoxOilStation";
            this.comboBoxOilStation.Size = new System.Drawing.Size(121, 20);
            this.comboBoxOilStation.TabIndex = 3;
            // 
            // FormSysUserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 205);
            this.Controls.Add(this.comboBoxOilStation);
            this.Controls.Add(this.comboBoxAuth);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.labelOil);
            this.Controls.Add(this.labelAuth);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Name = "FormSysUserInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormSysUserInfo";
            this.Load += new System.EventHandler(this.FormSysUserInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelAuth;
        private System.Windows.Forms.Label labelOil;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.ComboBox comboBoxAuth;
        private System.Windows.Forms.ComboBox comboBoxOilStation;
    }
}