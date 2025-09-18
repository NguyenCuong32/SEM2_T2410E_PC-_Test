using System;
namespace MusicStore;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        List<Instrument> instruments = new List<Instrument>()
            {
                new Guitar("Yamaha Guitar", 2020, 6),
                new Piano("Steinway Piano", 2018, 88),
                new Drum("Pearl Drum", 2019, "Acoustic"),
                new Violin("Stradivarius Violin", 2015, 4),
                new Flute("Silver Flute", 2021, "Silver")
            };
        foreach (var instrument in instruments)
        {
            instrument.PrintInfo();
            instrument.Play();
            Console.WriteLine("----------------------");
        }

        Console.ReadLine();
    }
}