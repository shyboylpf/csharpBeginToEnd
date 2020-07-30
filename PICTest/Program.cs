using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PICTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<byte[]> vs = new List<byte[]>();
            FileStream fileStream = new FileStream("hiv00008.pic", FileMode.Open, FileAccess.Read);
            if (fileStream.Length > 0)
            {
                fileStream.Seek(64000, SeekOrigin.Begin);
            }
            using (BinaryReader reader = new BinaryReader(fileStream))
            {
                //foreach (var item in Enumerable.Range(1, 16))
                //{
                //    Console.Write(reader.ReadSByte().ToString("X2"));
                //    if (item % 2 == 0)
                //    {
                //        Console.Write(" ");
                //    }
                //}

                var bytes = reader.ReadBytes((int)fileStream.Length);
                byte[] pattern = new byte[] { 0xff, 0xd8, 0xff };
                //Console.WriteLine(bytes.Contains(a));
                //foreach (var item in PatternAt(bytes, pattern))
                //{
                //    Console.WriteLine(item);
                //}
                var indexs = PatternAt(bytes, pattern).ToList();
                indexs.Add((int)fileStream.Length + 1);
                for (int i = 0; i < indexs.Count() - 1; i++)
                {
                    var pic = bytes.Skip(indexs[i]).Take(indexs[i + 1] - indexs[i]).ToArray();
                    vs.Add(pic);
                }

                //foreach (var item in bytes)
                //{
                //    Console.Write(item.ToString("X2"));
                //}
            }

            for (int i = 0; i < vs.Count; i++)
            {
                FileStream fileStream1 = new FileStream(i + ".jpg", FileMode.OpenOrCreate);
                using (BinaryWriter bw = new BinaryWriter(fileStream1))
                {
                    bw.Write(vs[i]);
                    bw.Flush();
                    bw.Close();
                }
            }
            //using (StreamReader reader = new StreamReader(fileStream))
            //{
            //    var all = reader.ReadToEnd();
            //}
            //Console.WriteLine("Hello World!");
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
    }
}