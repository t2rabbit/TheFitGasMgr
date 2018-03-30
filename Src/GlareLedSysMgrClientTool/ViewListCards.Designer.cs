namespace Property
{
    partial class ViewListCards
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonSend = new System.Windows.Forms.Button();
            this.dataGridViewCards = new System.Windows.Forms.DataGridView();
            this.ColumnCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnCardName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCardModule = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDevAddr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDevName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPortType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOrgName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCardSCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCardContext = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDevOnLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column41 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonSetDbContext = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCards)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前选择";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(62, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(475, 21);
            this.textBox1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(744, 39);
            this.panel1.TabIndex = 2;
            this.panel1.VisibleChanged += new System.EventHandler(this.panel1_VisibleChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonSetDbContext);
            this.panel2.Controls.Add(this.buttonSend);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 439);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(744, 100);
            this.panel2.TabIndex = 4;
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(88, 6);
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
            this.ColumnCardName,
            this.ColumnCardModule,
            this.ColumnDevAddr,
            this.ColumnDevName,
            this.ColumnPortType,
            this.ColumnOrgName,
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
            this.dataGridViewCards.Location = new System.Drawing.Point(0, 39);
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
            this.dataGridViewCards.Size = new System.Drawing.Size(744, 400);
            this.dataGridViewCards.TabIndex = 5;
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
            // ColumnCardName
            // 
            this.ColumnCardName.HeaderText = "卡名字";
            this.ColumnCardName.Name = "ColumnCardName";
            this.ColumnCardName.ReadOnly = true;
            // 
            // ColumnCardModule
            // 
            this.ColumnCardModule.HeaderText = "卡类型";
            this.ColumnCardModule.Name = "ColumnCardModule";
            this.ColumnCardModule.ReadOnly = true;
            // 
            // ColumnDevAddr
            // 
            this.ColumnDevAddr.HeaderText = "卡地址";
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
            // ColumnOrgName
            // 
            this.ColumnOrgName.HeaderText = "油站名";
            this.ColumnOrgName.Name = "ColumnOrgName";
            this.ColumnOrgName.ReadOnly = true;
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
            // buttonSetDbContext
            // 
            this.buttonSetDbContext.Location = new System.Drawing.Point(7, 6);
            this.buttonSetDbContext.Name = "buttonSetDbContext";
            this.buttonSetDbContext.Size = new System.Drawing.Size(75, 23);
            this.buttonSetDbContext.TabIndex = 4;
            this.buttonSetDbContext.Text = "设置DB内容";
            this.buttonSetDbContext.UseVisualStyleBackColor = true;
            this.buttonSetDbContext.Click += new System.EventHandler(this.buttonSetContext_Click);
            // 
            // ViewListCards
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 539);
            this.Controls.Add(this.dataGridViewCards);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ViewListCards";
            this.Text = "ViewListCards";
            this.Load += new System.EventHandler(this.ViewListCards_Load);
            this.VisibleChanged += new System.EventHandler(this.ViewListCards_VisibleChanged);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCards)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.DataGridView dataGridViewCards;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCardName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCardModule;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDevAddr;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDevName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPortType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOrgName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCardSCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCardContext;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDevOnLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column41;
        private System.Windows.Forms.Button buttonSetDbContext;
    }
}