using System;

public class Word
{
    private string _text;
    private bool _isHidden;

    // Ya que voy a crear una lista en Scripture que pasa valores de esta clase con
    // text = El que se asigne y _isHidden = Empty-- Lo mejor sería crear un constructor
    // para que cada nueva palabra ya tenga un bool por defecto.
    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide() => _isHidden = true;

    public bool IsHidden() => _isHidden;
    
    public string GetDisplayText() => _isHidden ? "_" : _text;
 
}