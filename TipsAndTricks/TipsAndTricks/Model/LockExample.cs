using System;
using System.Threading;

namespace TipsAndTricks.Model
{
	public class LockExample
	{
		private object syncHandle = new object();

		private string _state = "test";

		public string State
		{
			get
			{
				lock (syncHandle)
				{
					return _state;
				}
			}
			set
			{
				lock (syncHandle)
				{
					_state = value;
					Thread.Sleep(50);
					Console.WriteLine(_state);
				}
			}
		}
	}
}