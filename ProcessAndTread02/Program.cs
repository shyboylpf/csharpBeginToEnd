using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.ComponentModel;
using System.Threading;

namespace ProcessAndTread02
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Process myProcess;
                myProcess = Process.Start("Notepad.exe");
                for(int i=0; i<5; i++)
                {
                    if (!myProcess.HasExited)
                    {
                        myProcess.Refresh();
                        Console.WriteLine($"当前资源占用 : {myProcess.WorkingSet64.ToString()}");
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        break;
                    }
                }
                myProcess.CloseMainWindow();
                myProcess.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Hello World!");
        }
    }
}
