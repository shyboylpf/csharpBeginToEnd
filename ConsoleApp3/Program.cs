using System;
using System.IO;
using System.Text;
using System.Threading;

namespace ConsoleApp3
{
    internal class Program
    {
        private const string FILE_NAME = "hiv00005.pic";

        public static void Main()
        {
            if (!File.Exists(FILE_NAME))
            {
                Console.WriteLine($"{FILE_NAME} does not exist!");
                return;
            }
            FileStream fsIn = new FileStream(FILE_NAME, FileMode.Open,
                FileAccess.Read, FileShare.Read);
            // Create an instance of StreamReader that can read
            // characters from the FileStream.
            using (StreamReader sr = new StreamReader(fsIn))
            {
                string input;
                // While not at the end of the file, read lines from the file.
                while (sr.Peek() > -1)
                {
                    input = sr.ReadLine();
                    var bytes = Encoding.UTF8.GetBytes(input);
                    Console.WriteLine(bytes[0].ToString("X2"));
                    Console.WriteLine(input);
                    Console.WriteLine("==================" + sr.Peek());
                    Thread.Sleep(1000);
                }
            }
        }
    }
}