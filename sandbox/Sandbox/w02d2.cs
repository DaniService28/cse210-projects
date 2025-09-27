// using System;
// using System.Globalization;

// class Program
// {
//     static void Main(string[] args)
//     {
//         int x = 10;
//         int y = 20;
//         int result = Adder(x, y);
//         Console.WriteLine(result);

//         GreetUser("John");
//         changeValue(x);
//         Console.WriteLine(x); // x is still 10

//         int[] myArray = new int[] { 1, 2, 3, 4, 5 };
//         Console.Write("Before: ");
//         foreach (int number in myArray)
//         {
//             Console.WriteLine(number);
//         }

//         changeRefValue(myArray);
//         Console.Write("After: ");
//         foreach (int number in myArray)
//         {
//             Console.WriteLine(number);
//         }
//     }

//     // Working with functions
//     static int Adder(int a, int b)
//     {
//         return a + b;
//     }

//     static void GreetUser(string firstName)
//     {
//         Console.WriteLine($"Hello {firstName}");
//     }

//     static void changeValue(int x)
//     {
//         x = 100;
//     }

//     static void changeRefValue(int[] data)
//     {
//         data[2] = 100;
//     }
// }