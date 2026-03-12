using System;
using System.Collections.Generic;
using System.Text;

namespace C_Assignment2
{
    internal class Exercise10
    {
        static void Main(string[] args)
        {
            int a = 0, b = 1, next = 0;
            while (a <= 40)
            {
                Console.Write(a + " ");
                next = a + b;
                a = b;
                b = next;
            }
        }
    }
}
