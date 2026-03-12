using System;
using System.Collections.Generic;
using System.Text;

namespace C_Assignment1
{
    internal class Exercise5
    {
        static void Main(string[] args)
        {
            Console.Write("Enter first number: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            int b = int.Parse(Console.ReadLine());

            if (a > b) Console.WriteLine($"{a} is the highest.");
            else if (b > a) Console.WriteLine($"{b} is the highest.");
            else Console.WriteLine("Both numbers are equal.");
        }
    }
}
