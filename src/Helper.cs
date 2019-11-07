using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoneForTheDay
{
	class Helper
	{
		public static string GetAppSettingValue(string keyName)
		{
			return System.Configuration.ConfigurationManager.AppSettings[keyName] ?? "";
		}
	}
}
