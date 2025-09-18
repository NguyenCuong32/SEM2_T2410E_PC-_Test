using System;

using System.Collections.Generic;

namespace MusicStoreApp
{
    // Base abstract class
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

    // Guitar
    public class Guitar : Instrument
    {
        public int Strings { get; set; }

        public Guitar(string name, int year, int strings) : base(name, year)
        {
            Strings = strings;
        }

        public override void Play()
        {
            Console.WriteLine($"{Name} is playing with {Strings} strings.");
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Guitar - Name: {Name}, Year: {Year}, Strings: {Strings}");
        }
    }

    // Piano
    public class Piano : Instrument
    {
        public int Keys { get; set; }

        public Piano(string name, int year, int keys) : base(name, year)
        {
            Keys = keys;
        }

        public override void Play()
        {
            Console.WriteLine($"{Name} is playing with {Keys} keys.");
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Piano - Name: {Name}, Year: {Year}, Keys: {Keys}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Instrument> instruments = new List<Instrument>
            {
                new Guitar("Yamaha F310", 2020, 6),
                new Guitar("Fender Stratocaster", 2018, 6),
                new Guitar("Ibanez GRG170DX", 2019, 7),
                new Piano("Yamaha U1", 2017, 88),
                new Piano("Kawai K300", 2021, 76)
            };

            foreach (var instrument in instruments)
            {
                instrument.ShowInfo();
                instrument.Play();
            }
        }
    }
}