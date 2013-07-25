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
using System.Runtime.Serialization.Json;

namespace CyberAssistTool
{
	public partial class MainMenu : Form
	{
		private Dictionary<String, Dictionary<String, String>> userConfig = new Dictionary<String, Dictionary<String, String>>();
		private Dictionary<String, Dictionary<String, String>> textureGroupPresets = new Dictionary<String, Dictionary<String, String>>();
		private Dictionary<String, List<DataSource>> optionPresets;
		private IniFile ini;
		private List<DataSource> screenResList;
		private List<DataSource> screenTypeList;
		private String comboBoxSuffix = "ComboBox";

		public MainMenu()
		{
			InitializeComponent();
		}

		private void MainMenu_Load(object sender, EventArgs e)
		{
			this.CenterToScreen();
			currentGameLabel.Text = "";
			saveFileButton.Enabled = false;

			var assembly = Assembly.GetExecutingAssembly();

			LoadOptionPresets(assembly);
			LoadTextureGroupPresets(assembly);
			LoadScreenTypeList();
			LoadScreenResList();

		}

		private void MainMenu_Shown(object sender, EventArgs e)
		{
			FirstTimeSetup();
		}

		private void cacheButton_Click(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
			// Append the Hi-Rez cache folder location to the user's program data path
			String path = SettingsMenu.ProgramDataPath + btn.Tag.ToString();

			ForceDeleteDirectory(path);

		}

		private void exitMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void loadFileButton_Click(object sender, EventArgs e)
		{
			String filePath = "";
			String gameLabel = "";
			String fileLabel = "";
			try
			{
				FileChoiceDialog game = new FileChoiceDialog();
				game.StartPosition = FormStartPosition.CenterParent;
				game.ShowDialog(this);

				// If the user clicked "Tribes", append the tribes.ini location to the user's My Documents folder path
				if (game.DialogResult == DialogResult.Yes)
				{
					filePath = SettingsMenu.MyDocumentsPath + @"\My Games\Tribes Ascend\TribesGame\Config\tribes.ini";
					gameLabel = "Tribes Ascend";
					fileLabel = "tribes.ini";
				}
				// If the user clicked "Smite", append the BattleEngine.ini location to the user's My Documents folder path
				else if (game.DialogResult == DialogResult.No)
				{
					filePath = SettingsMenu.MyDocumentsPath + @"\My Games\Smite\BattleGame\Config\BattleEngine.ini";
					gameLabel = "Smite";
					fileLabel = "BattleEngine.ini";
				}
				// If the user clicked "Other", let the user choose the location of the INI file he/she wishes to edit
				else if (game.DialogResult == DialogResult.Retry)
				{
					// Open a file dialog box that only shows .ini files
					OpenFileDialog file = new OpenFileDialog();
					file.InitialDirectory = SettingsMenu.MyDocumentsPath + @"\My Games\";
					file.Filter = "INI Files|*.ini";

					if (file.ShowDialog() == DialogResult.OK)
					{
						filePath = file.FileName;
						try
						{
							// Attempt to get the name of the game. This isn't perfect and will not work if the config file isn't located under the My Games folder
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

				// If the selected file exists, update the labels and start the importing process
				if (filePath != "" && File.Exists(filePath))
				{
					ImportIniFile(filePath);
					currentGameLabel.Text = gameLabel;
					currentFileLabel.Text = fileLabel;
					saveFileButton.Enabled = true;
				}
				else
				{
					MessageBox.Show("File does not exist. Please double check your directory settings", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
					saveFileButton.Enabled = false;
				}

			}
			catch
			{
				MessageBox.Show("Something went wrong.\nContact Cyberlink or Limyc on the official Hi-Rez forum", "Borked", MessageBoxButtons.OK);

			}

		}

		private void openIniButton_Click(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			// Switch the current tab to "Config Editor"
			mainTabControl.SelectedTab = configEditorTab;

			// Append the appropriate file location to the user's My Documents folder path
			String path = SettingsMenu.MyDocumentsPath + button.Tag;

			// If the file exists, start the importing process
			if (File.Exists(path))
			{
				ImportIniFile(path);
			}

			// Update the labels based on which button was pressed
			if (button.Name.ToLower() == "tribes ini")
			{
				currentGameLabel.Text = "Tribes Ascend";
				currentFileLabel.Text = "tribes.ini";
			}
			else if (button.Name.ToLower() == "smite ini")
			{
				currentGameLabel.Text = "Smite";
				currentFileLabel.Text = "BattleEngine.ini";
			}

			saveFileButton.Enabled = true;
		}

		private void saveFileButton_Click(object sender, EventArgs e)
		{
			// Update the user config dictionary based on the combobox selections
			UpdateConfig();

			FileInfo file = new FileInfo(ini.Filename);

			// If the config file is set to read-only, remove the read-only flag, save to the file, and add the read-only property
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

		private void settingsMenuItem_Click(object sender, EventArgs e)
		{
			SettingsMenu options = new SettingsMenu();
			options.StartPosition = FormStartPosition.CenterParent;
			options.ShowDialog(this);
		}

		private void startProcessButton_Click(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			String tag = button.Tag.ToString();
			// Split all process/args into an array. Each set of process/args are delimited by the carrot ('^') symbol.
			String[] processes = tag.Split('^').ToArray();

			// Execute each process that exists in the array
			foreach (String s in processes)
			{
				try
				{
					// Split the processes from the commands. Processes are on the left side of the pipe ('|') delimiter.
					String[] info = s.Split('|').ToArray();
					String path = info[0];
					String args = "";

					// If the process has arguments, save them to a variable
					if (info.Length > 1)
					{
						args = info[1];
					}

					// Setup and start the new process
					Process p = new Process();
					p.StartInfo.FileName = path;
					p.StartInfo.Arguments = args;
					p.Start();

				}
				catch { }
			}
		}

		private String CapFirstLetter(String str)
		{
			return str.Substring(0, 1).ToUpper() + str.Substring(1);
		}

		private bool CompareTextureGroupSettings(Dictionary<String, String> dict, out List<DataSource> data, out String initialValue)
		{
			data = new List<DataSource>();
			initialValue = "Custom";
			String gameName = "";

			switch (ini.Filename.Split('\\').Last().ToLower())
			{
				case "tribes.ini":
					gameName = "tribes";
					break;
				case "battleengine.ini":
					gameName = "smite";
					break;
				default:
					// If the game name is not matched, the current game is not supported. Return false so the combobox is not enabled
					return false;
			}

			int i = 0;
			int j = 0;

			// For each value in tgsettings where the key contains the gameName
			foreach (var other in textureGroupPresets.Where(x => x.Key.Split(',')[0] == gameName))
			{
				// Add a new data source using the current key. ("presetValue", "gameName,presetValue")
				data.Add(new DataSource(other.Key.Split(',')[1], other.Key));

				// If the current settings have yet to be matched with a preset, continue checking for matches
				if (initialValue == "Custom")
				{
					// For each key/value pair in the presets dictionary
					foreach (var tgPreset in other.Value)
					{
						// If tgPreset.Value == tgCurrent.Value
						if (tgPreset.Value.ToLower() == dict[tgPreset.Key].ToLower())
						{
							// Increment the number of matched settings
							j++;
						}
						else
						{
							// Reset the number of matched settings and break the loop. This ensures that the outer loop will continue if there are still presets left.
							j = 0;
							break;
						}
					}
				}

				// If the number of settings in tgPreset == the number of matched settings in tgCurrent
				if (textureGroupPresets[other.Key].Count == j)
				{
					initialValue = other.Key;
					j = 0;
				}

				i++;
			}

			// If the initialValue is still custom, no preset was matched. Insert tgCurrent as a new dataSource.
			if (initialValue == "Custom")
			{
				data.Insert(0, new DataSource(initialValue, gameName + ",Custom"));
			}

			return true;
		}

		private void GetTextureGroupSettings(SettingGroup setting)
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
			textureGroupPresets.Add(setting.GameName + "," + setting.SettingName, textureGroups);
		}

		private Dictionary<String, String> FillDictionary(String sectionName)
		{
			Dictionary<String, String> dict = new Dictionary<String, String>();
			String[] section = this.ini.ReadKeysInSection(sectionName);

			// For each key found in the specified section of the ini file
			foreach (String key in section)
			{
				try
				{
					// If the dictionary does not already contain the key (needed for UE3 ini files :( )
					if (!dict.ContainsKey(key))
					{
						// Add the lowercase key and the titlecase value to the dictionary
						dict.Add(key.ToLower(), CapFirstLetter(ini.ReadSetting(sectionName, key, 65535, "").ToLower()));
					}
				}
				catch
				{

				}
			}
			return dict;

		}

		private void FirstTimeSetup()
		{
			// If the user has never run the program before, set the default My Documents and Program Data paths
			if (Properties.Settings.Default.FirstUse)
			{
				if (MessageBox.Show("This is a third party application. It is not endorsed by Hi-Rez Studios or its affiliates." +
									"\nThe authors are not liable for any damages caused by the use of the application." +
									"\n\nDo you agree to these terms?",
									"Disclaimer",
									MessageBoxButtons.YesNo,
									MessageBoxIcon.Exclamation) != DialogResult.Yes)
				{
					this.Close();
				}
				else
				{


					Properties.Settings.Default.MyDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
					Properties.Settings.Default.ProgramDataPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
					Properties.Settings.Default.FirstUse = false;
					Properties.Settings.Default.Save();

					System.Media.SystemSounds.Exclamation.Play();

					// If the user says they are not using the default install location, send them to the options window
					if (MessageBox.Show("Are you using default install locations for all Hi-Rez games?",
										"First Time Setup",
										MessageBoxButtons.YesNo,
										MessageBoxIcon.Question) != DialogResult.Yes)
					{
						settingsMenuItem.PerformClick();
					}

				}
			}
		}

		private static void ForceDeleteDirectory(string path)
		{
			if (Directory.Exists(path))
			{
				// Get the directory and set its attributes to Normal
				DirectoryInfo directory = new DirectoryInfo(path) { Attributes = FileAttributes.Normal };

				// For each file/folder in the root directory, set the file/folder's attributes to Normal
				foreach (var info in directory.GetFileSystemInfos("*", SearchOption.AllDirectories))
				{
					info.Attributes = FileAttributes.Normal;
				}

				// Delete the root directory recursively
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
			userConfig.Clear();

			try
			{
				// Add the ini section as the key and a dictionary of the key/value pairs from the section as the Value
				userConfig.Add("SystemSettings", FillDictionary("SystemSettings"));

				// If file is tribes.ini, use the specific section for the engine settings. Otherwise, use the UE3 default.
				if (path.Contains("tribes.ini"))
				{
					userConfig.Add("TribesGame.TrGameEngine", FillDictionary("TribesGame.TrGameEngine"));
				}
				else
				{
					userConfig.Add("Engine.Engine", FillDictionary("Engine.Engine"));
				}
			}
			catch { }

			// Load the userConfig into the appropriate comboboxes
			LoadIniFile();

		}

		private void LoadIniFile()
		{
			// For each combobox found in the config editor panel
			foreach (ComboBox cbo in configEditorPanel.Controls.OfType<ComboBox>())
			{
				// For each dictionary of key/value pairs (SystemSettings and Engine.Engine) found in userconfig.Values
				foreach (var dict in userConfig.Values)
				{
					// Remove the suffix from the combobox name so we can use it as a key for the dictionary
					String key = cbo.Name.Substring(0, cbo.Name.Length - comboBoxSuffix.Length).ToLower();

					try
					{
						// If the dictionary contains the key, use the default procedure. Otherwise, use the key-specific procedure.
						if (dict.ContainsKey(key))
						{
							var data = optionPresets[key].ToList();
							var currentValue = dict[key];

							// If none of the presets are equal to the current value, add a custom preset
							if (optionPresets[key].TrueForAll(x => x.Value.ToString() != currentValue))
							{
								data.Insert(0, new DataSource("User Defined", currentValue));
							}

							PopulateComboBox(cbo, data, "Name", "Value", currentValue);
							cbo.Enabled = true;

							break;
						}
						else if (key == "screentype")
						{
							PopulateComboBox(cbo, screenTypeList, "Name", "Value", dict["fullscreen"] + "," + dict["borderless"]);
							cbo.Enabled = true;

							break;
						}
						else if (key == "screenres")
						{
							PopulateComboBox(cbo, screenResList, "Name", "Value", dict["resx"] + "x" + dict["resy"]);
							cbo.Enabled = true;

							break;
						}
						else if (key == "texturedetail")
						{
							String initialValue;
							var data = new List<DataSource>();
							var isSupportedGame = CompareTextureGroupSettings(dict, out data, out initialValue);

							// If CompareTextureGroupSettings returned true, populate and enable the combobox
							if (isSupportedGame)
							{
								PopulateComboBox(cbo, data, "Name", "Value", initialValue);
								cbo.Enabled = true;
							}
							else
							{
								PopulateComboBox(cbo, null, null, null, null);
								cbo.Enabled = false;
							}

							break;
						}
						else
						{
							PopulateComboBox(cbo, null, null, null, null);
							cbo.Enabled = false;
							//Debug.WriteLine(cbo.Name.ToString() + " could not be populated");
						}
					}
					catch
					{
						PopulateComboBox(cbo, null, null, null, null);
						cbo.Enabled = false;
						//Debug.WriteLine(cbo.Name.ToString() + " could not be populated");
					}
				}

			}

		}

		private void LoadOptionPresets(Assembly asm)
		{
			try
			{
				using (var stream = asm.GetManifestResourceStream("CyberAssistTool.Resources.options.json"))
				using (var reader = new StreamReader(stream))
				{
					var json = reader.ReadToEnd();
					optionPresets = new Dictionary<String, List<DataSource>>().FromJson(json);
				}
			}
			catch
			{
				MessageBox.Show("Could not load config options.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}

		}

		private void LoadScreenResList()
		{
			screenResList = new List<DataSource>();
			DEVMODE vDevMode = new DEVMODE();
			String resolution = "";
			int i = 0;

			while (NativeMethods.EnumDisplaySettings(null, i, ref vDevMode))
			{
				if (vDevMode.dmPelsWidth >= 800)
				{
					resolution = vDevMode.dmPelsWidth + "x" + vDevMode.dmPelsHeight;
					screenResList.Add(new DataSource(resolution, resolution));
				}
				i++;
			}
			screenResList = screenResList.GroupBy(d => d.Value).Select(g => g.First()).ToList();
			//data.Sort((a, b) => Convert.ToInt32(a.Value.ToString().Split('x')[0]).CompareTo(Convert.ToInt32(b.Value.ToString().Split('x')[0])));

			screenResList = screenResList.OrderBy(x => Convert.ToInt32(x.Value.ToString().Split('x')[0]))
										.ThenBy(x => Convert.ToInt32(x.Value.ToString().Split('x')[1]))
										.ToList();
		}

		private void LoadScreenTypeList()
		{
			screenTypeList = new List<DataSource>();

			screenTypeList.Add(new DataSource("Fullscreen", "True,False"));
			screenTypeList.Add(new DataSource("Borderless", "False,True"));
			screenTypeList.Add(new DataSource("Windowed", "False,False"));
		}

		private void LoadTextureGroupPresets(Assembly asm)
		{
			/* 
			 * The texture group saving/loading procedure has not yet been refactored
			 * It's a bit clunky and still using an XML file to store the data
			 * This will be remedied in the near future (probably)
			 */

			try
			{
				// Get the XML file from the embedded resources and deseriealize it to List<settingGroup>
				using (XmlReader reader = XmlReader.Create(asm.GetManifestResourceStream("CyberAssistTool.Resources.texture_groups.xml")))
				{
					XmlSerializer xml = new XmlSerializer(typeof(List<SettingGroup>));
					var settingGroup = (List<SettingGroup>)xml.Deserialize(reader);

					// For each tgPreset in settingGroup, load the preset into a dictionary
					foreach (SettingGroup gamePreset in settingGroup)
					{
						GetTextureGroupSettings(gamePreset);
					}
				}
			}
			catch { }
		}

		private void PopulateComboBox(ComboBox cb, Object data, String displayMember, String valueMember, Object initialValue)
		{
			cb.DataSource = data;
			cb.DisplayMember = displayMember;
			cb.ValueMember = valueMember;
			cb.SelectedValue = initialValue;
			//Debug.WriteLine(initialValue);
		}

		private void SaveIniFile()
		{
			//For every section in the userConfig dictionary... 
			foreach (var section in userConfig)
			{
				// For every key/value pair in each section...
				foreach (var pair in section.Value)
				{
					// Write to the ini file
					ini.WriteSetting(section.Key, pair.Key, pair.Value);
				}
			}

		}

		private void UpdateConfig()
		{
			// For each combobox in the config editor panel
			foreach (ComboBox cbo in configEditorPanel.Controls.OfType<ComboBox>())
			{
				// For each dictionary of key/value pairs (SystemSettings and Engine.Engine) found in userconfig.Values
				foreach (var dict in userConfig.Values)
				{
					// Remove the suffix from the combobox name so we can use it as a key for the dictionary
					String key = cbo.Name.Substring(0, cbo.Name.Length - comboBoxSuffix.Length).ToLower();

					// If the combobox is enabled (was editable) and the key matches, run the key-specific procedure
					if (cbo.Enabled && key == "screentype")
					{
						try
						{
							String[] temp = cbo.SelectedValue.ToString().Split(',');
							dict["fullscreen"] = temp[0];
							dict["borderless"] = temp[1];
						}
						catch { }
					}
					else if (cbo.Enabled && key == "screenres")
					{
						try
						{
							String[] temp = cbo.SelectedValue.ToString().Split('x');
							dict["resx"] = temp[0];
							dict["resy"] = temp[1];
						}
						catch { }
					}
					else if (cbo.Enabled && key == "texturedetail")
					{
						// If the combobox value is not a custom setting
						if (!cbo.SelectedValue.ToString().Contains("custom"))
						{
							try
							{
								Dictionary<String, String> other = textureGroupPresets[cbo.SelectedValue.ToString()];

								// For each tg setting in the dictionary
								foreach (var tgCurrent in dict.ToList())
								{
									// If the key is a texturegroup (they all are), copy the value to the master dictionary
									if (tgCurrent.Key.Contains("texturegroup_"))
									{
										dict[tgCurrent.Key] = other[tgCurrent.Key];
									}
								}

								// Removes any extra options in the combobox
								String initialValue;
								var data = new List<DataSource>();
								CompareTextureGroupSettings(dict, out data, out initialValue);

								PopulateComboBox(cbo, data, "Name", "Value", initialValue);

							}
							catch { }
						}
					}
					// Otherwise, try to save the combobox value to the dictionary directly
					else if (cbo.Enabled)
					{
						String temp;
						// If the value associated with the key exists and the value is not null
						if (dict.TryGetValue(key, out temp) && cbo.SelectedValue != null)
						{
							dict[key] = cbo.SelectedValue.ToString();
							//Debug.WriteLine(cbo.SelectedValue.ToString());
						}
					}
				}
			}
		}

	}
}
