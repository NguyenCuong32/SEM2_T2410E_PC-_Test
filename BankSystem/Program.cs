using System;
namespace BankSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is the bank application. Choose account type: 1 = Normal, 2 = Exchange");
            int choice = int.Parse(Console.ReadLine());
            IAccount account;
            if (choice == 1)
            {
                Console.Write("Enter initial balance (VND): ");
                decimal amount = decimal.Parse(Console.ReadLine());
                account = new NormalAccount(amount);
            }
            else
            {
                Console.Write("Enter amount in USD: ");
                decimal usd = decimal.Parse(Console.ReadLine());
                Console.Write("Enter exchange rate (VND per USD): ");
                decimal rate = decimal.Parse(Console.ReadLine());
                account = new ExchangeAccount(usd, rate);
            }
            account.CheckBalance();
            Console.Write("Enter transfer amount (VND): ");
            decimal transferAmount = decimal.Parse(Console.ReadLine());
            account.Transfer(transferAmount);

            Console.ReadLine();
        }
    }
}