using System;

namespace C_Assignment2
{
    internal class Exercise2
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                Console.WriteLine($"Hi! {args[0]}");
                Console.WriteLine("Welcome to the world of C#");
            }
            else
            {
                Console.WriteLine("Please provide a username as a command line argument.");
                Console.WriteLine("Usage: dotnet run <YourName>");
            }
        }
    }
}
