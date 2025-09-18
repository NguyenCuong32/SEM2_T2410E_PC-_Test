using System;

namespace BankAndMusicApp.Instruments
{
    public class Guitar : Instrument
    {
        public int Strings { get; set; }

        public Guitar(string name, int year, int strings) : base(name, year)
        {
            Strings = strings;
        }

        public override void Play() => Console.WriteLine($"Playing {Name} with {Strings} strings...");

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Number of strings: {Strings}");
        }
    }
}
