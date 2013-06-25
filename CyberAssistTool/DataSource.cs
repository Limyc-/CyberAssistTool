using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace CyberAssistTool
{
	public class DataSource
	{
		public String Name { get; set; }
		public Object Value { get; set; }

		public DataSource() { }

		public DataSource(String name, Object value)
		{
			Name = name;
			Value = value;
		}

	}

}
