using System;

namespace ConsoleApp2
{
    class Guitar : Instrument
    {
        public int NumberOfStrings { get; set; }

        public Guitar(string name, int year, string playMethod, int numberOfStrings)
            : base(name, year, playMethod)
        {
            NumberOfStrings = numberOfStrings;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"[Guitar] Tên: {Name}, Năm SX: {Year}, Cách chơi: {PlayMethod}, Số dây: {NumberOfStrings}");
        }
    }
}
