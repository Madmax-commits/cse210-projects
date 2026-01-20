using System;

/*
 * JOURNAL APPLICATION
 * 
 * CORE FEATURES IMPLEMENTED:
 * - Write new journal entries with random prompts
 * - Display all entries in the journal
 * - Save journal to file
 * - Load journal from file
 * - Menu-driven interface
 * 
 * ABSTRACTION PRINCIPLE DEMONSTRATED:
 * The program demonstrates abstraction through proper use of member variables and methods:
 * 
 * Entry Class:
 *   - Private fields (_prompt, _response, _date) hide internal data representation
 *   - Public getter methods (GetPrompt, GetResponse, GetDate) provide controlled access
 *   - ToFileFormat/FromFileFormat methods hide serialization logic from callers
 *   - ToString() method abstracts display formatting
 * 
 * Journal Class:
 *   - Private _entries list and _prompts list hide collection details
 *   - Public methods (AddEntry, DisplayAll, GetRandomPrompt) provide clean interface
 *   - SaveToFile/LoadFromFile methods encapsulate file I/O complexity
 *   - Program class doesn't need to know how Journal stores or formats data
 * 
 * Program Class:
 *   - Works only with Journal's public interface
 *   - Doesn't know or care about internal implementation details
 *   - Menu logic is separated from Entry/Journal business logic
 * 
 * REQUIREMENTS EXCEEDED:
 * 1. Prompt Variety: 8 thoughtful prompts instead of minimum 5
 *    - "Who was the most interesting person I interacted with today?"
 *    - "What was the best part of my day?"
 *    - "How did I see the hand of the Lord in my life today?"
 *    - "What was the strongest emotion I felt today?"
 *    - "If I had one thing I could do over today, what would it be?"
 *    - "What am I grateful for today?" (Extra)
 *    - "What did I learn today?" (Extra)
 *    - "How did I help someone today?" (Extra)
 * 
 * 2. Automatic Date Recording: Uses DateTime.Now to automatically capture date
 *    (requirement only asked to store date as string, not to auto-populate)
 * 
 * 3. Robust Error Handling: Try-catch blocks in SaveToFile and LoadFromFile
 *    to gracefully handle file I/O exceptions
 * 
 * 4. Smart File Format: Uses ~|~ separator unlikely to appear in journal content
 *    (requirement only required "some symbol", this exceeds by choosing thoughtfully)
 * 
 * 5. User Experience: Default filename suggestion and input validation
 *    to make the application more user-friendly
 */

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool running = true;

        while (running)
        {
            DisplayMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry(journal);
                    break;
                case "2":
                    journal.DisplayAll();
                    break;
                case "3":
                    SaveJournal(journal);
                    break;
                case "4":
                    LoadJournal(journal);
                    break;
                case "5":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("\n========== Journal Menu ==========");
        Console.WriteLine("1. Write New Entry");
        Console.WriteLine("2. Display Journal");
        Console.WriteLine("3. Save Journal to File");
        Console.WriteLine("4. Load Journal from File");
        Console.WriteLine("5. Exit");
        Console.WriteLine("==================================");
        Console.Write("Please select an option (1-5): ");
    }

    static void WriteNewEntry(Journal journal)
    {
        string prompt = journal.GetRandomPrompt();
        Console.WriteLine($"\nPrompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        string date = DateTime.Now.ToString("yyyy-MM-dd");
        Entry entry = new Entry(prompt, response, date);
        journal.AddEntry(entry);

        Console.WriteLine("Entry added successfully!");
    }

    static void SaveJournal(Journal journal)
    {
        Console.Write("\nEnter filename to save (or press Enter for 'journal.txt'): ");
        string filename = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(filename))
        {
            filename = "journal.txt";
        }
        journal.SaveToFile(filename);
    }

    static void LoadJournal(Journal journal)
    {
        Console.Write("\nEnter filename to load: ");
        string filename = Console.ReadLine();
        journal.LoadFromFile(filename);
    }
}