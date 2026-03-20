using System;

class Student
{
    public int StudentId { get; set; }
    public string Name { get; set; }
    public int Marks { get; set; }

    public virtual void CalculateGrade()
    {
        if (Marks > 50)
            Console.WriteLine(Name + " Pass");
        else
            Console.WriteLine(Name + " Fail");
    }
}

class SchoolStudent : Student
{
    public override void CalculateGrade()
    {
        if (Marks > 40)
            Console.WriteLine(Name + " Pass");
        else
            Console.WriteLine(Name + " Fail");
    }
}

class CollegeStudent : Student
{
    public override void CalculateGrade()
    {
        if (Marks > 50)
            Console.WriteLine(Name + " Pass");
        else
            Console.WriteLine(Name + " Fail");
    }
}

class OnlineStudent : Student
{
    public override void CalculateGrade()
    {
        if (Marks > 60)
            Console.WriteLine(Name + " Pass");
        else
            Console.WriteLine(Name + " Fail");
    }
}

class Exercise5
{
    static void Main()
    {
        Student[] students =
        {
            new SchoolStudent { Name="Ravi", Marks=45 },
            new CollegeStudent { Name="Asha", Marks=55 },
            new OnlineStudent { Name="Kiran", Marks=58 }
        };

        foreach (Student s in students)
        {
            s.CalculateGrade();
        }
    }
}