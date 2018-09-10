﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 获取变量的地址
{
    class Program
    {
        static void Main()
        {
            int number;

            unsafe
            {
                // Assign the address of number to a pointer:
                int* p = &number;

                // Commenting the following statement will remove the
                // initialization of number.
                *p = 0xffff;

                // Print the value of *p:
                System.Console.WriteLine("Value at the location pointed to by p: {0:X}", *p);

                // Print the address stored in p:
                System.Console.WriteLine("The address stored in p: {0}", (int)p);
            }

            // Print the value of the variable number:
            System.Console.WriteLine("Value of the variable number: {0:X}", number);

            System.Console.ReadKey();
        }
    }
}
