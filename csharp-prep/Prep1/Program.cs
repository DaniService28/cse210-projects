using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep1 World!");

        // Declare variable
        string firstName = "Bob";
        Console.WriteLine($"Hello {firstName}");

        // Input lines
        Console.Write("What's your name?");
        string userName = Console.ReadLine();

        // numbers
        Console.WriteLine("How old are you?");
        int age = int.Parse(Console.ReadLine());

        //decimals numbers
        double x = 5.5;

        //float numbers
        float y = 5.5f;

        // booleans
        bool isDone = false;

        if (isDone)
        {
            Console.WriteLine("All done");
        }
    }
}