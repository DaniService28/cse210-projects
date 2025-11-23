using System;

class Program
{
    static void Main(string[] args)
    {
        // Create an instance of GoalManager to handle all goal-related logic
        GoalManager manager = new GoalManager();
        int userAction;

        // Main loop: keeps showing the menu until the user chooses option 6 (Quit)
        do
        {
            Console.Clear(); 
            manager.ShowPoints(); 
            Console.WriteLine();

            Console.WriteLine("Menu Options:");
            MenuOption(1, "Create New Goal");
            MenuOption(2, "List Goals");
            MenuOption(3, "Save Goals");
            MenuOption(4, "Load Goals");
            MenuOption(5, "Record Event");
            MenuOption(6, "Quit");
            Console.Write("Select a choice from the menu: ");

            userAction = int.Parse(Console.ReadLine());

            switch (userAction)
            {
                case 1:
                    // Create a new goal
                    manager.CreateGoal();
                    break;

                case 2:
                    // List all goals
                    manager.ListGoals();
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    break;

                case 3:
                    // Save goals to a file
                    Console.Write("What is the filename for the goal file? ");
                    string saveFile = Console.ReadLine();
                    manager.SaveGoals(saveFile);
                    Console.WriteLine("Goals saved successfully.");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    break;

                case 4:
                    // Load goals from a file
                    Console.Write("What is the filename for the goal file? ");
                    string loadFile = Console.ReadLine();
                    manager.LoadGoals(loadFile);
                    Console.WriteLine("Goals loaded successfully.");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    break;

                case 5:
                    // Record an event (mark a goal as accomplished)
                    manager.RecordEvent();
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    break;

                case 6:
                    // Exit the program
                    Console.WriteLine("Thanks for using the Goal Tracker!");
                    break;

                default:
                    // Handle invalid input
                    Console.WriteLine("Invalid option. Please try again.");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    break;
            }
        }
        while (userAction != 6); // Repeat until user chooses Quit
    }

    // Helper method to display a menu option in a consistent format
    public static void MenuOption(int number, string name)
    {
        Console.WriteLine($"    {number}. {name}");
    }
}