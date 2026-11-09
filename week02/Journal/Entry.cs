using System;

// Responsibility: hold and display one journal entry.
public class Entry
{
    public string _date = "";
    public string _promptText = "";
    public string _entryText = "";
    public string _mood = "";

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_promptText}");
        Console.WriteLine(_entryText);
        if (_mood != "")
        {
            Console.WriteLine($"Mood: {_mood}");
        }
        Console.WriteLine();
    }
}
