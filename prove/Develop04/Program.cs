using System;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

class Program
{
    public static string ActivityName(int option, string activity)
    {
        return $"\t{option}. Start {activity} activity: ";
    }

    static void Main(string[] args)
    {

        int action;
        List<string> activityLog = new List<string>();


        do
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine(ActivityName(1, "breathing"));
            Console.WriteLine(ActivityName(2, "reflecting"));
            Console.WriteLine(ActivityName(3, "listing"));
            Console.WriteLine("\t4. Quit");
            Console.Write("Select a choice from the menu: ");
            action = int.Parse(Console.ReadLine());

            if (action == 1)
            {
                Console.Clear();
                Breathing action1 = new Breathing();
                action1.StartingMessage();

                Console.Clear();
                Console.WriteLine("Get Ready!!");
                action1.DotsTimer(3);

                action1.DisplayActivity();
                action1.EndingMessage();
                activityLog.Add($"Completed breathing activity at {DateTime.Now}");

            }

            if (action == 2)
            {
                Console.Clear();
                Reflection action2 = new Reflection();
                action2.StartingMessage();

                Console.Clear();

                Console.WriteLine("Get Ready!!");
                action2.DotsTimer(3);

                Console.WriteLine("Consider the following prompt: \n");
                Console.WriteLine($"--- {action2.RandomPrompt()} ---");

                Console.WriteLine("When you have something in mind, press enter to continue.");
                while (Console.ReadKey(true).Key != ConsoleKey.Enter)
                {
                }
                Console.WriteLine("Now ponder on each of the following questions as they related to this experience");
                Console.Write($"You may begin in: ");
                action2.counterDown(5);

                Console.Clear();
                action2.randomReflections();
                action2.EndingMessage();
                activityLog.Add($"Completed reflecting activity at {DateTime.Now}");

            }

            if (action == 3)
            {
                Console.Clear();
                Listing action3 = new Listing();
                action3.StartingMessage();

                Console.Clear();
                Console.WriteLine("Get Ready!!");
                action3.DotsTimer(3);
                Console.WriteLine();

                Console.WriteLine("List as many responses as you can to the following prompt:");
                action3.DisplayQuestion();

                Console.Write($"You may begin in: ");
                action3.counterDown(5);
                Console.WriteLine();

                int itemsAdded = action3.AppendResponse();
                Console.WriteLine($"You listed {itemsAdded} items!\n");

                action3.EndingMessage();
                activityLog.Add($"Completed listing activity at {DateTime.Now}");

            }

        } while (action != 4);

        Console.Clear();
        Console.WriteLine($"You've completed {activityLog.Count} activities today. Keep it up!\n");

        Console.WriteLine("Session Summary:");
        foreach (string log in activityLog)
        {
            Console.WriteLine(log);
        }



    }


}