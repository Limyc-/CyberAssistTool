using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Json;

namespace CyberAssistTool
{
	public static class JsonHelper
	{
		public static String ToJson<T>(this T obj) where T : class
		{
			using (var ms = new MemoryStream())
			{
				var js = new DataContractJsonSerializer(typeof(T));
				js.WriteObject(ms, obj);

				return Encoding.Default.GetString(ms.ToArray());
			}
		}

		public static T FromJson<T>(this T obj, String json) where T : class
		{
			using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
			{
				var js = new DataContractJsonSerializer(typeof(T));
				return js.ReadObject(ms) as T;
			}
		}
	}
}
