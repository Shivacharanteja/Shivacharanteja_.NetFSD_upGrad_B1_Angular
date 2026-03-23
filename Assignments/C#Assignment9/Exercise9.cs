using System;
using System.Collections.Generic;
using System.Linq;

namespace C_Assignment9
{
    public record Order1(int Id, string CustomerName, DateTime OrderDate, double TotalAmount);

    class Exercise9
    {
        static void Main()
        {
            var orders = new List<Order1>()
            {
                new Order1(1,"Ram",DateTime.Now.AddDays(-10),2000),
                new Order1(2,"Ram",DateTime.Now.AddDays(-5),4000),
                new Order1(3,"Amit",DateTime.Now.AddDays(-40),5000)
            };

            // 1. Last 30 days
            var recent = from o in orders
                         where o.OrderDate >= DateTime.Now.AddDays(-30)
                         select o;

            Console.WriteLine("Last 30 Days:");
            foreach (var o in recent)
                Console.WriteLine(o.CustomerName);

            // 2. Monthly sales
            var monthly = from o in orders
                          group o by new { o.OrderDate.Year, o.OrderDate.Month } into g
                          select new { g.Key, Total = g.Sum(x => x.TotalAmount) };

            Console.WriteLine("\nMonthly:");
            foreach (var m in monthly)
                Console.WriteLine($"{m.Key.Month} - {m.Total}");

            // 3. Top customers
            var top = (from o in orders
                       group o by o.CustomerName into g
                       orderby g.Sum(x => x.TotalAmount) descending
                       select new { Name = g.Key, Total = g.Sum(x => x.TotalAmount) }).Take(5);

            Console.WriteLine("\nTop Customers:");
            foreach (var t in top)
                Console.WriteLine($"{t.Name} - {t.Total}");

            // 4. Highest per month
            var highest = from o in orders
                          group o by new { o.OrderDate.Year, o.OrderDate.Month } into g
                          select g.OrderByDescending(x => x.TotalAmount).First();

            Console.WriteLine("\nHighest per Month:");
            foreach (var h in highest)
                Console.WriteLine($"{h.CustomerName} - {h.TotalAmount}");
        }
    }
}