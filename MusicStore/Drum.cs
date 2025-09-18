using System;
using System.Collections.Generic;

namespace MusicStore
{
    public class Drum : Instrument
    {
        public string Type { get; set; }

        public Drum(string name, int year, string type)
            : base(name, year)
        {
            Type = type;
        }

        public override void Play()
        {
            Console.WriteLine($"{InstrumentName} ({Type}) is playing ");
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Instrument: {InstrumentName}, Year: {YearOfManufacture}, Type: {Type}");
        }
    }
}