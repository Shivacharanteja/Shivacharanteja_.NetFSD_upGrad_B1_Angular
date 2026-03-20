using System;

abstract class Sales
{
    public abstract int MonthlySales(int dailySales);

    public int DailySales()
    {
        return 400;
    }
}

interface IYearlySales
{
    int YearlySales(int monthlySales);
}

class SalesCalculation : Sales, IYearlySales
{
    public override int MonthlySales(int dailySales)
    {
        return dailySales * 30;
    }

    public int YearlySales(int monthlySales)
    {
        return monthlySales * 12;
    }
}

class Exercise2
{
    static void Main()
    {
        SalesCalculation s = new SalesCalculation();

        int daily = s.DailySales();
        int monthly = s.MonthlySales(daily);
        int yearly = s.YearlySales(monthly);

        Console.WriteLine("Daily sales: Rs." + daily);
        Console.WriteLine("Monthly sales: Rs." + monthly);
        Console.WriteLine("Annual sales: Rs." + yearly);
    }
}
