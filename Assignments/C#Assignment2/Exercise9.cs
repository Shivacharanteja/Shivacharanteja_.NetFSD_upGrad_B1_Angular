using System;
using System.Collections.Generic;
using System.Text;

namespace C_Assignment2
{
    internal class Exercise9
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number to find factorial: ");
            int n = int.Parse(Console.ReadLine());
            long factorial = 1;

            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }
            Console.WriteLine($"Factorial of {n} is {factorial}");
        }
    }
}
