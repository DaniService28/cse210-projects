using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    // List that stores all goals created by the user
    private List<Goal> _goals = new List<Goal>();

    // Total points accumulated by completing goals
    private int _totalPoints = 0;

    // Display current points
    public void ShowPoints()
    {
        Console.WriteLine($"You have {_totalPoints} points.");
    }

    // Create a new goal based on user input
    public void CreateGoal()
    {
        Console.Clear();
        Console.WriteLine("The types of goals are:");
        Console.WriteLine("    1. Simple Goal \n    2. Eternal Goal \n    3. Checklist Goal \n    4. Return");
        Console.Write("What kind of goal would you like to create: ");
        int typeGoal = int.Parse(Console.ReadLine());

        switch (typeGoal)
        {
            case 1:
                // Create a SimpleGoal
                SimpleGoal simpleGoal = new SimpleGoal("", "", 0);
                simpleGoal.CreateGoal();
                _goals.Add(simpleGoal);
                break;
            case 2:
                // Create an EternalGoal
                EternalGoal eternalGoal = new EternalGoal("", "", 0);
                eternalGoal.CreateGoal();
                _goals.Add(eternalGoal);
                break;
            case 3:
                // Create a ChecklistGoal
                ListGoal listGoal = new ListGoal("", "", 0, 0, 0);
                listGoal.CreateGoal();
                _goals.Add(listGoal);
                break;
            case 4:
                // Return to main menu
                break;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    }

    // List all goals with their details
    public void ListGoals()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetStringRepresentation()}");
        }
    }

    // Save all goals to a file
    public void SaveGoals(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Goal goal in _goals)
            {
                // Each goal writes its details in a format suitable for saving
                outputFile.WriteLine(goal.GetStringDetails());
            }
        }
    }

    // Load goals from a file
    public void LoadGoals(string filename)
    {
        using (StreamReader reader = new StreamReader(filename))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] parts = line.Split(',');

                string type = parts[0];
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);

                switch (type)
                {
                    case "SimpleGoal":
                        _goals.Add(new SimpleGoal(name, description, points));
                        break;
                    case "EternalGoal":
                        _goals.Add(new EternalGoal(name, description, points));
                        break;
                    case "CheckListGoal":
                        int targetCount = int.Parse(parts[4]);
                        int currentCount = int.Parse(parts[5]);
                        int bonusPoints = int.Parse(parts[6]);
                        var checklistGoal = new ListGoal(name, description, points, targetCount, bonusPoints);
                        checklistGoal.SetCurrentCount(currentCount);
                        _goals.Add(checklistGoal);
                        break;
                    default:
                        Console.WriteLine($"Unknown goal type: {type}");
                        break;
                }
            }
        }
    }

    // Record an event (mark a goal as accomplished)
    public void RecordEvent()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetStringRepresentation()}");
        }

        Console.Write("Which goal did you accomplish?: ");
        if (int.TryParse(Console.ReadLine(), out int goalNumber) && goalNumber > 0 && goalNumber <= _goals.Count)
        {
            var goal = _goals[goalNumber - 1];
            int earnedPoints = goal.RecordEvent();
            _totalPoints += earnedPoints;
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }

        Console.WriteLine($"You have {_totalPoints} points.");
    }

}