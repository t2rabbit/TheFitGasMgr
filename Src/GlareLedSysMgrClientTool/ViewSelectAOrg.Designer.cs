namespace Property
{
    partial class ViewSelectAOrg
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSeleedOrg = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonSetContext = new System.Windows.Forms.Button();
            this.buttonRead = new System.Windows.Forms.Button();
            this.buttonSend = new System.Windows.Forms.Button();
            this.dataGridViewCards = new System.Windows.Forms.DataGridView();
            this.ColumnDevName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPortType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDevAddr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCardSCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCardContext = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDevOnLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column41 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前组织选择为：";
            // 
            // textBoxSeleedOrg
            // 
            this.textBoxSeleedOrg.Enabled = false;
            this.textBoxSeleedOrg.Location = new System.Drawing.Point(155, 11);
            this.textBoxSeleedOrg.Name = "textBoxSeleedOrg";
            this.textBoxSeleedOrg.ReadOnly = true;
            this.textBoxSeleedOrg.Size = new System.Drawing.Size(322, 21);
            this.textBoxSeleedOrg.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxSeleedOrg);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(556, 84);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonSetContext);
            this.panel2.Controls.Add(this.buttonRead);
            this.panel2.Controls.Add(this.buttonSend);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 445);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(556, 100);
            this.panel2.TabIndex = 3;
            // 
            // buttonSetContext
            // 
            this.buttonSetContext.Location = new System.Drawing.Point(10, 5);
            this.buttonSetContext.Name = "buttonSetContext";
            this.buttonSetContext.Size = new System.Drawing.Size(75, 23);
            this.buttonSetContext.TabIndex = 2;
            this.buttonSetContext.Text = "设置内容";
            this.buttonSetContext.UseVisualStyleBackColor = true;
            this.buttonSetContext.Click += new System.EventHandler(this.buttonSetContext_Click);
            // 
            // buttonRead
            // 
            this.buttonRead.Location = new System.Drawing.Point(99, 6);
            this.buttonRead.Name = "buttonRead";
            this.buttonRead.Size = new System.Drawing.Size(75, 23);
            this.buttonRead.TabIndex = 1;
            this.buttonRead.Text = "读取";
            this.buttonRead.UseVisualStyleBackColor = true;
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(180, 6);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 0;
            this.buttonSend.Text = "发送";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // dataGridViewCards
            // 
            this.dataGridViewCards.AllowUserToAddRows = false;
            this.dataGridViewCards.AllowUserToDeleteRows = false;
            this.dataGridViewCards.AllowUserToResizeRows = false;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.White;
            this.dataGridViewCards.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewCards.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewCards.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewCards.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCards.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewCards.ColumnHeadersHeight = 26;
            this.dataGridViewCards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewCards.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDevName,
            this.ColumnPortType,
            this.ColumnDevAddr,
            this.ColumnCardSCount,
            this.ColumnCardContext,
            this.ColumnDevOnLine,
            this.Column41});
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCards.DefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridViewCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCards.Location = new System.Drawing.Point(0, 84);
            this.dataGridViewCards.Name = "dataGridViewCards";
            this.dataGridViewCards.ReadOnly = true;
            this.dataGridViewCards.RowHeadersVisible = false;
            this.dataGridViewCards.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.Ivory;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.Blue;
            this.dataGridViewCards.RowsDefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridViewCards.RowTemplate.Height = 26;
            this.dataGridViewCards.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCards.Size = new System.Drawing.Size(556, 361);
            this.dataGridViewCards.TabIndex = 8;
            // 
            // ColumnDevName
            // 
            this.ColumnDevName.HeaderText = "端口名";
            this.ColumnDevName.Name = "ColumnDevName";
            this.ColumnDevName.ReadOnly = true;
            // 
            // ColumnPortType
            // 
            this.ColumnPortType.FillWeight = 50F;
            this.ColumnPortType.HeaderText = "端口类型";
            this.ColumnPortType.Name = "ColumnPortType";
            this.ColumnPortType.ReadOnly = true;
            this.ColumnPortType.Width = 80;
            // 
            // ColumnDevAddr
            // 
            this.ColumnDevAddr.HeaderText = "卡号";
            this.ColumnDevAddr.Name = "ColumnDevAddr";
            this.ColumnDevAddr.ReadOnly = true;
            // 
            // ColumnCardSCount
            // 
            this.ColumnCardSCount.HeaderText = "屏幕数量";
            this.ColumnCardSCount.Name = "ColumnCardSCount";
            this.ColumnCardSCount.ReadOnly = true;
            // 
            // ColumnCardContext
            // 
            this.ColumnCardContext.HeaderText = "屏幕内容";
            this.ColumnCardContext.Name = "ColumnCardContext";
            this.ColumnCardContext.ReadOnly = true;
            // 
            // ColumnDevOnLine
            // 
            this.ColumnDevOnLine.HeaderText = "是否在线";
            this.ColumnDevOnLine.Name = "ColumnDevOnLine";
            this.ColumnDevOnLine.ReadOnly = true;
            // 
            // Column41
            // 
            this.Column41.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column41.HeaderText = "";
            this.Column41.Name = "Column41";
            this.Column41.ReadOnly = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Property.Properties.Resources.bullet_triangle_yellow;
            this.pictureBox1.Location = new System.Drawing.Point(10, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Property.Properties.Resources.bullet_triangle_yellow;
            this.pictureBox2.Location = new System.Drawing.Point(10, 49);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "端口列表>>";
            // 
            // ViewSelectAOrg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 545);
            this.Controls.Add(this.dataGridViewCards);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ViewSelectAOrg";
            this.Text = "ViewSelectOrg";
            this.Load += new System.EventHandler(this.ViewSelectOrg_Load);
            this.VisibleChanged += new System.EventHandler(this.ViewSelectOrg_VisibleChanged);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSeleedOrg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridViewCards;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDevName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPortType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDevAddr;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCardSCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCardContext;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDevOnLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column41;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Button buttonRead;
        private System.Windows.Forms.Button buttonSetContext;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
    }
}