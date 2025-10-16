using System;
using System.Runtime.ExceptionServices;

class Program
{
    static void Main(string[] args)
    {
        Fraction newF1 = new Fraction();
        Console.WriteLine(newF1.GetDecimalValue());
        Console.WriteLine(newF1.GetFractionString());

        Fraction newF2 = new Fraction(5);
        Console.WriteLine(newF2.GetDecimalValue());
        Console.WriteLine(newF2.GetFractionString());

        Fraction newF3 = new Fraction(3, 4);
        Console.WriteLine(newF3.GetDecimalValue());
        Console.WriteLine(newF3.GetFractionString());

        Fraction newF4 = new Fraction(1, 3);
        Console.WriteLine(newF4.GetDecimalValue());
        Console.WriteLine(newF4.GetFractionString());

    }
}