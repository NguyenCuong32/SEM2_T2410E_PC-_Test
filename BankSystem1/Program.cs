using System;
using System.Globalization;

namespace BankSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bank System");
            Console.WriteLine("Choose account type: 1. Normal  2. Exchange (USD to VND)");
            Console.Write("Choice (1 or 2): ");
            string choice = Console.ReadLine();

            Account account;
            if (choice == "1")
            {
                Console.Write("Enter initial balance in VND (25000000): ");
                decimal initial = ReadDecimalFromConsole();
                account = new NormalAccount(initial);
            }
            else
            {
                Console.Write("Enter amount in foreign currency (USD): ");
                decimal foreign = ReadDecimalFromConsole();
                Console.Write("Enter exchange rate VND per 1 unit (default 25000): ");
                string rateStr = Console.ReadLine();
                decimal rate = string.IsNullOrWhiteSpace(rateStr) ? 25000m : decimal.Parse(rateStr, CultureInfo.InvariantCulture);
                account = new ExchangeAccount(foreign, rate);
            }

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine();
                Console.WriteLine("Choose operation: 1.Check balancer  2.Transfer  3.Exit");
                Console.Write("Option: ");
                string op = Console.ReadLine();
                switch (op)
                {
                    case "1":
                        account.CheckBalance();
                        break;
                    case "2":
                        Console.Write("Enter transfer amount in VND: ");
                        decimal amt = ReadDecimalFromConsole();
                        account.Transfer(amt);
                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }

            Console.WriteLine("Bye!");
        }

        static decimal ReadDecimalFromConsole()
        {
            while (true)
            {
                string s = Console.ReadLine();
                if (decimal.TryParse(s, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal result))
                    return result;
                Console.Write("Invalid number. Please re-enter: ");
            }
        }
    }
}
