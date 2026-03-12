using System;
using System.Collections.Generic;
using System.Text;

namespace C_Assignment2
{
    internal class Exercise14
    {
        static void Main(string[] args)
        {
            int[] nums = new int[5];
            Console.WriteLine("Enter five numbers:");
            for (int i = 0; i < 5; i++)
            {
                nums[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine($"The smallest number is: {nums.Min()}");
        }
    }
}
