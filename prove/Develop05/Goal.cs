public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    public int _points;

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public virtual void CreateGoal()
    {
        Console.Write("What is the name of your goal? ");
        _shortName = Console.ReadLine();
        Console.Write("What is a short description of your goal?: ");
        _description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        _points = int.Parse(Console.ReadLine());
    }

    public abstract int RecordEvent();

    public abstract bool IsComplete();
    public abstract string GetStringRepresentation();

    public virtual string GetStringDetails()
    {
        return $"{_shortName},{_description},{_points}";
    }
}