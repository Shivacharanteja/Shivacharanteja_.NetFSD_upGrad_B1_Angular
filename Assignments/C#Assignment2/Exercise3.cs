using System;

namespace C_Assignment2
{
    internal class Exercise3
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Error: Please provide two numbers as arguments.");
                return;
            }
            if (int.TryParse(args[0], out int num1) && int.TryParse(args[1], out int num2))
            {
                int start = Math.Min(num1, num2);
                int end = Math.Max(num1, num2);

                Console.WriteLine($"Numbers between {start} and {end}:");
                for (int i = start + 1; i < end; i++)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Error: Please ensure both arguments are valid integers.");
            }
        }
    }
}
