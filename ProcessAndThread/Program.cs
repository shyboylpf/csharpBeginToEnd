using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.ComponentModel;

namespace ProcessAndThread
{
    class Program
    {
        void OpenApplication(string myDocumentPath)
        {
            Process.Start(myDocumentPath);
        }
        void OpenWithArguments()
        {
            Process.Start("IExplore.exe", "www.163.com");
            Process.Start("IExplore.exe", "I:\\temp\\a.html");
            Process.Start("IExplore.exe", "I:\\temp\\b.jpg");
        }
        static void Main(string[] args)
        {
            string myDocumentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Program program = new Program();
            program.OpenApplication(myDocumentPath);
            program.OpenWithArguments();
            Console.WriteLine("Hello World!");
        }
    }
}
