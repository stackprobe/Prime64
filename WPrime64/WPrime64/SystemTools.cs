using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Text;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace WPrime64
{
	public static class SystemTools
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
			return GetCryptoRand() % modulo; // todo
		}

		public static uint GetCryptoRand(uint minval, uint maxval)
		{
			return GetCryptoRand(maxval + 1 - minval) + minval;
		}

		public delegate void Perform_d();

		// sync > @ AntiWindowsDefenderSmartScreen

		public static void AntiWindowsDefenderSmartScreen()
		{
			WriteLog("awdss_1");

			if (Is初回起動())
			{
				WriteLog("awdss_2");

				foreach (string exeFile in Directory.GetFiles(BootTools.SelfDir, "*.exe", SearchOption.TopDirectoryOnly))
				{
					try
					{
						WriteLog("awdss_exeFile: " + exeFile);

						if (exeFile.ToLower() == BootTools.SelfFile.ToLower())
						{
							WriteLog("awdss_self_noop");
						}
						else
						{
							byte[] exeData = File.ReadAllBytes(exeFile);
							File.Delete(exeFile);
							File.WriteAllBytes(exeFile, exeData);
						}
						WriteLog("awdss_OK");
					}
					catch (Exception e)
					{
						WriteLog(e);
					}
				}
				WriteLog("awdss_3");
			}
			WriteLog("awdss_4");
		}

		// < sync

		public static bool 初回起動Flag;

		public static bool Is初回起動()
		{
			return 初回起動Flag;
		}

		public static void WriteLog(object message)
		{
			Logger.WriteLog(message);
		}

		// sync > @ PostShown

		public static void PostShown_GetAllControl(Form f, Action<Control> reaction)
		{
			Queue<Control.ControlCollection> controlTable = new Queue<Control.ControlCollection>();

			controlTable.Enqueue(f.Controls);

			while (1 <= controlTable.Count)
			{
				foreach (Control control in controlTable.Dequeue())
				{
					GroupBox gb = control as GroupBox;

					if (gb != null)
					{
						controlTable.Enqueue(gb.Controls);
					}
					TabControl tc = control as TabControl;

					if (tc != null)
					{
						foreach (TabPage tp in tc.TabPages)
						{
							controlTable.Enqueue(tp.Controls);
						}
					}
					SplitContainer sc = control as SplitContainer;

					if (sc != null)
					{
						controlTable.Enqueue(sc.Panel1.Controls);
						controlTable.Enqueue(sc.Panel2.Controls);
					}
					Panel p = control as Panel;

					if (p != null)
					{
						controlTable.Enqueue(p.Controls);
					}
					reaction(control);
				}
			}
		}

		public static void PostShown(Form f)
		{
			PostShown_GetAllControl(f, control =>
			{
				Control c = new Control[]
				{
					control as TextBox,
					control as NumericUpDown,
				}
				.FirstOrDefault(v => v != null);

				if (c != null)
				{
					if (c.ContextMenuStrip == null)
					{
						ToolStripMenuItem item = new ToolStripMenuItem();

						item.Text = "項目なし";
						item.Enabled = false;

						ContextMenuStrip menu = new ContextMenuStrip();

						menu.Items.Add(item);

						c.ContextMenuStrip = menu;
					}
				}
			});
		}

		// < sync
	}
}
