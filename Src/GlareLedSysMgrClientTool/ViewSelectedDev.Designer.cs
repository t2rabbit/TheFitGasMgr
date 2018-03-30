namespace Property
{
    partial class ViewSelectedDev
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSeleedOrg = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonSetContext = new System.Windows.Forms.Button();
            this.buttonRead = new System.Windows.Forms.Button();
            this.buttonSend = new System.Windows.Forms.Button();
            this.dataGridViewCards = new System.Windows.Forms.DataGridView();
            this.panelOrg = new System.Windows.Forms.Panel();
            this.ColumnCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnDevAddr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDevName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPortType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCardSCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCardContext = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDevOnLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column41 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCards)).BeginInit();
            this.panelOrg.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前选择的端口为:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(161, 47);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(322, 21);
            this.textBox1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelOrg);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(855, 86);
            this.panel1.TabIndex = 2;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Property.Properties.Resources.bullet_triangle_yellow;
            this.pictureBox2.Location = new System.Drawing.Point(16, 41);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Property.Properties.Resources.bullet_triangle_yellow;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "当前组织选择为：";
            // 
            // textBoxSeleedOrg
            // 
            this.textBoxSeleedOrg.Enabled = false;
            this.textBoxSeleedOrg.Location = new System.Drawing.Point(145, 9);
            this.textBoxSeleedOrg.Name = "textBoxSeleedOrg";
            this.textBoxSeleedOrg.ReadOnly = true;
            this.textBoxSeleedOrg.Size = new System.Drawing.Size(322, 21);
            this.textBoxSeleedOrg.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonSetContext);
            this.panel2.Controls.Add(this.buttonRead);
            this.panel2.Controls.Add(this.buttonSend);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 488);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(855, 100);
            this.panel2.TabIndex = 3;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // buttonSetContext
            // 
            this.buttonSetContext.Location = new System.Drawing.Point(16, 20);
            this.buttonSetContext.Name = "buttonSetContext";
            this.buttonSetContext.Size = new System.Drawing.Size(75, 23);
            this.buttonSetContext.TabIndex = 5;
            this.buttonSetContext.Text = "设置内容";
            this.buttonSetContext.UseVisualStyleBackColor = true;
            this.buttonSetContext.Click += new System.EventHandler(this.buttonSetContext_Click);
            // 
            // buttonRead
            // 
            this.buttonRead.Location = new System.Drawing.Point(101, 20);
            this.buttonRead.Name = "buttonRead";
            this.buttonRead.Size = new System.Drawing.Size(75, 23);
            this.buttonRead.TabIndex = 4;
            this.buttonRead.Text = "读取";
            this.buttonRead.UseVisualStyleBackColor = true;
            this.buttonRead.Click += new System.EventHandler(this.buttonRead_Click);
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(182, 20);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 3;
            this.buttonSend.Text = "发送";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // dataGridViewCards
            // 
            this.dataGridViewCards.AllowUserToAddRows = false;
            this.dataGridViewCards.AllowUserToDeleteRows = false;
            this.dataGridViewCards.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dataGridViewCards.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewCards.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewCards.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewCards.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCards.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewCards.ColumnHeadersHeight = 26;
            this.dataGridViewCards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewCards.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCheck,
            this.ColumnDevAddr,
            this.ColumnDevName,
            this.ColumnPortType,
            this.ColumnCardSCount,
            this.ColumnCardContext,
            this.ColumnDevOnLine,
            this.Column41});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCards.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCards.Location = new System.Drawing.Point(0, 86);
            this.dataGridViewCards.Name = "dataGridViewCards";
            this.dataGridViewCards.ReadOnly = true;
            this.dataGridViewCards.RowHeadersVisible = false;
            this.dataGridViewCards.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Ivory;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Blue;
            this.dataGridViewCards.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewCards.RowTemplate.Height = 26;
            this.dataGridViewCards.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCards.Size = new System.Drawing.Size(855, 402);
            this.dataGridViewCards.TabIndex = 4;
            // 
            // panelOrg
            // 
            this.panelOrg.Controls.Add(this.pictureBox1);
            this.panelOrg.Controls.Add(this.textBoxSeleedOrg);
            this.panelOrg.Controls.Add(this.label2);
            this.panelOrg.Location = new System.Drawing.Point(15, 0);
            this.panelOrg.Name = "panelOrg";
            this.panelOrg.Size = new System.Drawing.Size(689, 35);
            this.panelOrg.TabIndex = 6;
            // 
            // ColumnCheck
            // 
            this.ColumnCheck.HeaderText = "";
            this.ColumnCheck.Name = "ColumnCheck";
            this.ColumnCheck.ReadOnly = true;
            this.ColumnCheck.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnCheck.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnCheck.Width = 30;
            // 
            // ColumnDevAddr
            // 
            this.ColumnDevAddr.HeaderText = "卡号";
            this.ColumnDevAddr.Name = "ColumnDevAddr";
            this.ColumnDevAddr.ReadOnly = true;
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
            // ViewSelectedDev
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Property.Properties.Resources._09215152;
            this.ClientSize = new System.Drawing.Size(855, 588);
            this.Controls.Add(this.dataGridViewCards);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ViewSelectedDev";
            this.Text = "ViewInit";
            this.Load += new System.EventHandler(this.ViewSelectedDev_Load);
            this.VisibleChanged += new System.EventHandler(this.ViewSelectedDev_VisibleChanged);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCards)).EndInit();
            this.panelOrg.ResumeLayout(false);
            this.panelOrg.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridViewCards;
        private System.Windows.Forms.Button buttonSetContext;
        private System.Windows.Forms.Button buttonRead;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSeleedOrg;
        private System.Windows.Forms.Panel panelOrg;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDevAddr;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDevName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPortType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCardSCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCardContext;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDevOnLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column41;

    }
}