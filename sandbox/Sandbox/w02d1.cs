// using System;

// class Program
// {
//     static void Main(string[] args)
//     {
//         //foreach
//         List<string> fruits = new List<string>() { "Apples", "Banana", "Cherry" };
//         foreach (string fruit in fruits)
//         {
//             Console.WriteLine(fruit);
//         }

//         //for loops
//         for (int i = 0; i <= 10; i++)
//         {
//             Console.WriteLine($"i: {i}");
//         }

//         // while loop
//         Console.Write("Make a choice (y or n): ");
//         string value = Console.ReadLine().ToUpper();

//         while (value != "Y" && value != "N")
//         {
//             Console.WriteLine("Chose y or n");
//             value = Console.ReadLine().ToUpper();
//         }

//         // do while loop
//         do
//         {
//             Console.Write("Enter y or n");
//             Console.ReadLine().ToUpper();

//         } while (value != "Y" && value != "N");
//     }
// }