using System;

namespace ConsoleApp2
{
    class Piano : Instrument
    {
        public int NumberOfKeys { get; set; }

        public Piano(string name, int year, string playMethod, int numberOfKeys)
            : base(name, year, playMethod)
        {
            NumberOfKeys = numberOfKeys;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"[Piano] Tên: {Name}, Năm SX: {Year}, Cách chơi: {PlayMethod}, Số phím: {NumberOfKeys}");
        }
    }
}
