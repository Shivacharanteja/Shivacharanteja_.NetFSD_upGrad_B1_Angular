namespace C_Assignment1
{
    internal class exercise1
    {
        static void Main(string[] args)
        {
            Console.Write("Enter first number: ");
            double num1 = double.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            double num2 = double.Parse(Console.ReadLine());

            if (num2 != 0)
            {
                Console.WriteLine($"The quotient is: {num1 / num2}");
            }
            else
            {
                Console.WriteLine("Error: Division by zero is not allowed.");
            }
        }
    }
}
