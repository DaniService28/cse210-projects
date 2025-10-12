using System;

public class PromptGenerator
{
    public List<string> prompts = new List<string>
    {
        "Who was the most interesting person you interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    public Random _random = new Random();

    public string GetPrompt()
    {
        int index = _random.Next(prompts.Count);
        return prompts[index];
    }
}