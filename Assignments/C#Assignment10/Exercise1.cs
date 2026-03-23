using System;
using System.Collections.Generic;
using System.Threading;

namespace C_Assignment10
{
    class Exercise1
    {
        static int[] partialSums = new int[5];

        static void Main()
        {
            // 1. Numbers 1 to 50
            List<int> numbers = new List<int>();
            for (int i = 1; i <= 50; i++)
                numbers.Add(i);

            // 2. Split into 5 parts (each 10 numbers)
            List<List<int>> parts = new List<List<int>>();

            for (int i = 0; i < 5; i++)
            {
                parts.Add(numbers.GetRange(i * 10, 10));
            }

            Thread[] threads = new Thread[5];

            // 3. Create threads
            for (int i = 0; i < 5; i++)
            {
                int index = i; // avoid closure issue

                threads[i] = new Thread(() =>
                {
                    int sum = 0;

                    Console.WriteLine($"\nThread {index + 1} processing:");

                    foreach (var num in parts[index])
                    {
                        Console.Write(num + " ");
                        sum += num;
                    }

                    partialSums[index] = sum;
                    Console.WriteLine($"\nThread {index + 1} Sum: {sum}");
                });

                threads[i].Start();
            }

            // Wait for all threads
            foreach (var t in threads)
                t.Join();

            // Final sum
            int finalSum = 0;
            foreach (var s in partialSums)
                finalSum += s;

            Console.WriteLine($"\nFinal Sum: {finalSum}");
        }
    }
}
