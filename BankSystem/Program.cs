using System;

namespace BankSystem
{
    public interface IAccount
    {
        decimal GetBalance();
        void Transfer(decimal amount);
    }

    public abstract class Account : IAccount
    {
        protected decimal balance;

        public Account(decimal initialBalance)
        {
            balance = initialBalance;
        }

        public virtual decimal GetBalance()
        {
            return balance;
        }

        public virtual void Transfer(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Invalid transfer amount!");
                return;
            }
            if (amount > balance)
            {
                Console.WriteLine("Not enough balance!");
                return;
            }
            balance -= amount;
            Console.WriteLine($"You transferred {amount:N0} đ, Your balance: {balance:N0} đ");
        }
    }

    public class NormalAccount : Account
    {
        public NormalAccount(decimal initialBalance) : base(initialBalance) { }

        public override decimal GetBalance()
        {
            Console.WriteLine($"Your balance: {balance:N0} đ");
            return balance;
        }
    }

    public class ExchangeAccount : Account
    {
        private decimal exchangeRate;
        private decimal amount;

        public ExchangeAccount(decimal exchangeRate, decimal amount) : base(0)
        {
            this.exchangeRate = exchangeRate;
            this.amount = amount;
            this.balance = exchangeRate * amount;
        }

        public override decimal GetBalance()
        {
            Console.WriteLine($"Your balance: {balance:N0} đ");
            return balance;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Bank Account System ===");

            Console.Write("Enter initial balance for Normal Account (VND): ");
            decimal normalBalance = decimal.Parse(Console.ReadLine());
            IAccount normalAcc = new NormalAccount(normalBalance);
            normalAcc.GetBalance();
            normalAcc.Transfer(1_000_000);
            normalAcc.GetBalance();

            Console.WriteLine();

            Console.Write("Enter exchange rate (e.g., 25000): ");
            decimal rate = decimal.Parse(Console.ReadLine());
            Console.Write("Enter amount in foreign currency: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            IAccount exchangeAcc = new ExchangeAccount(rate, amount);
            exchangeAcc.GetBalance();
            exchangeAcc.Transfer(2_000_000);
            exchangeAcc.GetBalance();
        }
    }
}
