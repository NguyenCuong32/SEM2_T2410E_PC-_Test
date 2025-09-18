using System;

namespace MusicStore
{
    public class Guitar : Instrument
    {
        public int NumberOfStrings { get; set; }

        public Guitar(string name, int year, int strings) : base(name, year)
        {
            NumberOfStrings = strings;
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Instrument: {Name}, Year: {Year}, Strings: {NumberOfStrings}");
        }

        public override void Play()
        {
            Console.WriteLine($"{Name}: Strum strum!");
        }
    }
}
