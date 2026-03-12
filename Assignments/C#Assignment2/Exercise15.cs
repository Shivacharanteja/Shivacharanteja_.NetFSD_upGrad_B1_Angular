using System;
using System.Collections.Generic;
using System.Text;

namespace C_Assignment2
{
    internal class Exercise15
    {
        static void Main(string[] args)
        {
            int[] marks = new int[10];
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"Enter mark {i + 1}: ");
                marks[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine($"Total: {marks.Sum()}");
            Console.WriteLine($"Average: {marks.Average()}");
            Console.WriteLine($"Min: {marks.Min()}");
            Console.WriteLine($"Max: {marks.Max()}");
            var ascending = marks.OrderBy(x => x).ToArray();
            var descending = marks.OrderByDescending(x => x).ToArray();
            Console.WriteLine("Ascending: " + string.Join(", ", ascending));
        }
    }
}
