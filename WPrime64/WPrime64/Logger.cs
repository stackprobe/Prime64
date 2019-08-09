using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WPrime64
{
	public static class Logger
	{
		public static string LOG_FILE
		{
			get
			{
				return Path.Combine(BootTools.SelfDir, "WPrime64.log");
			}
		}

		private static long WL_Count = 0;

		public static void WriteLog(object e)
		{
			try
			{
				using (StreamWriter writer = new StreamWriter(LOG_FILE, WL_Count++ % 1000 != 0, StringTools.ENCODING_SJIS))
				{
					writer.WriteLine("[" + DateTime.Now + "." + WL_Count.ToString("D3") + "] " + e);
				}
			}
			catch
			{ }
		}
	}
}
