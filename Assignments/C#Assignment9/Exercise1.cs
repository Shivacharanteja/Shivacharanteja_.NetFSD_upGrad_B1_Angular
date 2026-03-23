using System;
using System.Collections.Generic;
using System.Linq;

namespace C_Assignment9
{
    public record Student(int Id, string Name, int Age, int Marks);

    class Exercise1
    {
        static void Main()
        {
            var students = new List<Student>()
            {
                new Student(1,"Ram",20,80),
                new Student(2,"Laxman",17,70),
                new Student(3,"Hanuman",22,90),
                new Student(4,"Bharat",25,60)
            };

            // 1. Marks > 75
            var highMarks = from s in students
                            where s.Marks > 75
                            select s;

            Console.WriteLine("Marks > 75:");
            foreach (var s in highMarks)
                Console.WriteLine($"{s.Name} - {s.Marks}");

            // 2. Age 18–25
            var ageRange = from s in students
                           where s.Age >= 18 && s.Age <= 25
                           select s;

            Console.WriteLine("\nAge 18–25:");
            foreach (var s in ageRange)
                Console.WriteLine($"{s.Name} - {s.Age}");

            // 3. Sort by Marks Desc
            var sorted = from s in students
                         orderby s.Marks descending
                         select s;

            Console.WriteLine("\nSorted by Marks Desc:");
            foreach (var s in sorted)
                Console.WriteLine($"{s.Name} - {s.Marks}");

            // 4. Name & Marks
            var projection = from s in students
                             select new { s.Name, s.Marks };

            Console.WriteLine("\nName & Marks:");
            foreach (var s in projection)
                Console.WriteLine($"{s.Name} - {s.Marks}");
        }
    }
}