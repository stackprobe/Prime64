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
	public partial class UlamSpiralOutputDlg : Form
	{
		private bool XPressed;

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

		private long L;
		private long T;
		private long R;
		private long B;
		private string PrimeColor;
		private string NotPrimeColor;
		private string CenterColor;
		private string OutFile;

		public UlamSpiralOutputDlg(long l, long t, long r, long b, string primeColor, string notPrimeColor, string centerColor, string outFile)
		{
			this.L = l;
			this.T = t;
			this.R = r;
			this.B = b;
			this.PrimeColor = primeColor;
			this.NotPrimeColor = notPrimeColor;
			this.CenterColor = centerColor;
			this.OutFile = outFile;

			InitializeComponent();

			this.Text = "Prime64 - (" + this.L + ", " + this.T + ") to (" + this.R + ", " + this.B + ")";
		}

		private void BusyDlg_Load(object sender, EventArgs e)
		{
			// noop
		}

		private void BusyDlg_Shown(object sender, EventArgs e)
		{
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

			this.ProcMan = new ProcessMan();
			this.ProcMan.Start(
				Gnd.I.Prime64File,
				Gnd.I.MainWin.CmdPartOptUMRTM() +
				"/US2 " +
				this.L + " " +
				this.T + " " +
				this.R + " " +
				this.B + " " +
				this.PrimeColor + " " +
				this.NotPrimeColor + " " +
				this.CenterColor + " " +
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
						if (File.Exists(this.OutFile))
							File.Delete(this.OutFile);

						this.MainMessage.Text = "中止しました。";

						MessageBox.Show(
							this,
							"中止しました。",
							"Prime64",
							MessageBoxButtons.OK,
							MessageBoxIcon.Warning
							);
					}
					else if (File.Exists(this.OutFile) == false)
					{
						this.MainPBar.Value = 0;
						this.MainMessage.Text = "エラーにより停止しました。";

						MessageBox.Show(
							this,
							"エラーにより停止しました。",
							"Prime64",
							MessageBoxButtons.OK,
							MessageBoxIcon.Error
							);
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
								int c = 0;

								int x = int.Parse(lines[c++]);
								int y = int.Parse(lines[c++]);
								int w = int.Parse(lines[c++]);
								int h = int.Parse(lines[c++]);

								int n = x + y * w;
								int d = w * h;

								double rate = (double)n / d;
								rate *= IntTools.IMAX * 0.9;
								rate += IntTools.IMAX * 0.05;
								this.MainPBar.Value = (int)(rate + 0.5);

								if (y < h)
								{
									this.MainMessage.Text = "BMPデータを作成しています... いま " + (this.L + x) + ", " + (this.T + y) + " あたり";
								}
								else
								{
									this.MainMessage.Text = "BMPファイルを作成しています...";
								}
							}
						}
					}
					catch (Exception ex)
					{
						this.MainMessage.Text = ex.Message;
					}
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
	}
}
