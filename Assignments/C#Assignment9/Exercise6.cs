
using System;
using System.Collections.Generic;
using System.Linq;

namespace C_Assignment9
{
    class Exercise6
    {
        static void Main()
        {
            List<int> nums = new() { 1, 2, 3, 2, 4, 5, 3, 6 };

            // 1. Remove duplicates
            var distinct = (from n in nums select n).Distinct();

            Console.WriteLine("Distinct:");
            foreach (var n in distinct) Console.WriteLine(n);

            // 2. Find duplicates
            var duplicates = from n in nums
                             group n by n into g
                             where g.Count() > 1
                             select g.Key;

            Console.WriteLine("\nDuplicates:");
            foreach (var d in duplicates) Console.WriteLine(d);

            // 3. Count occurrences
            var count = from n in nums
                        group n by n into g
                        select new { Number = g.Key, Count = g.Count() };

            Console.WriteLine("\nOccurrences:");
            foreach (var c in count)
                Console.WriteLine($"{c.Number} - {c.Count}");
        }
    }
}