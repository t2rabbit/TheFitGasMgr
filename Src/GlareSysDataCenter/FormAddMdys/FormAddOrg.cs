using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GlareSysEfDbAndModels;

namespace GlareSysDataCenter.FromAddMdys
{
    public partial class FormAddOrg : Form
    {
        public FormAddOrg()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OrgInfo obj = new OrgInfo()
            { Address = "",
                CreateDt = DateTime.Now,
                Id = 0,
                IsDel = 0,
                ManageName = textBoxManagerName.Text,
                ManageTel = textBoxTel.Text,
                Name = textBoxName.Text,
                UpdateDt = DateTime.Now
            };
            string strMsg;
            if (!GlareLedSysBll.OrgBll.AddAOrg(ref obj , out strMsg))
            {
                MessageBox.Show(strMsg);
                DialogResult = DialogResult.Cancel;
            }
        }
    }
}
