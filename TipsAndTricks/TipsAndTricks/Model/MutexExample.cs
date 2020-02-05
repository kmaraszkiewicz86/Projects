using System;
using System.Threading;

namespace TipsAndTricks.Model
{
	class MutexExample
	{
		private static Mutex mutex = new Mutex();
		private const int numhits = 1;

		public static void ThreadProcess()
		{
			for (int i = 0; i < numhits; i++)
			{
				UseCsharpcorner();
			}
		}

		public static void UseCsharpcorner()
		{
			mutex.WaitOne();   // Wait until it is safe to enter.  
			Console.WriteLine("{0} has entered in the C_sharpcorner.com",
				Thread.CurrentThread.Name);
			// Place code to access non-reentrant resources here.  
			Thread.Sleep(500);    // Wait until it is safe to enter.  
			Console.WriteLine("{0} is leaving the C_sharpcorner.com\r\n",
				Thread.CurrentThread.Name);
			mutex.ReleaseMutex();    // Release the Mutex.  
		}
	}
}