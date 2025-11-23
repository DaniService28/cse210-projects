public class SimpleGoal : Goal
{

    private bool _isComplete;

    public SimpleGoal(string shortName, string description, int points) : base(shortName, description, points)
    {
        _isComplete = false;
    }


    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            Console.WriteLine($"Congratulations! You earned {_points} points.");
            return _points;
        }
        else
        {
            Console.WriteLine("This goal is already completed.");
            return 0;
        }

    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringDetails()
    {
        return $"SimpleGoal,{base.GetStringDetails()},{_isComplete}";
    }

    public override string GetStringRepresentation()
    {
        if (!_isComplete)
        {
            return $"[ ] SimpleGoal: {_shortName}, {_description}";
        }
        else
        {
            return $"[X] SimpleGoal: {_shortName}, ({_description})";
        }
    }
}