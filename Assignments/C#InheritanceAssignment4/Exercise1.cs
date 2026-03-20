using System;
class Staff
{
    public int StaffId { get; set; }
    public string Name { get; set; }
    public double BaseSalary { get; set; }

    public virtual double CalculateSalary()
    {
        return BaseSalary;
    }
}

class Doctor : Staff
{
    public double ConsultationFee { get; set; }

    public override double CalculateSalary()
    {
        return BaseSalary + ConsultationFee;
    }
}

class Nurse : Staff
{
    public double NightShiftAllowance { get; set; }

    public override double CalculateSalary()
    {
        return BaseSalary + NightShiftAllowance;
    }
}

class LabTechnician : Staff
{
    public double EquipmentAllowance { get; set; }

    public override double CalculateSalary()
    {
        return BaseSalary + EquipmentAllowance;
    }
}

class Exercise1
{
    static void Main()
    {
        Staff s1 = new Doctor { StaffId = 1, Name = "Raj", BaseSalary = 30000, ConsultationFee = 10000 };
        Staff s2 = new Nurse { StaffId = 2, Name = "Anu", BaseSalary = 20000, NightShiftAllowance = 5000 };
        Staff s3 = new LabTechnician { StaffId = 3, Name = "Sam", BaseSalary = 18000, EquipmentAllowance = 3000 };

        Staff[] staff = { s1, s2, s3 };

        foreach (var s in staff)
        {
            Console.WriteLine(s.Name + " Salary: " + s.CalculateSalary());
        }
    }
}
