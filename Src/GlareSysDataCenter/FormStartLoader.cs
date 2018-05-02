using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GlareSysDataCenter
{
    public partial class FormStartLoader : Form
    {
        BackgroundWorker bkw;
        public FormStartLoader(BackgroundWorker bk)
        {
            bkw = bk;
            bkw.ProgressChanged += new ProgressChangedEventHandler(process_changed);
            bkw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(process_complete);
            InitializeComponent();
        }

        private void FormStartLoader_Load(object sender, EventArgs e)
        {

        }

        public void process_changed(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;
        }

        void process_complete(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();//执行完之后，直接关闭页面
        }

        int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = i++;

            if (i>=90)
            { i = 1; }
        }
    }
}
