using System;
using System.Collections.Generic;

namespace MusicStore
{
    public class Piano : Instrument
    {
        public int NumberOfKeys { get; set; }

        public Piano(string name, int year, int numberOfKeys)
            : base(name, year)
        {
            NumberOfKeys = numberOfKeys;
        }

        public override void Play()
        {
            Console.WriteLine($"{InstrumentName} is playing with {NumberOfKeys} keys ");
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Instrument: {InstrumentName}, Year: {YearOfManufacture}, Keys: {NumberOfKeys}");
        }
    }
}
