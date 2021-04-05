﻿using System;
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
					runprocess(finfo.Directory + "/" + appname ,arguments);
				}
				else
				{
					Regex reg = new Regex(".+cs");
					Match command = reg.Match(fullcommand[3]);
					runprocess(finfo.Directory + "/" + appname ,command.Value);
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
			ps.OutputDataReceived += delegate(object sender, DataReceivedEventArgs e) { Console.WriteLine(e.Data); };
			ps.Start();
			
		}
		
		public static void changeTargetVersion (string projectSln){
			
			string folderpath = new FileInfo(projectSln).Directory.ToString();
			string file1 = "Assembly-CSharp.csproj";
			string file2 = "Assembly-CSharp-Editor.csproj";
			
			
			if (File.Exists(folderpath+"/"+file1)){
				
			    	string f1 = File.ReadAllText(folderpath+"/"+file1).Replace("<TargetFrameworkVersion>v4.7.1</TargetFrameworkVersion>",
			                                                     "<TargetFrameworkVersion>v4.6.1</TargetFrameworkVersion>");
			    	File.WriteAllText(folderpath+"/"+file1,f1);
			    
			    }
			if (File.Exists(folderpath+"/"+file2)){
			    
			    string f1 = File.ReadAllText(folderpath+"/"+file2).Replace("<TargetFrameworkVersion>v4.7.1</TargetFrameworkVersion>",
			                                                     "<TargetFrameworkVersion>v4.6.1</TargetFrameworkVersion>");
			    	File.WriteAllText(folderpath+"/"+file1,f1);
			    }
				
		}
	}
}
