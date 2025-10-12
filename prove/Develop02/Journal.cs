using System;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayJournal()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        try
        {
            string filename = file;
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                foreach (Entry entry in _entries)
                {
                    outputFile.WriteLine($"{entry._date}---{entry._promptText}---{entry._entryText}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}");
        }
    }

    public void LoadToFile(string file)
    {
        try
        {
            string filename = file;
            string[] lines = System.IO.File.ReadAllLines(filename);

            Console.WriteLine("Loading file...");

            foreach (string line in lines)
            {
                Entry entry = new Entry();
                string[] parts = line.Split("---");

                entry._date = parts[0];
                entry._promptText = parts[1];
                entry._entryText = parts[2];

                AddEntry(entry);
            }
        }

        catch (Exception ex)
        {
            Console.WriteLine($"Error loading file: {ex.Message}");
        }


    }
}