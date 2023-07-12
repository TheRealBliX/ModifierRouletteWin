using System;
namespace ModifierRoulette;

public class Modifier
{
    //Info
    public string? _name = null;
    public string? _description = null;
    public bool _isEnable = false;

    //Getting info
    public Modifier(string? name, string? description, bool isEnable = false)
    {
        _name = name;
        _description = description;
        _isEnable = isEnable;
    }

    //Return parts
    public string? GetName()
    {
        return _name;
    }
    public string? GetDescription()
    {
        return _description;
    }
    public bool GetStatus()
    {
        return _isEnable;
    }
}

