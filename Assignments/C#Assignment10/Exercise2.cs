using System;
using System.Threading;

namespace C_Assignment10
{
    class BankAccount
    {
        public int Balance = 1000;
        private readonly object lockObj = new object();

        public void Withdraw(int amount)
        {
            lock (lockObj) // critical section
            {
                if (Balance >= amount)
                {
                    Console.WriteLine($"Processing withdrawal of {amount}");
                    Thread.Sleep(100);
                    Balance -= amount;
                    Console.WriteLine($"Remaining Balance: {Balance}");
                }
                else
                {
                    Console.WriteLine("Insufficient Balance!");
                }
            }
        }
    }

    class Exercise2
    {
        static void Main()
        {
            BankAccount account = new BankAccount();

            Thread t1 = new Thread(() => account.Withdraw(700));
            Thread t2 = new Thread(() => account.Withdraw(700));
            Thread t3 = new Thread(() => account.Withdraw(700));

            t1.Start();
            t2.Start();
            t3.Start();

            t1.Join();
            t2.Join();
            t3.Join();

            Console.WriteLine($"Final Balance: {account.Balance}");
        }
    }
}
