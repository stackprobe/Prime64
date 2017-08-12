using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WPrime64
{
	public class Logger
	{
		public static string LOG_FILE
		{
			get
			{
				return Path.Combine(BootTools.SelfDir, "WPrime64.log");
			}
		}

		public static void Clear()
		{
			File.Delete(LOG_FILE);
		}

		private static int WL_Count = 0;

		public static void WriteLog(object e)
		{
			try
			{
				if (1000 < WL_Count)
					return;

				using (StreamWriter sw = new StreamWriter(LOG_FILE, true, StringTools.ENCODING_SJIS))
				{
					sw.WriteLine("[" + DateTime.Now + "." + WL_Count + "] " + e);
				}
				WL_Count++;
			}
			catch
			{ }
		}
	}
}
