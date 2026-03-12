using System;
using System.Collections.Generic;
using System.Text;

namespace C_Assignment2
{
    internal class Exercise18
    {
        static void Main(string[] args)
        {
            Console.Write("Enter first word: ");
            string w1 = Console.ReadLine();
            Console.Write("Enter second word: ");
            string w2 = Console.ReadLine();

            if (w1.Equals(w2, StringComparison.OrdinalIgnoreCase))
                Console.WriteLine("The words are the same.");
            else
                Console.WriteLine("The words are different.");
        }
    }
}
