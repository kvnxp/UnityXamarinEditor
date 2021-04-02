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

//			Process.EnterDebugMode();
			string appname = "XamarinStudio.exe";
			Process[] pro = Process.GetProcessesByName(appname.Replace(".exe", ""));
			
			string[] fullcommand = Environment.GetCommandLineArgs();

			if (fullcommand.Length > 2)
			{
					FileInfo finfo = new FileInfo(fullcommand[0]);
				
				if (pro.Length == 0)
				{
					string arguments = fullcommand[2] + " " + fullcommand[3].Replace("-1", "0");
//					Process.Start(finfo.Directory + "/" + appname, arguments);
					runprocess(finfo.Directory + "/" + appname ,arguments);
				}
				else
				{
					Regex reg = new Regex(".+cs");
					Match command = reg.Match(fullcommand[3]);
					runprocess(finfo.Directory + "/" + appname ,command.Value);
				}
				//Console.ReadKey();
			}
		}
		
		public static void runprocess(string process,string arguments){
			ProcessStartInfo info = new ProcessStartInfo();
			info.FileName = process;
			info.Arguments = arguments;
			info.UseShellExecute = true;
			Process ps = new Process();
			ps.StartInfo = info;
			ps.Start();
		
		
		}


	}
}
