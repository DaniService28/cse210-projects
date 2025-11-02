using System.Security.Principal;

public class Activity
{
    protected string _activityName;
    protected string _description;
    protected int _duration;

    public Activity(string Activity, string Description)
    {
        _activityName = Activity;
        _description = Description;
    }


    public int StartingMessage()
    {
        Console.WriteLine($"Welcome to the {_activityName} Activity\n");
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");

        
        return _duration = int.Parse(Console.ReadLine());
    }

    public void EndingMessage()
    {
        Console.WriteLine("Well done!!");
        DotsTimer(3);
        Console.WriteLine($"You have completed another {_duration} seconds of the {_activityName} Activity");
        DotsTimer(3);
    }

    public void DotsTimer(int times)
    {
        for (int i = 0; i < times; i++)
        {
            Console.Write(".");
            Thread.Sleep(400);
            Console.Write("\b \b");
            Console.Write("..");
            Thread.Sleep(400);
            Console.Write("\b\b  \b\b");
            Console.Write("...");
            Thread.Sleep(400);
            Console.Write("\b\b\b   \b\b\b");
            Thread.Sleep(400);
        }
    }

    public void counterDown(int seconds)
    {
        for (int i = seconds; i >= 0; i--)
        {
            Console.Write(seconds);
            Thread.Sleep(400);
            Console.Write("\b \b");
        }
    }


}