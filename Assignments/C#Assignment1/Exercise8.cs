using System;
using System.Collections.Generic;
using System.Text;

namespace C_Assignment1
{
    internal class Exercise8
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a string: ");
            string input = Console.ReadLine();
            if (input.Length >= 3)
            {
                char thirdChar = char.ToLower(input[2]);
                if (char.IsLetter(thirdChar))
                {
                    if ("aeiou".Contains(thirdChar))
                    {
                        Console.WriteLine($"The third character '{input[2]}' is a Vowel.");
                    }
                    else
                    {
                        Console.WriteLine($"The third character '{input[2]}' is a Consonant.");
                    }
                }
                else
                {
                    Console.WriteLine($"The third character '{input[2]}' is not a letter.");
                }
            }
            else
            {
                Console.WriteLine("The string is too short. Please enter at least 3 characters.");
            }
        }
    }
}
