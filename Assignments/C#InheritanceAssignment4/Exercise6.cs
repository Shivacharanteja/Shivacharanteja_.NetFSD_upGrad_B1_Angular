using System;

class Furniture
{
    public int OrderId;
    public string OrderDate;
    public string FurnitureType;
    public int Qty;
    public double TotalAmt;
    public string PaymentMode;

    public virtual void GetData()
    {
        Console.WriteLine("Enter Order Id");
        OrderId = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Order Date");
        OrderDate = Console.ReadLine();

        Console.WriteLine("Enter Quantity");
        Qty = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Payment Mode");
        PaymentMode = Console.ReadLine();
    }

    public virtual void ShowData()
    {
        Console.WriteLine("Order Id: " + OrderId);
        Console.WriteLine("Order Date: " + OrderDate);
        Console.WriteLine("Quantity: " + Qty);
        Console.WriteLine("Payment Mode: " + PaymentMode);
    }
}

class Chair : Furniture
{
    public string ChairType;
    public string Purpose;
    public string ColorOrWoodType;
    public double Rate;

    public override void GetData()
    {
        base.GetData();

        Console.WriteLine("Enter Chair Type (Wood/Steel/Plastic)");
        ChairType = Console.ReadLine();

        Console.WriteLine("Enter Purpose (Home/Office)");
        Purpose = Console.ReadLine();

        Console.WriteLine("Enter Wood/Steel/Color Type");
        ColorOrWoodType = Console.ReadLine();

        Console.WriteLine("Enter Rate");
        Rate = Convert.ToDouble(Console.ReadLine());
    }

    public override void ShowData()
    {
        base.ShowData();

        Console.WriteLine("Chair Type: " + ChairType);
        Console.WriteLine("Purpose: " + Purpose);
        Console.WriteLine("Material Type: " + ColorOrWoodType);
        Console.WriteLine("Rate: " + Rate);
    }
}

class Cot : Furniture
{
    public string CotType;
    public string Capacity;
    public double Rate;

    public override void GetData()
    {
        base.GetData();

        Console.WriteLine("Enter Cot Type (Wood/Steel)");
        CotType = Console.ReadLine();

        Console.WriteLine("Enter Capacity (Single/Double)");
        Capacity = Console.ReadLine();

        Console.WriteLine("Enter Rate");
        Rate = Convert.ToDouble(Console.ReadLine());
    }

    public override void ShowData()
    {
        base.ShowData();

        Console.WriteLine("Cot Type: " + CotType);
        Console.WriteLine("Capacity: " + Capacity);
        Console.WriteLine("Rate: " + Rate);
    }
}
class Exercise6
{
    static void Main()
    {
        Chair c = new Chair();
        c.GetData();
        c.ShowData();
    }
}
