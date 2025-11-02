using System.Data;

public class Reflection : Activity
{
    private Random _random = new Random();

    private List<string> _reflect = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless.",
        "Think of a time when you forgave someone even though it was hard.",
        "Think of a time when you made a sacrifice for someone else's happiness."
    };

    public Reflection() : base("Reflection", "This activity will help you reflect in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {

    }

    public string RandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }

    public void randomReflections()
    {
        DateTime end = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < end)
        {
            int index = _random.Next(_reflect.Count);
            Console.Write($"> {_reflect[index]} ");
            base.DotsTimer(2);
            Console.WriteLine();

            while (Console.ReadKey(true).Key != ConsoleKey.Enter)
            {
            }
        }
    }
}