using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;

namespace CyberAssistTool
{
	public partial class MainMenu : Form
	{
		private Dictionary<String, Dictionary<String, String>> library = new Dictionary<String, Dictionary<String, String>>();
		private Dictionary<String, Dictionary<String, String>> TgSettings = new Dictionary<String, Dictionary<String, String>>();
		private IniFile ini;

		public MainMenu()
		{
			InitializeComponent();
		}

		private void MainMenu_Load(object sender, EventArgs e)
		{
			this.CenterToScreen();
			currentGameLbl.Text = "";
			saveFileBtn.Enabled = false;
			LoadTextureGroups();
			FirstTimeSetup();

		}

		private void startProcessBtn_Click(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			String tag = button.Tag.ToString();
			String[] processes = tag.Split('^').ToArray();

			foreach (String s in processes)
			{
				try
				{
					String[] info = s.Split('|').ToArray();
					String path = info[0];
					String args = "";

					if (info.Length > 1)
					{
						args = info[1];
					}

					Process p = new Process();
					p.StartInfo.FileName = path;
					p.StartInfo.Arguments = args;
					p.Start();

				}
				catch
				{

					//Debug.WriteLine("Something Broke");
				}

			}

		}

		private void purgeBtn_Click(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			String path = Settings.MyDocumentsPath + button.Tag.ToString();

			ForceDeleteDirectory(path);

		}

		private void settingsMi_Click(object sender, EventArgs e)
		{
			Settings options = new Settings();
			options.StartPosition = FormStartPosition.CenterParent;
			options.ShowDialog(this);
		}

		private void exitMi_Click(object sender, EventArgs e)
		{
			this.Close();
		}	

		private void openIniBtn_Click(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
			mainTc.SelectedTab = iniEditorTab;
			ImportIniFile(Settings.MyDocumentsPath + btn.Tag);
			if (btn.Name.ToLower() == "tribes ini")
			{
				currentGameLbl.Text = "Tribes Ascend";
				currentFileLbl.Text = "tribes.ini";
			}
			else if (btn.Name.ToLower() == "smite ini")
			{
				currentGameLbl.Text = "Smite";
				currentFileLbl.Text = "BattleEngine.ini";
			}
			
			saveFileBtn.Enabled = true;
		}

		private void cacheBtn_Click(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			String path = Settings.ProgramDataPath + button.Tag.ToString();

			ForceDeleteDirectory(path);

		}

		private void loadFileBtn_Click(object sender, EventArgs e)
		{
			String filePath = "";
			String gameLabel = "";
			String fileLabel = "";
			try
			{
				ConfigChoice game = new ConfigChoice();
				game.StartPosition = FormStartPosition.CenterParent;
				game.ShowDialog(this);

				if (game.DialogResult == DialogResult.Yes)
				{
					filePath = Settings.MyDocumentsPath + @"\My Games\Tribes Ascend\TribesGame\Config\tribes.ini";
					gameLabel = "Tribes Ascend";
					fileLabel = "tribes.ini";
				}
				else if (game.DialogResult == DialogResult.No)
				{
					filePath = Settings.MyDocumentsPath + @"\My Games\Smite\BattleGame\Config\BattleEngine.ini";
					gameLabel = "Smite";
					fileLabel = "BattleEngine.ini";
				}
				else if (game.DialogResult == DialogResult.Retry)
				{
					OpenFileDialog file = new OpenFileDialog();
					file.InitialDirectory = Settings.MyDocumentsPath + @"\My Games\";
					file.Filter = "INI Files|*.ini";
					if (file.ShowDialog() == DialogResult.OK)
					{
						filePath = file.FileName;
						try
						{
							String[] gameName = file.FileName.Split('\\').ToArray();
							gameLabel = gameName[gameName.Length - 4];
						}
						catch
						{
							gameLabel = "";

						}

						fileLabel = Path.GetFileName(file.FileName);
					}
				}

				if (filePath != "" && File.Exists(filePath))
				{
					ImportIniFile(filePath);
					currentGameLbl.Text = gameLabel;
					currentFileLbl.Text = fileLabel;
					saveFileBtn.Enabled = true;
				}
				else
				{
					MessageBox.Show("File does not exist. Please double check your directory settings", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
					saveFileBtn.Enabled = false;
				}

			}
			catch
			{
				MessageBox.Show("Something went wrong.\nContact Cyberlink or Limyc on the official Hi-Rez forum", "Borked", MessageBoxButtons.OK);

			}

		}

		private void saveFileBtn_Click(object sender, EventArgs e)
		{
			FileInfo file = new FileInfo(ini.Filename);
			if (file.IsReadOnly)
			{
				file.IsReadOnly = false;
				SaveIniFile();
				file.IsReadOnly = true;
			}
			else
			{
				SaveIniFile();
			}
			System.Media.SystemSounds.Asterisk.Play();
		}

		private void iniSettingsCbo_SelectedValueChanged(object sender, EventArgs e)
		{
			ComboBox cbo = (ComboBox)sender;

			String key = cbo.Name.Substring(0, cbo.Name.Length - 3).ToLower();

			foreach (var dict in library.Values)
			{
				if (cbo.Name == "screenTypeCbo")
				{
					try
					{
						String[] temp = cbo.SelectedValue.ToString().Split(',');
						dict["fullscreen"] = temp[0];
						dict["borderless"] = temp[1];
					}
					catch
					{

					}
					break;
				}
				else if (cbo.Name == "screenResCbo")
				{
					try
					{
						String[] temp = cbo.SelectedValue.ToString().Split('x');
						dict["resx"] = temp[0];
						dict["resy"] = temp[1];
					}
					catch
					{

					}
					break;

				}
				else if (cbo.Name == "textureDetailCbo")
				{
					try
					{
						Dictionary<String, String> other = TgSettings[cbo.SelectedValue.ToString()];

						foreach (var pair in dict.ToList())
						{
							if (pair.Key.Contains("texturegroup_"))
							{
								dict[pair.Key] = other[pair.Key];
							}
						}
					}
					catch
					{

					}
					break;
				}
				else
				{
					String temp;
					if (dict.TryGetValue(key, out temp) && cbo.SelectedValue != null)
					{
						dict[key] = cbo.SelectedValue.ToString();
						//Debug.WriteLine(cbo.SelectedValue.ToString());
					}
				}
			}
		}

		/// <summary>
		/// Credit goes to http://stackoverflow.com/a/8714329
		/// </summary>
		private static void ForceDeleteDirectory(string path)
		{
			if (Directory.Exists(path))
			{
				DirectoryInfo directory = new DirectoryInfo(path) { Attributes = FileAttributes.Normal };

				foreach (FileSystemInfo info in directory.GetFileSystemInfos("*", SearchOption.AllDirectories))
				{
					info.Attributes = FileAttributes.Normal;
				}

				directory.Delete(true);

				System.Media.SystemSounds.Asterisk.Play();
				MessageBox.Show("Directory has been successfully deleted", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				System.Media.SystemSounds.Hand.Play();
				MessageBox.Show("Directory does not exist", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

			}

		}

		private void ImportIniFile(String path)
		{
			ini = new IniFile(path);
			//systemSettings = new Dictionary<String, String>();
			//engineSettings = new Dictionary<String, String>();
			library.Clear();

			library.Add("SystemSettings", FillDictionary("SystemSettings"));

			if (path.Contains("tribes.ini"))
			{
				library.Add("TribesGame.TrGameEngine", FillDictionary("TribesGame.TrGameEngine"));
			}
			else if (path.Contains("BattleEngine.ini"))
			{
				library.Add("Engine.Engine", FillDictionary("Engine.Engine"));
			}

			LoadIniFile();

		}

		private Dictionary<String, String> FillDictionary(String sectionName)
		{
			Dictionary<String, String> dict = new Dictionary<String, String>();
			String[] section = ini.ReadKeysInSection(sectionName);

			foreach (String s in section)
			{
				try
				{
					dict.Add(s.ToLower(), CapFirstLetter(ini.ReadSetting(sectionName, s, 65535, "").ToLower()));
				}
				catch
				{
					Debug.WriteLine("The key " + s + " already exists");

				}

			}

			return dict;
		}

		private String CapFirstLetter(String str)
		{
			return str.Substring(0, 1).ToUpper() + str.Substring(1);
		}

		private void LoadIniFile()
		{
			foreach (ComboBox cbo in iniEditorPnl.Controls.OfType<ComboBox>())
			{
				foreach (var dict in library.Values)
				{
					if (dict.ContainsKey(cbo.Name.Substring(0, cbo.Name.Length - 3).ToLower()))
					{
						try
						{
							String[] pairs = cbo.Tag.ToString().Split('|').ToArray();
							Dictionary<String, String> options = pairs.ToDictionary(s => s.Split(',')[0], s => s.Split(',')[1]);

							List<DataSource> data = new List<DataSource>();

							String key = cbo.Name.Substring(0, cbo.Name.Length - 3).ToLower();

							double temp;
							if (double.TryParse(dict[key], out temp))
							{
								dict[key] = temp.ToString("0");
							}


							if (!options.Values.Contains<String>(dict[key], StringComparer.OrdinalIgnoreCase))
							{

								data.Add(new DataSource("User Defined", dict[key]));
								//Debug.WriteLine(key + "=" + dict[key] + " not found");

							}

							foreach (var pair in options)
							{
								data.Add(new DataSource(pair.Key, pair.Value));
							}

							PopulateComboBox(cbo, data, "Name", "Value", dict[key]);

							cbo.Enabled = true;
							
						}
						catch 
						{
							PopulateComboBox(cbo, null, null, null, null);
							cbo.Enabled = false;
							Debug.WriteLine(cbo.Name.ToString() + " could not be populated");
							
						}
						break;
						//Debug.WriteLine(cb.Name.Substring(0, cb.Name.Length - 3) + "\t|\tTrue");
					}
					else if (cbo.Name == "screenTypeCbo")
					{
						String[] pairs = cbo.Tag.ToString().Split('|').ToArray();
						Dictionary<String, String> options = pairs.ToDictionary(s => s.Split(';')[0], s => s.Split(';')[1]);

						List<DataSource> data = new List<DataSource>();

						foreach (var pair in options)
						{
							data.Add(new DataSource(pair.Key, pair.Value));
						}

						PopulateComboBox(cbo, data, "Name", "Value", dict["fullscreen"] + "," + dict["borderless"]);

						cbo.Enabled = true;

						break;
					}
					//http://stackoverflow.com/a/744609
					else if (cbo.Name == "screenResCbo")
					{
						List<DataSource> data = new List<DataSource>();
						DEVMODE vDevMode = new DEVMODE();
						String resolution = "";
						int i = 0;

						while (NativeMethods.EnumDisplaySettings(null, i, ref vDevMode))
						{
							if (vDevMode.dmPelsWidth >= 800)
							{
								resolution = vDevMode.dmPelsWidth + "x" + vDevMode.dmPelsHeight;
								data.Add(new DataSource(resolution, resolution));
							}
							i++;
						}
						data = data.GroupBy(d => d.Value).Select(g => g.First()).ToList();
						//data.Sort((a, b) => Convert.ToInt32(a.Value.ToString().Split('x')[0]).CompareTo(Convert.ToInt32(b.Value.ToString().Split('x')[0])));

						data = data.OrderBy(x => Convert.ToInt32(x.Value.ToString().Split('x')[0]))
									.ThenBy(x => Convert.ToInt32(x.Value.ToString().Split('x')[1]))
									.ToList();

						PopulateComboBox(cbo, data, "Name", "Value", dict["resx"] + "x" + dict["resy"]);

						cbo.Enabled = true;

						break;
					}
					else if (cbo.Name == "textureDetailCbo")
					{
						try
						{
							List<DataSource> data = new List<DataSource>();
							String gameName = "";
							List<String> possibleSettings = new List<String>();

							if (ini.Filename.Split('\\').Last().ToLower() == "tribes.ini")
							{
								gameName = "tribes";
								possibleSettings.Add("Minimum");
								possibleSettings.Add("Low");
								possibleSettings.Add("Medium");
								possibleSettings.Add("High");
								possibleSettings.Add("Very High");
							}
							else if (ini.Filename.Split('\\').Last().ToLower() == "battleengine.ini")
							{
								gameName = "smite";

								possibleSettings.Add("Lowest");
								possibleSettings.Add("Low");
								possibleSettings.Add("Medium");
								possibleSettings.Add("High");
								possibleSettings.Add("Highest");
							}

							int i = 0;
							int j = 0;
							String initialVal = ",";
							foreach (var other in TgSettings.Where(x => x.Key.Split(',')[0] == gameName))
							{
								data.Add(new DataSource(possibleSettings[i], other.Key));
								if (initialVal == ",")
								{
									foreach (var pair in other.Value)
									{
										if (pair.Value.ToLower() == dict[pair.Key].ToLower())
										{
											j++;
										}
										else
										{
											j = 0;
											break;
										}

									}
								}

								if (TgSettings[other.Key].Count == j)
								{
									initialVal = other.Key;
									j = 0;
								}
								i++;
							}

							PopulateComboBox(cbo, data, "Name", "Value", initialVal);
						}
						catch
						{

						}
						cbo.Enabled = true;
						break;
					}
					else
					{
						PopulateComboBox(cbo, null, null, null, null);
						cbo.Enabled = false;
						//Debug.WriteLine(cb.Name.Substring(0, cb.Name.Length - 3) + "\t|\tFalse");
					}
				}

			}

		}

		private void PopulateComboBox(ComboBox cb, Object data, String displayMember, String valueMember, Object initialValue)
		{
			cb.DataSource = data;
			cb.DisplayMember = displayMember;
			cb.ValueMember = valueMember;
			cb.SelectedValue = initialValue;
			//Debug.WriteLine(initialValue);
		}

		private void LoadTextureGroups()
		{
			//this.GetType().Assembly.GetManifestResourceStream(@"CyberAssistTool.Resources." + @"texture_groups.bin");
			try
			{
				using (XmlReader reader = XmlReader.Create(Assembly.GetExecutingAssembly().GetManifestResourceStream("CyberAssistTool.Resources.texture_groups.xml")))
				{
					XmlSerializer bin = new XmlSerializer(typeof(List<SettingGroup>));

					var settingGroup = (List<SettingGroup>)bin.Deserialize(reader);

					List<DataSource> tribesData = new List<DataSource>();
					List<DataSource> smiteData = new List<DataSource>();

					foreach (SettingGroup setting in settingGroup)
					{
						getTgSettings(setting);
					}
				}
			}
			catch (IOException)
			{
			}
		}

		private void getTgSettings(SettingGroup setting)
		{
			Dictionary<String, String> textureGroups = new Dictionary<String, String>();
			foreach (TextureGroup tg in setting.TextureGroups)
			{
				if (tg.Name != "shadowmap")
				{
					textureGroups.Add("texturegroup_" + tg.Name, String.Format("(MinLODSize={0},MaxLODSize={1},LODBias={2},MinMagFilter={3},MipFilter={4},MipGenSettings={5})",
													tg.MinLodSize,
													tg.MaxLodSize,
													tg.LodBias,
													tg.MinMagFilter,
													tg.MipFilter,
													tg.MipGenSettings));
				}
				else
				{
					textureGroups.Add("texturegroup_" + tg.Name, String.Format("(MinLODSize={0},MaxLODSize={1},LODBias={2},MinMagFilter={3},MipFilter={4},NumStreamedMips={5},MipGenSettings={6})",
													tg.MinLodSize,
													tg.MaxLodSize,
													tg.LodBias,
													tg.MinMagFilter,
													tg.MipFilter,
													tg.NumStreamedMips,
													tg.MipGenSettings));
				}
			}
			TgSettings.Add(setting.GameName + "," + setting.SettingName, textureGroups);
		}

		private void SaveIniFile()
		{
			//For every kvp1 in the main array, and for every kvp2 in kvp1.Value, write to the ini file.
			foreach (var shelf in library)
			{
				foreach (var pair in shelf.Value)
				{
					ini.WriteSetting(shelf.Key, pair.Key, pair.Value);
				}
			}

		}

		private void FirstTimeSetup()
		{
			if (Properties.Settings.Default.FirstUse)
			{
				Properties.Settings.Default.MyDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
				Properties.Settings.Default.ProgramDataPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
				Properties.Settings.Default.FirstUse = false;
				Properties.Settings.Default.Save();

				System.Media.SystemSounds.Exclamation.Play();
				if (MessageBox.Show("Are you using default install locations for all Hi-Rez games?",
									"First Time Setup",
									MessageBoxButtons.YesNo,
									MessageBoxIcon.Question) != DialogResult.Yes)
				{
					settingsMi.PerformClick();
				}

			}
		}

		private void toolTip1_Popup(object sender, PopupEventArgs e)
		{
			
		}
	
	}
}
