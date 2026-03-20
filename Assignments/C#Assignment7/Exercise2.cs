using System;
using System.Collections.Generic;
using System.Text;

namespace C_Assignment7
{
    class Student
    {
        public int Id;
        public string Name;
        public int Marks;
    }

    internal class Exercise2
    {
        static void Main()
        {
            Dictionary<int, Student> students = new Dictionary<int, Student>();

            students.Add(1, new Student { Id = 1, Name = "A", Marks = 80 });
            students.Add(2, new Student { Id = 2, Name = "B", Marks = 70 });
            students.Add(3, new Student { Id = 3, Name = "C", Marks = 90 });
            students.Add(4, new Student { Id = 4, Name = "D", Marks = 60 });
            students.Add(5, new Student { Id = 5, Name = "E", Marks = 85 });

            // Retrieve
            Console.WriteLine(students[1].Name);

            // Check existence
            Console.WriteLine(students.ContainsKey(3));

            // Update
            students[2].Marks = 75;

            // Remove
            students.Remove(4);

            // Bonus: Marks > 75
            Console.WriteLine("\nTop Students:");
            foreach (var s in students.Values)
            {
                if (s.Marks > 75)
                    Console.WriteLine(s.Name);
            }
        }
    }
}