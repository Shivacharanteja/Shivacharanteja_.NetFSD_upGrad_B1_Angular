using System;
using System.Collections.Generic;
using System.Text;

namespace C_Assignment1
{
    internal class Exercise7
    {
        static void Main(string[] args)
        {
            Console.Write("Enter distance: ");
            double dist = double.Parse(Console.ReadLine());
            Console.Write("Enter speed: ");
            double speed = double.Parse(Console.ReadLine());
            if (speed > 0)
            {
                double time = dist / speed;
                Console.WriteLine($"Time taken for the journey: {time} hours.");
            }
            else
            {
                Console.WriteLine("Speed must be greater than zero.");
            }
        }
    }
}
