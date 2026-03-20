using System;
using System.Collections.Generic;
using System.Text;

namespace C_Assignment7
{
    internal class Exercise3
    {
        static void Main()
        {
            HashSet<string> emails = new HashSet<string>()
        {
            "a@mail.com",
            "b@mail.com",
            "c@mail.com",
            "a@mail.com",
            "d@mail.com",
            "e@mail.com"
        };

            Console.WriteLine("Unique Emails:");
            foreach (var e in emails)
                Console.WriteLine(e);

            // Check
            Console.WriteLine(emails.Contains("b@mail.com"));

            // Remove
            emails.Remove("c@mail.com");

            // Bonus: Common participants
            HashSet<string> event2 = new HashSet<string>() { "a@mail.com", "x@mail.com" };

            event2.IntersectWith(emails);

            Console.WriteLine("Common Participants:");
            foreach (var e in event2)
                Console.WriteLine(e);
        }
    }
}