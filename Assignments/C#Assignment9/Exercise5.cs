using System;
using System.Collections.Generic;
using System.Linq;

namespace C_Assignment9
{
    public record Customer(int Id, string Name);
    public record Order(int Id, int CustomerId, double Amount);

    class Exercise5
    {
        static void Main()
        {
            var customers = new List<Customer>()
            {
                new Customer(1,"Ram"),
                new Customer(2,"Amit"),
                new Customer(3,"Ravi")
            };

            var orders = new List<Order>()
            {
                new Order(1,1,3000),
                new Order(2,1,2500),
                new Order(3,2,1000)
            };

            // 1. Join
            var join = from c in customers
                       join o in orders
                       on c.Id equals o.CustomerId
                       select new { c.Name, o.Amount };

            Console.WriteLine("Join Result:");
            foreach (var j in join)
                Console.WriteLine($"{j.Name} - {j.Amount}");

            // 2. Total per customer
            var total = from o in orders
                        group o by o.CustomerId into g
                        select new { CustomerId = g.Key, Total = g.Sum(x => x.Amount) };

            Console.WriteLine("\nTotal per Customer:");
            foreach (var t in total)
                Console.WriteLine($"{t.CustomerId} - {t.Total}");

            // 3. Total > 5000
            var high = from t in total
                       where t.Total > 5000
                       select t;

            Console.WriteLine("\nTotal > 5000:");
            foreach (var h in high)
                Console.WriteLine($"{h.CustomerId} - {h.Total}");

            // 4. No Orders
            var noOrders = from c in customers
                           join o in orders
                           on c.Id equals o.CustomerId into grp
                           where !grp.Any()
                           select c;

            Console.WriteLine("\nCustomers with No Orders:");
            foreach (var c in noOrders)
                Console.WriteLine(c.Name);
        }
    }
}
