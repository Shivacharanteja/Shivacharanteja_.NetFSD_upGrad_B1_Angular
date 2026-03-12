using System;
using System.Collections.Generic;
using System.Text;

namespace C_Assignment1
{
    internal class Exercise4
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int n = int.Parse(Console.ReadLine());
            string result = (n % 2 == 0) ? "Even" : "Odd";
            Console.WriteLine($"{n} is {result}.");
        }
    }
}
