using System;

namespace BankAndMusicApp.Instruments
{
    public abstract class Instrument
    {
        public string Name { get; set; }
        public int Year { get; set; }

        protected Instrument(string name, int year)
        {
            Name = name;
            Year = year;
        }

        public abstract void Play();

        public virtual void ShowInfo()
        {
            Console.WriteLine($"{Name} - {Year}");
        }
    }
}
