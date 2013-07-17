using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace CyberAssistTool
{
	public partial class RepairMenu : Form
	{
		public RepairMenu()
		{
			InitializeComponent();
		}

		private void repairButton_Click(object sender, EventArgs e)
		{
			repairButton.Enabled = false;

			Process p = new Process();
			p.StartInfo.FileName = "cmd.exe";
			p.StartInfo.RedirectStandardInput = true;
			p.StartInfo.UseShellExecute = false;
			p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
			p.Start();

			using (StreamWriter shell = p.StandardInput)
			{
				if (shell.BaseStream.CanWrite)
				{
					shell.WriteLine(@"taskkill /s /f /im Smite.exe");
					shell.WriteLine(@"timeout /t 3");
					progressBar.Increment(7);
					shell.WriteLine(@"taskkill /s /f /im HirezLauncherUI.exe");
					shell.WriteLine(@"timeout /t 3");
					progressBar.Increment(7);
					shell.WriteLine(@"taskkill /s /f /im HirezGameNotifier.exe");
					shell.WriteLine(@"timeout /t 3");
					progressBar.Increment(7);
					shell.WriteLine(@"Net stop HiPatchService");
					shell.WriteLine(@"timeout /t 3");
					progressBar.Increment(7);
					//shell.WriteLine(@"xcopy C:\Users\%username%\Documents\My Games\Smite\*.* C:\Users\%username%\Documents\My Games\CAT_Holding\");
					shell.WriteLine(@"timeout /t 3");
					progressBar.Increment(7);
					//shell.WriteLine(@"DEL C:\Users\%username%\Documents\My Games\Smite\*.*");
					shell.WriteLine(@"timeout /t 3");
					progressBar.Increment(7);
					shell.WriteLine(@"Net start HiPatchService");
					shell.WriteLine(@"timeout /t 3");
					progressBar.Increment(7);
					shell.WriteLine(@"timeout /t 3");
					shell.WriteLine(@"C:\Program Files\Hi-Rez Studios\HiRezLauncherUI.exe game=300 product=17");
					progressBar.Increment(7);
					shell.WriteLine(@"timeout /t 20");
					progressBar.Increment(7);
					shell.WriteLine(@"taskkill /s /f /im HirezLauncherUI.exe");
					shell.WriteLine(@"timeout /t 3");
					progressBar.Increment(7);
					shell.WriteLine(@"Net stop HiPatchService");
					shell.WriteLine(@"timeout /t 3");
					progressBar.Increment(7);
					//shell.WriteLine(@"xcopy C:\Users\%username%\Documents\My Games\CAT_Holding\*.* C:\Users\%username%\Documents\My Games\Smite\");
					shell.WriteLine(@"Net start HiPatchService");
					shell.WriteLine(@"timeout /t 3");
					progressBar.Increment(7);
					shell.WriteLine(@"C:\Program Files\Hi-Rez Studios\HiRezLauncherUI.exe game=300 product=17");
					shell.WriteLine(@"timeout /t 3");
					progressBar.Increment(9);
				}
			}
			p.Close();

			System.Media.SystemSounds.Exclamation.Play();
			MessageBox.Show("Success!", "Operation Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
			repairButton.Enabled = true;
		}

	}
}
