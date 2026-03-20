using System;

interface GovtRules
{
    double EmployeePF(double basicSalary);
    string LeaveDetails();
    double gratuityAmount(float serviceCompleted, double basicSalary);
}

class TCS : GovtRules
{
    public int EmpId { get; set; }
    public string Name { get; set; }
    public string Dept { get; set; }
    public string Desg { get; set; }
    public double BasicSalary { get; set; }

    public TCS(int id, string name, string dept, string desg, double salary)
    {
        EmpId = id;
        Name = name;
        Dept = dept;
        Desg = desg;
        BasicSalary = salary;
    }

    public double EmployeePF(double basicSalary)
    {
        double empPF = basicSalary * 0.12;
        double employerPF = basicSalary * 0.0833;
        double pension = basicSalary * 0.0367;

        Console.WriteLine("Employee PF: " + empPF);
        Console.WriteLine("Employer PF: " + employerPF);
        Console.WriteLine("Pension Fund: " + pension);

        return empPF + employerPF + pension;
    }

    public string LeaveDetails()
    {
        return "1 Casual Leave per month\n12 Sick Leave per year\n10 Privilege Leave per year";
    }

    public double gratuityAmount(float serviceCompleted, double basicSalary)
    {
        if (serviceCompleted > 20)
            return 3 * basicSalary;
        else if (serviceCompleted > 10)
            return 2 * basicSalary;
        else if (serviceCompleted > 5)
            return basicSalary;
        else
            return 0;
    }
}

class Accenture : GovtRules
{
    public int EmpId { get; set; }
    public string Name { get; set; }
    public string Dept { get; set; }
    public string Desg { get; set; }
    public double BasicSalary { get; set; }

    public Accenture(int id, string name, string dept, string desg, double salary)
    {
        EmpId = id;
        Name = name;
        Dept = dept;
        Desg = desg;
        BasicSalary = salary;
    }

    public double EmployeePF(double basicSalary)
    {
        double empPF = basicSalary * 0.12;
        double employerPF = basicSalary * 0.12;

        Console.WriteLine("Employee PF: " + empPF);
        Console.WriteLine("Employer PF: " + employerPF);

        return empPF + employerPF;
    }

    public string LeaveDetails()
    {
        return "2 Casual Leave per month\n5 Sick Leave per year\n5 Privilege Leave per year";
    }

    public double gratuityAmount(float serviceCompleted, double basicSalary)
    {
        return 0; // Not applicable
    }
}

class Exercise1
{
    static void Main()
    {
        TCS t = new TCS(101, "Shiva", "IT", "Developer", 50000);
        Console.WriteLine("---- TCS Employee ----");
        Console.WriteLine("PF Contribution:");
        t.EmployeePF(t.BasicSalary);

        Console.WriteLine("\nLeave Details:");
        Console.WriteLine(t.LeaveDetails());

        Console.WriteLine("\nGratuity Amount:");
        Console.WriteLine(t.gratuityAmount(12, t.BasicSalary));


        Accenture a = new Accenture(102, "Rahul", "HR", "Manager", 45000);
        Console.WriteLine("\n---- Accenture Employee ----");
        Console.WriteLine("PF Contribution:");
        a.EmployeePF(a.BasicSalary);

        Console.WriteLine("\nLeave Details:");
        Console.WriteLine(a.LeaveDetails());

        Console.WriteLine("\nGratuity Amount:");
        Console.WriteLine(a.gratuityAmount(8, a.BasicSalary));
    }
}