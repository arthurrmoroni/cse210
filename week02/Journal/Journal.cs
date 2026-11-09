using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

// Responsibility: keep the list of entries, display them, and save/load them to a file.
public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("The journal is empty.\n");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    // Saves as a real CSV file that can be opened in Excel.
    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine("Date,Prompt,Entry,Mood");

            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(
                    $"{ToCsvField(entry._date)},{ToCsvField(entry._promptText)}," +
                    $"{ToCsvField(entry._entryText)},{ToCsvField(entry._mood)}");
            }
        }
    }

    // Loads a CSV file and replaces the current entries.
    public void LoadFromFile(string filename)
    {
        string[] lines = File.ReadAllLines(filename);
        _entries.Clear();

        // Skip the header line (index 0)
        for (int i = 1; i < lines.Length; i++)
        {
            if (lines[i].Trim() == "")
            {
                continue;
            }

            List<string> parts = ParseCsvLine(lines[i]);

            Entry entry = new Entry();
            entry._date = parts[0];
            entry._promptText = parts[1];
            entry._entryText = parts[2];
            entry._mood = parts.Count > 3 ? parts[3] : "";

            _entries.Add(entry);
        }
    }

    // Wraps a value in quotes and doubles any quotes inside it,
    // so commas and quotes in the text don't break the file.
    private string ToCsvField(string value)
    {
        return "\"" + value.Replace("\"", "\"\"") + "\"";
    }

    // Splits one CSV line into fields, respecting quoted text.
    private List<string> ParseCsvLine(string line)
    {
        List<string> fields = new List<string>();
        StringBuilder current = new StringBuilder();
        bool insideQuotes = false;

        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];

            if (insideQuotes)
            {
                if (c == '"' && i + 1 < line.Length && line[i + 1] == '"')
                {
                    current.Append('"');
                    i++;
                }
                else if (c == '"')
                {
                    insideQuotes = false;
                }
                else
                {
                    current.Append(c);
                }
            }
            else
            {
                if (c == '"')
                {
                    insideQuotes = true;
                }
                else if (c == ',')
                {
                    fields.Add(current.ToString());
                    current.Clear();
                }
                else
                {
                    current.Append(c);
                }
            }
        }

        fields.Add(current.ToString());
        return fields;
    }
}