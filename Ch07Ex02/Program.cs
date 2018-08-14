using System;

namespace Ch07Ex02
{
    class Program
    {
        static void Main(string[] args)
        {
            IndexerClass test = new IndexerClass();
            test[2] = 4;
            test[5] = 32;
            for(int i=0; i<=10; i++)
            {
                Console.WriteLine($"{i} = {test[i]}");
            }
            Console.WriteLine("Hello World!");
        }
    }
    interface ISomeInterface
    {
        int this[int index] { get; set; }
    }
    class IndexerClass : ISomeInterface
    {
        private int[] arr = new int[100];
        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= 100)
                {
                    return 0;
                }
                else
                {
                    return arr[index];
                }
            }
            set
            {
                if (!(index < 0 || index >= 100))
                {
                    arr[index] = value;
                }
            }
        }
    }
}
