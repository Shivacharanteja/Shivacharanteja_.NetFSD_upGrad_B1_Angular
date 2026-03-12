using System;
using System.Collections.Generic;
using System.Text;

namespace C_Assignment2
{
    internal class Exercise11
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number for the table: ");
            int tableNum = int.Parse(Console.ReadLine());

            for (int i = 1; i <= 20; i++)
            {
                Console.WriteLine($"{tableNum} x {i} = {tableNum * i}");
            }
        }
    }
}
