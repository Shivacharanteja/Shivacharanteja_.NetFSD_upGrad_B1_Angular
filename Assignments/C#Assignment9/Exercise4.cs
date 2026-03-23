using System;
using System.Collections.Generic;
using System.Linq;

namespace C_Assignment9
{
    public record Employee(int Id, string Name, string Department, double Salary);

    class Exercise4
    {
        static void Main()
        {
            var employees = new List<Employee>()
            {
                new Employee(1,"A","IT",50000),
                new Employee(2,"B","HR",40000),
                new Employee(3,"C","IT",70000)
            };

            // 1. IT
            var it = from e in employees where e.Department == "IT" select e;

            Console.WriteLine("IT Employees:");
            foreach (var e in it) Console.WriteLine(e.Name);

            // 2. Highest
            var highest = (from e in employees orderby e.Salary descending select e).First();
            Console.WriteLine($"\nHighest Salary: {highest.Name}");

            // 3. Avg
            var avg = (from e in employees select e.Salary).Average();
            Console.WriteLine($"Average Salary: {avg}");

            // 4 & 5 Group + Count
            var group = from e in employees
                        group e by e.Department into g
                        select new { Dept = g.Key, Count = g.Count() };

            Console.WriteLine("\nDept Count:");
            foreach (var g in group)
                Console.WriteLine($"{g.Dept} - {g.Count}");
        }
    }
}
