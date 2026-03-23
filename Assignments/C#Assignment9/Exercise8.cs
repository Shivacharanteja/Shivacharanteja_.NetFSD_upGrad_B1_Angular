using System;
using System.Collections.Generic;
using System.Linq;

namespace C_Assignment9
{
    public record Student1(int Id, string Name, string Class, string Subject, int Marks);

    class Exercise8
    {
        static void Main()
        {
            var students = new List<Student1>()
            {
                new Student1(1,"Ram","10","Math",80),
                new Student1(2,"Ram","10","Science",70),
                new Student1(3,"Laxman","10","Math",90),
                new Student1(4,"Bharat","9","Math",85)
            };

            var result = from s in students
                         group s by s.Class into cg
                         select new
                         {
                             Class = cg.Key,
                             Subjects = from sub in cg
                                        group sub by sub.Subject into sg
                                        select new
                                        {
                                            Subject = sg.Key,
                                            AvgMarks = sg.Average(x => x.Marks)
                                        }
                         };

            foreach (var cls in result)
            {
                Console.WriteLine($"Class: {cls.Class}");
                foreach (var sub in cls.Subjects)
                    Console.WriteLine($"{sub.Subject} - Avg: {sub.AvgMarks}");
            }
        }
    }
}