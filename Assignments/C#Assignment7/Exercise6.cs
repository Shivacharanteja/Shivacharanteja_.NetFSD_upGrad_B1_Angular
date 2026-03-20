using System;
using System.Collections.Generic;
using System.Text;

namespace C_Assignment7
{
    class Song
    {
        public int Id;
        public string Title;
        public string Artist;
    }

    internal class Exercise6
    {
        static void Main()
        {
            LinkedList<Song> playlist = new LinkedList<Song>();

            var s1 = new Song { Id = 1, Title = "Song1", Artist = "A" };
            var s2 = new Song { Id = 2, Title = "Song2", Artist = "B" };
            var s3 = new Song { Id = 3, Title = "Song3", Artist = "C" };

            playlist.AddFirst(s1);
            playlist.AddLast(s2);
            var node = playlist.AddLast(s3);

            // Add in middle
            playlist.AddAfter(node, new Song { Id = 4, Title = "Song4", Artist = "D" });

            // Remove
            playlist.Remove(s2);

            Console.WriteLine("Forward:");
            foreach (var s in playlist)
                Console.WriteLine(s.Title);

            Console.WriteLine("\nBackward:");
            var current = playlist.Last;
            while (current != null)
            {
                Console.WriteLine(current.Value.Title);
                current = current.Previous;
            }

            // Find
            foreach (var s in playlist)
            {
                if (s.Title == "Song3")
                    Console.WriteLine("Found: " + s.Title);
            }
        }
    }
}
