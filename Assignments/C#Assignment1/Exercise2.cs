using System;
using System.Collections.Generic;
using System.Text;

namespace C_Assignment1
{
    internal class Exercise2
    {
        static void Main(string[] args)
        {
            Console.Write("Enter distance in KM: ");
            double km = double.Parse(Console.ReadLine());
            double meters = km * 1000;
            Console.WriteLine($"{km} KM is equal to {meters} Meters.");
        }
    }
}
