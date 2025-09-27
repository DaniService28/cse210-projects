// using System;

// class Program
// {
//     static void Main(string[] args)
//     {
//         List<int> numbers = new List<int>();
//         Console.WriteLine("Enter a list of numbers, type 0 when finished.");

//         int userNumber = -1;
//         while (userNumber != 0)
//         {
//             Console.Write("Enter number: ");
//             string userInput = Console.ReadLine();
//             userNumber = int.Parse(userInput);

//             if (userNumber != 0)
//             {
//                 numbers.Add(userNumber);
//             }
//         }

//         // Part 1
//         int sum = 0;
//         foreach (int number in numbers)
//         {
//             sum += number;
//         }

//         Console.WriteLine($"The sum is: {sum}");

//         // Part 2
//         float average = ((float)sum) / numbers.Count;
//         Console.WriteLine($"The average is: {average}");

//         // Part 3
//         int largestNumber = numbers[0];

//         foreach (int number in numbers)
//         {
//             if (number > largestNumber)
//             {
//                 largestNumber = number;
//             }
//         }

//         Console.WriteLine($"The largest number is: {largestNumber}");
//     }
// }