using System;
using System.Collections.Generic;
namespace MusicStore
{
    public class Violin : Instrument
    {
        public int NumberOfStrings { get; set; }

        public Violin(string name, int year, int numberOfStrings)
            : base(name, year)
        {
            NumberOfStrings = numberOfStrings;
        }

        public override void Play()
        {
            Console.WriteLine($"{InstrumentName} with {NumberOfStrings} strings is playing ");
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Instrument: {InstrumentName}, Year: {YearOfManufacture}, Strings: {NumberOfStrings}");
        }
    }

}