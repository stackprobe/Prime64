using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using System.Drawing;

namespace WPrime64
{
	public static class IntTools
	{
		public static void Normalize(TextBox tb)
		{
			tb.Text = Normalize(tb.Text);
			CheckULong(tb);
		}

		public static string Normalize(string str)
		{
			str = Strings.StrConv(str, VbStrConv.Narrow);
			str = str.Replace(",", "");

			{
				int dotPos = str.IndexOf('.');

				if (dotPos != -1 && StringTools.ContainsOnly(str.Substring(dotPos + 1), "0"))
					str = str.Substring(0, dotPos);
			}

			str = str.Trim();

			while (2 <= str.Length && str[0] == '0')
				str = str.Substring(1);

			return str;
		}

		public static readonly Color DEF_TB_FORECOLOR = new TextBox().ForeColor;

		public static void CheckULong(TextBox tb)
		{
			if (tb.Text == "" || CheckULong(tb.Text)) // ? 未入力 || 正常
			{
				tb.ForeColor = DEF_TB_FORECOLOR;
			}
			else // ? 異常
			{
				tb.ForeColor = Color.Red;
			}
		}

		public static bool CheckULong(string str)
		{
			return IsULongString(Normalize(str));
		}

		public static bool IsULongString(string str)
		{
			try
			{
				return str == "" + ParseULong(str);
			}
			catch
			{
				return false;
			}
		}

		public static ulong ParseULong(string str, ulong defval = 0)
		{
			try
			{
				return ulong.Parse(str);
			}
			catch
			{
				return defval;
			}
		}

		public static void CheckLongRange(TextBox tb, long minval, long maxval, bool normalizeFlag)
		{
			if (normalizeFlag)
			{
				tb.Text = Normalize(tb.Text);
			}
			if (tb.Text == "" || GetLongRange(tb, minval, maxval) != null) // ? 未入力 || 正常
			{
				tb.ForeColor = DEF_TB_FORECOLOR;
			}
			else // ? 異常
			{
				tb.ForeColor = Color.Red;
			}
		}

		public static long? GetLongRange(TextBox tb, long minval, long maxval)
		{
			try
			{
				long value = long.Parse(Normalize(tb.Text));

				if (value < minval || maxval < value)
				{
					return null;
				}
				return value;
			}
			catch
			{
				return null;
			}
		}

		public static int ToInt(double value)
		{
			if (value < 0.0)
				return (int)(value - 0.5);

			return (int)(value + 0.5);
		}

		public const int IMAX = 1000000000;

		public static int ToInt(string str, int minval, int maxval)
		{
			int value = int.Parse(str);

			if (value < minval || maxval < value)
				throw new Exception("Out of Range (" + minval + " - " + maxval + ")");

			return value;
		}
	}
}
