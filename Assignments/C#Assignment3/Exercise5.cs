using System;

class MedicalTest
{
    public int TestId;
    public string TestName;
    public double TestCost;

    public MedicalTest(int id, string name, double cost)
    {
        TestId = id;
        TestName = name;
        TestCost = cost;
    }
}

class Exercise5
{
    static void Main()
    {
        MedicalTest t1 = new MedicalTest(1, "Blood Test", 500);
        MedicalTest t2 = new MedicalTest(2, "X-Ray", 1200);

        Console.WriteLine(t1.TestName + " Cost: " + t1.TestCost);
        Console.WriteLine(t2.TestName + " Cost: " + t2.TestCost);
    }
}
