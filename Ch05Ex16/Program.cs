using System;

namespace Ch05Ex16
{
    class Program
    {
        static void Main(string[] args)
        {
            SmapleCollection<string> stringCollection = new SmapleCollection<string>();
            stringCollection[0] = "HelloWorld";
            Console.WriteLine(stringCollection[0]);
            Console.WriteLine("Hello World!");
        }
    }

    class SmapleCollection<T>
    {
        private T[] arr = new T[100]; // 私有数组
        public T this[int i]
        {
            get { return arr[i]; }
            set { arr[i] = value; }
        }
    }
}
