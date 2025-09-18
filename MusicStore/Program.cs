using System;
using System.Collections.Generic;

namespace MusicStore
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

        public virtual void ShowInfo()
        {
            Console.WriteLine($"Instrument: {Name}, Year: {Year}");
        }
    }
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
            base.ShowInfo();
            Console.WriteLine($"Strings: {Strings}");
        }
    }
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
            base.ShowInfo();
            Console.WriteLine($"Keys: {Keys}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Instrument> instruments = new List<Instrument>
            {
                new Guitar("Yamaha Guitar", 2020, 6),
                new Piano("Steinway Piano", 2018, 88),
                new Guitar("Fender Guitar", 2022, 7),
                new Piano("Casio Piano", 2021, 76),
                new Guitar("Gibson Guitar", 2019, 12)
            };

            foreach (var instrument in instruments)
            {
                instrument.ShowInfo();
                instrument.Play();
                Console.WriteLine("--------------------");
            }

            Console.ReadLine();
        }
    }
}
