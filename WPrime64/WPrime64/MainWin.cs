using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace WPrime64
{
	public partial class MainWin : Form
	{
		public MainWin()
		{
			InitializeComponent();
		}

		private void MainWin_Load(object sender, EventArgs e)
		{
			this.MinimumSize = this.Size;

			{
				bool existsPrimeDat;

				using (Mutex m = new Mutex(false, Gnd.I.FACTORY_COMMON_MUTEX))
				using (new IMutex(m))
				{
					existsPrimeDat = File.Exists("Prime.dat");
				}
				if (existsPrimeDat == false)
				{
					// Prime.dat のため、ディスクの空きチェック
					{
						DriveInfo di = new DriveInfo(BootTools.SelfDir.Substring(0, 2));
						int diskFree_mb = IntTools.ToInt(di.AvailableFreeSpace / 1000000.0);

						if (diskFree_mb < Gnd.I.SettingData.DiskFreeOnBoot_MB) // ? < 300 MB
						{
							string message = "起動に必要なディスクの空き領域が不足しています。(" + diskFree_mb + "_" + Gnd.I.SettingData.DiskFreeOnBoot_MB + ")";

							MessageBox.Show(message, Program.APP_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
							throw new Exception(message);
						}
					}

#if true
					{
						ProcessStartInfo psi = new ProcessStartInfo();

						psi.FileName = Gnd.I.Prime64File;
						psi.Arguments = "/P 1";
						psi.CreateNoWindow = true;
						psi.UseShellExecute = false;

						Process.Start(psi); // 待たない！
					}
#else // old @ 2017.5.17
					this.ProcMan.Start(Gnd.I.Prime64File, "/P 1");

					using (BusyDlg f = new BusyDlg())
					{
						f.SetInterval(delegate
						{
							return this.ProcMan.IsEnd() == false;
						});
						f.SetMessage("データファイルを作成しています...");
						f.ShowDialog();

						this.Location = f.Location;
					}

					if (Gnd.I.SettingData.HidePrimeDat)
					{
						this.ProcMan.Start("ATTRIB.EXE", "+S +H Prime.dat");
						this.ProcMan.End();
					}
#endif
				}
			}
		}

		private void NennotameMkPrimeDat()
		{
#if false // old @ 2017.5.17
			this.ProcMan.Start(Gnd.I.Prime64File, "/P 1");
			this.ProcMan.End();
#endif
		}

		private void MainWin_Shown(object sender, EventArgs e)
		{
			this.Chkファイルを分割して出力.Checked = Gnd.I.SettingData.OutFileDiv;
			this.Resized_Tabウラムの螺旋();
			this.US_Changed(true);
			this.MinValue.Focus();
		}

		private void MainWin_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (Gnd.I.SettingData.KeepPrimeDat == false)
			{
				// Prime64.exe の終了待ち。
				{
					Process p;

					{
						ProcessStartInfo psi = new ProcessStartInfo();

						psi.FileName = Gnd.I.Prime64File;
						psi.Arguments = "/P 1";
						psi.CreateNoWindow = true;
						psi.UseShellExecute = false;

						p = Process.Start(psi);
					}

					using (BusyDlg f = new BusyDlg())
					{
						f.SetInterval(delegate
						{
							return p.HasExited == false;
						});

						f.SetMessage("プログラムを終了しています...");
						f.ShowDialog();
					}
				}

				using (Mutex m = new Mutex(false, Gnd.I.FACTORY_COMMON_MUTEX))
				using (new IMutex(m))
				{
					File.Delete("Prime.dat");
				}
			}
		}

		private void BtnDo出力_Click(object sender, EventArgs e)
		{
			try
			{
				//IntTools.Normalize(this.MinValue);
				//IntTools.Normalize(this.MaxValue);

				string strmin = this.MinValue.Text;
				string strmax = this.MaxValue.Text;

				if (IntTools.IsULongString(strmin) == false)
					throw new Exception("[最小値] に 0 ～ " + ulong.MaxValue + " の整数を入力して下さい。");

				if (IntTools.IsULongString(strmax) == false)
					throw new Exception("[最大値] に 0 ～ " + ulong.MaxValue + " の整数を入力して下さい。");

				ulong minval = ulong.Parse(strmin);
				ulong maxval = ulong.Parse(strmax);

				if (maxval < minval)
					throw new Exception("[最小値] に [最大値] より大きな値が入力されています。");

				string outFile = null;

				{
					//SaveFileDialogクラスのインスタンスを作成
					SaveFileDialog sfd = new SaveFileDialog();

					//はじめのファイル名を指定する
					//sfd.FileName = "新しいファイル.html";
					sfd.FileName = "Prime_" + minval + "-" + maxval + ".txt";
					//はじめに表示されるフォルダを指定する
					//sfd.InitialDirectory = @"C:\";
					//sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
					sfd.InitialDirectory = Directory.GetCurrentDirectory();
					//[ファイルの種類]に表示される選択肢を指定する
					sfd.Filter =
						//"HTMLファイル(*.html;*.htm)|*.html;*.htm|すべてのファイル(*.*)|*.*";
						"テキストファイル(*.txt)|*.txt|すべてのファイル(*.*)|*.*";
					//[ファイルの種類]ではじめに
					//「すべてのファイル」が選択されているようにする
					//sfd.FilterIndex = 2;
					sfd.FilterIndex = 1;
					//タイトルを設定する
					//sfd.Title = "保存先のファイルを選択してください";
					sfd.Title = "出力ファイルを指定してください";
					//ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
					sfd.RestoreDirectory = true;
					//既に存在するファイル名を指定したとき警告する
					//デフォルトでTrueなので指定する必要はない
					sfd.OverwritePrompt = true;
					//存在しないパスが指定されたとき警告を表示する
					//デフォルトでTrueなので指定する必要はない
					sfd.CheckPathExists = true;

					//ダイアログを表示する
					if (sfd.ShowDialog() == DialogResult.OK)
					{
						//OKボタンがクリックされたとき
						//選択されたファイル名を表示する
						//Console.WriteLine(sfd.FileName);
						outFile = sfd.FileName;
					}
				}

				if (outFile == null)
					return;

				AppTools.CheckOutputFile(outFile);

				this.Visible = false;

				using (PrimeRangeOutputDlg f = new PrimeRangeOutputDlg(minval, maxval, outFile, false, this.Chkファイルを分割して出力.Checked))
				{
					f.ShowDialog();
				}
				this.Visible = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					ex.Message,
					"出力できません",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning
					);
			}
			finally
			{
				this.MinValue.Focus();
				//this.MinValue.SelectAll(); // 勝手に全セレクトされる。
			}
		}

		private ProcessMan ProcMan = new ProcessMan();
		private bool LastExec_IsPrime = true;

		private void BtnIsPrime_Click(object sender, EventArgs e)
		{
			this.LastExec_IsPrime = true;

			IntTools.Normalize(this.IsPrimeInputValue);
			string str = this.IsPrimeInputValue.Text;

			if (IntTools.IsULongString(str) == false)
			{
				MessageBox.Show(
					"0 ～ " + ulong.MaxValue + " の整数を入力して下さい。",
					"判定できません",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning
					);

				this.PostExec_IsPrime();
				return;
			}
			this.NennotameMkPrimeDat();

			WorkDir workDir = new WorkDir();
			string outFile = workDir.MakePath();
			this.ProcMan.Start(Gnd.I.Prime64File, "//O \"" + outFile + "\" /P " + str);

			using (BusyDlg f = new BusyDlg())
			{
				f.SetInterval(delegate
				{
					return this.ProcMan.IsEnd() == false;
				});

				f.ShowDialog();
			}
			string[] lines = File.ReadAllLines(outFile);
			lines = StringTools.Prime64StdoutFilter(lines);
			string ans = lines[0];

			if (ans == "IS_PRIME")
			{
				this.IsPrimeOutput.Text = str + "\r\nこの値は 素数 です。";
			}
			else if (ans == "IS_NOT_PRIME")
			{
				this.IsPrimeOutput.Text = str + "\r\nこの値は 素数 ではありません。2未満の整数又は合成数です。";
			}
			else
			{
				this.IsPrimeOutput.Text = str + "\r\n(エラー)";
			}
			workDir.Destroy();
			workDir = null;

			this.PostExec_IsPrime();
		}

		private void PostExec_IsPrime()
		{
			this.IsPrimeInputValue.SelectAll();
			this.IsPrimeInputValue.Focus();
		}

		private void IsPrimeInputValue_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)13) // ? Enter
			{
				if (this.LastExec_IsPrime)
					this.BtnIsPrime_Click(null, null);
				else
					this.BtnFindNearPrime_Click(null, null);

				e.Handled = true;
			}
		}

		private void BtnFindNearPrime_Click(object sender, EventArgs e)
		{
			this.LastExec_IsPrime = false;

			IntTools.Normalize(this.IsPrimeInputValue);
			string str = this.IsPrimeInputValue.Text;

			if (IntTools.IsULongString(str) == false)
			{
				MessageBox.Show(
					"0 ～ " + ulong.MaxValue + " の整数を入力して下さい。",
					"判定できません",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning
					);

				this.PostExec_IsPrime();
				return;
			}
			this.NennotameMkPrimeDat();

			WorkDir workDir = new WorkDir();
			string outFile = workDir.MakePath();
			this.ProcMan.Start(Gnd.I.Prime64File, "//O \"" + outFile + "\" /LH " + str);

			using (BusyDlg f = new BusyDlg())
			{
				f.SetInterval(delegate
				{
					return this.ProcMan.IsEnd() == false;
				});

				f.ShowDialog();
			}
			string[] lines = File.ReadAllLines(outFile);
			lines = StringTools.Prime64StdoutFilter(lines);
			string str_l = lines[0];
			string str_h = lines[1];

			if (str_l == "0")
				str_l = "(なし)";

			if (str_h == "0")
				str_h = Gnd.I.PRIME_MIN_OVER_UL;

			this.IsPrimeOutput.Text = "入力値：\r\n" + str + "\r\n入力値より小さい最大の素数：\r\n" + str_l + "\r\n入力値より大きい最小の素数：\r\n" + str_h;
			//this.IsPrimeOutput.Text = "n=\r\n" + str + "\r\nnより小さい最大の素数=\r\n" + str_l + "\r\nnより大きい最小の素数=\r\n" + str_h;
			//this.IsPrimeOutput.Text = str + "\r\n" + str_l + "\r\n" + str_h + "\r\n\r\n# 上から「入力値, 入力値より小さい最大の素数, 入力値より大きい最小の素数」です。";
			//this.IsPrimeOutput.Text = str_l + "\r\n" + str_h + "\r\n\r\n# 上から「 " + str + " より小さい最大の素数」「 " + str + " より大きい最小の素数」です。素数が見つからない場合は 0 を表示します。";

			workDir.Destroy();
			workDir = null;

			this.PostExec_IsPrime();
		}

		private void IsPrimeOutput_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)1) // ? Ctrl+A
			{
				this.IsPrimeOutput.SelectAll();
				e.Handled = true;
			}
		}

		private void BtnFactorize_Click(object sender, EventArgs e)
		{
			IntTools.Normalize(this.FactorizeInputValue);
			string str = this.FactorizeInputValue.Text;

			if (IntTools.IsULongString(str) == false || ulong.Parse(str) < 1)
			{
				MessageBox.Show(
					"1 ～ " + ulong.MaxValue + " の整数を入力して下さい。",
					"素因数分解できません",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning
					);

				this.PostExec_Factorize();
				return;
			}
			this.NennotameMkPrimeDat();

			WorkDir workDir = new WorkDir();
			string outFile = workDir.MakePath();
			this.ProcMan.Start(Gnd.I.Prime64File, "//O \"" + outFile + "\" /F " + str);

			using (BusyDlg f = new BusyDlg())
			{
				f.SetInterval(delegate
				{
					return this.ProcMan.IsEnd() == false;
				});

				f.ShowDialog();
			}
			string[] lines = File.ReadAllLines(outFile);
			lines = StringTools.Prime64StdoutFilter(lines);

			if (this.CheckFactorizeBekijou.Checked)
				lines = this.ToBekijou(lines);

			if (this.Chk改行しない.Checked)
				this.FactorizeOutput.Text = str + " = " + string.Join(" * ", lines);
			else
				this.FactorizeOutput.Text = str + " の 素因数 は ...\r\n" + string.Join("\r\n", lines);

			workDir.Destroy();
			workDir = null;

			this.PostExec_Factorize();
		}

		private string[] ToBekijou(string[] lines)
		{
			List<string> ret = new List<string>();

			for (int index = 0; index < lines.Length; )
			{
				int ndx;

				for (ndx = 1; index + ndx < lines.Length && lines[index] == lines[index + ndx]; ndx++)
				{ }

				if (ndx == 1)
					ret.Add(lines[index]);
				else
					ret.Add(lines[index] + " ^ " + ndx);

				index += ndx;
			}
			return ret.ToArray();
		}

		private void PostExec_Factorize()
		{
			this.FactorizeInputValue.SelectAll();
			this.FactorizeInputValue.Focus();
		}

		private void FactorizeInputValue_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)13) // ? Enter
			{
				this.BtnFactorize_Click(null, null);
				e.Handled = true;
			}
		}

		private void FactorizeOutput_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)1) // ? Ctrl+A
			{
				this.FactorizeOutput.SelectAll();
				e.Handled = true;
			}
		}

		private void MinValue_Leave(object sender, EventArgs e)
		{
			IntTools.Normalize(this.MinValue);
		}

		private void MaxValue_Leave(object sender, EventArgs e)
		{
			IntTools.Normalize(this.MaxValue);
		}

		private void IsPrimeInputValue_Leave(object sender, EventArgs e)
		{
			IntTools.Normalize(this.IsPrimeInputValue);
		}

		private void FactorizeInputValue_Leave(object sender, EventArgs e)
		{
			IntTools.Normalize(this.FactorizeInputValue);
		}

		private void BtnPrimeCount_Click(object sender, EventArgs e)
		{
			try
			{
				//IntTools.Normalize(this.PrimeCountMinval);
				//IntTools.Normalize(this.PrimeCountMaxval);

				string strmin = this.PrimeCountMinval.Text;
				string strmax = this.PrimeCountMaxval.Text;

				if (IntTools.IsULongString(strmin) == false)
					throw new Exception("[最小値] に 0 ～ " + ulong.MaxValue + " の整数を入力して下さい。");

				if (IntTools.IsULongString(strmax) == false)
					throw new Exception("[最大値] に 0 ～ " + ulong.MaxValue + " の整数を入力して下さい。");

				ulong minval = ulong.Parse(strmin);
				ulong maxval = ulong.Parse(strmax);

				if (maxval < minval)
					throw new Exception("[最小値] に [最大値] より大きな値が入力されています。");

				string outFile = null;

				{
					//SaveFileDialogクラスのインスタンスを作成
					SaveFileDialog sfd = new SaveFileDialog();

					//はじめのファイル名を指定する
					//sfd.FileName = "新しいファイル.html";
					sfd.FileName = "PrimeCount_" + minval + "-" + maxval + ".txt";
					//はじめに表示されるフォルダを指定する
					//sfd.InitialDirectory = @"C:\";
					//sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
					sfd.InitialDirectory = Directory.GetCurrentDirectory();
					//[ファイルの種類]に表示される選択肢を指定する
					sfd.Filter =
						//"HTMLファイル(*.html;*.htm)|*.html;*.htm|すべてのファイル(*.*)|*.*";
						"テキストファイル(*.txt)|*.txt|すべてのファイル(*.*)|*.*";
					//[ファイルの種類]ではじめに
					//「すべてのファイル」が選択されているようにする
					//sfd.FilterIndex = 2;
					sfd.FilterIndex = 1;
					//タイトルを設定する
					//sfd.Title = "保存先のファイルを選択してください";
					sfd.Title = "出力ファイルを指定してください";
					//ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
					sfd.RestoreDirectory = true;
					//既に存在するファイル名を指定したとき警告する
					//デフォルトでTrueなので指定する必要はない
					sfd.OverwritePrompt = true;
					//存在しないパスが指定されたとき警告を表示する
					//デフォルトでTrueなので指定する必要はない
					sfd.CheckPathExists = true;

					//ダイアログを表示する
					if (sfd.ShowDialog() == DialogResult.OK)
					{
						//OKボタンがクリックされたとき
						//選択されたファイル名を表示する
						//Console.WriteLine(sfd.FileName);
						outFile = sfd.FileName;
					}
				}

				if (outFile == null)
					return;

				AppTools.CheckOutputFile(outFile);

				this.Visible = false;

				using (PrimeRangeOutputDlg f = new PrimeRangeOutputDlg(minval, maxval, outFile, true))
				{
					f.ShowDialog();
				}
				this.Visible = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					ex.Message,
					"出力できません",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning
					);
			}
			finally
			{
				this.PrimeCountMinval.Focus();
				//this.PrimeCountMinval.SelectAll(); // 勝手に全セレクトされる。
			}
		}

		private void MinValue_TextChanged(object sender, EventArgs e)
		{
			IntTools.CheckULong(this.MinValue);
		}

		private void MaxValue_TextChanged(object sender, EventArgs e)
		{
			IntTools.CheckULong(this.MaxValue);
		}

		private void IsPrimeInputValue_TextChanged(object sender, EventArgs e)
		{
			IntTools.CheckULong(this.IsPrimeInputValue);
		}

		private void FactorizeInputValue_TextChanged(object sender, EventArgs e)
		{
			IntTools.CheckULong(this.FactorizeInputValue);
		}

		private void PrimeCountMinval_TextChanged(object sender, EventArgs e)
		{
			IntTools.CheckULong(this.PrimeCountMinval);
		}

		private void PrimeCountMaxval_TextChanged(object sender, EventArgs e)
		{
			IntTools.CheckULong(this.PrimeCountMaxval);
		}

		private void PrimeCountMinval_Leave(object sender, EventArgs e)
		{
			IntTools.Normalize(this.PrimeCountMinval);
		}

		private void PrimeCountMaxval_Leave(object sender, EventArgs e)
		{
			IntTools.Normalize(this.PrimeCountMaxval);
		}

		private void MainWin_Resize(object sender, EventArgs e)
		{
			if (this.MainTab.SelectedTab == this.Tabウラムの螺旋)
				this.Resized_Tabウラムの螺旋();
		}

		private void MainTab_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.MainTab.SelectedTab == this.Tabウラムの螺旋)
				this.Resized_Tabウラムの螺旋();
		}

		private int? RTU_D;

		private void Resized_Tabウラムの螺旋()
		{
			try
			{
				if (this.RTU_D == null)
					this.RTU_D = this.US_T.Left + this.US_T.Width - this.US_L.Left - this.Width;

				int w = this.Width + this.RTU_D.Value;

				const int MID = 10;

				w -= MID;
				w /= 2;

				this.US_L.Width = w;
				this.US_T.Width = w;
				this.US_R.Width = w;
				this.US_B.Width = w;
				this.BtnPrimeColor.Width = w;
				this.BtnNotPrimeColor.Width = w;
				this.BtnCenterColor.Width = w;
				this.Btn_US.Width = w;

				int l = this.US_L.Left + w + MID;

				this.US_Y軸.Left = l;
				this.US_T.Left = l;
				this.US_B.Left = l;
				this.BtnNotPrimeColor.Left = l;
				this.Btn_US.Left = l;
			}
			catch
			{ }
		}

		private void US_L_TextChanged(object sender, EventArgs e)
		{
			this.US_Changed(false);
		}

		private void US_T_TextChanged(object sender, EventArgs e)
		{
			this.US_Changed(false);
		}

		private void US_R_TextChanged(object sender, EventArgs e)
		{
			this.US_Changed(false);
		}

		private void US_B_TextChanged(object sender, EventArgs e)
		{
			this.US_Changed(false);
		}

		private void US_L_Leave(object sender, EventArgs e)
		{
			this.US_Changed(true);
		}

		private void US_T_Leave(object sender, EventArgs e)
		{
			this.US_Changed(true);
		}

		private void US_R_Leave(object sender, EventArgs e)
		{
			this.US_Changed(true);
		}

		private void US_B_Leave(object sender, EventArgs e)
		{
			this.US_Changed(true);
		}

		private const long US_X_MIN = -0x7fffffffL;
		private const long US_X_MAX = 0x80000000L;
		private const long US_Y_MIN = -0x80000000L;
		private const long US_Y_MAX = 0x7fffffffL;
		private const long US_W_H_MAX = 30001;
		private const long US_WXH_MAX = 300040001;

		private void US_Changed(bool normalizeFlag)
		{
			IntTools.CheckLongRange(this.US_L, US_X_MIN, US_X_MAX, normalizeFlag);
			IntTools.CheckLongRange(this.US_T, US_Y_MIN, US_Y_MAX, normalizeFlag);
			IntTools.CheckLongRange(this.US_R, US_X_MIN, US_X_MAX, normalizeFlag);
			IntTools.CheckLongRange(this.US_B, US_Y_MIN, US_Y_MAX, normalizeFlag);

			{
				long? w = null;
				long? h = null;
				long? wxh = null;

				try
				{
					long l = IntTools.GetLongRange(this.US_L, US_X_MIN, US_X_MAX).Value;
					long t = IntTools.GetLongRange(this.US_T, US_Y_MIN, US_Y_MAX).Value;
					long r = IntTools.GetLongRange(this.US_R, US_X_MIN, US_X_MAX).Value;
					long b = IntTools.GetLongRange(this.US_B, US_Y_MIN, US_Y_MAX).Value;

					w = r - l + 1;
					h = b - t + 1;

					if (1 <= w && w < int.MaxValue && 1 <= h && h < int.MaxValue)
					{
						wxh = w * h;
					}
				}
				catch
				{ }

				this.SizeInfo.Text = "幅: " + w + "\n高さ: " + h + "\n幅×高さ: " + wxh;

				if (w == null || h == null || wxh == null) // ? 異常
				{
					this.SizeInfo.ForeColor = Color.Red;
				}
				else if (US_W_H_MAX < w || US_W_H_MAX < h || US_WXH_MAX < wxh) // ? 大きすぎる
				{
					this.SizeInfo.ForeColor = Color.OrangeRed;
				}
				else // ? 正常
				{
					this.SizeInfo.ForeColor = IntTools.DEF_TB_FORECOLOR;
				}
			}
		}

		private void BtnPrimeColor_Click(object sender, EventArgs e)
		{
			this.EditColor(this.BtnPrimeColor);
		}

		private void BtnNotPrimeColor_Click(object sender, EventArgs e)
		{
			this.EditColor(this.BtnNotPrimeColor);
		}

		private void BtnCenterColor_Click(object sender, EventArgs e)
		{
			this.EditColor(this.BtnCenterColor);
		}

		private string EC_Name;
		private string EC_RefStrColor;
		private Color EC_Color;

		private void EditColor(Button btn)
		{
			this.EC_Load(btn);

			{
				int[] customs = new int[16];

				{
					Random r = new Random();

					for (int c = 0; c < customs.Length; c++)
						customs[c] = r.Next(0x1000000);
				}

				using (ColorDialog f = new ColorDialog())
				{
					f.Color = this.EC_Color;
					f.CustomColors = customs;

					if (f.ShowDialog() == DialogResult.OK)
					{
						this.EC_Color = f.Color;
					}
				}
			}

			this.EC_Save(btn);
		}

		private void EC_Load(Button btn)
		{
			string[] tokens = btn.Text.Split('=');

			this.EC_Name = tokens[0].Trim();
			this.EC_RefStrColor = tokens[1].Trim();
			this.EC_Color = StringTools.GetColor(this.EC_RefStrColor);
		}

		private void EC_Save(Button btn)
		{
			btn.Text = this.EC_Name + " = " + StringTools.GetString(this.EC_Color);
		}

		private void Btn_US_Click(object sender, EventArgs e)
		{
			try
			{
				this.US_Changed(true);

				long l;
				long t;
				long r;
				long b;

				try
				{
					l = IntTools.GetLongRange(this.US_L, US_X_MIN, US_X_MAX).Value;
					t = IntTools.GetLongRange(this.US_T, US_Y_MIN, US_Y_MAX).Value;
					r = IntTools.GetLongRange(this.US_R, US_X_MIN, US_X_MAX).Value;
					b = IntTools.GetLongRange(this.US_B, US_Y_MIN, US_Y_MAX).Value;
				}
				catch
				{
					throw new Exception("座標の書式に問題があります。");
				}

				if (Gnd.I.SettingData.USCheckOff == false)
				{
					if (r < l)
						throw new Exception("[右下X] < [左上X] になっています。");

					if (b < t)
						throw new Exception("[右下Y] < [左上Y] になっています。");

					long w = r - l + 1;
					long h = b - t + 1;

					if (US_W_H_MAX < w)
						throw new Exception("[幅] は " + US_W_H_MAX + " 以下でなければなりません。");

					if (US_W_H_MAX < h)
						throw new Exception("[高さ] は " + US_W_H_MAX + " 以下でなければなりません。");

					long wxh = w * h;

					if (US_WXH_MAX < wxh)
						throw new Exception("[幅×高さ] は " + US_WXH_MAX + " 以下でなければなりません。");
				}

				this.EC_Load(this.BtnPrimeColor);
				string primeColor = this.EC_RefStrColor;
				this.EC_Load(this.BtnNotPrimeColor);
				string notPrimeColor = this.EC_RefStrColor;
				this.EC_Load(this.BtnCenterColor);
				string centerColor = this.EC_RefStrColor;

				string outFile = null;

				{
					//SaveFileDialogクラスのインスタンスを作成
					SaveFileDialog sfd = new SaveFileDialog();

					//はじめのファイル名を指定する
					//sfd.FileName = "新しいファイル.html";
					sfd.FileName = "UlamSpiral_" + l + "_" + t + "_" + r + "_" + b + ".bmp";
					//はじめに表示されるフォルダを指定する
					//sfd.InitialDirectory = @"C:\";
					//sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
					sfd.InitialDirectory = Directory.GetCurrentDirectory();
					//[ファイルの種類]に表示される選択肢を指定する
					sfd.Filter =
						//"HTMLファイル(*.html;*.htm)|*.html;*.htm|すべてのファイル(*.*)|*.*";
						"ビットマップファイル(*.bmp)|*.bmp|すべてのファイル(*.*)|*.*";
					//[ファイルの種類]ではじめに
					//「すべてのファイル」が選択されているようにする
					//sfd.FilterIndex = 2;
					sfd.FilterIndex = 1;
					//タイトルを設定する
					//sfd.Title = "保存先のファイルを選択してください";
					sfd.Title = "出力ファイルを指定してください";
					//ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
					sfd.RestoreDirectory = true;
					//既に存在するファイル名を指定したとき警告する
					//デフォルトでTrueなので指定する必要はない
					sfd.OverwritePrompt = true;
					//存在しないパスが指定されたとき警告を表示する
					//デフォルトでTrueなので指定する必要はない
					sfd.CheckPathExists = true;

					//ダイアログを表示する
					if (sfd.ShowDialog() == DialogResult.OK)
					{
						//OKボタンがクリックされたとき
						//選択されたファイル名を表示する
						//Console.WriteLine(sfd.FileName);
						outFile = sfd.FileName;
					}
				}

				if (outFile == null)
					return;

				AppTools.CheckOutputFile(outFile);

				this.Visible = false;

				using (UlamSpiralOutputDlg f = new UlamSpiralOutputDlg(l, t, r, b, primeColor, notPrimeColor, centerColor, outFile))
				{
					f.ShowDialog();
				}
				this.Visible = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					ex.Message,
					"BMPファイルを出力できません",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning
					);
			}
			finally
			{
				this.US_L.Focus();
				//this.US_L.SelectAll(); // 勝手に全セレクトされる。
			}
		}

		private void MinValue_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)13) // ? Enter
			{
				this.MaxValue.Focus();
				e.Handled = true;
			}
		}

		private void MaxValue_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)13) // ? Enter
			{
				this.BtnDo出力.Focus();
				e.Handled = true;
			}
		}

		private void PrimeCountMinval_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)13) // ? Enter
			{
				this.PrimeCountMaxval.Focus();
				e.Handled = true;
			}
		}

		private void PrimeCountMaxval_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)13) // ? Enter
			{
				this.BtnPrimeCount.Focus();
				e.Handled = true;
			}
		}

		private void US_L_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)13) // ? Enter
			{
				this.US_T.Focus();
				e.Handled = true;
			}
		}

		private void US_T_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)13) // ? Enter
			{
				this.US_R.Focus();
				e.Handled = true;
			}
		}

		private void US_R_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)13) // ? Enter
			{
				this.US_B.Focus();
				e.Handled = true;
			}
		}

		private void US_B_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)13) // ? Enter
			{
				this.Btn_US.Focus();
				e.Handled = true;
			}
		}
	}
}
