using System;

class Nurse
{
    public int NurseId { get; set; }
    public string NurseName { get; set; }
    public string Department { get; set; }
}

class Exercise7
{
    static void Main()
    {
        Nurse n = new Nurse
        {
            NurseId = 1,
            NurseName = "Anita",
            Department = "Emergency"
        };

        Console.WriteLine("Nurse Id: " + n.NurseId);
        Console.WriteLine("Name: " + n.NurseName);
        Console.WriteLine("Department: " + n.Department);
    }
}
