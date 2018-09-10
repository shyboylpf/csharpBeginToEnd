using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fixed_语句
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        unsafe private static void ModifyFixedStorage()
        {
            Point pt = new Point();
            fixed(int* p = &pt.x)
            {
                *p = 1;
            }
        }
    }
    class Point
    {
        public int x;
        public int y;
    }

}
