using System;
using System.Collections.Generic;
using BankAndMusicApp.Accounts;
using BankAndMusicApp.Instruments;

namespace BankAndMusicApp
{
    class Program
    {
        static void Main(string[] args)
        {
         
            Console.Write("Enter amount (USD): ");
            decimal amount = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter exchange rate: ");
            decimal rate = Convert.ToDecimal(Console.ReadLine());

            IAccount normalAcc = new NormalAccount(amount * rate);
            IAccount exchangeAcc = new ExchangeAccount(amount, rate);

            Console.WriteLine("\n--- Normal Account ---");
            normalAcc.ShowBalance();

            Console.Write("Enter amount to transfer from Normal Account: ");
            decimal normalTransfer = Convert.ToDecimal(Console.ReadLine());
            normalAcc.Transfer(normalTransfer);

            Console.WriteLine("\n--- Exchange Account ---");
            exchangeAcc.ShowBalance();

            Console.Write("Enter amount to transfer from Exchange Account: ");
            decimal exchangeTransfer = Convert.ToDecimal(Console.ReadLine());
            exchangeAcc.Transfer(exchangeTransfer);

           
            Console.WriteLine("\n--- Instrument List ---");
            List<Instrument> instruments = new List<Instrument>()
            {
                new Guitar("Yamaha F310", 2022, 6),
                new Guitar("Fender Stratocaster", 2021, 6),
                new Piano("Kawai K300", 2020, 88),
                new Piano("Roland FP-30X", 2023, 88),
                new Guitar("Classical Guitar", 2019, 5)
            };

            foreach (var inst in instruments)
            {
                inst.ShowInfo();
                inst.Play();
                Console.WriteLine();
            }
        }
    }
}
