using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace WPrime64
{
	public class IMutex : IDisposable
	{
		private Mutex Mtx;

		public IMutex(Mutex mtx)
		{
			this.Mtx = mtx;
			this.Mtx.WaitOne();
		}

		public void Dispose()
		{
			if (this.Mtx != null)
			{
				this.Mtx.ReleaseMutex();
				this.Mtx = null;
			}
		}
	}
}
