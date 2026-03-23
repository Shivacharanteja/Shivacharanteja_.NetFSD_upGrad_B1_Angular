using System;
using System.Collections.Generic;
using System.Linq;

namespace C_Assignment9
{
    class Exercise3
    {
        static void Main()
        {
            List<string> names = new() { "Ravi", "Kiran", "Amit", "Raj", "Anil" };

            // 1. Starts with A
            var startsWithA = from n in names
                              where n.StartsWith("A")
                              select n;

            Console.WriteLine("Starts with A:");
            foreach (var n in startsWithA) Console.WriteLine(n);

            // 2. Sort
            var sorted = from n in names
                         orderby n
                         select n;

            Console.WriteLine("\nSorted:");
            foreach (var n in sorted) Console.WriteLine(n);

            // 3. Uppercase
            var upper = from n in names
                        select n.ToUpper();

            Console.WriteLine("\nUppercase:");
            foreach (var n in upper) Console.WriteLine(n);

            // 4. Length > 4
            var longNames = from n in names
                            where n.Length > 4
                            select n;

            Console.WriteLine("\nLength > 4:");
            foreach (var n in longNames) Console.WriteLine(n);
        }
    }
}
