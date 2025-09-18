
using System;
using System.Collections.Generic;


public interface IPlayable
{
    void Play();
}



public abstract class Instrument : IPlayable
{
    public string Name { get; }
    public int YearOfManufacture { get; }

    protected Instrument(string name, int year)
    {
        Name = name;
        YearOfManufacture = year;
    }

    public abstract void Play();
    public abstract string Info();
}

public sealed class Guitar : Instrument
{
    public int NumberOfStrings { get; }

    public Guitar(string name, int year, int strings) : base(name, year)
    {
        NumberOfStrings = strings;
    }

    public override void Play()
    {
        Console.WriteLine($"{Name}: strumming {NumberOfStrings}-string guitar ");
    }

    public override string Info()
    {
        return $"Guitar | Name: {Name}, Year: {YearOfManufacture}, Strings: {NumberOfStrings}";
    }
}

public sealed class Piano : Instrument
{
    public int Keys { get; }

    public Piano(string name, int year, int keys) : base(name, year)
    {
        Keys = keys;
    }

    public override void Play()
    {
        Console.WriteLine($"{Name}: playing a {Keys}-key piano ");
    }

    public override string Info()
    {
        return $"Piano  | Name: {Name}, Year: {YearOfManufacture}, Keys: {Keys}";
    }
}



public static class Program
{
    public static void Main()
    {
        
        var instruments = new List<Instrument>
        {
            new Guitar("Yamaha F310", 2020, 6),
            new Guitar("Fender Stratocaster", 2019, 6),
            new Piano("Yamaha U3", 2018, 88),
            new Piano("Casio PX-870", 2021, 88),
            new Guitar("Taylor GS Mini", 2022, 6)
        };

        Console.WriteLine("=== MUSIC STORE INVENTORY ===\n");

        
        foreach (var ins in instruments)
        {
            Console.WriteLine(ins.Info());
            ins.Play();
            Console.WriteLine(new string('-', 50));
        }

        Console.WriteLine("Done. Press any key to exit...");
        Console.ReadKey();
    }
}

