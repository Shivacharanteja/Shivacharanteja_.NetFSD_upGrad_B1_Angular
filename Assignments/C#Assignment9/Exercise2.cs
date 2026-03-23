using System;
using System.Collections.Generic;
using System.Linq;

namespace C_Assignment9
{
    class Exercise2
    {
        static void Main()
        {
            List<int> numbers = new() { 5, 10, 15, 20, 25, 30 };

            // 1. Even
            var evens = from n in numbers
                        where n % 2 == 0
                        select n;

            Console.WriteLine("Even Numbers:");
            foreach (var n in evens) Console.WriteLine(n);

            // 2. >15
            var greater = from n in numbers
                          where n > 15
                          select n;

            Console.WriteLine("\n>15:");
            foreach (var n in greater) Console.WriteLine(n);

            // 3. Squares
            var squares = from n in numbers
                          select n * n;

            Console.WriteLine("\nSquares:");
            foreach (var n in squares) Console.WriteLine(n);

            // 4. Count divisible by 5
            var count = (from n in numbers
                         where n % 5 == 0
                         select n).Count();

            Console.WriteLine($"\nCount divisible by 5: {count}");
        }
    }
}
