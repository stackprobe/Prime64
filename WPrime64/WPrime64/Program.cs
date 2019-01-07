using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using Microsoft.Win32;
using System.Text;
using Charlotte;

namespace WPrime64
{
	static class Program
	{
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main()
		{
			BootTools.OnBoot();

			Application.ThreadException += new ThreadExceptionEventHandler(ThreadException);
			AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledException);
			SystemEvents.SessionEnding += new SessionEndingEventHandler(SessionEnding);

			Mutex procMtx = new Mutex(false, "{053833f4-d25b-4768-a521-b56796d57280}");

			if (procMtx.WaitOne(0) && GlobalProcMtx.Create("{9102c3e9-3399-439a-9082-c3adb06c3df7}", APP_TITLE))
			{
				CheckSelfDir();
				CheckCopiedExe();

				SystemTools.AntiWindowsDefenderSmartScreen();

				Gnd.I.LoadSettingData();

				// core >

				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new MainWin());

				// < core

				GlobalProcMtx.Release();
				procMtx.ReleaseMutex();
			}
			procMtx.Close();
		}

		public const string APP_TITLE = "Prime64";

		private static void ThreadException(object sender, ThreadExceptionEventArgs e)
		{
			UnhandledError(e.Exception, "ThreadException");
		}

		private static void UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			UnhandledError(e.ExceptionObject, "UnhandledException");
		}

		private static void UnhandledError(object message, string reason)
		{
			try
			{
				message = "[" + reason + "] " + message;
				Logger.WriteLog(message);
			}
			catch
			{ }

			Environment.Exit(1);
		}

		private static void SessionEnding(object sender, SessionEndingEventArgs e)
		{
			Environment.Exit(3);
		}

		private static void CheckSelfDir()
		{
			string dir = BootTools.SelfDir;
			Encoding SJIS = Encoding.GetEncoding(932);

			if (dir != SJIS.GetString(SJIS.GetBytes(dir)))
			{
				MessageBox.Show(
					"Shift_JIS に変換出来ない文字を含むパスからは実行できません。",
					APP_TITLE + " / エラー",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
					);

				Environment.Exit(4);
			}
			if (dir.StartsWith("\\\\"))
			{
				MessageBox.Show(
					"ネットワークフォルダからは実行できません。",
					APP_TITLE + " / エラー",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
					);

				Environment.Exit(5);
			}
		}

		private static void CheckCopiedExe()
		{
			if (File.Exists("Prime64.exe")) // リリースに含まれるファイル
				return;

			if (Directory.Exists(@"..\Debug")) // ? devenv
				return;

			MessageBox.Show(
				"WHY AM I ALONE ?",
				"",
				MessageBoxButtons.OK,
				MessageBoxIcon.Error
				);

			Environment.Exit(6);
		}
	}
}
