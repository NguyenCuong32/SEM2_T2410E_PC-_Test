using System;
using System.Collections.Generic;

namespace MusicStore
{
    public class Guitar : Instrument
    {
        public int NumberOfStrings { get; set; }

        public Guitar(string name, int year, int numberOfStrings)
            : base(name, year)
        {
            NumberOfStrings = numberOfStrings;
        }

        public override void Play()
        {
            Console.WriteLine($"{InstrumentName} is playing with {NumberOfStrings} strings ");
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Instrument: {InstrumentName}, Year: {YearOfManufacture}, Strings: {NumberOfStrings}");
        }
    }
}