public class Breathing : Activity
{
    public Breathing() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus your breathing.")
    {
    }

    public void DisplayActivity()
    {
        for (int i = 0; i < _duration; i += 10)
        {
            Console.Write("Breathe in...");
            base.counterDown(4);
            Console.WriteLine();

            Console.Write("Breathe out...");
            base.counterDown(6);
            Console.WriteLine("\n");
        }
    }

}