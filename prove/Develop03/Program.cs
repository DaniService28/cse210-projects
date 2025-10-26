using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference();
        string scriptureReference = reference.GetScripture();

        Scripture scripture = new Scripture();
        scripture.ConvertTextIntoList(scriptureReference);

        Console.Write(reference.DisplayReference());
        Console.WriteLine(reference.DisplayScripture());
        string userPrompt = string.Empty;

        while (userPrompt != "quit" && !scripture.IsCompletelyHidden())
        {
            Console.WriteLine("Press enter to hide words or type 'quit' to end the program");
            userPrompt = Console.ReadLine();


            Console.Clear();

            string message = scripture.HideRandomWord();


            Console.WriteLine(message);
            Console.Write(reference.DisplayReference());
            scripture.GetDisplayText();
            Console.WriteLine(scripture.GetProgressPercentage());


            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine("The scripture is completely hidden. Exiting the program.");
            }
            else if (userPrompt == "quit")
            {
                Console.Clear();
                Console.WriteLine("Exiting the program.");
            }
        }


    }
}