using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace SystemTemperatureChecker
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			// EMBEDDED DLL HANDLER tested OK 01-15-2014
			// Must run in Program Class (where exception occurs
			AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
			Application.Run(new MainForm());
		}
		// EMBEDDED DLL LOADER 
		// VERSION 2.0 01-15-2014 derives resourcename from args and application namespace
		// assumes resource is a DLL
		// this should load any missing DLL that is properly embedded
		static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
		{
			string appname = Application.ProductName + "."; // gets Application Namespace
			string[] dll = args.Name.ToString().Split(','); // separates args.Name string
			string resourcename = appname + dll[0] + ".dll"; // element [0] contains the missing resource name
			Assembly MyAssembly = Assembly.GetExecutingAssembly();
			Stream AssemblyStream = MyAssembly.GetManifestResourceStream(resourcename);
			byte[] raw = new byte[AssemblyStream.Length];
			AssemblyStream.Read(raw, 0, raw.Length);
			return Assembly.Load(raw);
		}
	}
}