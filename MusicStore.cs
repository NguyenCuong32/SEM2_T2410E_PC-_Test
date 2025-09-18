using System;
using System.Collections.Generic;

abstract class Instrument
{
    public string Name { get; set; }
    public int Year { get; set; }
    public Instrument(string name, int year)
    {
        Name = name; Year = year;
    }
    public abstract void Play();
    public override string ToString()
    {
        return $"{Name}, Year: {Year}";
    }
}

class Guitar : Instrument
{
    public int NumberOfStrings { get; set; }
    public Guitar(string name, int year, int strings) : base(name, year)
    {
        NumberOfStrings = strings;
    }
    public override void Play()
    {
        Console.WriteLine($"{Name} is playing with {NumberOfStrings} strings");
    }
    public override string ToString()
    {
        return base.ToString() + $", Strings: {NumberOfStrings}";
    }
}

class Piano : Instrument
{
    public int Keys { get; set; }
    public Piano(string name, int year, int keys) : base(name, year)
    {
        Keys = keys;
    }
    public override void Play()
    {
        Console.WriteLine($"{Name} is playing with {Keys} keys");
    }
    public override string ToString()
    {
        return base.ToString() + $", Keys: {Keys}";
    }
}
