using System;

class Billing
{
    public string PatientName;
    public double ConsultationFee;
    public double TestCharges;

    public double CalculateTotalBill()
    {
        return ConsultationFee + TestCharges;
    }
}

class Exercise6
{
    static void Main()
    {
        Billing bill = new Billing();

        bill.PatientName = "Ramesh";
        bill.ConsultationFee = 1000;
        bill.TestCharges = 500;

        Console.WriteLine("Patient Name: " + bill.PatientName);
        Console.WriteLine("Total Bill: " + bill.CalculateTotalBill());
    }
}