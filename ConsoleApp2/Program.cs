using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.ComponentModel;

namespace ConsoleApp2
{
    class MyProcess
    {
        const int ERROR_FILE_NOT_FOUND = 2;
        const int ERROR_ACCESS_DENIED = 5;
        public void PrintProcessInfo()
        {
            Process myProcess = new Process();
            try
            {
                string myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                myProcess.StartInfo.FileName = myDocumentsPath + "\\MyFile.doc";
                myProcess.StartInfo.Verb = "Print";
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.Start();
            }
            catch(Win32Exception e)
            {
                if (e.NativeErrorCode == ERROR_FILE_NOT_FOUND)
                {
                    Console.WriteLine(e.Message + ". Check the path.");
                }
                else if(e.NativeErrorCode == ERROR_ACCESS_DENIED)
                {
                    Console.WriteLine(e.Message + ".没权限打印");
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyProcess myProcess = new MyProcess();
            myProcess.PrintProcessInfo();
            Console.WriteLine("Hello World!");
        }
    }
}
