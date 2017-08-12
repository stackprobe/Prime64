using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPrime64
{
	public class AppTools
	{
		public static void CheckOutputFile(string outFile)
		{
			if (JString.IsJString(outFile, true, false, false, true, 1, 300) == false)
			{
				throw new Exception("Shift_JIS に変換出来ない文字を含むパスは指定できません。");
			}
		}
	}
}
