using System;
class Account
{
    public int AccountNumber { get; set; }
    public double Balance { get; set; }

    public void CalculateInterest()
    {
        Console.WriteLine("Base account interest calculation");
    }
}

class SavingsAccount : Account
{
    public new void CalculateInterest()
    {
        Console.WriteLine("Savings account interest calculation");
    }
}

class CurrentAccount : Account
{
    public new void CalculateInterest()
    {
        Console.WriteLine("Current account interest calculation");
    }
}
class Exercise2
{
    static void Main()
    {
        Account acc = new SavingsAccount();
        acc.CalculateInterest();
    }
}
