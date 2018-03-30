namespace Property
{
    partial class FormTest
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timeTemputer1 = new SevenSegTest.TimeTemputer();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // timeTemputer1
            // 
            this.timeTemputer1.BackColor = System.Drawing.Color.Black;
            this.timeTemputer1.BFiexZero = true;
            this.timeTemputer1.BShowDashDot = true;
            this.timeTemputer1.dtTime = new System.DateTime(2018, 3, 18, 9, 7, 50, 929);
            this.timeTemputer1.IDashDotWidth = 0;
            this.timeTemputer1.IDigHeight = 30;
            this.timeTemputer1.IDigWidth = 24;
            this.timeTemputer1.IsShowDashAfterYear = false;
            this.timeTemputer1.IsShowDay = true;
            this.timeTemputer1.IsShowHour = true;
            this.timeTemputer1.IsShowMinute = true;
            this.timeTemputer1.IsShowMonth = true;
            this.timeTemputer1.IsShowSecond = true;
            this.timeTemputer1.IsShowYear = true;
            this.timeTemputer1.Location = new System.Drawing.Point(30, 129);
            this.timeTemputer1.Name = "timeTemputer1";
            this.timeTemputer1.Size = new System.Drawing.Size(627, 34);
            this.timeTemputer1.TabIndex = 2;
            this.timeTemputer1.YearCount = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(70, 189);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "button1";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 273);
            this.Controls.Add(this.timeTemputer1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "FormTest";
            this.Text = "FormTest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private SevenSegTest.TimeTemputer timeTemputer1;
        private System.Windows.Forms.Button button2;
    }
}