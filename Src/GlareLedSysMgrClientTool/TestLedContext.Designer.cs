namespace Property
{
    partial class TestLedContext
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
            this.oilScreenEx1 = new SevenSegTest.OilScreenEx();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // oilScreenEx1
            // 
            this.oilScreenEx1.BAppend10_9 = false;
            this.oilScreenEx1.BAppend99 = false;
            this.oilScreenEx1.iAppendCount = 2;
            this.oilScreenEx1.iIndexOfPoint = 1;
            this.oilScreenEx1.iMainCount = 6;
            this.oilScreenEx1.Location = new System.Drawing.Point(17, 74);
            this.oilScreenEx1.Name = "oilScreenEx1";
            this.oilScreenEx1.Size = new System.Drawing.Size(235, 58);
            this.oilScreenEx1.strValue = "1.2.3.4.5.6";
            this.oilScreenEx1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(132, 175);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TestLedContext
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.oilScreenEx1);
            this.Name = "TestLedContext";
            this.Text = "TestLedContext";
            this.ResumeLayout(false);

        }

        #endregion

        private SevenSegTest.OilScreenEx oilScreenEx1;
        private System.Windows.Forms.Button button1;
    }
}