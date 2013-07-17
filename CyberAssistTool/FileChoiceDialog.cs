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
	public partial class FileChoiceDialog : Form
	{
		public FileChoiceDialog()
		{
			InitializeComponent();
		}

		private void tribesButton_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Yes;
			this.Close();
		}

		private void smiteButton_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.No;
			this.Close();
		}

		private void otherButton_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Retry;
			this.Close();
		}

	}
}
