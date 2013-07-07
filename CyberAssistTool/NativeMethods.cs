using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CyberAssistTool
{

	[StructLayout(LayoutKind.Sequential)]
	public struct DEVMODE
	{

		private const int CCHDEVICENAME = 0x20;
		private const int CCHFORMNAME = 0x20;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
		public string dmDeviceName;
		public short dmSpecVersion;
		public short dmDriverVersion;
		public short dmSize;
		public short dmDriverExtra;
		public int dmFields;
		public int dmPositionX;
		public int dmPositionY;
		public ScreenOrientation dmDisplayOrientation;
		public int dmDisplayFixedOutput;
		public short dmColor;
		public short dmDuplex;
		public short dmYResolution;
		public short dmTTOption;
		public short dmCollate;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
		public string dmFormName;
		public short dmLogPixels;
		public int dmBitsPerPel;
		public int dmPelsWidth;
		public int dmPelsHeight;
		public int dmDisplayFlags;
		public int dmDisplayFrequency;
		public int dmICMMethod;
		public int dmICMIntent;
		public int dmMediaType;
		public int dmDitherType;
		public int dmReserved1;
		public int dmReserved2;
		public int dmPanningWidth;
		public int dmPanningHeight;

	}

	internal class NativeMethods
	{
		[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern bool WritePrivateProfileString(String lpAppName, String lpKeyName, String lpString, String lpFileName);

		[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern uint GetPrivateProfileString(String lpAppName, String lpKeyName, String lpDefault, String lpReturnedString, uint nSize, String lpFileName);

		[DllImport("user32.dll")]
		public static extern bool EnumDisplaySettings(string deviceName, int modeNum, ref DEVMODE devMode);
		const int ENUM_CURRENT_SETTINGS = -1;
		const int ENUM_REGISTRY_SETTINGS = -2;
	}
}
