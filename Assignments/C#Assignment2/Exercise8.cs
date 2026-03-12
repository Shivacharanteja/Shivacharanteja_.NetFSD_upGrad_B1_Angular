using System;
using System.Collections.Generic;
using System.Text;

namespace C_Assignment2
{
    internal class Exercise8
    {
        static void Main(string[] args)
        {
            for (int i = 0; i <= 25; i++)
            {
                Console.Write((i * i) + (i == 25 ? "" : ", "));
            }
        }
    }
}
