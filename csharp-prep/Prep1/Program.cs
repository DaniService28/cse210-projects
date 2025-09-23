using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello Prep1 World!");

        // // Declare variable
        // string firstName = "Bob";
        // Console.WriteLine($"Hello {firstName}");

        // // Input lines
        // Console.Write("What's your name?");
        // string userName = Console.ReadLine();

        // // numbers
        // Console.WriteLine("How old are you?");
        // int age = int.Parse(Console.ReadLine());

        // //decimals numbers
        // double x = 5.5;

        // //float numbers
        // float y = 5.5f;

        // // booleans
        // bool isDone = false;

        // if (isDone)
        // {
        //     Console.WriteLine("All done");
        // }
        // Console.Write("What is your first name: ");
        // string first_name = Console.ReadLine();

        // Console.Write("What is your last name: ");
        // string last_name = Console.ReadLine();

        // Console.WriteLine($"Your name is {last_name}, {first_name} {last_name}");

        Console.Write("What's your grade percentage?: ");
        string userInput = Console.ReadLine();
        int grade = int.Parse(userInput);
        string letter = "";

        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        if (letter == "C" || letter == "B" || letter == "C")
        {
            Console.WriteLine($"Your grade is {letter}");
            Console.WriteLine($"Congratulations you passed the course");
        }
        else
        {
            Console.WriteLine($"Your grade is {letter}");
            Console.WriteLine($"Try harder next time");
        }
    }
}