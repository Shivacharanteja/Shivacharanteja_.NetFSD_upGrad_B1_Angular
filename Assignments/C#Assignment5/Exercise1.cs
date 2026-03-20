using System;

class CheckBalanceException : Exception
{
    public CheckBalanceException(string message) : base(message)
    {
    }
}

class BankAccount
{
    public int AccountNumber;
    public string Name;
    public double Balance;
    public char TransactionType;
    public double TransactionAmount;

    public BankAccount(int accNo, string name, double balance)
    {
        AccountNumber = accNo;
        Name = name;
        Balance = balance;
    }

    public void Transaction(char type, double amount)
    {
        TransactionType = type;
        TransactionAmount = amount;

        if (type == 'd' || type == 'D')
        {
            Balance = Balance + amount;
            Console.WriteLine("Amount Deposited Successfully");
        }
        else if (type == 'c' || type == 'C')
        {
            if (Balance - amount < 500)
            {
                throw new CheckBalanceException("Minimum balance of 500 should be maintained!");
            }
            else
            {
                Balance = Balance - amount;
                Console.WriteLine("Withdrawal Successful");
            }
        }
    }

    public void Display()
    {
        Console.WriteLine("Account Number: " + AccountNumber);
        Console.WriteLine("Account Holder: " + Name);
        Console.WriteLine("Balance: " + Balance);
    }
}

class Exercise1
{
    static void Main()
    {
        try
        {
            BankAccount b = new BankAccount(101, "Shiva", 1000);

            Console.WriteLine("Enter Transaction Type (d/c):");
            char type = Convert.ToChar(Console.ReadLine());

            Console.WriteLine("Enter Transaction Amount:");
            double amt = Convert.ToDouble(Console.ReadLine());

            b.Transaction(type, amt);
            b.Display();
        }
        catch (CheckBalanceException e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
    }
}
