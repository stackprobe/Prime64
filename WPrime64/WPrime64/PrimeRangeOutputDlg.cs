using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Permissions;
using System.Threading;
using System.IO;

namespace WPrime64
{
	public partial class PrimeRangeOutputDlg : Form
	{
		private bool XPressed = false;

		#region ALT_F4 抑止

		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
		protected override void WndProc(ref Message m)
		{
			const int WM_SYSCOMMAND = 0x112;
			const long SC_CLOSE = 0xF060L;

			if (m.Msg == WM_SYSCOMMAND && (m.WParam.ToInt64() & 0xFFF0L) == SC_CLOSE)
			{
				this.XPressed = true;
				return;
			}
			base.WndProc(ref m);
		}

		#endregion

		private ulong Minval;
		private ulong Maxval;
		private string OutFile;
		private bool CountMode;
		private bool DivMode;

		public PrimeRangeOutputDlg(ulong minval, ulong maxval, string outFile, bool countMode, bool divMode = false)
		{
			this.Minval = minval;
			this.Maxval = maxval;
			this.OutFile = outFile;
			this.CountMode = countMode;
			this.DivMode = divMode;

			InitializeComponent();

			this.Text = "Prime64 - " + this.Minval + " to " + this.Maxval + (divMode ? " (出力ファイル分割)" : "");
			this.Chk出力先ドライブの空き領域が逼迫してきたら中止する.Visible = countMode == false && StringTools.IsLocalDiskFullPath(this.OutFile);
			this.Chk出力先ドライブの空き領域が逼迫してきたら中止する.Checked = Gnd.I.SettingData.CheckDiskFreeOnOutput;

			this.TTip.SetToolTip(this.Chk出力先ドライブの空き領域が逼迫してきたら中止する, null); // LblNode追加で、要らなくなった。
			// old
			/*
			this.TTip.SetToolTip(
				this.Chk出力先ドライブの空き領域が逼迫してきたら中止する,
				this.OutFile[0] +
				" ドライブの空き領域が、" +
				Gnd.I.SettingData.DiskFreeOnOutput_MB +
				" メガバイト未満且つ " +
				Gnd.I.SettingData.DiskFreeOnOutput_Pct +
				" パーセント未満になったら、自動的に中止する。"
				);
				*/

			{
				string text = this.LblNote.Text;

				text = text.Replace("$F", "" + Gnd.I.SettingData.DiskFreeOnOutput_MB);
				text = text.Replace("$P", "" + Gnd.I.SettingData.DiskFreeOnOutput_Pct);

				this.LblNote.Text = text;
			}
		}

		private void BusyDlg_Load(object sender, EventArgs e)
		{
			// noop
		}

		private void BusyDlg_Shown(object sender, EventArgs e)
		{
			this.LblNote.Visible = this.Chk出力先ドライブの空き領域が逼迫してきたら中止する.Visible;
			this.Start();
			this.MT_Enabled = true;
		}

		private void BusyDlg_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.MT_Enabled = false;
			this.End();
		}

		private string CancelEvName;
		private string ReportEvName;
		private string ReportMtxName;
		private WorkDir ReportDir;
		private string ReportFile;

		private EventWaitHandle CancelEv;
		private EventWaitHandle ReportEv;
		private Mutex ReportMtx;

		private ProcessMan ProcMan;
		private bool Cancelled;
		private bool Cancelled_空き不足;

		private void Start()
		{
			this.CancelEvName = StringTools.MakeUUID();
			this.ReportEvName = StringTools.MakeUUID();
			this.ReportMtxName = StringTools.MakeUUID();
			this.ReportDir = new WorkDir();
			this.ReportFile = this.ReportDir.MakePath() + ".txt";

			this.CancelEv = new EventWaitHandle(false, EventResetMode.AutoReset, this.CancelEvName);
			this.ReportEv = new EventWaitHandle(false, EventResetMode.AutoReset, this.ReportEvName);
			this.ReportMtx = new Mutex(false, this.ReportMtxName);

			string command = this.CountMode ? "/C2" : "/R2";

			if (this.DivMode)
				command += " /D";

			this.ProcMan = new ProcessMan();
			this.ProcMan.Start(
				Gnd.I.Prime64File,
				Gnd.I.MainWin.CmdPartOptUMRTM() +
				command + " " +
				this.Minval + " " +
				this.Maxval + " " +
				"\"" + this.OutFile + "\" " +
				this.CancelEvName + " " +
				this.ReportEvName + " " +
				this.ReportMtxName + " " +
				"\"" + this.ReportFile + "\""
				);
		}

		private void End()
		{
			this.CancelEv.Close();
			this.CancelEv = null;
			this.ReportEv.Close();
			this.ReportEv = null;
			this.ReportMtx.Close();
			this.ReportMtx = null;
			this.ReportDir.Destroy();
			this.ReportDir = null;
		}

		private void BtnCancel_Click(object sender, EventArgs e)
		{
			this.Cancelled = true;
			this.CancelEv.Set();

			this.MainMessage.Text = "中止しています...";
			this.BtnCancel.Enabled = false;
			this.Chk出力先ドライブの空き領域が逼迫してきたら中止する.Enabled = false;
		}

		private bool MT_Enabled;
		private bool MT_Busy;
		private long MT_Count;

		private void MainTimer_Tick(object sender, EventArgs e)
		{
			if (this.MT_Enabled == false || this.MT_Busy)
				return;

			this.MT_Busy = true;

			try
			{
				if (this.MT_Count == 0) // ? 初回
				{
					this.MainPBar.Value = IntTools.IMAX / 20;
					return;
				}
				if (this.MT_Count % 200 == 0) // 1分毎
				{
					GC.Collect();
				}
				if (this.ProcMan.IsEnd())
				{
					if (this.Cancelled)
					{
						// リスト出力のときは削除しない！！！
						if (this.CountMode)
							if (File.Exists(this.OutFile))
								File.Delete(this.OutFile);

						this.MainMessage.Text = "中止しました。";

						if (this.Cancelled_空き不足)
						{
							MessageBox.Show(
								this,
								"出力先ドライブの空き領域が逼迫しているため、\r\nプログラムによって中止されました。",
								"Prime64",
								MessageBoxButtons.OK,
								MessageBoxIcon.Warning
								);
						}
						else
						{
							MessageBox.Show(
								this,
								"中止しました。",
								"Prime64",
								MessageBoxButtons.OK,
								MessageBoxIcon.Warning
								);
						}
					}
					else
					{
						this.MainPBar.Value = IntTools.IMAX;
						this.MainMessage.Text = "完了しました。";

						MessageBox.Show(
							this,
							"完了しました。",
							"Prime64",
							MessageBoxButtons.OK,
							MessageBoxIcon.Information
							);
					}
					this.MT_Enabled = false;
					this.Close();
					return;
				}
				if (this.Cancelled == false && this.ReportEv.WaitOne(0))
				{
					try
					{
						using (new IMutex(this.ReportMtx))
						{
							if (File.Exists(this.ReportFile))
							{
								string[] lines = File.ReadAllLines(this.ReportFile);

								ulong value = ulong.Parse(lines[0]);

								ulong n = value - this.Minval;
								ulong d = this.Maxval - this.Minval;
								double rate = (double)n / d;
								rate *= IntTools.IMAX * 0.9;
								rate += IntTools.IMAX * 0.05;
								this.MainPBar.Value = (int)(rate + 0.5);

								if (this.CountMode)
								{
									//this.MainMessage.Text = "素数の「個数」を数えています... " + value + ", " + lines[1] + " なう";
									this.MainMessage.Text = "素数の「個数」を数えています... " + value + " あたりまで数えました。";
								}
								else
								{
									this.MainMessage.Text = "計算/出力しています... " + value + " あたりまで出力しました。";
								}
							}
						}
					}
					catch (Exception ex)
					{
						this.MainMessage.Text = ex.Message;
					}
				}
				if (
					this.MT_Count % 10 == 0 && // 3秒毎
					this.Chk出力先ドライブの空き領域が逼迫してきたら中止する.Checked &&
					this.Cancelled == false &&
					this.CountMode == false &&
					this.Is空き不足()
					)
				{
					if (this.BtnCancel.Enabled)
						this.BtnCancel_Click(null, null);

					this.Cancelled_空き不足 = true;
				}
				if (this.XPressed)
				{
					if (this.BtnCancel.Enabled)
						this.BtnCancel_Click(null, null);

					this.XPressed = false;
				}
			}
			catch (Exception ex)
			{
				this.MT_Enabled = false;
				throw ex;
			}
			finally
			{
				this.MT_Count++;
				this.MT_Busy = false;
			}
		}

		private bool Is空き不足()
		{
			try
			{
				string file = this.OutFile;

				if (StringTools.IsLocalDiskFullPath(file))
				{
					DriveInfo di = new DriveInfo(file[0] + ":");
					long size = di.TotalSize;
					//long free = di.TotalFreeSpace;
					long free = di.AvailableFreeSpace;
					long free_kb = free / 1000;
					long free_mb = free_kb / 1000;
					double freeRate = (double)free / (double)size;
					int freePct = IntTools.ToInt(freeRate * 100);

					if (
						freePct < Gnd.I.SettingData.DiskFreeOnOutput_Pct &&
						free_mb < Gnd.I.SettingData.DiskFreeOnOutput_MB
						)
						return true;
				}
			}
			catch
			{ }

			return false;
		}
	}
}
