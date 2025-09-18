using System;
using System.Collections.Generic;

namespace MusicStore
{
    public abstract class Instrument
    {
        public string InstrumentName { get; set; }
        public int YearOfManufacture { get; set; }

        public Instrument(string name, int year)
        {
            InstrumentName = name;
            YearOfManufacture = year;
        }

        public abstract void Play();
        public abstract void PrintInfo();
    }
}