using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Instrument> instruments = new List<Instrument>()
            {
                new Guitar("Guitar Classic", 2020, "Gảy", 6),
                new Guitar("Guitar Bass", 2019, "Gảy", 5),
                new Piano("Piano Điện", 2021, "Gõ phím", 88),
                new Piano("Piano Cơ", 2018, "Gõ phím", 76),
                new Guitar("Ukulele", 2022, "Gảy", 4)
            };

            
            Console.WriteLine("Danh sách nhạc cụ:");
            foreach (var instrument in instruments)
            {
                instrument.DisplayInfo();
            }

            Console.ReadLine();
        }
    }
}
