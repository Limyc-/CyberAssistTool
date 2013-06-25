using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace CyberAssistTool
{
	/// <summary>
	/// Credit goes to http://www.blackwasp.co.uk/IniFile.aspx
	/// </summary>
	public class IniFile
	{
		String fileName;

		public String Filename
		{
			get { return fileName; }
		}

		public IniFile(String fileName)
		{
			this.fileName = fileName;
		}

		public void WriteSetting(String section, String key, String value)
		{
			if (NativeMethods.WritePrivateProfileString(section, key, value, fileName) == false)
			{
				throw new Win32Exception(Marshal.GetLastWin32Error());
			}
		}

		public String ReadSetting(String section, String key, uint maxLength, String defaultValue)
		{
			String value = new String(' ', (int)maxLength);
			NativeMethods.GetPrivateProfileString(section, key, defaultValue, value, maxLength, fileName);
			return value.Split('\0')[0];
		}

		public String[] ReadSections()
		{
			String value = new String(' ', 65535);
			NativeMethods.GetPrivateProfileString(null, null, "\0", value, 65535, fileName);
			return SplitNullTerminatedStrings(value);
		}

		private static String[] SplitNullTerminatedStrings(String value)
		{
			String[] raw = value.Split('\0');
			int itemCount = raw.Length - 2;
			String[] items = new String[itemCount];
			Array.Copy(raw, items, itemCount);
			return items;
		}

		public String[] ReadKeysInSection(String section)
		{
			String value = new String(' ', 65535);
			NativeMethods.GetPrivateProfileString(section, null, "\0", value, 65535, fileName);
			return SplitNullTerminatedStrings(value);
		}
	}
}
