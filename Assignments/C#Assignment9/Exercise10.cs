using System;
using System.Collections.Generic;
using System.Linq;

namespace C_Assignment9
{
    public record Employee1(int Id, string Name, string Department, double Salary);

    class Exercise10
    {
        static void Main()
        {
            var employees = new List<Employee1>()
            {
                new Employee1(1,"A","IT",50000),
                new Employee1(2,"B","HR",40000),
                new Employee1(3,"C","IT",70000)
            };

            var result = from e in employees
                         orderby e.Department, e.Salary descending
                         select e;

            foreach (var e in result)
                Console.WriteLine($"{e.Department} - {e.Salary}");
        }
    }
}