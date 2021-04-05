using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Diagnostics;

//XamarinStudio.exe
//<TargetFrameworkVersion>v4.7.1</TargetFrameworkVersion>

/*
 * 	Args
 * [0] application exe
 * [1] -nologo
 * [2] Project Solution File
 * [3] project CS file ; line
 * */



namespace args
{
	class MainClass
	{

		public static void Main(string[] args)
		{

			string appname = "XamarinStudio.exe";
			Process[] pro = Process.GetProcessesByName(appname.Replace(".exe", ""));
			string[] fullcommand = Environment.GetCommandLineArgs();
			
			if (fullcommand.Length > 2)
			{
				changeTargetVersion(fullcommand[2]);
				
				FileInfo finfo = new FileInfo(fullcommand[0]);

				if (pro.Length == 0)
				{
					string arguments = fullcommand[2] + " " + fullcommand[3].Replace("-1", "0");
					Console.WriteLine("opening "+ arguments);
					runprocess(finfo.Directory + "/" + appname ,arguments);
				}
				else
				{
					Regex reg = new Regex(".+cs");
					Match command = reg.Match(fullcommand[3]);
					Console.WriteLine("opening "+ fullcommand[3].Replace("-1", "0"));
					
					runprocess(finfo.Directory + "/" + appname ,fullcommand[3].Replace("-1", "0"));
				}
				//Console.ReadKey();
				Application.Run(new wait_view());
			}
		}

		public static void runprocess(string process, string arguments)
		{
			ProcessStartInfo info = new ProcessStartInfo();
			info.FileName = process;
			info.Arguments = arguments;
			info.UseShellExecute = true;
			Process ps = new Process();
			ps.StartInfo = info;
			ps.Start();
			
		}
		
		public static void changeTargetVersion (string projectSln){
			
			string folderpath = new FileInfo(projectSln).Directory.ToString();
			string file1 = "Assembly-CSharp.csproj";
			string file2 = "Assembly-CSharp-Editor.csproj";
			
//			Console.WriteLine(folderpath);
			if (File.Exists(folderpath+"/"+file1)){
				
//				Console.WriteLine("change " + file1);
			    	string file = File.ReadAllText(folderpath+"/"+file1).Replace("<TargetFrameworkVersion>v4.7.1</TargetFrameworkVersion>",
			                                                     "<TargetFrameworkVersion>v4.6.1</TargetFrameworkVersion>");
			    	File.WriteAllText(folderpath+"/"+file1,file);
			    
			    }
			if (File.Exists(folderpath+"/"+file2)){
			    
			    string file = File.ReadAllText(folderpath+"/"+file2).Replace("<TargetFrameworkVersion>v4.7.1</TargetFrameworkVersion>",
			                                                     "<TargetFrameworkVersion>v4.6.1</TargetFrameworkVersion>");
			    	File.WriteAllText(folderpath+"/"+file2,file);
			    }
				
		}
	}
}
