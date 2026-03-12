using System;
using System.Collections.Generic;
using System.Text;

namespace C_Assignment2
{
    internal class Exercise17
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a word to reverse: ");
            string original = Console.ReadLine();
            char[] charArray = original.ToCharArray();
            Array.Reverse(charArray);
            Console.WriteLine($"Reversed word: {new string(charArray)}");
        }
    }
}
