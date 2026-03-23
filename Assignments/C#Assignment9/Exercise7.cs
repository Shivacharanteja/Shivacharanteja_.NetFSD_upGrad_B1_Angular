using System;
using System.Collections.Generic;
using System.Linq;

namespace C_Assignment9
{
    public record Product(int Id, string Name, string Category, double Price, int Stock);

    class Exercise7
    {
        static void Main()
        {
            var products = new List<Product>()
            {
                new Product(1,"P1","Electronics",5000,5),
                new Product(2,"P2","Electronics",10000,15),
                new Product(3,"P3","Grocery",200,0),
                new Product(4,"P4","Grocery",300,8)
            };

            // 1. Stock < 10
            var lowStock = from p in products
                           where p.Stock < 10
                           select p;

            Console.WriteLine("Low Stock:");
            foreach (var p in lowStock)
                Console.WriteLine($"{p.Name} - {p.Stock}");

            // 2. Top 3 expensive
            var top3 = (from p in products
                        orderby p.Price descending
                        select p).Take(3);

            Console.WriteLine("\nTop 3 Expensive:");
            foreach (var p in top3)
                Console.WriteLine($"{p.Name} - {p.Price}");

            // 3. Group by category
            var group = from p in products
                        group p by p.Category;

            Console.WriteLine("\nGroup by Category:");
            foreach (var g in group)
                Console.WriteLine(g.Key);

            // 4. Total stock per category
            var totalStock = from p in products
                             group p by p.Category into g
                             select new { Category = g.Key, Total = g.Sum(x => x.Stock) };

            Console.WriteLine("\nStock per Category:");
            foreach (var t in totalStock)
                Console.WriteLine($"{t.Category} - {t.Total}");

            // 5. Any out of stock
            var outOfStock = (from p in products where p.Stock == 0 select p).Any();
            Console.WriteLine($"\nAny Out of Stock: {outOfStock}");
        }
    }
}