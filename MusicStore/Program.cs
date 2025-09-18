using System;
using System.Collections.Generic;

namespace MusicStoreApp
{
    public abstract class Instrument
    {
        public string Name { get; set; }
        public int Year { get; set; }

        public Instrument(string name, int year)
        {
            Name = name;
            Year = year;
        }

        public abstract void Play();
        public abstract void ShowInfo();
    }

    public class Guitar : Instrument
    {
        public int NumberOfStrings { get; set; }

        public Guitar(string name, int year, int strings) : base(name, year)
        {
            NumberOfStrings = strings;
        }

        public override void Play()
        {
            Console.WriteLine($"{Name} is playing with {NumberOfStrings} strings.");
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Instrument: {Name}, Year: {Year}, Strings: {NumberOfStrings}");
        }
    }

    public class Piano : Instrument
    {
        public int NumberOfKeys { get; set; }

        public Piano(string name, int year, int keys) : base(name, year)
        {
            NumberOfKeys = keys;
        }

        public override void Play()
        {
            Console.WriteLine($"{Name} is playing with {NumberOfKeys} keys.");
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Instrument: {Name}, Year: {Year}, Keys: {NumberOfKeys}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Music Store Instruments ===");

            List<Instrument> instruments = new List<Instrument>()
            {
                new Guitar("Classic Guitar", 2020, 6),
                new Guitar("Bass Guitar", 2021, 4),
                new Piano("Yamaha Piano", 2019, 88),
                new Piano("Casio Piano", 2022, 76),
                new Guitar("Electric Guitar", 2023, 7)
            };

            foreach (var ins in instruments)
            {
                ins.ShowInfo();
                ins.Play();
                Console.WriteLine();
            }
        }
    }
}
