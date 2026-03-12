using System;
using System.Collections.Generic;
using System.Text;

namespace C_Assignment2
{
    internal class Exercise5
    {
        static void Main(string[] args)
        {
            int oddCount = 0, evenCount = 0;
            Console.WriteLine("Enter 5 numbers:");
            for (int i = 0; i < 5; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num % 2 == 0) evenCount++;
                else oddCount++;
            }
            Console.WriteLine($"Even: {evenCount}, Odd: {oddCount}");
        }
    }
}
