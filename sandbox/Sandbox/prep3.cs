// using System;

// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             Random randomGenerator = new Random();
//             int randomNumber = randomGenerator.Next(1, 101);

//             int userGuess = 0;

//             while (userGuess != randomNumber)
//             {
//                 Console.Write("What is your guess? ");
//                 userGuess = int.Parse(Console.ReadLine());

//                 if (randomNumber > userGuess)
//                 {
//                     Console.WriteLine("Higher");
//                 }
//                 else if (randomNumber < userGuess)
//                 {
//                     Console.WriteLine("Lower");
//                 }
//                 else
//                 {
//                     Console.WriteLine("You guessed it!");
//                 }

//             }
//         }
//     }
// }