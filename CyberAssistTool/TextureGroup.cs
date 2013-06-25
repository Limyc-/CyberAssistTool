using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CyberAssistTool
{
	[Serializable()]
	public class TextureGroup
	{
		public String Name { get; set; }
		public int MinLodSize { get; set; }
		public int MaxLodSize { get; set; }
		public int LodBias { get; set; }
		public String MinMagFilter { get; set; }
		public String MipFilter { get; set; }
		public int NumStreamedMips { get; set; }
		public String MipGenSettings { get; set; }

		public TextureGroup() { }

		public TextureGroup(String name, int minLodSize, int maxLodSize, int lodBias, String minMagFilter, String mipFilter, String mipGenSettings)
		{
			Name = name;
			MinLodSize = minLodSize;
			MaxLodSize = maxLodSize;
			LodBias = lodBias;
			MinMagFilter = minMagFilter;
			MipFilter = mipFilter;
			NumStreamedMips = 0;
			MipGenSettings = mipGenSettings;
		}

		public TextureGroup(String name, int minLodSize, int maxLodSize, int lodBias, String minMagFilter, String mipFilter, int numStreamedMips, String mipGenSettings)
		{
			Name = name;
			MinLodSize = minLodSize;
			MaxLodSize = maxLodSize;
			LodBias = lodBias;
			MinMagFilter = minMagFilter;
			MipFilter = mipFilter;
			NumStreamedMips = numStreamedMips;
			MipGenSettings = mipGenSettings;
		}
	}
}
