


using System;
using System.Collections.Generic;
using System.Linq;

/*
EXCEEDING REQUIREMENTS:
- Program uses a library of scriptures instead of a single one.
- A scripture is randomly selected at runtime.
- When hiding words, only words that are NOT already hidden are selected.
- This improves memorization by preventing wasted turns.
*/

class Program
{
    static void Main(string[] args)
    {
        // Scripture library
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world that he gave his only begotten Son " +
                "that whosoever believeth in him should not perish but have everlasting life."
            ),
            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart and lean not unto thine own understanding " +
                "in all thy ways acknowledge him and he shall direct thy paths."
            ),
            new Scripture(
                new Reference("Psalm", 23, 1),
                "The Lord is my shepherd I shall not want."
            )
        };

        // Pick random scripture
        Random rand = new Random();
        Scripture scripture = scriptures[rand.Next(scriptures.Count)];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.Write("Press Enter to continue or type 'quit' to exit: ");

            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords(3);

            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                break;
            }
        }
    }
}
