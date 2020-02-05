using System;
using System.Threading;
using TipsAndTricks.Model;

namespace TipsAndTricks
{
	class Program
	{
		static void Main(string[] args)
		{
			var indexsers = new Indexers(new[]
			{
				"test1",
				"test2",
				"test3"
			});

			try
			{
				indexsers[1] = "testowanie123";

				Console.WriteLine($"[1] => {indexsers[1]}");

				indexsers[10] = "testowanie987";

			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}

			var lockExample = new LockExample();
			
			for (int i = 0; i < 5; i++)
			{
				var thread = new Thread(state =>
				{
					lockExample.State = state.ToString();
				});
				thread.Start($"test{i}");
			}

			for (int i = 0; i < 4; i++)
			{
				Thread mycorner = new Thread(new ThreadStart(MutexExample.ThreadProcess));
				mycorner.Name = String.Format("Thread{0}", i + 1);
				mycorner.Start();
			}
			Console.Read();

			Console.ReadKey();
		}
	}
}
