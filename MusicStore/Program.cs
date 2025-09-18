using System;
using System.Collections.Generic;

namespace MusicStore
{
    class Program
    {
        static void Main(string[] args)
        {
            var instruments = new List<Instrument>()
            {
                new Guitar("Acoustic Guitar", 2020, 6),
                new Piano("Grand Piano", 2019, 88),
                new Guitar("Electric Guitar", 2021, 7),
                new Piano("Digital Piano", 2022, 76),
                new Guitar("Bass Guitar", 2018, 5)
            };

            Console.WriteLine("Music Store Inventory");
            foreach (var inst in instruments)
            {
                inst.ShowInfo();
                inst.Play();
                Console.WriteLine();
            }
        }
    }
}
