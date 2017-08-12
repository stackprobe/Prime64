using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WPrime64
{
	public class SettingData
	{
		public SettingData(string file)
		{
			try
			{
				this.Lines = File.ReadAllLines(file);

				this.KeepPrimeDat = int.Parse(this.NextLine()) != 0;
				this.HidePrimeDat = int.Parse(this.NextLine()) != 0;
				this.USCheckOff = int.Parse(this.NextLine()) != 0;
				this.DiskFreeOnBoot_MB = IntTools.ToInt(this.NextLine(), 1, IntTools.IMAX);
				this.DiskFreeOnOutput_Pct = IntTools.ToInt(this.NextLine(), 0, 100);
				this.DiskFreeOnOutput_MB = IntTools.ToInt(this.NextLine(), 1, IntTools.IMAX);
				this.CheckDiskFreeOnOutput = int.Parse(this.NextLine()) != 0;
				this.OutFileDiv = int.Parse(this.NextLine()) != 0;
				this.LogInfo = int.Parse(this.NextLine()) != 0;
				// ここへ追加
			}
			catch
			{ }
			finally
			{
				this.Lines = null;

				WriteInfo("KeepPrimeDat: " + this.KeepPrimeDat);
				WriteInfo("HidePrimeDat: " + this.HidePrimeDat);
				WriteInfo("USCheckOff: " + this.USCheckOff);
				WriteInfo("DiskFreeOnBoot_MB: " + this.DiskFreeOnBoot_MB);
				WriteInfo("DiskFreeOnOutput_Pct: " + this.DiskFreeOnOutput_Pct);
				WriteInfo("DiskFreeOnOutput_MB: " + this.DiskFreeOnOutput_MB);
				WriteInfo("CheckDiskFreeOnOutput: " + this.CheckDiskFreeOnOutput);
				WriteInfo("OutFileDiv: " + this.OutFileDiv);
				WriteInfo("LogInfo: " + this.LogInfo);
				// ここへ追加
			}
		}

		private string[] Lines;
		private int RIndex;

		private string NextLine()
		{
			for (; ; )
			{
				string line = this.Lines[this.RIndex];
				this.RIndex++;

				if (line != "" && line[0] != ';')
					return line;
			}
		}

		public bool KeepPrimeDat = false;
		public bool HidePrimeDat = false;
		public bool USCheckOff = false;
		public int DiskFreeOnBoot_MB = 300;
		public int DiskFreeOnOutput_Pct = 10;
		public int DiskFreeOnOutput_MB = 3000;
		public bool CheckDiskFreeOnOutput = true;
		public bool OutFileDiv = false;
		public bool LogInfo = true;
		// ここへ追加

		public void WriteInfo(Object e)
		{
			if (LogInfo)
				Logger.WriteLog(e);
		}
	}
}
