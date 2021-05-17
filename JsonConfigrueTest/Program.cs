using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using System;
using System.IO;

namespace JsonConfigrueTest
{
    internal class Program
    {
        private static string HIKDirectory;
        private static string StoragePath;

        private static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json")
                        .AddJsonFile($"appsettings.{Environment.MachineName}.json", true);
            var config = builder.Build();

            HIKDirectory = config["HIKMotionDetectionService:HIKDirectory"]; // 配置键
            StoragePath = config["HIKMotionDetectionService:StoragePath"]; // 配置键
            if (!Directory.Exists(HIKDirectory))
            {
                Directory.CreateDirectory(HIKDirectory);
            }

            string desFile = DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
            string fullPath = Path.Combine(StoragePath, desFile);
            using (FileStream fileStream1 = new FileStream(fullPath, FileMode.OpenOrCreate))
            {
                using BinaryWriter bw = new BinaryWriter(fileStream1);
                bw.Write(new byte[] { 255, 255, 255 });
                bw.Flush();
                bw.Close();
            }
            FileInfo fileInfo = new FileInfo(fullPath);
            var fullname = fileInfo.FullName;
            var name = fileInfo.Name;
            var length = fileInfo.Length;
            var datetime = fileInfo.CreationTime;

            Console.WriteLine();
            Console.WriteLine(HIKDirectory);
            Console.WriteLine(StoragePath);
        }
    }
}