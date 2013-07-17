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
	public partial class SettingsMenu : Form
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

		public SettingsMenu()
		{
			InitializeComponent();
		}

		private void Settings_Load(object sender, EventArgs e)
		{
			myDocumentsTextBox.Text = MyDocumentsPath;
			programDataTextBox.Text = ProgramDataPath;
		}

		private void pathButton_Click(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
			TextBox textBox;

			FolderBrowserDialog browser = new FolderBrowserDialog();
			if (btn == myDocumentsButton)
			{
				browser.SelectedPath = MyDocumentsPath;
				textBox = myDocumentsTextBox;
			}
			else
			{
				browser.SelectedPath = ProgramDataPath;
				textBox = programDataTextBox;
			}
			
			if (browser.ShowDialog() == DialogResult.OK)
			{
				textBox.Text = browser.SelectedPath;
			}
		}

		private void resetButton_Click(object sender, EventArgs e)
		{
			MyDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			ProgramDataPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
			myDocumentsTextBox.Text = MyDocumentsPath;
			programDataTextBox.Text = ProgramDataPath;
		}

		private void saveButton_Click(object sender, EventArgs e)
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
			System.Media.SystemSounds.Asterisk.Play();
			this.Close();
			
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		

	}
}
