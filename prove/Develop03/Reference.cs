using System;
using System.Globalization;

public class Reference
{
    private string _book;
    private int _chapter;
    private string _verses;
    private string _scripture;

    public Reference()
    {
        _book = "John";
        _chapter = 3;
        _verses = "16";
        _scripture = "For God so loved the world that he gave his only begotten Son";
    }

    public string GetScripture()
    {
        return _scripture;
    }

    public string DisplayReference()
    {
        return $"{_book} {_chapter}: {_verses}: ";
    }

    public string DisplayScripture()
    {
        return $"'{_scripture}'";
    }


}
