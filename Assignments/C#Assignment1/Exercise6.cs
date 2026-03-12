using System;
using System.Collections.Generic;
using System.Text;

namespace C_Assignment1
{
    internal class Exercise6
    {
        static void Main(string[] args)
        {
            Console.Write("Enter rectangle length: ");
            double l = double.Parse(Console.ReadLine());
            Console.Write("Enter rectangle breadth: ");
            double b_rect = double.Parse(Console.ReadLine());
            Console.WriteLine($"Area of Rectangle: {l * b_rect}");

            Console.Write("Enter side of square: ");
            double s = double.Parse(Console.ReadLine());
            Console.WriteLine($"Area of Square: {s * s}");
        }
    }
}
