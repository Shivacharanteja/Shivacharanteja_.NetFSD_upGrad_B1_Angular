using System;
using System.IO;
using System.Collections.Generic;

class Exercise1
{
    static string filePath = "employee_log.txt";

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n1. Add Login Entry");
            Console.WriteLine("2. Update Logout Time");
            Console.WriteLine("3. Exit");
            Console.Write("Enter choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddLogin();
                    break;
                case 2:
                    UpdateLogout();
                    break;
                case 3:
                    return;
            }
        }
    }

    static void AddLogin()
    {
        try
        {
            Console.Write("Employee ID: ");
            string id = Console.ReadLine();

            Console.Write("Name: ");
            string name = Console.ReadLine();

            string loginTime = DateTime.Now.ToString();

            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine($"{id}|{name}|{loginTime}|");
            }

            Console.WriteLine("Login recorded.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void UpdateLogout()
    {
        try
        {
            Console.Write("Enter Employee ID: ");
            string id = Console.ReadLine();

            string[] lines = File.ReadAllLines(filePath);
            List<string> updatedLines = new List<string>();

            foreach (string line in lines)
            {
                string[] parts = line.Split('|');

                if (parts[0] == id && parts[3] == "")
                {
                    parts[3] = DateTime.Now.ToString();
                }

                updatedLines.Add(string.Join("|", parts));
            }

            File.WriteAllLines(filePath, updatedLines);
            Console.WriteLine("Logout updated.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
