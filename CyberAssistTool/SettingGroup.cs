using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CyberAssistTool
{
	[Serializable]
	public class SettingGroup
	{
		public List<TextureGroup> TextureGroups { get; set; }
		public String GameName { get; set; }
		public String SettingName { get; set; }

		public SettingGroup() { }

		public SettingGroup(String gameName, String settingName, List<TextureGroup> textureGroups)
		{
			GameName = gameName;
			SettingName = settingName;
			TextureGroups = textureGroups;
		}
	}
}
