using System;
using System.IO;

class Exercise2
{
    static void Main()
    {
        Console.WriteLine("1. Create Report");
        Console.WriteLine("2. View Report");
        int choice = int.Parse(Console.ReadLine());

        if (choice == 1)
            CreateReport();
        else
            ReadReport();
    }

    static void CreateReport()
    {
        try
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Roll Number: ");
            string roll = Console.ReadLine();

            Console.Write("Marks 1: ");
            int m1 = int.Parse(Console.ReadLine());

            Console.Write("Marks 2: ");
            int m2 = int.Parse(Console.ReadLine());

            Console.Write("Marks 3: ");
            int m3 = int.Parse(Console.ReadLine());

            int total = m1 + m2 + m3;
            double avg = total / 3.0;

            string grade;
            if (avg >= 75) grade = "A";
            else if (avg >= 50) grade = "B";
            else if (avg >= 35) grade = "C";
            else grade = "Fail";

            string content = $"Name: {name}\nRoll Number: {roll}\nMarks: {m1}, {m2}, {m3}\nTotal: {total}\nAverage: {avg}\nGrade: {grade}";

            File.WriteAllText($"{roll}.txt", content);

            Console.WriteLine("Report saved.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void ReadReport()
    {
        try
        {
            Console.Write("Enter Roll Number: ");
            string roll = Console.ReadLine();

            string data = File.ReadAllText($"{roll}.txt");
            Console.WriteLine("\n" + data);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Report not found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}