using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Diagnostics;
//XamarinStudio.exe

namespace args
{
	class MainClass
	{

		public static void Main(string[] args)
		{
			string appname = "XamarinStudio.exe";
			Process[] pro = Process.GetProcessesByName(appname.Replace(".exe", ""));
			string[] fullcommand = Environment.GetCommandLineArgs();

			if (pro.Length == 0)
			{

				FileInfo finfo = new FileInfo(fullcommand[0]);
				string arguments = fullcommand[2] + " " + fullcommand[3].Replace("-1", "0");
				Process.Start(finfo.Directory + "/" + appname, arguments);
			}
			else
			{
				Regex reg = new Regex(".+cs");
				Match command = reg.Match(fullcommand[3]);

				Process.Start(command.Value);
			}
			//Console.ReadKey();

		}



	}
}
