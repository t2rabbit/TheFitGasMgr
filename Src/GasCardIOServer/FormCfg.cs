using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using IOServer.BLL;

namespace IOServer
{
	public partial class FormCfg : Form
	{
		public FormCfg()
		{
			InitializeComponent();
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;

			Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			AppSettingsSection app = config.AppSettings;
			

			app.Settings["Hdesc121Live"].Value = textBoxHdesc121LiveTimes.Text;
			app.Settings["Hdesc121SendHeadbeat"].Value = textBoxHdesc121SendHeartbeat.Text;
			app.Settings["AutoGetDevData"].Value = checkBoxGetDevDataStart.Checked ? "1" : "0";
			app.Settings["AutoUploadData"].Value = checkBoxUploadDataStart.Checked ? "1" : "0";
			config.Save(ConfigurationSaveMode.Modified);

			this.DialogResult = DialogResult.OK;
			MessageBox.Show("配置更改成功!");

			// MessageBox.Show(ConfigurationManager.AppSettings["AutoUploadData"]);
			ConfigurationManager.RefreshSection("appSettings");
		}

		private void FormCfg_Load(object sender, EventArgs e)
		{

			txtPickupPeriod.Text = CfgMgr.GetGetDevDataRate().ToString();
			textBoxHdesc121LiveTimes.Text = ConfigurationManager.AppSettings["Hdesc121Live"];
			textBoxHdesc121SendHeartbeat.Text = ConfigurationManager.AppSettings["Hdesc121SendHeadbeat"];
			checkBoxGetDevDataStart.Checked = ConfigurationManager.AppSettings["AutoGetDevData"] == "1";
			checkBoxUploadDataStart.Checked = ConfigurationManager.AppSettings["AutoUploadData"] == "1";

	

			
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
		}
	}
}
