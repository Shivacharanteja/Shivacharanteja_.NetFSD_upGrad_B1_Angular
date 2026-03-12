using System;
using System.Collections.Generic;
using System.Text;

namespace C_Assignment2
{
    internal class Exercise13
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter three numbers:");
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            int n3 = int.Parse(Console.ReadLine());

            int max = Math.Max(n1, Math.Max(n2, n3));
            Console.WriteLine($"The largest number is: {max}");
        }
    }
}
