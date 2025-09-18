using System;
using System.Collections.Generic;
using System.Globalization;

namespace AssignmentSet01
{
    public static class Money
    {
        private static readonly CultureInfo vi = new CultureInfo("vi-VN");
        public static string Vnd(decimal amount) => string.Format(vi, "{0:c0}", amount);
    }


    public interface IAccount
    {
        decimal Balance { get; }
        string CheckBalance();
        string Transfer(decimal amount);
    }

    public abstract class Account : IAccount
    {
        protected decimal _balance;
        protected Account(decimal initial) => _balance = initial;

        public decimal Balance => _balance;

        public virtual string CheckBalance() => $"Your balancer: {Money.Vnd(_balance)}";

        public virtual string Transfer(decimal amount)
        {
            if (amount <= 0) return "Transfer amount must be > 0.";
            if (amount > _balance) return "Insufficient funds.";
            _balance -= amount;
            return $"Your transferred {Money.Vnd(amount)}, Your balancer : {Money.Vnd(_balance)}";
        }
    }

    public class NormalAccount : Account
    {
        public NormalAccount(decimal initial) : base(initial) { }
    }

    
    public interface IExchangeRateService
    {
        decimal GetRate(string fromCurrency, string toCurrency);
    }

    
    public class FixedExchangeRateService : IExchangeRateService
    {
        private readonly Dictionary<(string from, string to), decimal> _rates
            = new Dictionary<(string from, string to), decimal>(StringTupleComparer.OrdinalIgnoreCase)
            {
                { ("USD","VND"), 25000m }
            };

        public decimal GetRate(string fromCurrency, string toCurrency)
        {
            if (_rates.TryGetValue((fromCurrency, toCurrency), out var r)) return r;
            throw new InvalidOperationException($"No rate {fromCurrency}->{toCurrency} configured.");
        }

        
        private class StringTupleComparer : IEqualityComparer<(string, string)>
        {
            public static readonly StringTupleComparer OrdinalIgnoreCase = new StringTupleComparer();
            public bool Equals((string, string) x, (string, string) y) =>
                string.Equals(x.Item1, y.Item1, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(x.Item2, y.Item2, StringComparison.OrdinalIgnoreCase);
            public int GetHashCode((string, string) obj) =>
                StringComparer.OrdinalIgnoreCase.GetHashCode(obj.Item1) * 397 ^
                StringComparer.OrdinalIgnoreCase.GetHashCode(obj.Item2);
        }
    }

    public class ExchangeAccount : Account
    {
        private readonly string _from;
        private readonly string _to;
        private readonly IExchangeRateService _rates;

        public ExchangeAccount(decimal initial, string fromCurrency, string toCurrency, IExchangeRateService rates)
            : base(initial)
        {
            _from = fromCurrency;
            _to = toCurrency;
            _rates = rates;
        }

        
        public string ConvertAmount(decimal amount)
        {
            var rate = _rates.GetRate(_from, _to);
            var converted = rate * amount;
            return $"Exchange rate today {_from} to {_to} is {rate:n0}. Your amount is {amount:n0} {_from}. " +
                   $"Balancer = {rate:n0} × {amount:n0} = {Money.Vnd(converted)}";
        }
    }

    
    public interface IPlayable { string Play(); }

    public abstract class Instrument : IPlayable
    {
        public string Name { get; }
        public int Year { get; }

        protected Instrument(string name, int year)
        {
            Name = name;
            Year = year;
        }

        public abstract string Play();

        public override string ToString() => $"{Name} (manufactured {Year})";
    }

    public class Guitar : Instrument
    {
        public int NumberOfStrings { get; }

        public Guitar(string name, int year, int strings) : base(name, year)
        {
            NumberOfStrings = strings;
        }

        public override string Play() => $"🎸 {Name} strums with {NumberOfStrings} strings!";
        public override string ToString() => base.ToString() + $", strings: {NumberOfStrings}";
    }

    public class Piano : Instrument
    {
        public int Keys { get; }

        public Piano(string name, int year, int keys) : base(name, year)
        {
            Keys = keys;
        }

        public override string Play() => $"🎹 {Name} plays across {Keys} keys!";
        public override string ToString() => base.ToString() + $", keys: {Keys}";
    }

    
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            
            Console.WriteLine("=== Account system ===");
            Console.Write("Enter initial amount (e.g., 25000000 for 25M VND): ");
            decimal initial = ReadDecimal();

            Console.Write("Choose account type [1] Normal  [2] Exchange(USD→VND): ");
            var choice = Console.ReadLine();

            IAccount account;
            if (choice == "2")
            {
                var rateSvc = new FixedExchangeRateService();
                var exAcc = new ExchangeAccount(initial, "USD", "VND", rateSvc);
                account = exAcc;

                Console.Write("Enter an amount in USD to convert (e.g., 1000): ");
                var usd = ReadDecimal();
                Console.WriteLine(exAcc.ConvertAmount(usd));
            }
            else
            {
                account = new NormalAccount(initial);
            }

            Console.WriteLine(account.CheckBalance());

            Console.Write("Enter transfer amount (e.g., 1000000 for 1M VND): ");
            var transfer = ReadDecimal();
            Console.WriteLine(account.Transfer(transfer));

            
            Console.WriteLine("\n=== Music Store inventory ===");
            var instruments = new List<Instrument>
            {
                new Guitar("Fender Stratocaster", 2019, 6),
                new Piano("Yamaha U1", 2010, 88),
                new Guitar("Cordoba C5", 2022, 6),
                new Piano("Kawai K300", 2018, 88),
                new Guitar("Ibanez RG7421", 2021, 7)
            };

            Console.WriteLine("All instrument information:");
            foreach (var i in instruments)
            {
                Console.WriteLine("- " + i.ToString());
                Console.WriteLine("  " + i.Play());
            }

            Console.WriteLine("\nDone. Press any key to exit...");
            Console.ReadKey();
        }

        private static decimal ReadDecimal()
        {
            while (true)
            {
                if (decimal.TryParse(Console.ReadLine(), out var d) && d >= 0) return d;
                Console.Write("Please enter a valid non-negative number: ");
            }
        }
    }
}
