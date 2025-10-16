using System;
using System.Runtime.InteropServices;

public class Fraction
{
    private int _topNumber;
    private int _bottomNumber;

    public Fraction()
    {
        _topNumber = 1;
        _bottomNumber = 1;
    }

    public Fraction(int userTop)
    {
        _topNumber = userTop;
        _bottomNumber = 1;
    }

    public Fraction(int userTop, int userBottom)
    {
        _topNumber = userTop;
        _bottomNumber = userBottom;
    }


    public string GetFractionString()
    {
        string stringFraction = $"{_topNumber}/{_bottomNumber}";
        return stringFraction;
    }

    public double GetDecimalValue()
    {
        return (double)_topNumber / (double)_bottomNumber; ;
    }
}
