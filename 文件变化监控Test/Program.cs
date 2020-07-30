using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace 文件变化监控Test
{
    internal class Program
    {
        private static long fileLastPos = 0;
        private static byte[] pattern = new byte[] { 0xff, 0xd8, 0xff };

        private static void Main(string[] args)
        {
            //IFileProvider fileProvider = new PhysicalFileProvider(@"d:\tmp\vedio");
            IFileProvider fileProvider = new PhysicalFileProvider(@"e:\vedio\datadir0");
            //ChangeToken.OnChange(() => fileProvider.Watch("data.txt"), () => LoadFileAsync(fileProvider));
            var changeToken = fileProvider.Watch("*.pic");
            changeToken.RegisterChangeCallback(_ => LoadFileAsync(fileProvider), null);
            Console.ReadKey();
        }

        public static void LoadFileAsync(IFileProvider fileProvider)
        {
            IDirectoryContents items = fileProvider.GetDirectoryContents("");
            foreach (var item in items)
            {
                if (item.Length > 0 && item.Name.EndsWith("pic"))
                {
                    FileStream fileStream = new FileStream(item.PhysicalPath, FileMode.Open, FileAccess.Read);
                    byte[] bytes = null;
                    // 重置文件指针
                    if (item.Length > fileLastPos)
                    {
                        fileStream.Seek(fileLastPos, SeekOrigin.Begin);
                    }
                    //读取文件, 并修改指针
                    using (BinaryReader reader = new BinaryReader(fileStream))
                    {
                        bytes = reader.ReadBytes((int)fileStream.Length);
                        var index = IndexAt(bytes, pattern);
                        if (index != -1)
                        {
                            bytes = bytes.Skip(index).ToArray();
                        }
                        fileLastPos = fileStream.Length;
                    }
                    string desFile = DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
                    FileStream fileStream1 = new FileStream(desFile, FileMode.OpenOrCreate);
                    using (BinaryWriter bw = new BinaryWriter(fileStream1))
                    {
                        bw.Write(bytes);
                        bw.Flush();
                        bw.Close();
                    }

                    Console.WriteLine(desFile);
                }
            }
            var changeToken = fileProvider.Watch("*.pic");
            changeToken.RegisterChangeCallback(_ => LoadFileAsync(fileProvider), null);
        }

        public static IEnumerable<int> PatternAt(byte[] source, byte[] pattern)
        {
            for (int i = 0; i < source.Length; i++)
            {
                if (source.Skip(i).Take(pattern.Length).SequenceEqual(pattern))
                {
                    yield return i;
                }
            }
        }

        public static int IndexAt(byte[] source, byte[] pattern)
        {
            for (int i = 0; i < source.Length; i++)
            {
                if (source.Skip(i).Take(pattern.Length).SequenceEqual(pattern))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}