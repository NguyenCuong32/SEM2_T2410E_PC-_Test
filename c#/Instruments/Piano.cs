using System;

namespace BankAndMusicApp.Instruments
{
    public class Piano : Instrument
    {
        public int Keys { get; set; }

        public Piano(string name, int year, int keys) : base(name, year)
        {
            Keys = keys;
        }

        public override void Play() => Console.WriteLine($"Playing {Name} with {Keys} keys...");

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Number of keys: {Keys}");
        }
    }
}
