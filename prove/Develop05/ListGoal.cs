public class ListGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonusPoints;

    public ListGoal(string shortName, string description, int points, int target, int bonusPoints) : base(shortName, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonusPoints = bonusPoints;
    }

    public override void CreateGoal()
    {
        base.CreateGoal();
        Console.Write("How many times does this goal need to be accomplished for a bonus? ");
        _target = int.Parse(Console.ReadLine());
        Console.Write("What is the bonus for accomplishing it that many times? ");
        _bonusPoints = int.Parse(Console.ReadLine());
    }

    public override int RecordEvent()
    {
        if (_amountCompleted < _target - 1)
        {
            _amountCompleted++;
            Console.WriteLine($"Congratulations! You earned {_points} points.");
            return _points;
        }
        else if (_amountCompleted == _target - 1)
        {
            _amountCompleted++;
            Console.WriteLine($"Congratulations! You earned {_points} points.");
            Console.WriteLine($"And a bonus of {_bonusPoints}!");
            return _points + _bonusPoints;
        }
        else
        {
            Console.WriteLine("This goal is already completed.");
            return 0;
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted == _target;
    }

    public override string GetStringRepresentation()
    {
        return IsComplete() ? $"[X] {_shortName} ({_description}) -- Currently completed: {_amountCompleted}/{_target}" : $"[ ] {_shortName} ({_description}) -- Currently completed: {_amountCompleted}/{_target}";
    }

    public override string GetStringDetails()
    {
        return $"CheckListGoal, {base.GetStringDetails()}, {_target}, {_amountCompleted}, {_bonusPoints}";
    }

    public void SetCurrentCount(int count)
    {
        _amountCompleted = count;
    }
}