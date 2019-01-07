using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Text;
using System.Security.Cryptography;

namespace WPrime64
{
	public class SystemTools
	{
		public static string GetTmp()
		{
			return GetEnv("TMP", @"C:\temp");
		}

		public static string GetEnv(string name, string defval)
		{
			try
			{
				string value = Environment.GetEnvironmentVariable(name);

				if (value == null || value.Length == 0)
					value = defval;

				return value;
			}
			catch
			{
				return defval;
			}
		}

		private static RNGCryptoServiceProvider _rngc = new RNGCryptoServiceProvider();

		public static uint GetCryptoRand()
		{
			byte[] buff = new byte[4];

			_rngc.GetBytes(buff);

			return
				((uint)buff[0] << 24) |
				((uint)buff[1] << 16) |
				((uint)buff[2] << 8) |
				((uint)buff[3] << 0);
		}

		public static uint GetCryptoRand(uint modulo)
		{
			return GetCryptoRand() % modulo; // FIXME
		}

		public static uint GetCryptoRand(uint minval, uint maxval)
		{
			return GetCryptoRand(maxval + 1 - minval) + minval;
		}

		public delegate void Perform_d();

		public static void AntiWindowsDefenderSmartScreen()
		{
			bool 初回起動Flag = File.Exists(Logger.LOG_FILE) == false;

			Logger.WriteLog("awdss_1");

			if (初回起動Flag)
			{
				Logger.WriteLog("awdss_2");

				foreach (string exeFile in Directory.GetFiles(BootTools.SelfDir, "*.exe", SearchOption.TopDirectoryOnly))
				{
					try
					{
						Logger.WriteLog("awdss_exeFile: " + exeFile);

						if (exeFile.ToLower() == BootTools.SelfFile.ToLower())
						{
							Logger.WriteLog("awdss_self_noop");
						}
						else
						{
							byte[] exeData = File.ReadAllBytes(exeFile);
							File.Delete(exeFile);
							File.WriteAllBytes(exeFile, exeData);
						}
						Logger.WriteLog("awdss_OK");
					}
					catch (Exception e)
					{
						Logger.WriteLog(e);
					}
				}
				Logger.WriteLog("awdss_3");
			}
			Logger.WriteLog("awdss_4");
		}
	}
}
