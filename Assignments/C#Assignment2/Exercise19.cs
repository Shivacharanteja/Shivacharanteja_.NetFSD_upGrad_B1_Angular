using System;
using System.Collections.Generic;
using System.Text;

namespace C_Assignment2
{
    internal class Exercise19
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a word: ");
            string word = Console.ReadLine();
            string reversed = new string(word.Reverse().ToArray());

            if (word.Equals(reversed, StringComparison.OrdinalIgnoreCase))
                Console.WriteLine("It is a palindrome.");
            else
                Console.WriteLine("Not a palindrome.");
        }
    }
}
