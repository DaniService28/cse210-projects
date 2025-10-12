using System;

class Program
{
    static void Main(string[] args)
    {
        Journal theJournal = new Journal();

        int userPrompt = -1;

        //Open a While loop to repeat the menu as much as the user need it.
        while (userPrompt != 5)
        {
            //Display the main menu and repeat until the user choise option #5 
            Console.WriteLine("Please select one of the following choises: \n1. Write.\n2. Display." +
            "\n3. Load.\n4. Save.\n5. Quit. \nWhat would you like to do? ");

            userPrompt = int.Parse(Console.ReadLine());

            if (userPrompt == 1)
            {
                Entry newEntry = new Entry();

                //Used theCurrentTime method to get the current time    
                DateTime theCurrentTime = DateTime.Now;
                newEntry._date = theCurrentTime.ToString("dd/MM/yyyy HH:mm");

                //Use the GetRamdonPrompt to iterate with the prompt attribute and display it to the user
                PromptGenerator prompt = new PromptGenerator();
                newEntry._promptText = prompt.GetPrompt();
                Console.WriteLine($"{newEntry._promptText}");
                Console.Write("> ");

                //Ask for an answer
                newEntry._entryText = Console.ReadLine();

                Console.WriteLine();

                //Adding entries with a method from Journal class
                theJournal.AddEntry(newEntry);
            }

            if (userPrompt == 2)
            {
                Console.WriteLine("\nYou have recently added the following:\n");
                //Display the list with all the entris.
                theJournal.DisplayJournal();
            }

            if (userPrompt == 3)
            {
                //The user has to provided a filename with ".txt"
                Console.WriteLine("What is the filename?");
                string userFile = Console.ReadLine();

                theJournal.LoadToFile(userFile);
            }

            if (userPrompt == 4)
            {
                //Ask for a filename and call the method SavetoFile.
                Console.WriteLine("What is the filename?");
                string userFile = Console.ReadLine();

                theJournal.SaveToFile(userFile);
            }
        }
    }
}