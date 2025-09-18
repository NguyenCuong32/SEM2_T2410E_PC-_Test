using System;

namespace BankAccountApp
{
    // Interface for account
    public interface IAccount
    {
        void Deposit(decimal amount);
        void Transfer(decimal amount);
        void CheckBalance();
    }

    // Abstract class
    public abstract class Account : IAccount
    {
        protected decimal balance;

        public Account(decimal amount)
        {
            balance = amount;
        }

        public abstract void Deposit(decimal amount);
        public abstract void Transfer(decimal amount);
        public abstract void CheckBalance();
    }

    // Normal Account
    public class NormalAccount : Account
    {
        public NormalAccount(decimal amount) : base(amount) { }

        public override void Deposit(decimal amount)
        {
            balance += amount;
        }

        public override void Transfer(decimal amount)
        {
            if (balance >= amount)
            {
                balance -= amount;
                Console.WriteLine($"Your transferred {amount:n0} đ, Your balancer: {balance:n0} đ");
            }
            else
            {
                Console.WriteLine("Not enough balance!");
            }
        }

        public override void CheckBalance()
        {
            Console.WriteLine($"Your balancer: {balance:n0} đ");
        }
    }

    // Exchange Account
    public class ExchangeAccount : Account
    {
        private decimal exchangeRate;

        public ExchangeAccount(decimal amount, decimal rate) : base(amount)
        {
            exchangeRate = rate;
            balance = amount * exchangeRate;
        }

        public override void Deposit(decimal amount)
        {
            balance += amount * exchangeRate;
        }

        public override void Transfer(decimal amount)
        {
            if (balance >= amount)
            {
                balance -= amount;
                Console.WriteLine($"Your transferred {amount:n0} đ, Your balancer: {balance:n0} đ");
            }
            else
            {
                Console.WriteLine("Not enough balance!");
            }
        }

        public override void CheckBalance()
        {
            Console.WriteLine($"Your balancer: {balance:n0} đ");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose account type: 1. Normal  2. Exchange");
            int choice = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter your amount:");
            decimal amount = decimal.Parse(Console.ReadLine());

            IAccount account;

            if (choice == 1)
            {
                account = new NormalAccount(amount);
            }
            else
            {
                Console.WriteLine("Enter exchange rate:");
                decimal rate = decimal.Parse(Console.ReadLine());
                account = new ExchangeAccount(amount, rate);
            }

            account.CheckBalance();

            Console.WriteLine("Enter transfer amount:");
            decimal transfer = decimal.Parse(Console.ReadLine());
            account.Transfer(transfer);

            account.CheckBalance();
        }
    }
}