using System;

public class Scripture
{
    private List<Word> _words = new List<Word>();
    private Random _random = new Random();

    public void ConvertScriptureIntoList(string scripture)
    {
        foreach (string wordText in scripture.Split(" "))
        {
            _words.Add(new Word(wordText));
        }
    }

    public string HideRandomWord()
    {
        List<Word> showedWords = _words.Where(word => !word.IsHidden()).ToList();

        if (showedWords.Count > 0)
        {
            int randomIndex = _random.Next(showedWords.Count);
            showedWords[randomIndex].Hide();
            return "Word hidden";
        }

        else
        {
            return "Scripture is empty";
        }
    }

    public void GetDisplayText()
    {
        List<string> displayWords = new List<string>();

        foreach (var word in _words)
        {
            displayWords.Add(word.GetDisplayText());
        }

        Console.WriteLine(string.Join(" ", displayWords));
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }

    // Show creativity
    public string GetProgressInPercentage()
    {
        int totalWords = _words.Count;
        int hiddenWords = _words.Count(word => word.IsHidden());
        int percent = (hiddenWords * 100) / totalWords;
        return $"Progress: {percent}% hidden";
    }

}