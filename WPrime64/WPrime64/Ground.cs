using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Threading;

namespace WPrime64
{
	public class Gnd
	{
		private static Gnd _i = null;

		public static Gnd I
		{
			get
			{
				if (_i == null)
					_i = new Gnd();

				return _i;
			}
		}

		private Gnd()
		{
			{
				string file = "Prime64.exe";

				if (File.Exists(file) == false)
					file = @"C:\Factory\Program\Prime64\Prime64.exe";

				this.Prime64File = file;
			}
		}

		public void LoadSettingData()
		{
			this.SettingData = new SettingData("WPrime64.conf");
		}

		public string Prime64File;
		public SettingData SettingData;

		public readonly string PRIME_MIN_OVER_UL = "18446744073709551629"; // 2^64 以上で最小の素数 == 2^64 + 13

		public readonly string FACTORY_COMMON_MUTEX = "cerulean.charlotte Factory common mutex object"; // @ C:/Factoty/Common/Mutex.c

		public MainWin MainWin;
	}
}
