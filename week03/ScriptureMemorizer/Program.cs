using System;

// Creativity / exceeding requirements:
// - Words are only hidden once (a word already hidden is not selected again),
//   so every press of enter reliably hides new words instead of wasting the
//   attempt on already-hidden words.
// - The scripture reference correctly displays either a single verse
//   ("John 3:16") or a verse range ("Proverbs 3:5-6") depending on which
//   Reference constructor was used.

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        Scripture scripture = new Scripture(reference,
            "Trust in the Lord with all your heart and lean not on your own understanding.");

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
