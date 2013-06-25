using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CyberAssistTool
{
	public partial class Settings : Form
	{
		public static String MyDocumentsPath
		{
			get { return Properties.Settings.Default.MyDocumentsPath; }
			set
			{
				Properties.Settings.Default.MyDocumentsPath = value;
				Properties.Settings.Default.Save();
			}
		}
		public static String ProgramDataPath
		{
			get { return Properties.Settings.Default.ProgramDataPath; }
			set 
			{ 
				Properties.Settings.Default.ProgramDataPath = value;
				Properties.Settings.Default.Save();
			}
		}

		public Settings()
		{
			InitializeComponent();
		}

		private void Settings_Load(object sender, EventArgs e)
		{
			myDocumentsTb.Text = MyDocumentsPath;
			programDataTb.Text = ProgramDataPath;
		}

		private void pathBtn_Click(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			TextBox textBox;

			FolderBrowserDialog browser = new FolderBrowserDialog();
			if (button == myDocumentsBtn)
			{
				browser.SelectedPath = MyDocumentsPath;
				textBox = myDocumentsTb;
			}
			else
			{
				browser.SelectedPath = ProgramDataPath;
				textBox = programDataTb;
			}
			
			if (browser.ShowDialog() == DialogResult.OK)
			{
				textBox.Text = browser.SelectedPath;
			}
		}

		private void resetBtn_Click(object sender, EventArgs e)
		{
			MyDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			ProgramDataPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
			myDocumentsTb.Text = MyDocumentsPath;
			programDataTb.Text = ProgramDataPath;
		}

		private void saveBtn_Click(object sender, EventArgs e)
		{
			foreach (var tb in this.Controls.OfType<TextBox>())
			{
				if (Directory.Exists(tb.Text))
				{
					if (tb.Name.Contains("myDocuments"))
					{
						MyDocumentsPath = tb.Text.TrimEnd('\\');
					}
					else
					{
						ProgramDataPath = tb.Text.TrimEnd('\\');
					}
				}
				else
				{
					System.Media.SystemSounds.Exclamation.Play();
					MessageBox.Show("Invalid directory path", "Error");
					tb.Focus();
					tb.SelectAll();
				}
			}
			
		}

		private void cancelBtn_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		

	}
}
