using System;
using System.Collections.Generic;

namespace MusicStoreApp
{
    public interface IPlayable
    {
        void Play();
    }

    public abstract class Instrument : IPlayable
    {
        public string Name { get; set; }
        public int Year { get; set; }

        protected Instrument(string name, int year)
        {
            Name = name; Year = year;
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
            Console.WriteLine($"{Name} is playing with {Strings} strings...");
        }
        public override void ShowInfo()
        {
            Console.WriteLine($"Guitar: {Name}, Year: {Year}, Strings: {Strings}");
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
            Console.WriteLine($"{Name} is playing with {Keys} keys...");
        }
        public override void ShowInfo()
        {
            Console.WriteLine($"Piano: {Name}, Year: {Year}, Keys: {Keys}");
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== BÀI 2: MUSIC STORE (Instrument/Guitar/Piano) ===");

            // Tạo danh sách 5 nhạc cụ (đáp ứng: “Create a list object with 5 … and print all info”)
            var instruments = new List<Instrument>
            {
                new Guitar("Yamaha F310", 2020, 6),
                new Guitar("Fender Stratocaster", 2018, 6),
                new Piano("Yamaha U1", 2019, 88),
                new Piano("Casio PX-160", 2021, 76),
                new Guitar("Taylor GS Mini", 2022, 5)
            };

            Console.WriteLine(">> Danh sách 5 nhạc cụ:");
            foreach (var inst in instruments)
            {
                inst.ShowInfo();
                inst.Play();
            }
        }
    }
}
