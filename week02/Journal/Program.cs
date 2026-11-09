using System;
using System.IO;

// EXCEEDING REQUIREMENTS:
// 1. The journal is saved as a real .csv file (with a header row) that can be
//    opened in Excel. Every field is wrapped in quotes and any quotes inside
//    the text are doubled, so commas and quotation marks in an entry are
//    handled correctly when saving and loading.
// 2. Each entry also records the user's mood (rated 1-5), which helps people
//    notice patterns in how they feel over time.
// 3. The program checks that the file exists before loading, warns before
//    quitting with unsaved entries, and offers extra prompts beyond the
//    required five.

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        bool hasUnsavedChanges = false;
        string choice = "";

        Console.WriteLine("Welcome to the Journal Program!");

        while (choice != "5")
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine(prompt);
                Console.Write("> ");
                string response = Console.ReadLine();

                Console.Write("How would you rate your mood today (1-5)? ");
                string mood = Console.ReadLine();

                Entry entry = new Entry();
                entry._date = DateTime.Now.ToShortDateString();
                entry._promptText = prompt;
                entry._entryText = response;
                entry._mood = mood;

                journal.AddEntry(entry);
                hasUnsavedChanges = true;
            }
            else if (choice == "2")
            {
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();

                if (File.Exists(filename))
                {
                    journal.LoadFromFile(filename);
                    hasUnsavedChanges = false;
                    Console.WriteLine("Journal loaded.");
                }
                else
                {
                    Console.WriteLine("That file was not found.");
                }
            }
            else if (choice == "4")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                journal.SaveToFile(filename);
                hasUnsavedChanges = false;
                Console.WriteLine("Journal saved.");
            }
            else if (choice == "5")
            {
                if (hasUnsavedChanges)
                {
                    Console.Write("You have unsaved entries. Quit anyway? (y/n) ");
                    string answer = Console.ReadLine();
                    if (answer.ToLower() != "y")
                    {
                        choice = "";
                    }
                }
            }
            else
            {
                Console.WriteLine("Please choose a number from 1 to 5.");
            }
        }
    }
}