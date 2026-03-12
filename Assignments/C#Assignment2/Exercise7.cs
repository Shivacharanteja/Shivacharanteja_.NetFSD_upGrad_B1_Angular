using System;
using System.Collections.Generic;
using System.Text;

namespace C_Assignment2
{
    internal class Exercise7
    {
        static void Main(string[] args)
        {
            double total = 0;
            while (true)
            {
                Console.Write("Enter Product Number (1, 2, 3 or 0 to exit): ");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 0) break;
                Console.Write("Enter quantity sold: ");
                int qty = int.Parse(Console.ReadLine());
                if (choice == 1) total += 22.5 * qty;
                else if (choice == 2) total += 44.50 * qty;
                else if (choice == 3) total += 9.98 * qty;
            }
            Console.WriteLine($"Total Price: {total}");
        }
    }
}
