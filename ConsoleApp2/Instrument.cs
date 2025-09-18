using System;

namespace ConsoleApp2
{
   
    class Instrument
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public string PlayMethod { get; set; }

        public Instrument(string name, int year, string playMethod)
        {
            Name = name;
            Year = year;
            PlayMethod = playMethod;
        }

        // Hàm in thông tin (ảo để lớp con override)
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Tên: {Name}, Năm SX: {Year}, Cách chơi: {PlayMethod}");
        }
    }
}
