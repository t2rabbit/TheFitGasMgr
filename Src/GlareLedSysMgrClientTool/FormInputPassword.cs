using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YdPublic;

namespace Property
{
    public partial class FormInputPassword : Form
    {
        public string StrPassword { get; set; }
        public FormInputPassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (StrPassword != textBox1.Text)
            {
                DialogResult = DialogResult.None;
                MessageBox.Show(LanguageMgr.GetKey("InputPassword"));
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void FormInputPassword_Load(object sender, EventArgs e)
        {
            LanguageMgr.ReloadLanguage(this);
        }
    }
}
