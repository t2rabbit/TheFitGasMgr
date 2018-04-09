namespace 功能测试代码
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonLoginWs = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.buttonDel = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.buttonAddRelCtl = new System.Windows.Forms.Button();
            this.buttonGetAllProject = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonLoginWs
            // 
            this.buttonLoginWs.Location = new System.Drawing.Point(13, 52);
            this.buttonLoginWs.Name = "buttonLoginWs";
            this.buttonLoginWs.Size = new System.Drawing.Size(158, 23);
            this.buttonLoginWs.TabIndex = 1;
            this.buttonLoginWs.Text = "buttonLoginWs";
            this.buttonLoginWs.UseVisualStyleBackColor = true;
            this.buttonLoginWs.Click += new System.EventHandler(this.buttonLoginWs_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 81);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "添加中心用户";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 110);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(158, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "添加网关";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(13, 139);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(158, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "添加设备";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(13, 168);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(158, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "添加节点";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // buttonDel
            // 
            this.buttonDel.Location = new System.Drawing.Point(13, 197);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(92, 23);
            this.buttonDel.TabIndex = 3;
            this.buttonDel.Text = "删除节点";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(111, 198);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(60, 21);
            this.textBox1.TabIndex = 4;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(309, 52);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(158, 23);
            this.button5.TabIndex = 2;
            this.button5.Text = "添加计划的控制命令";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // buttonAddRelCtl
            // 
            this.buttonAddRelCtl.Location = new System.Drawing.Point(309, 81);
            this.buttonAddRelCtl.Name = "buttonAddRelCtl";
            this.buttonAddRelCtl.Size = new System.Drawing.Size(158, 23);
            this.buttonAddRelCtl.TabIndex = 2;
            this.buttonAddRelCtl.Text = "添加实时控制的命令";
            this.buttonAddRelCtl.UseVisualStyleBackColor = true;
            this.buttonAddRelCtl.Click += new System.EventHandler(this.buttonAddRelCtl_Click);
            // 
            // buttonGetAllProject
            // 
            this.buttonGetAllProject.Location = new System.Drawing.Point(364, 157);
            this.buttonGetAllProject.Name = "buttonGetAllProject";
            this.buttonGetAllProject.Size = new System.Drawing.Size(75, 23);
            this.buttonGetAllProject.TabIndex = 5;
            this.buttonGetAllProject.Text = "getall";
            this.buttonGetAllProject.UseVisualStyleBackColor = true;
            this.buttonGetAllProject.Click += new System.EventHandler(this.buttonGetAllProject_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 273);
            this.Controls.Add(this.buttonGetAllProject);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonDel);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonAddRelCtl);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonLoginWs);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLoginWs;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button buttonAddRelCtl;
        private System.Windows.Forms.Button buttonGetAllProject;
    }
}

