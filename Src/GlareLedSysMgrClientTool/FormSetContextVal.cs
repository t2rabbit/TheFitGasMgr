using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Property
{
    public partial class FormSetContextVal : Form
    {
        public string strContext = "";
        public FormSetContextVal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            strContext = "";
            strContext += MakeAString(textBox1);
            strContext += "-";
            strContext += MakeAString(textBox2);
            strContext += "-";
            strContext += MakeAString(textBox3);
            strContext += "-";
            strContext += MakeAString(textBox4);
            strContext += "-";
            strContext += MakeAString(textBox5);
            strContext += "-";
            strContext += MakeAString(textBox6);
            strContext += "-";
            strContext += MakeAString(textBox7);
            strContext += "-";
            strContext += MakeAString(textBox8);
            strContext += "-";
            strContext += MakeAString(textBox9);
            strContext += "-";
            strContext += MakeAString(textBox10);
            strContext += "-";
            strContext += MakeAString(textBox11);
            strContext += "-";
            strContext += MakeAString(textBox12);
            

            DialogResult = DialogResult.OK;
        }

        private string MakeAString(TextBox tx)
        {
            if (tx.Text == "")
            {
                return "000000";
            }
            return tx.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
