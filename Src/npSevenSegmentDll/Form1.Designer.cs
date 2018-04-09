namespace SevenSegTest
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkDotOn = new System.Windows.Forms.CheckBox();
            this.chkDotShow = new System.Windows.Forms.CheckBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.oilScreen1 = new SevenSegTest.OilScreen();
            this.sevenSegmentArray2 = new DmitryBrant.CustomControls.SevenSegmentArray();
            this.sevenSegmentArray1 = new DmitryBrant.CustomControls.SevenSegmentArray();
            this.sevenSegment1 = new DmitryBrant.CustomControls.SevenSegment();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "Symbol:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(75, 11);
            this.textBox1.MaxLength = 1;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(46, 21);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(75, 35);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(46, 21);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "Pattern:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkDotOn);
            this.groupBox1.Controls.Add(this.chkDotShow);
            this.groupBox1.Location = new System.Drawing.Point(12, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(112, 45);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Decimal point";
            // 
            // chkDotOn
            // 
            this.chkDotOn.AutoSize = true;
            this.chkDotOn.Location = new System.Drawing.Point(63, 19);
            this.chkDotOn.Name = "chkDotOn";
            this.chkDotOn.Size = new System.Drawing.Size(36, 16);
            this.chkDotOn.TabIndex = 3;
            this.chkDotOn.Text = "On";
            this.chkDotOn.UseVisualStyleBackColor = true;
            this.chkDotOn.CheckedChanged += new System.EventHandler(this.chkDotShow_CheckedChanged);
            // 
            // chkDotShow
            // 
            this.chkDotShow.AutoSize = true;
            this.chkDotShow.Checked = true;
            this.chkDotShow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDotShow.Location = new System.Drawing.Point(10, 19);
            this.chkDotShow.Name = "chkDotShow";
            this.chkDotShow.Size = new System.Drawing.Size(48, 16);
            this.chkDotShow.TabIndex = 2;
            this.chkDotShow.Text = "Show";
            this.chkDotShow.UseVisualStyleBackColor = true;
            this.chkDotShow.CheckedChanged += new System.EventHandler(this.chkDotShow_CheckedChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(180, 137);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(139, 21);
            this.textBox2.TabIndex = 9;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(71, 137);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(52, 21);
            this.numericUpDown2.TabIndex = 10;
            this.numericUpDown2.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "Elements:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(143, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "Text:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(97, 110);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // oilScreen1
            // 
            this.oilScreen1.BAppend10_9 = false;
            this.oilScreen1.BAppend99 = true;
            this.oilScreen1.iAppendCount = 1;
            this.oilScreen1.iIndexOfPoint = 1;
            this.oilScreen1.iMainCount = 5;
            this.oilScreen1.Location = new System.Drawing.Point(358, 46);
            this.oilScreen1.Name = "oilScreen1";
            this.oilScreen1.Size = new System.Drawing.Size(263, 58);
            this.oilScreen1.strValue = "123456";
            this.oilScreen1.TabIndex = 15;
            // 
            // sevenSegmentArray2
            // 
            this.sevenSegmentArray2.ArrayCount = 4;
            this.sevenSegmentArray2.ColorBackground = System.Drawing.Color.DarkGray;
            this.sevenSegmentArray2.ColorDark = System.Drawing.Color.FromArgb(32, 29, 38);
            this.sevenSegmentArray2.ColorLight = System.Drawing.Color.Red;
            this.sevenSegmentArray2.DecimalShow = true;
            this.sevenSegmentArray2.DisabelCount = 0;
            this.sevenSegmentArray2.ElementPadding = new System.Windows.Forms.Padding(4);
            this.sevenSegmentArray2.ElementWidth = 10;
            this.sevenSegmentArray2.IndexOfPoint = 0;
            this.sevenSegmentArray2.ItalicFactor = 0F;
            this.sevenSegmentArray2.Location = new System.Drawing.Point(222, 37);
            this.sevenSegmentArray2.Name = "sevenSegmentArray2";
            this.sevenSegmentArray2.Size = new System.Drawing.Size(130, 67);
            this.sevenSegmentArray2.TabIndex = 13;
            this.sevenSegmentArray2.TabStop = false;
            this.sevenSegmentArray2.Value = null;
            this.sevenSegmentArray2.Visible = false;
            // 
            // sevenSegmentArray1
            // 
            this.sevenSegmentArray1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sevenSegmentArray1.ArrayCount = 8;
            this.sevenSegmentArray1.ColorBackground = System.Drawing.Color.Black;
            this.sevenSegmentArray1.ColorDark = System.Drawing.Color.FromArgb(32, 29, 38);
            this.sevenSegmentArray1.ColorLight = System.Drawing.Color.Red;
            this.sevenSegmentArray1.DecimalShow = true;
            this.sevenSegmentArray1.DisabelCount = 0;
            this.sevenSegmentArray1.ElementPadding = new System.Windows.Forms.Padding(6, 4, 4, 4);
            this.sevenSegmentArray1.ElementWidth = 10;
            this.sevenSegmentArray1.IndexOfPoint = 0;
            this.sevenSegmentArray1.ItalicFactor = -0.1F;
            this.sevenSegmentArray1.Location = new System.Drawing.Point(12, 161);
            this.sevenSegmentArray1.Name = "sevenSegmentArray1";
            this.sevenSegmentArray1.Size = new System.Drawing.Size(600, 235);
            this.sevenSegmentArray1.TabIndex = 8;
            this.sevenSegmentArray1.TabStop = false;
            this.sevenSegmentArray1.Value = "";
            this.sevenSegmentArray1.Visible = false;
            // 
            // sevenSegment1
            // 
            this.sevenSegment1.ColorBackground = System.Drawing.Color.DimGray;
            this.sevenSegment1.ColorDark = System.Drawing.Color.FromArgb(32, 29, 38);
            this.sevenSegment1.ColorLight = System.Drawing.Color.Lime;
            this.sevenSegment1.CustomPattern = 0;
            this.sevenSegment1.DecimalOn = false;
            this.sevenSegment1.DecimalShow = true;
            this.sevenSegment1.ElementWidth = 10;
            this.sevenSegment1.ItalicFactor = -0.1F;
            this.sevenSegment1.Location = new System.Drawing.Point(146, 14);
            this.sevenSegment1.Name = "sevenSegment1";
            this.sevenSegment1.Padding = new System.Windows.Forms.Padding(12, 4, 8, 4);
            this.sevenSegment1.Size = new System.Drawing.Size(70, 90);
            this.sevenSegment1.TabIndex = 7;
            this.sevenSegment1.TabStop = false;
            this.sevenSegment1.Value = null;
            this.sevenSegment1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 406);
            this.Controls.Add(this.oilScreen1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.sevenSegmentArray2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.sevenSegmentArray1);
            this.Controls.Add(this.sevenSegment1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Seven-Segment Test";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkDotOn;
        private System.Windows.Forms.CheckBox chkDotShow;
        private DmitryBrant.CustomControls.SevenSegment sevenSegment1;
        private DmitryBrant.CustomControls.SevenSegmentArray sevenSegmentArray1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private DmitryBrant.CustomControls.SevenSegmentArray sevenSegmentArray2;
        private System.Windows.Forms.Button button1;
        private OilScreen oilScreen1;


    }
}

