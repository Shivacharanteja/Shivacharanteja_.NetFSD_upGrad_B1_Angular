using System;

public class Vehicle
{
    public string VehicleNumber { get; set; }
    public string Brand { get; set; }

    public void StartVehicle()
    {
        Console.WriteLine("Vehicle Started");
    }
}

public class Car : Vehicle
{
    public string FuelType { get; set; }
}

public sealed class ElectricCar : Car
{
    public int BatteryCapacity { get; set; }
}

//public class ElectricCar : Car
//{
 
//}
class Exercise4
{
    static void Main(string[] args)
    {
        ElectricCar ec = new ElectricCar();

        ec.VehicleNumber = "TG21 4102";
        ec.Brand = "Tesla";
        ec.FuelType = "Electric";
        ec.BatteryCapacity = 75;

        ec.StartVehicle();

        Console.WriteLine("Vehicle Number: " + ec.VehicleNumber);
        Console.WriteLine("Brand: " + ec.Brand);
        Console.WriteLine("Fuel Type: " + ec.FuelType);
        Console.WriteLine("Battery Capacity: " + ec.BatteryCapacity + " kWh");
    }
}