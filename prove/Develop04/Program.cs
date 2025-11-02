using System;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

class Program
{
    public static string ActivityName(int option, string activity)
    {
        return $"\t{option}. Start {activity} activity: ";
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Menu Options:");
        int action;

        do
        {
            Console.WriteLine(ActivityName(1, "breathing"));
            Console.WriteLine(ActivityName(2, "reflecting"));
            Console.WriteLine(ActivityName(3, "listing"));
            Console.WriteLine("\t4. Quit");
            Console.Write("Select a choice from the menu: ");
            action = int.Parse(Console.ReadLine());

        } while (action != 4);
        {
            
        }


    }


}