using System;

namespace MusicStore
{
    public class Piano : Instrument
    {
        public int Keys { get; set; }

        public Piano(string name, int year, int keys) : base(name, year)
        {
            Keys = keys;
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Instrument: {Name}, Year: {Year}, Keys: {Keys}");
        }

        public override void Play()
        {
            Console.WriteLine($"{Name}: Plink plonk!");
        }
    }
}
