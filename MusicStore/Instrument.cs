using System;

namespace MusicStore
{
    public abstract class Instrument : IPlayable
    {
        public string Name { get; set; }
        public int Year { get; set; }

        public Instrument(string name, int year)
        {
            Name = name;
            Year = year;
        }

        public virtual void Play()
        {
            Console.WriteLine($"{Name} is playing...");
        }

        public abstract void ShowInfo();
    }
}
