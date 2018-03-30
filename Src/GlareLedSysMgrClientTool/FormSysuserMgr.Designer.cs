namespace Property
{
    partial class FormSysuserMgr
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonDel = new System.Windows.Forms.Button();
            this.buttonMdy = new System.Windows.Forms.Button();
            this.dataGridViewSysUser = new System.Windows.Forms.DataGridView();
            this.ColumnDevName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPortType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDevAddr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column41 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSysUser)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(537, 60);
            this.panel1.TabIndex = 0;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(12, 31);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "添加";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonDel);
            this.panel2.Controls.Add(this.buttonMdy);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 371);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(537, 60);
            this.panel2.TabIndex = 1;
            // 
            // buttonDel
            // 
            this.buttonDel.Location = new System.Drawing.Point(93, 6);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(75, 23);
            this.buttonDel.TabIndex = 0;
            this.buttonDel.Text = "删除";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // buttonMdy
            // 
            this.buttonMdy.Location = new System.Drawing.Point(12, 6);
            this.buttonMdy.Name = "buttonMdy";
            this.buttonMdy.Size = new System.Drawing.Size(75, 23);
            this.buttonMdy.TabIndex = 0;
            this.buttonMdy.Text = "修改";
            this.buttonMdy.UseVisualStyleBackColor = true;
            this.buttonMdy.Click += new System.EventHandler(this.buttonMdy_Click);
            // 
            // dataGridViewSysUser
            // 
            this.dataGridViewSysUser.AllowUserToAddRows = false;
            this.dataGridViewSysUser.AllowUserToDeleteRows = false;
            this.dataGridViewSysUser.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dataGridViewSysUser.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewSysUser.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewSysUser.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSysUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewSysUser.ColumnHeadersHeight = 26;
            this.dataGridViewSysUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewSysUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDevName,
            this.ColumnPortType,
            this.ColumnDevAddr,
            this.Column41});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewSysUser.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewSysUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSysUser.Location = new System.Drawing.Point(0, 60);
            this.dataGridViewSysUser.Name = "dataGridViewSysUser";
            this.dataGridViewSysUser.ReadOnly = true;
            this.dataGridViewSysUser.RowHeadersVisible = false;
            this.dataGridViewSysUser.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Ivory;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Blue;
            this.dataGridViewSysUser.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewSysUser.RowTemplate.Height = 26;
            this.dataGridViewSysUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSysUser.Size = new System.Drawing.Size(537, 311);
            this.dataGridViewSysUser.TabIndex = 9;
            // 
            // ColumnDevName
            // 
            this.ColumnDevName.HeaderText = "用户名";
            this.ColumnDevName.Name = "ColumnDevName";
            this.ColumnDevName.ReadOnly = true;
            // 
            // ColumnPortType
            // 
            this.ColumnPortType.FillWeight = 50F;
            this.ColumnPortType.HeaderText = "加油站ID";
            this.ColumnPortType.Name = "ColumnPortType";
            this.ColumnPortType.ReadOnly = true;
            this.ColumnPortType.Width = 80;
            // 
            // ColumnDevAddr
            // 
            this.ColumnDevAddr.HeaderText = "权限";
            this.ColumnDevAddr.Name = "ColumnDevAddr";
            this.ColumnDevAddr.ReadOnly = true;
            // 
            // Column41
            // 
            this.Column41.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column41.HeaderText = "";
            this.Column41.Name = "Column41";
            this.Column41.ReadOnly = true;
            // 
            // FormSysuserMgr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 431);
            this.Controls.Add(this.dataGridViewSysUser);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormSysuserMgr";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormSysuserMgr";
            this.Load += new System.EventHandler(this.FormSysuserMgr_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSysUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridViewSysUser;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Button buttonMdy;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDevName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPortType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDevAddr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column41;
    }
}