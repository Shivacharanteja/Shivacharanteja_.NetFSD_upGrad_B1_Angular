
using System;
using System.IO;

class Exercise3
{
    static void Main()
    {
        string fileName = "";

        while (true)
        {
            Console.WriteLine("\n1. Create File");
            Console.WriteLine("2. Write to File");
            Console.WriteLine("3. Read File");
            Console.WriteLine("4. Append Text");
            Console.WriteLine("5. Delete File");
            Console.WriteLine("6. Exit");

            int choice = int.Parse(Console.ReadLine());

            try
            {
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter file name: ");
                        fileName = Console.ReadLine() + ".txt";
                        File.Create(fileName).Close();
                        Console.WriteLine("File created.");
                        break;

                    case 2:
                        using (FileStream fs = new FileStream(fileName, FileMode.Create))
                        using (StreamWriter sw = new StreamWriter(fs))
                        {
                            Console.WriteLine("Enter text (type END to stop):");
                            string line;
                            while ((line = Console.ReadLine()) != "END")
                            {
                                sw.WriteLine(line);
                            }
                        }
                        break;

                    case 3:
                        using (StreamReader sr = new StreamReader(fileName))
                        {
                            Console.WriteLine(sr.ReadToEnd());
                        }
                        break;

                    case 4:
                        using (FileStream fs = new FileStream(fileName, FileMode.Append))
                        using (StreamWriter sw = new StreamWriter(fs))
                        {
                            Console.WriteLine("Enter text to append (END to stop):");
                            string line;
                            while ((line = Console.ReadLine()) != "END")
                            {
                                sw.WriteLine(line);
                            }
                        }
                        break;

                    case 5:
                        File.Delete(fileName);
                        Console.WriteLine("File deleted.");
                        break;

                    case 6:
                        return;
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Access denied.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}