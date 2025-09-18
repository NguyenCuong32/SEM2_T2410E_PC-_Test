using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("=== MENU ===");
            Console.WriteLine("1. Bài 1: Banking");
            Console.WriteLine("2. Bài 2: Music Store");
            Console.WriteLine("0. Thoát");
            Console.Write("Chọn: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": RunBanking(); break;
                case "2": RunMusicStore(); break;
                case "0": return;
                default:  Console.WriteLine("Sai lựa chọn"); break;
            }
            Console.WriteLine("\n-----------------\n");
        }
    }

    static void RunBanking()
    {
        Console.Write("Enter amount: ");
        decimal amount = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine("Choose account type: 1-Normal, 2-Exchange");
        int choice = int.Parse(Console.ReadLine());

        IAccount account;
        if (choice == 1)
            account = new NormalAccount(amount);
        else
        {
            Console.Write("Enter exchange rate: ");
            decimal rate = Convert.ToDecimal(Console.ReadLine());
            account = new ExchangeAccount(amount, rate);
        }

        account.CheckBalance();

        Console.Write("Enter transfer amount: ");
        decimal transferAmount = Convert.ToDecimal(Console.ReadLine());
        account.Transfer(transferAmount);
    }

    static void RunMusicStore()
    {
        List<Instrument> instruments = new List<Instrument>()
        {
            new Guitar("Guitar A", 2020, 6),
            new Piano("Piano B", 2019, 88),
            new Guitar("Guitar C", 2021, 12),
            new Piano("Piano D", 2018, 76),
            new Guitar("Guitar E", 2022, 7)
        };

        foreach (var ins in instruments)
        {
            Console.WriteLine(ins);
            ins.Play();
        }
    }
}
