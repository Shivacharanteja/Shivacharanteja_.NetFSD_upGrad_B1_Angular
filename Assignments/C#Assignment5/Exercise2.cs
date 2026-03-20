using System;

class TicketException : Exception
{
    public TicketException(string message) : base(message)
    {
    }
}

class TicketBooking
{
    int availableTickets = 15;

    public void BookTickets(int tickets)
    {
        if (tickets > availableTickets)
        {
            throw new TicketException("Tickets not available!");
        }
        else
        {
            availableTickets = availableTickets - tickets;
            Console.WriteLine("Tickets booked successfully");
            Console.WriteLine("Remaining Tickets: " + availableTickets);
        }
    }
}

class Exercise2
{
    static void Main()
    {
        TicketBooking tb = new TicketBooking();

        try
        {
            Console.WriteLine("Do you want to book tickets? (yes/no)");
            string choice = Console.ReadLine();

            if (choice.ToLower() == "yes")
            {
                Console.WriteLine("Enter number of tickets:");
                int tickets = Convert.ToInt32(Console.ReadLine());

                tb.BookTickets(tickets);
            }
            else
            {
                Console.WriteLine("Thank you!");
            }
        }
        catch (TicketException e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
    }
}
