using System.Net;

public class Listing : Activity
{
    Random _random = new Random();

    private List<string> _reflectionQuestions = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };


    public Listing() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area")
    {
    }

    public void DisplayQuestion()
    {
        int index = _random.Next(_reflectionQuestions.Count);
        Console.WriteLine($"---{_reflectionQuestions[index]}--- ");
    }

    public int AppendResponse()
    {
        List<string> responses = new List<string> { };
        DateTime end = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < end)
        {
            Console.Write("> ");
            string response = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(response))
            {
                responses.Add(response);
            }

        }

        return responses.Count;
    }
}