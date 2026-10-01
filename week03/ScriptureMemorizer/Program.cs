using System;
using System.Collections.Generic;

// Creativity / exceeding requirements:
// - Words are only hidden once (a word already hidden is not selected again),
//   so every press of enter reliably hides new words instead of wasting the
//   attempt on already-hidden words.
// - The program works with a small library of scriptures instead of a single
//   hard-coded one. A random scripture is chosen from the library each time
//   the program runs, so the user gets a different verse to memorize on
//   each run.

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> library = new List<Scripture>
        {
            new Scripture(new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all your heart and lean not on your own understanding."),
            new Scripture(new Reference("John", 3, 16),
                "For God so loved the world that he gave his only begotten Son."),
            new Scripture(new Reference("Philippians", 4, 13),
                "I can do all things through Christ which strengtheneth me."),
            new Scripture(new Reference("Joshua", 1, 9),
                "Be strong and of a good courage, be not afraid, for the Lord thy God is with thee wherever thou goest.")
        };

        Random random = new Random();
        Scripture scripture = library[random.Next(library.Count)];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            if (scripture.IsCompletelyHidden())
            {
                break;
            }

            Console.WriteLine("\nPress enter to continue or type 'quit' to end.");
            string input = Console.ReadLine();

            if (input != null && input.Trim().ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
        }
    }
}
