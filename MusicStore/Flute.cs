using System;
using System.Collections.Generic;
namespace MusicStore
{
    public class Flute : Instrument
    {
        public string Material { get; set; }

        public Flute(string name, int year, string material)
            : base(name, year)
        {
            Material = material;
        }

        public override void Play()
        {
            Console.WriteLine($"{InstrumentName} made of {Material} is playing ");
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Instrument: {InstrumentName}, Year: {YearOfManufacture}, Material: {Material}");
        }
    }
}