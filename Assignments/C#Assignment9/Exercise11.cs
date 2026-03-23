using System;
using System.Collections.Generic;
using System.Linq;

namespace C_Assignment9
{
    public record Employee2(int Id, string Name, string Department, double Salary, DateTime JoiningDate);

    class Exercise11
    {
        static void Main()
        {
            var employees = new List<Employee2>()
            {
                new Employee2(1,"A","IT",50000,DateTime.Now.AddMonths(-2)),
                new Employee2(2,"B","HR",40000,DateTime.Now.AddMonths(-8)),
                new Employee2(3,"C","IT",70000,DateTime.Now.AddMonths(-1))
            };

            // 1. Total
            Console.WriteLine("Total: " + employees.Count());

            // 2. Avg per dept
            var avg = from e in employees
                      group e by e.Department into g
                      select new { Dept = g.Key, Avg = g.Average(x => x.Salary) };

            foreach (var a in avg)
                Console.WriteLine($"{a.Dept} - {a.Avg}");

            // 3. Last 6 months
            var recent = from e in employees
                         where e.JoiningDate >= DateTime.Now.AddMonths(-6)
                         select e;

            Console.WriteLine("\nRecent:");
            foreach (var r in recent)
                Console.WriteLine(r.Name);

            // 4. Highest per dept
            var highest = from e in employees
                          group e by e.Department into g
                          select g.OrderByDescending(x => x.Salary).First();

            Console.WriteLine("\nHighest per Dept:");
            foreach (var h in highest)
                Console.WriteLine($"{h.Department} - {h.Name}");

            // 5. Distribution
            Console.WriteLine($"\nMin: {employees.Min(x => x.Salary)}");
            Console.WriteLine($"Max: {employees.Max(x => x.Salary)}");
            Console.WriteLine($"Avg: {employees.Average(x => x.Salary)}");
        }
    }
}