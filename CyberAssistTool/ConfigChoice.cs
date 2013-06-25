using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CyberAssistTool
{
	public partial class ConfigChoice : Form
	{
		public ConfigChoice()
		{
			InitializeComponent();
		}

		private void ConfigChoice_Load(object sender, EventArgs e)
		{
			//this.ShowInTaskbar = false;
			//this.ShowIcon = false;
			
		}

		private void tribesBtn_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Yes;
			this.Close();
		}

		private void smiteBtn_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.No;
			this.Close();
		}

		private void otherBtn_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Retry;
			this.Close();
		}

	}
}
