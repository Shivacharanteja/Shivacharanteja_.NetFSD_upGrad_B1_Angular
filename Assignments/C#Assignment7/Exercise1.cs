using System;
using System.Collections.Generic;
using System.Linq;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string Category { get; set; }
}

class Exercise1
{
    static void Main()
    {
        List<Product> products = new List<Product>();

        // 1. Add 10 products
        for (int i = 1; i <= 10; i++)
        {
            products.Add(new Product { Id = i, Name = $"Product {i}", Price = i * 200, Category = i % 2 == 0 ? "Electronics" : "Books" });
        }

        // 2. Display all
        products.ForEach(p => Console.WriteLine($"{p.Id}: {p.Name} - {p.Price} ({p.Category})"));

        // 3. Find products > 1000
        var expensive = products.FindAll(p => p.Price > 1000);

        // 4. Sort by Price Ascending
        var sorted = products.OrderBy(p => p.Price).ToList();

        // 5. Remove by Id
        products.RemoveAll(p => p.Id == 5);

        // BONUS: LINQ to filter by category
        var electronics = products.Where(p => p.Category == "Electronics");
    }
}