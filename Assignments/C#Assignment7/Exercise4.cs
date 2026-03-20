using System;
using System.Collections.Generic;
using System.Text;

namespace C_Assignment7
{
    internal class Exercise4
    {
        static void Main()
        {
            Stack<string> actions = new Stack<string>();

            actions.Push("Type A");
            actions.Push("Type B");
            actions.Push("Delete B");
            actions.Push("Type C");

            Console.WriteLine("Undo:");
            for (int i = 0; i < 3; i++)
                Console.WriteLine(actions.Pop());

            Console.WriteLine("Top Action: " + actions.Peek());

            // Bonus: Redo
            Stack<string> redo = new Stack<string>();
            redo.Push("Redo Type C");

            Console.WriteLine("Redo: " + redo.Pop());
        }
    }
}