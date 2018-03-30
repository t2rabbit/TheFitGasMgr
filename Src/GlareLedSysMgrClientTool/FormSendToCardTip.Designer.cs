namespace Property
{
    partial class FormSendToCardTip
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewCardList = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCardListCaidName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCardListPortName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCardListOrgName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCardListPortType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCardListScreenCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCardListScreenInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCardListIsOnLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCardList)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewCardList
            // 
            this.dataGridViewCardList.AllowUserToAddRows = false;
            this.dataGridViewCardList.AllowUserToDeleteRows = false;
            this.dataGridViewCardList.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.dataGridViewCardList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewCardList.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewCardList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewCardList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCardList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewCardList.ColumnHeadersHeight = 26;
            this.dataGridViewCardList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewCardList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewCardListCaidName,
            this.dataGridViewCardListPortName,
            this.dataGridViewCardListOrgName,
            this.dataGridViewCardListPortType,
            this.dataGridViewCardListScreenCount,
            this.dataGridViewCardListScreenInfo,
            this.dataGridViewCardListIsOnLine,
            this.dataGridViewTextBoxColumn8});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCardList.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewCardList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCardList.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewCardList.Name = "dataGridViewCardList";
            this.dataGridViewCardList.RowHeadersVisible = false;
            this.dataGridViewCardList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Ivory;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Blue;
            this.dataGridViewCardList.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewCardList.RowTemplate.Height = 26;
            this.dataGridViewCardList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCardList.Size = new System.Drawing.Size(786, 275);
            this.dataGridViewCardList.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(103, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 16;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = " 结果";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewCheckBoxColumn1.Width = 200;
            // 
            // dataGridViewCardListCaidName
            // 
            this.dataGridViewCardListCaidName.HeaderText = "卡号";
            this.dataGridViewCardListCaidName.Name = "dataGridViewCardListCaidName";
            // 
            // dataGridViewCardListPortName
            // 
            this.dataGridViewCardListPortName.HeaderText = "端口名";
            this.dataGridViewCardListPortName.Name = "dataGridViewCardListPortName";
            // 
            // dataGridViewCardListOrgName
            // 
            this.dataGridViewCardListOrgName.HeaderText = "组织";
            this.dataGridViewCardListOrgName.Name = "dataGridViewCardListOrgName";
            // 
            // dataGridViewCardListPortType
            // 
            this.dataGridViewCardListPortType.FillWeight = 50F;
            this.dataGridViewCardListPortType.HeaderText = "端口类型";
            this.dataGridViewCardListPortType.Name = "dataGridViewCardListPortType";
            this.dataGridViewCardListPortType.Width = 80;
            // 
            // dataGridViewCardListScreenCount
            // 
            this.dataGridViewCardListScreenCount.HeaderText = "屏幕数量";
            this.dataGridViewCardListScreenCount.Name = "dataGridViewCardListScreenCount";
            // 
            // dataGridViewCardListScreenInfo
            // 
            this.dataGridViewCardListScreenInfo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewCardListScreenInfo.HeaderText = "屏幕内容";
            this.dataGridViewCardListScreenInfo.Name = "dataGridViewCardListScreenInfo";
            // 
            // dataGridViewCardListIsOnLine
            // 
            this.dataGridViewCardListIsOnLine.HeaderText = "是否在线";
            this.dataGridViewCardListIsOnLine.Name = "dataGridViewCardListIsOnLine";
            this.dataGridViewCardListIsOnLine.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn8.HeaderText = "";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Visible = false;
            this.dataGridViewTextBoxColumn8.Width = 76;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 275);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(786, 41);
            this.panel1.TabIndex = 17;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonCancel);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(586, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 41);
            this.panel2.TabIndex = 17;
            // 
            // FormSendToCardTip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 316);
            this.Controls.Add(this.dataGridViewCardList);
            this.Controls.Add(this.panel1);
            this.Name = "FormSendToCardTip";
            this.Text = "FormSendToCardTip";
            this.Load += new System.EventHandler(this.FormSendToCardTip_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCardList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewCardList;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewCardListCaidName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewCardListPortName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewCardListOrgName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewCardListPortType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewCardListScreenCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewCardListScreenInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewCardListIsOnLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;

    }
}